#include <OpenHome/Private/TestFramework.h>
#include <OpenHome/Private/OptionParser.h>
#include <OpenHome/OhNetTypes.h>
#include <OpenHome/Net/Core/DvDevice.h>
#include <OpenHome/Net/Core/DvOpenhomeOrgTestBasic1.h>
#include <OpenHome/Net/Core/CpOpenhomeOrgTestBasic1.h>
#include <OpenHome/Net/Core/OhNet.h>
#include <OpenHome/Net/Core/CpDevice.h>
#include <OpenHome/Net/Core/CpDeviceUpnp.h>
#include <OpenHome/Private/Ascii.h>
#include <OpenHome/Private/Maths.h>
#include <OpenHome/Net/Private/Stack.h>
#include <OpenHome/Net/Private/DviStack.h>

#include <vector>

using namespace OpenHome;
using namespace OpenHome::Net;
using namespace OpenHome::TestFramework;

namespace OpenHome {
namespace TestDvSubscription {

class ProviderTestBasic : public DvProviderOpenhomeOrgTestBasic1
{
public:
    ProviderTestBasic(DvDevice& aDevice);
private:
    void SetUint(IDvInvocation& aInvocation, TUint aValueUint);
    void GetUint(IDvInvocation& aInvocation, IDvInvocationResponseUint& aValueUint);
    void SetInt(IDvInvocation& aInvocation, TInt aValueInt);
    void GetInt(IDvInvocation& aInvocation, IDvInvocationResponseInt& aValueInt);
    void SetBool(IDvInvocation& aInvocation, TBool aValueBool);
    void GetBool(IDvInvocation& aInvocation, IDvInvocationResponseBool& aValueBool);
    void SetMultiple(IDvInvocation& aInvocation, TUint aValueUint, TInt aValueInt, TBool aValueBool);
    void SetString(IDvInvocation& aInvocation, const Brx& aValueStr);
    void GetString(IDvInvocation& aInvocation, IDvInvocationResponseString& aValueStr);
    void SetBinary(IDvInvocation& aInvocation, const Brx& aValueBin);
    void GetBinary(IDvInvocation& aInvocation, IDvInvocationResponseBinary& aValueBin);
};

class DeviceBasic
{
public:
    DeviceBasic();
    ~DeviceBasic();
private:
    DvDeviceStandard* iDevice;
    ProviderTestBasic* iTestBasic;
};

class CpDevices
{
public:
    CpDevices(Semaphore& aAddedSem);
    ~CpDevices();
    void Test();
    void Added(CpDevice& aDevice);
    void Removed(CpDevice& aDevice);
private:
    void UpdatesComplete();
private:
    Mutex iLock;
    std::vector<CpDevice*> iList;
    Semaphore& iAddedSem;
    Semaphore iUpdatesComplete;
};

} // namespace OpenHome
} // namespace TestDvSubscription

using namespace OpenHome::TestDvSubscription;

ProviderTestBasic::ProviderTestBasic(DvDevice& aDevice)
    : DvProviderOpenhomeOrgTestBasic1(aDevice)
{
    EnablePropertyVarUint();
    EnablePropertyVarInt();
    EnablePropertyVarBool();
    EnablePropertyVarStr();
    EnablePropertyVarBin();
    SetPropertyVarUint(0);
    SetPropertyVarInt(0);
    SetPropertyVarBool(false);
    SetPropertyVarStr(Brx::Empty());
    SetPropertyVarBin(Brx::Empty());

    EnableActionSetUint();
    EnableActionGetUint();
    EnableActionSetInt();
    EnableActionGetInt();
    EnableActionSetBool();
    EnableActionGetBool();
    EnableActionSetMultiple();
    EnableActionSetString();
    EnableActionGetString();
    EnableActionSetBinary();
    EnableActionGetBinary();
}

void ProviderTestBasic::SetUint(IDvInvocation& aInvocation, TUint aValueUint)
{
    SetPropertyVarUint(aValueUint);
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::GetUint(IDvInvocation& aInvocation, IDvInvocationResponseUint& aValueUint)
{
    aInvocation.StartResponse();
    TUint val;
    GetPropertyVarUint(val);
    aValueUint.Write(val);
    aInvocation.EndResponse();
}

void ProviderTestBasic::SetInt(IDvInvocation& aInvocation, TInt aValueInt)
{
    SetPropertyVarInt(aValueInt);
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::GetInt(IDvInvocation& aInvocation, IDvInvocationResponseInt& aValueInt)
{
    aInvocation.StartResponse();
    TInt val;
    GetPropertyVarInt(val);
    aValueInt.Write(val);
    aInvocation.EndResponse();
}

void ProviderTestBasic::SetBool(IDvInvocation& aInvocation, TBool aValueBool)
{
    SetPropertyVarBool(aValueBool);
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::GetBool(IDvInvocation& aInvocation, IDvInvocationResponseBool& aValueBool)
{
    aInvocation.StartResponse();
    TBool val;
    GetPropertyVarBool(val);
    aValueBool.Write(val);
    aInvocation.EndResponse();
}

void ProviderTestBasic::SetMultiple(IDvInvocation& aInvocation, TUint aValueUint, TInt aValueInt, TBool aValueBool)
{
    PropertiesLock();
    SetPropertyVarUint(aValueUint);
    SetPropertyVarInt(aValueInt);
    SetPropertyVarBool(aValueBool);
    PropertiesUnlock();
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::SetString(IDvInvocation& aInvocation, const Brx& aValueStr)
{
    SetPropertyVarStr(aValueStr);
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::GetString(IDvInvocation& aInvocation, IDvInvocationResponseString& aValueStr)
{
    aInvocation.StartResponse();
    Brhz val;
    GetPropertyVarStr(val);
    aValueStr.Write(val);
    aValueStr.WriteFlush();
    aInvocation.EndResponse();
}

void ProviderTestBasic::SetBinary(IDvInvocation& aInvocation, const Brx& aValueBin)
{
    SetPropertyVarBin(aValueBin);
    aInvocation.StartResponse();
    aInvocation.EndResponse();
}

void ProviderTestBasic::GetBinary(IDvInvocation& aInvocation, IDvInvocationResponseBinary& aValueBin)
{
    aInvocation.StartResponse();
    Brh val;
    GetPropertyVarBin(val);
    aValueBin.Write(val);
    aValueBin.WriteFlush();
    aInvocation.EndResponse();
}


static Bwh gDeviceName("device");

static void RandomiseUdn(Bwh& aUdn)
{
    aUdn.Grow(aUdn.Bytes() + 1 + Ascii::kMaxUintStringBytes + 1);
    aUdn.Append('-');
    Bws<Ascii::kMaxUintStringBytes> buf;
    std::vector<NetworkAdapter*>* subnetList = Stack::NetworkAdapterList().CreateSubnetList();
    TUint max = (*subnetList)[0]->Address();
    TUint seed = DviStack::ServerUpnp().Port((*subnetList)[0]->Address());
    SetRandomSeed(seed);
    Stack::NetworkAdapterList().DestroySubnetList(subnetList);
    (void)Ascii::AppendDec(buf, Random(max));
    aUdn.Append(buf);
    aUdn.PtrZ();
}

DeviceBasic::DeviceBasic()
{
    RandomiseUdn(gDeviceName);
    iDevice = new DvDeviceStandard(gDeviceName);
    iDevice->SetAttribute("Upnp.Domain", "openhome.org");
    iDevice->SetAttribute("Upnp.Type", "Test");
    iDevice->SetAttribute("Upnp.Version", "1");
    iDevice->SetAttribute("Upnp.FriendlyName", "ohNetTestDevice");
    iDevice->SetAttribute("Upnp.Manufacturer", "None");
    iDevice->SetAttribute("Upnp.ModelName", "ohNet test device");
    iTestBasic = new ProviderTestBasic(*iDevice);
    iDevice->SetEnabled();
}

DeviceBasic::~DeviceBasic()
{
    delete iTestBasic;
    delete iDevice;
}




CpDevices::CpDevices(Semaphore& aAddedSem)
    : iLock("DLMX")
    , iAddedSem(aAddedSem)
    , iUpdatesComplete("DSB2", 0)
{
}

CpDevices::~CpDevices()
{
    const TUint count = (TUint)iList.size();
    for (TUint i=0; i<count; i++) {
        iList[i]->RemoveRef();
    }
    iList.clear();
}

void CpDevices::Test()
{
    ASSERT(iList.size() == 1);
    CpProxyOpenhomeOrgTestBasic1* proxy = new CpProxyOpenhomeOrgTestBasic1(*(iList[0]));
    Functor functor = MakeFunctor(*this, &CpDevices::UpdatesComplete);
    proxy->SetPropertyChanged(functor);
    proxy->Subscribe();
    iUpdatesComplete.Wait(); // wait for initial event

    /* For each property,
         call the setter action it
         wait on a property being updated
         check that the property matches the value set
         check that the getter action matches the property
    */

    Print("Uint...\n");
    proxy->SyncSetUint(1);
    iUpdatesComplete.Wait();
    TUint propUint;
    proxy->PropertyVarUint(propUint);
    ASSERT(propUint == 1);
    TUint valUint;
    proxy->SyncGetUint(valUint);
    ASSERT(propUint == valUint);

    Print("Int...\n");
    proxy->SyncSetInt(-99);
    iUpdatesComplete.Wait();
    TInt propInt;
    proxy->PropertyVarInt(propInt);
    ASSERT(propInt == -99);
    TInt valInt;
    proxy->SyncGetInt(valInt);
    ASSERT(propInt == valInt);

    Print("Bool...\n");
    proxy->SyncSetBool(true);
    iUpdatesComplete.Wait();
    TBool propBool;
    proxy->PropertyVarBool(propBool);
    ASSERT(propBool);
    TBool valBool;
    proxy->SyncGetBool(valBool);
    ASSERT(valBool);

    Print("String...\n");
    Brn str("Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut "
            "labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco "
            "laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in "
            "voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat "
            "non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
    proxy->SyncSetString(str);
    iUpdatesComplete.Wait();
    Brhz propStr;
    proxy->PropertyVarStr(propStr);
    ASSERT(propStr == str);
    // test again to check that PropertyVarStr didn't TransferTo the property
    proxy->PropertyVarStr(propStr);
    ASSERT(propStr == str);
    Brh valStr;
    proxy->SyncGetString(valStr);
    ASSERT(propStr == valStr);

    Print("Binary...\n");
    char bin[256];
    for (TUint i=0; i<256; i++) {
        bin[i] = (char)i;
    }
    Brn bufBin((const TByte*)&bin[0], 256);
    proxy->SyncSetBinary(bufBin);
    iUpdatesComplete.Wait();
    Brh propBin;
    proxy->PropertyVarBin(propBin);
    ASSERT(propBin == bufBin);
    // test again to check that PropertyVarBin didn't TransferTo the property
    proxy->PropertyVarBin(propBin);
    ASSERT(propBin == bufBin);
    Brh valBin;
    proxy->SyncGetBinary(valBin);
    ASSERT(propBin == valBin);

    Print("Multiple...\n");
    proxy->SyncSetMultiple(15, 658, false);
    iUpdatesComplete.Wait();
    proxy->PropertyVarUint(propUint);
    ASSERT(propUint == 15);
    proxy->SyncGetUint(valUint);
    ASSERT(propUint == valUint);
    proxy->PropertyVarInt(propInt);
    ASSERT(propInt == 658);
    proxy->SyncGetInt(valInt);
    ASSERT(propInt == valInt);
    proxy->PropertyVarBool(propBool);
    ASSERT(!propBool);
    proxy->SyncGetBool(valBool);
    ASSERT(!valBool);

    delete proxy; // automatically unsubscribes
}

void CpDevices::Added(CpDevice& aDevice)
{
    iLock.Wait();
    if (aDevice.Udn() == gDeviceName) {
        iList.push_back(&aDevice);
        aDevice.AddRef();
        iAddedSem.Signal();
    }
    iLock.Signal();
}

void CpDevices::Removed(CpDevice& /*aDevice*/)
{
}

void CpDevices::UpdatesComplete()
{
    iUpdatesComplete.Signal();
}


void TestDvSubscription()
{
    InitialisationParams& initParams = Stack::InitParams();
    TUint oldMsearchTime = initParams.MsearchTimeSecs();
    initParams.SetMsearchTime(1);
    Print("TestDvSubscription - starting\n");

    Semaphore* sem = new Semaphore("SEM1", 0);
    DeviceBasic* device = new DeviceBasic;
    CpDevices* deviceList = new CpDevices(*sem);
    FunctorCpDevice added = MakeFunctorCpDevice(*deviceList, &CpDevices::Added);
    FunctorCpDevice removed = MakeFunctorCpDevice(*deviceList, &CpDevices::Removed);
    Brn domainName("openhome.org");
    Brn serviceType("TestBasic");
    TUint ver = 1;
    CpDeviceListUpnpServiceType* list =
                new CpDeviceListUpnpServiceType(domainName, serviceType, ver, added, removed);
    sem->Wait(30*1000); // allow up to 30 seconds to issue the msearch and receive a response
    delete sem;
    deviceList->Test();
    delete list;
    delete deviceList;
    delete device;

    Print("TestDvSubscription - completed\n");
    initParams.SetMsearchTime(oldMsearchTime);
}
