#include <OpenHome/Net/Private/CpiDeviceDv.h>
#include <OpenHome/Net/Private/DviDevice.h>
#include <OpenHome/Net/Private/DviService.h>
#include <OpenHome/OhNetTypes.h>
#include <OpenHome/Buffer.h>
#include <OpenHome/Net/Private/CpiService.h>
#include <OpenHome/Net/Private/CpiSubscription.h>
#include <OpenHome/Private/Stream.h>
#include <OpenHome/Net/Core/CpProxy.h>
#include <OpenHome/Private/Printer.h>
#include <OpenHome/Net/Private/Stack.h>

using namespace OpenHome;
using namespace OpenHome::Net;

// CpiDeviceDv

CpiDeviceDv::CpiDeviceDv(DviDevice& aDevice)
    : iDeviceDv(aDevice)
    , iSubscriptionDv(NULL)
    , iSubscriptionCp(NULL)
{
    iDeviceDv.AddWeakRef();
    iDeviceCp = new CpiDevice(iDeviceDv.Udn(), *this, *this, NULL);
    iDeviceCp->SetReady();
}

CpiDevice& CpiDeviceDv::Device()
{
    return *iDeviceCp;
}

void CpiDeviceDv::InvokeAction(Invocation& aInvocation)
{
    const OpenHome::Net::ServiceType& serviceType = aInvocation.ServiceType();
    DviService* service = iDeviceDv.ServiceReference(serviceType);
    if (service == NULL) {
        const HttpStatus& err = HttpStatus::kNotFound;
        aInvocation.SetError(Error::eUpnp, err.Code(), err.Reason());
    }
    else {
        InvocationDv stream(aInvocation, *service);
        stream.Start();
        service->RemoveRef();
    }
    aInvocation.SignalCompleted();
}

TBool CpiDeviceDv::GetAttribute(const char* aKey, Brh& aValue) const
{
    const TChar* value = NULL;
    iDeviceDv.GetAttribute(aKey, &value);
    if (value != NULL) {
        aValue.Set(value);
    }
    return false;
}

TUint CpiDeviceDv::Subscribe(CpiSubscription& aSubscription, const OpenHome::Uri& /*aSubscriber*/)
{
    iSubscriptionCp = &aSubscription;
    Brh sid;
    iDeviceDv.CreateSid(sid);
    Brn tmp(sid);
    Brh transfer(tmp);
    aSubscription.SetSid(transfer);
    TUint durationSecs = Stack::InitParams().SubscriptionDurationSecs();
    iSubscriptionDv = new DviSubscription(iDeviceDv, *this, NULL, sid, durationSecs);
    iSubscriptionDv->AddRef(); // guard against subscription expiring before client tries to renew or unsubscribe
    DviSubscriptionManager::AddSubscription(*iSubscriptionDv);
    DviService* service = iDeviceDv.ServiceReference(aSubscription.ServiceType());
    ASSERT(service != NULL);
    service->AddSubscription(iSubscriptionDv);
    service->RemoveRef();
    return durationSecs;
}

TUint CpiDeviceDv::Renew(CpiSubscription& /*aSubscription*/)
{
    TUint durationSecs = Stack::InitParams().SubscriptionDurationSecs();
    iSubscriptionDv->Renew(durationSecs);
    return durationSecs;
}

void CpiDeviceDv::Unsubscribe(CpiSubscription& aSubscription, const Brx& aSid)
{
    if (NULL == iSubscriptionDv)
    {
        return;
    }
    DviService* service = iDeviceDv.ServiceReference(aSubscription.ServiceType());
    if (service != NULL) {
        service->RemoveSubscription(aSid);
        service->RemoveRef();
    }
    iSubscriptionDv->RemoveRef();
    iSubscriptionDv = NULL;
    iSubscriptionCp = NULL;
}

void CpiDeviceDv::NotifyRemovedBeforeReady()
{
}

void CpiDeviceDv::Release()
{
    iDeviceDv.RemoveWeakRef();
    iDeviceCp = NULL; // device will delete itself when this returns;
    delete this;
}

IPropertyWriter* CpiDeviceDv::CreateWriter(const IDviSubscriptionUserData* /*aUserData*/,
                                           const Brx& /*aSid*/, TUint aSequenceNumber)
{
    if (!iSubscriptionCp->UpdateSequenceNumber(aSequenceNumber)) {
        iSubscriptionCp->SetNotificationError();
        return NULL;
    }
    ASSERT(iSubscriptionCp != NULL);
    return new PropertyWriterDv(*iSubscriptionCp);
}

void CpiDeviceDv::NotifySubscriptionDeleted(const Brx& /*aSid*/)
{
}

void CpiDeviceDv::NotifySubscriptionExpired(const Brx& /*aSid*/)
{
}


// InvocationDv

InvocationDv::InvocationDv(Invocation& aInvocation, DviService& aService)
    : iInvocation(aInvocation)
    , iService(aService)
    , iWriteArg(NULL)
{
}

void InvocationDv::Start()
{
    Invoke();
}

void InvocationDv::Invoke()
{
    const Brx& actionName = iInvocation.Action().Name();
    try {
        iService.Invoke(*this, actionName);
    }
    catch (InvocationError&) {}
    catch (ParameterValidationError&) {
        InvocationReportError(Error::eCodeParameterInvalid, Error::kDescriptionParameterInvalid);
    }
}

TUint InvocationDv::Version() const
{
    return iInvocation.ServiceType().Version();
}

TIpAddress InvocationDv::Adapter() const
{
    return 0;
}

const char* InvocationDv::ResourceUriPrefix() const
{
    return NULL;
}

void InvocationDv::InvocationReadStart()
{
    iReadIndex = 0;
}

TBool InvocationDv::InvocationReadBool(const TChar* aName)
{
    ArgumentBool* arg = static_cast<ArgumentBool*>(InputArgument(aName));
    return arg->Value();
}

void InvocationDv::InvocationReadString(const TChar* aName, Brhz& aString)
{
    ArgumentString* arg = static_cast<ArgumentString*>(InputArgument(aName));
    aString.Set(arg->Value());
}

TInt InvocationDv::InvocationReadInt(const TChar* aName)
{
    ArgumentInt* arg = static_cast<ArgumentInt*>(InputArgument(aName));
    return arg->Value();
}

TUint InvocationDv::InvocationReadUint(const TChar* aName)
{
    ArgumentUint* arg = static_cast<ArgumentUint*>(InputArgument(aName));
    return arg->Value();
}

void InvocationDv::InvocationReadBinary(const TChar* aName, Brh& aData)
{
    ArgumentBinary* arg = static_cast<ArgumentBinary*>(InputArgument(aName));
    aData.Set(arg->Value());
}

void InvocationDv::InvocationReadEnd()
{
}

void InvocationDv::InvocationReportError(TUint aCode, const Brx& aDescription)
{
    iInvocation.SetError(Error::eUpnp, aCode, aDescription);
}

void InvocationDv::InvocationWriteStart()
{
    iWriteIndex = 0;
}

void InvocationDv::InvocationWriteBool(const TChar* aName, TBool aValue)
{
    Bws<1> buf;
    buf.SetBytes(1);
    buf[0] = (aValue? 1 : 0);
    OutputProcessorDv procDv;
    OutputArgument(aName)->ProcessOutput(procDv, buf);
}

void InvocationDv::InvocationWriteInt(const TChar* aName, TInt aValue)
{
    Bws<4> buf((const TByte*)&aValue, 4);
    OutputProcessorDv procDv;
    OutputArgument(aName)->ProcessOutput(procDv, buf);
}

void InvocationDv::InvocationWriteUint(const TChar* aName, TUint aValue)
{
    Bws<4> buf((const TByte*)&aValue, 4);
    OutputProcessorDv procDv;
    OutputArgument(aName)->ProcessOutput(procDv, buf);
}

void InvocationDv::InvocationWriteBinaryStart(const TChar* aName)
{
    ASSERT(iWriteArg == NULL);
    iWriteArg = OutputArgument(aName);
    ASSERT(static_cast<ArgumentBinary*>(iWriteArg)->Value().Bytes() == 0);
}

void InvocationDv::InvocationWriteBinary(TByte aValue)
{
    // binary and string writing are the same here since we're not base64 encoding or xml escaping the data
    InvocationWriteString(aValue);
}

void InvocationDv::InvocationWriteBinary(const Brx& aValue)
{
    InvocationWriteString(aValue);
}

void InvocationDv::InvocationWriteBinaryEnd(const TChar* aName)
{
    InvocationWriteStringEnd(aName);
}

void InvocationDv::InvocationWriteStringStart(const TChar* aName)
{
    ASSERT(iWriteArg == NULL);
    iWriteArg = OutputArgument(aName);
    ASSERT(static_cast<ArgumentString*>(iWriteArg)->Value().Bytes() == 0);
}

void InvocationDv::InvocationWriteString(TByte aValue)
{
    Brn buf(&aValue, 1);
    InvocationWriteString(buf);
}

void InvocationDv::InvocationWriteString(const Brx& aValue)
{
    ASSERT(iWriteArg != NULL);
    OutputProcessorDv procDv;
    iWriteArg->ProcessOutput(procDv, aValue);
}

void InvocationDv::InvocationWriteStringEnd(const TChar* /*aName*/)
{
    iWriteArg = NULL;
}

void InvocationDv::InvocationWriteEnd()
{
}

OpenHome::Net::Argument* InvocationDv::InputArgument(const TChar* aName)
{
    return Argument(aName, iInvocation.InputArguments(), iReadIndex);
}

OpenHome::Net::Argument* InvocationDv::OutputArgument(const TChar* aName)
{
    return Argument(aName, iInvocation.OutputArguments(), iWriteIndex);
}

OpenHome::Net::Argument* InvocationDv::Argument(const TChar* aName, const Invocation::VectorArguments& aVector, TUint& aIndex)
{
    OpenHome::Net::Argument* ret = NULL;
    Brn name(aName);
    TUint index = aIndex;
    do {
        OpenHome::Net::Argument* arg = aVector[index];
        if (arg->Parameter().Name() == name) {
            ret = arg;
            break;
        }
        GetNextIndex(index, aVector);
    } while (index != aIndex);
    ASSERT(ret != NULL);
    GetNextIndex(aIndex, aVector);
    return ret;
}

void InvocationDv::GetNextIndex(TUint& aIndex, const Invocation::VectorArguments& aVector)
{
    aIndex++;
    if (aIndex == aVector.size()) {
        aIndex = 0;
    }
}


// PropertyWriterDv

PropertyWriterDv::PropertyWriterDv(IEventProcessor& aEventProcessor)
    : iEventProcessor(aEventProcessor)
{
    iEventProcessor.EventUpdateStart();
}

void PropertyWriterDv::PropertyWriteString(const Brx& aName, const Brx& aValue)
{
    OutputProcessorDv procDv;
    iEventProcessor.EventUpdate(aName, aValue, procDv);
}

void PropertyWriterDv::PropertyWriteInt(const Brx& aName, TInt aValue)
{
    Bws<4> buf((const TByte*)&aValue, 4);
    OutputProcessorDv procDv;
    iEventProcessor.EventUpdate(aName, buf, procDv);
}

void PropertyWriterDv::PropertyWriteUint(const Brx& aName, TUint aValue)
{
    Bws<4> buf((const TByte*)&aValue, 4);
    OutputProcessorDv procDv;
    iEventProcessor.EventUpdate(aName, buf, procDv);
}

void PropertyWriterDv::PropertyWriteBool(const Brx& aName, TBool aValue)
{
    Bws<1> buf;
    buf.SetBytes(1);
    buf[0] = (aValue? 1 : 0);
    OutputProcessorDv procDv;
    iEventProcessor.EventUpdate(aName, buf, procDv);
}

void PropertyWriterDv::PropertyWriteBinary(const Brx& aName, const Brx& aValue)
{
    OutputProcessorDv procDv;
    iEventProcessor.EventUpdate(aName, aValue, procDv);
}

void PropertyWriterDv::PropertyWriteEnd()
{
    iEventProcessor.EventUpdateEnd();
}


// OutputProcessorDv

void OutputProcessorDv::ProcessString(const Brx& aBuffer, Brhz& aVal)
{
    TUint bytes = aBuffer.Bytes();
    Bwh tmp(bytes + 1);
    tmp.Append(aBuffer);
    tmp.Append((TByte)0);
    tmp.SetBytes(bytes);
    tmp.TransferTo(aVal);
}

void OutputProcessorDv::ProcessInt(const Brx& aBuffer, TInt& aVal)
{
    ASSERT(aBuffer.Bytes() == 4);
    (void)memcpy(&aVal, aBuffer.Ptr(), 4);
}

void OutputProcessorDv::ProcessUint(const Brx& aBuffer, TUint& aVal)
{
    ASSERT(aBuffer.Bytes() == 4);
    (void)memcpy(&aVal, aBuffer.Ptr(), 4);
}

void OutputProcessorDv::ProcessBool(const Brx& aBuffer, TBool& aVal)
{
    ASSERT(aBuffer.Bytes() == 1);
    aVal = (aBuffer[0] != 0);
}

void OutputProcessorDv::ProcessBinary(const Brx& aBuffer, Brh& aVal)
{
    Bwh tmp(aBuffer.Bytes());
    if (aBuffer.Bytes() > 0) {
        tmp.Append(aBuffer);
    }
    tmp.TransferTo(aVal);
}
