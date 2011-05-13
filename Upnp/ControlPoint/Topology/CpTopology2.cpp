#include "CpTopology2.h"

#include <Debug.h>
#include <Parser.h>
#include <Ascii.h>
#include <XmlParser.h>

using namespace Zapp;

// CpTopology2Source

CpTopology2Source::CpTopology2Source(const Brx& aName, const Brx& aType, TBool aVisible)
	: iName(aName)
	, iType(aType)
	, iVisible(aVisible)
{
}

const Brx& CpTopology2Source::Name() const
{
	return (iName);
}

const Brx& CpTopology2Source::Type() const
{
	return (iType);
}

TBool CpTopology2Source::Visible() const
{
	return (iVisible);
}
    
void CpTopology2Source::Update(const Brx& aName, const Brx& aType, TBool aVisible)
{
	iName.Replace(aName);
	iType.Replace(aType);
	iVisible = aVisible;
}

// CpTopology2Group

CpTopology2Group::CpTopology2Group(ICpTopology2GroupHandler& aHandler, CpDevice& aDevice, TBool aStandby, const Brx& aRoom, const Brx& aName, TUint aSourceIndex, TBool aHasVolumeControl, TUint aVolume, TBool aMute)
	: iHandler(aHandler)
	, iDevice(aDevice)
	, iStandby(aStandby)
	, iRoom(aRoom)
	, iName(aName)
	, iSourceIndex(aSourceIndex)
	, iHasVolumeControl(aHasVolumeControl)
	, iVolume(aVolume)
	, iMute(aMute)
	, iUserData(0)
	, iRefCount(1)
{
	iDevice.AddRef();
}

CpTopology2Group::~CpTopology2Group()
{
	iDevice.RemoveRef();
}

void CpTopology2Group::AddSource(const Brx& aName, const Brx& aType, TBool aVisible)
{
	iSourceList.push_back(new CpTopology2Source(aName, aType, aVisible));
}

void CpTopology2Group::UpdateRoom(const Brx& aRoom)
{
	iRoom.Replace(aRoom);
}

void CpTopology2Group::UpdateName(const Brx& aName)
{
	iName.Replace(aName);
}

void CpTopology2Group::UpdateSourceIndex(TUint aIndex)
{
	iSourceIndex = aIndex;
}

void CpTopology2Group::UpdateStandby(TBool aValue)
{
	iStandby = aValue;
}

void CpTopology2Group::UpdateVolume(TUint aValue)
{
	iVolume = aValue;
}

void CpTopology2Group::UpdateMute(TBool aValue)
{
	iMute = aValue;
}

void CpTopology2Group::UpdateSource(TUint aIndex, const Brx& aName, const Brx& aType, TBool aVisible)
{
	iSourceList[aIndex]->Update(aName, aType, aVisible);
}

void CpTopology2Group::AddRef()
{
    iRefCount++;
}

void CpTopology2Group::RemoveRef()
{
    if (--iRefCount == 0) {
        delete this;
    }
}

TUint CpTopology2Group::SourceCount() const
{
	return (TUint)iSourceList.size();
}

TUint CpTopology2Group::SourceIndex() const
{
	return (iSourceIndex);
}

TBool CpTopology2Group::Standby() const
{
	return (iStandby);
}

void CpTopology2Group::SetSourceIndex(TUint aIndex)
{
	ASSERT(aIndex < iSourceList.size());
	iHandler.SetSourceIndex(aIndex);
}

void CpTopology2Group::SetStandby(TBool aValue)
{
	iHandler.SetStandby(aValue);
}

const Brx& CpTopology2Group::Room() const
{
	return (iRoom);
}

const Brx& CpTopology2Group::Name() const
{
	return (iName);
}

const Brx& CpTopology2Group::SourceName(TUint aIndex) const
{
	return (iSourceList[aIndex]->Name());
}

const Brx& CpTopology2Group::SourceType(TUint aIndex) const
{
	return (iSourceList[aIndex]->Type());
}

TBool CpTopology2Group::SourceVisible(TUint aIndex) const
{
	return (iSourceList[aIndex]->Visible());
}

CpDevice& CpTopology2Group::Device() const
{
	return (iDevice);
}

TBool CpTopology2Group::HasVolumeControl() const
{
	return (iHasVolumeControl);
}

TUint CpTopology2Group::Volume() const
{
	ASSERT(iHasVolumeControl);
	return (iVolume);
}

void CpTopology2Group::SetVolume(TUint aValue) const
{
	ASSERT(iHasVolumeControl);
	iHandler.SetVolume(aValue);
}

TBool CpTopology2Group::Mute() const
{
	ASSERT(iHasVolumeControl);
	return (iMute);
}

void CpTopology2Group::SetMute(TBool aValue)
{
	ASSERT(iHasVolumeControl);
	iHandler.SetMute(aValue);
}

void CpTopology2Group::SetUserData(void* aPtr)
{
	iUserData = aPtr;
}

void* CpTopology2Group::UserData() const
{
	return (iUserData);
}

// CpTopology2Device

CpTopology2Device::CpTopology2Device(CpDevice& aDevice)
    : iDevice(aDevice)
{
    //iDevice.AddRef();
}
	
TBool CpTopology2Device::IsAttachedTo(CpDevice& aDevice)
{
	return (iDevice.Udn() == aDevice.Udn());
}

CpTopology2Device::~CpTopology2Device()
{
    //iDevice.RemoveRef();
}
	
// CpTopology2Product

CpTopology2Product::CpTopology2Product(CpDevice& aDevice, ICpTopology2Handler& aHandler)
    : CpTopology2Device(aDevice)
    , iHandler(aHandler)
    , iServiceProduct(0)
    , iServiceVolume(0)
    , iGroup(0)
{
    iFunctorSetSourceIndex = MakeFunctorAsync(*this, &CpTopology2Product::CallbackSetSourceIndex);
    iFunctorSetStandby = MakeFunctorAsync(*this, &CpTopology2Product::CallbackSetStandby);
    iFunctorSetVolume = MakeFunctorAsync(*this, &CpTopology2Product::CallbackSetVolume);
    iFunctorSetMute = MakeFunctorAsync(*this, &CpTopology2Product::CallbackSetMute);
	iServiceProduct = new CpProxyAvOpenhomeOrgProduct1(iDevice);

	Functor functorInitial = MakeFunctor(*this, &CpTopology2Product::EventProductInitialEvent);

    iServiceProduct->SetPropertyInitialEvent(functorInitial);

	iServiceProduct->Subscribe();
}

CpTopology2Product::~CpTopology2Product()
{
	delete (iServiceProduct);
	delete (iServiceVolume);
	
	if (iGroup != 0) {
		iHandler.GroupRemoved(*iGroup);
		iGroup->RemoveRef();
	}
}

void CpTopology2Product::EventProductInitialEvent()
{
    Functor functorRoom = MakeFunctor(*this, &CpTopology2Product::EventProductRoomChanged);
    Functor functorName = MakeFunctor(*this, &CpTopology2Product::EventProductNameChanged);
    Functor functorStandby = MakeFunctor(*this, &CpTopology2Product::EventProductStandbyChanged);
    Functor functorSourceIndex = MakeFunctor(*this, &CpTopology2Product::EventProductSourceIndexChanged);
    Functor functorSourceXml = MakeFunctor(*this, &CpTopology2Product::EventProductSourceXmlChanged);

    iServiceProduct->SetPropertyProductRoomChanged(functorRoom);    
    iServiceProduct->SetPropertyProductNameChanged(functorName);    
    iServiceProduct->SetPropertyStandbyChanged(functorStandby); 
    iServiceProduct->SetPropertySourceIndexChanged(functorSourceIndex); 
    iServiceProduct->SetPropertySourceXmlChanged(functorSourceXml);
      
	Brhz attributes;

	iServiceProduct->PropertyAttributes(attributes);

    Parser parser(attributes);
    
    for (;;) {
        Brn attribute = parser.Next();
        
        if (attribute.Bytes() == 0) {
            break;
        }
        
        if (attribute == Brn("Volume")) {
            iServiceVolume = new CpProxyAvOpenhomeOrgVolume1(iDevice);
            Functor functorInitial = MakeFunctor(*this, &CpTopology2Product::EventPreampInitialEvent);
            iServiceVolume->SetPropertyInitialEvent(functorInitial);    
            iServiceVolume->Subscribe();
            return;
        }
    }
    
	Brhz room;
	Brhz name;
	TUint sourceIndex;
	TBool standby;
	Brhz xml;
	
	iServiceProduct->PropertyProductRoom(room);
	iServiceProduct->PropertyProductName(name);
	iServiceProduct->PropertySourceIndex(sourceIndex);
	iServiceProduct->PropertyStandby(standby);
	iServiceProduct->PropertySourceXml(xml);
	
	iGroup = new CpTopology2Group(*this, iDevice, standby, room, name, sourceIndex, false, 0, false);
	
	ProcessSourceXml(xml, true);
	
	iHandler.GroupAdded(*iGroup);
}

void CpTopology2Product::EventPreampInitialEvent()
{
    Functor functorVolume = MakeFunctor(*this, &CpTopology2Product::EventVolumeChanged);
    Functor functorMute = MakeFunctor(*this, &CpTopology2Product::EventMuteChanged);
    iServiceVolume->SetPropertyVolumeChanged(functorVolume);    
    iServiceVolume->SetPropertyMuteChanged(functorMute);    

	Brhz room;
	Brhz name;
	TUint sourceIndex;
	TBool standby;
	Brhz xml;
	
	iServiceProduct->PropertyProductRoom(room);
	iServiceProduct->PropertyProductName(name);
	iServiceProduct->PropertySourceIndex(sourceIndex);
	iServiceProduct->PropertyStandby(standby);
	iServiceProduct->PropertySourceXml(xml);
	
	TUint volume;
	TBool mute;
	
	iServiceVolume->PropertyVolume(volume);
	iServiceVolume->PropertyMute(mute);

	iGroup = new CpTopology2Group(*this, iDevice, standby, room, name, sourceIndex, true, volume, mute);
	
	ProcessSourceXml(xml, true);

    iHandler.GroupAdded(*iGroup);
}

/*  Example source xml

	<SourceList>
		<Source>
			<Name>Playlist</Name>
			<Type>Playlist</Type>
			<Visible>1</Visible>
		</Source>
		<Source>
			<Name>Radio</Name>
			<Type>Radio</Type>
			<Visible>1</Visible>
		</Source>
	</SourceList>
*/

void CpTopology2Product::ProcessSourceXml(const Brx& aXml, TBool aInitial)
{
	TUint count = 0;

	TBool updated = false;
	
	try {
	    Brn sourceList = XmlParserBasic::Find("SourceList", aXml);

		for (;;) {
			Brn source = XmlParserBasic::Find("Source", sourceList, sourceList);
			Brn name = XmlParserBasic::Find("Name", source);
			Brn type = XmlParserBasic::Find("Type", source);
			Brn visible = XmlParserBasic::Find("Visible", source);
			
			TBool vis = false;
			
			if (visible == Brn("true")) {
				vis = true;
			}
			
			if (aInitial) {
				iGroup->AddSource(name, type, vis);
			}
			else {
				iGroup->UpdateSource(count, name, type, vis);
				updated = true;
			}

			count++;
		}
	}
	catch (XmlError) {
	}
	
	if (updated) {
		iHandler.GroupSourceListChanged(*iGroup);
	}
}

void CpTopology2Product::EventProductRoomChanged()
{
    LOG(kTopology, "CpTopology2::EventProductRoomChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	Brhz room;
	iServiceProduct->PropertyProductRoom(room);
	
	iHandler.GroupRemoved(*iGroup);
	iGroup->UpdateRoom(room);
	iHandler.GroupAdded(*iGroup);
}
	
void CpTopology2Product::EventProductNameChanged()
{
    LOG(kTopology, "CpTopology2::EventProductNameChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	Brhz name;
	iServiceProduct->PropertyProductName(name);
	
	iHandler.GroupRemoved(*iGroup);
	iGroup->UpdateName(name);
	iHandler.GroupAdded(*iGroup);
}

void CpTopology2Product::EventProductStandbyChanged()
{
    LOG(kTopology, "CpTopology2::EventProductStandbyChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	TBool standby;
	iServiceProduct->PropertyStandby(standby);
	
	iGroup->UpdateStandby(standby);
	iHandler.GroupStandbyChanged(*iGroup);
}
	
void CpTopology2Product::EventProductSourceIndexChanged()
{
    LOG(kTopology, "CpTopology2::EventProductSourceIndexChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	TUint sourceIndex;
	iServiceProduct->PropertySourceIndex(sourceIndex);
	
	iGroup->UpdateSourceIndex(sourceIndex);
	iHandler.GroupSourceIndexChanged(*iGroup);
}
	
void CpTopology2Product::EventProductSourceXmlChanged()
{
    LOG(kTopology, "CpTopology2::EventProductSourceXmlChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	Brhz xml;
	
	iServiceProduct->PropertySourceXml(xml);

	ProcessSourceXml(xml, false);	
}	

void CpTopology2Product::EventVolumeChanged()
{
    LOG(kTopology, "CpTopology2::EventVolumeChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	TUint volume;
	iServiceVolume->PropertyVolume(volume);

	iGroup->UpdateVolume(volume);
	iHandler.GroupVolumeChanged(*iGroup);
}	

void CpTopology2Product::EventMuteChanged()
{
    LOG(kTopology, "CpTopology2::EventMuteChanged ");
    LOG(kTopology, iGroup->Room());
    LOG(kTopology, ":");
    LOG(kTopology, iGroup->Name());
    LOG(kTopology, "\n");

	TBool mute;
	iServiceVolume->PropertyMute(mute);

	iGroup->UpdateMute(mute);
	iHandler.GroupMuteChanged(*iGroup);
}	

void CpTopology2Product::SetSourceIndex(TUint aIndex)
{
	iServiceProduct->BeginSetSourceIndex(aIndex, iFunctorSetSourceIndex);
}

void CpTopology2Product::CallbackSetSourceIndex(IAsync& aAsync)
{
	iServiceProduct->EndSetSourceIndex(aAsync);
}
	
void CpTopology2Product::SetStandby(TBool aValue)
{
	iServiceProduct->BeginSetStandby(aValue, iFunctorSetStandby);
}

void CpTopology2Product::CallbackSetStandby(IAsync& aAsync)
{
	iServiceProduct->EndSetStandby(aAsync);
}		

void CpTopology2Product::SetVolume(TUint aValue)
{
	iServiceVolume->BeginSetVolume(aValue, iFunctorSetVolume);
}

void CpTopology2Product::CallbackSetVolume(IAsync& aAsync)
{
	iServiceVolume->EndSetVolume(aAsync);
}		

void CpTopology2Product::SetMute(TBool aValue)
{
	iServiceVolume->BeginSetMute(aValue, iFunctorSetVolume);
}

void CpTopology2Product::CallbackSetMute(IAsync& aAsync)
{
	iServiceVolume->EndSetMute(aAsync);
}		

// CpTopology2MediaRenderer

CpTopology2MediaRenderer::CpTopology2MediaRenderer(CpDevice& aDevice, ICpTopology2Handler& aHandler)
	: CpTopology2Device(aDevice)
	, iHandler(aHandler)
    , iServiceRenderingControl(0)
    , iGroup(0)
    , iVolume(0)
    , iMute(false)
{
    iFunctorSetVolume = MakeFunctorAsync(*this, &CpTopology2MediaRenderer::CallbackSetVolume);
    iFunctorSetMute = MakeFunctorAsync(*this, &CpTopology2MediaRenderer::CallbackSetMute);

	Brh version;

	iHasVolume = aDevice.GetAttribute("Upnp.Service.upnp.org.RenderingControl", version);
	iHasTransport = aDevice.GetAttribute("Upnp.Service.upnp.org.AVTransport", version);

	if (iHasVolume || iHasTransport) {
	
		if (iHasVolume) {
			iServiceRenderingControl = new CpProxyUpnpOrgRenderingControl1(iDevice);
			Functor initial = MakeFunctor(*this, &CpTopology2MediaRenderer::EventRenderingControlPropertyChanged);
			iServiceRenderingControl->SetPropertyChanged(initial);	
			iServiceRenderingControl->Subscribe();
			return;
		}

		Brh friendly;
		
		iDevice.GetAttribute("Upnp.FriendlyName", friendly);
	
		Brn room;
		Brn name;
		
		ParseFriendlyName(friendly, room, name);
		iGroup = new CpTopology2Group(*this, iDevice, false, room, name, 0, false, 0, false);
		iGroup->AddSource(Brn("MediaRenderer"), Brn("UpnpAv"), true);
		iHandler.GroupAdded(*iGroup);
	}
}

CpTopology2MediaRenderer::~CpTopology2MediaRenderer()
{
	delete (iServiceRenderingControl);
	
	if (iGroup != 0) {
		iHandler.GroupRemoved(*iGroup);
		iGroup->RemoveRef();
	}
}

/* Example LastChange property

<Event xmlns="urn:schemas-upnp-org:metadata-1-0/RCS/">
    <InstanceID val="0">
        <PresetNameList val="FactoryDefaults"/>
        <Mute channel= "Master" val="0"/>
        <Volume channel= "Master" val="50"/>
        <VolumeDB val="-7680"/>
    </InstanceID>
</Event>

*/

void CpTopology2MediaRenderer::ProcessLastChange()
{
	try {
		Brhz lastChange;
		
		iServiceRenderingControl->PropertyLastChange(lastChange);
		
	    Brn event = XmlParserBasic::Find("Event", lastChange);
		Brn instance = XmlParserBasic::Find("InstanceID", event);
		
		try {
			iVolume = Ascii::Uint(XmlParserBasic::FindAttribute("Volume", "val", instance));
		}
		catch (XmlError) {
		}
		catch (AsciiError) {
		}
		
		try {
			Brn mute = XmlParserBasic::FindAttribute("Mute", "val", instance);
			iMute = (mute != Brn("0"));
		}
		catch (XmlError) {
		}
	}
	catch (XmlError)
	{
	}
}

void CpTopology2MediaRenderer::EventRenderingControlPropertyChanged()
{
	ProcessLastChange();
	
	if (iGroup == 0) {
		Brh friendly;
		
		iDevice.GetAttribute("Upnp.FriendlyName", friendly);
	
		Brn room;
		Brn name;
		
		ParseFriendlyName(friendly, room, name);
		iGroup = new CpTopology2Group(*this, iDevice, false, room, name, 0, true, iVolume, iMute);
		
		if (iHasTransport) {
			iGroup->AddSource(Brn("MediaRenderer"), Brn("UpnpAv"), true);
		}
		
		iHandler.GroupAdded(*iGroup);
	}
	else {
		if (iVolume != iGroup->Volume()) {
			iGroup->UpdateVolume(iVolume);
			iHandler.GroupVolumeChanged(*iGroup);
		}
		
		if (iMute != iGroup->Mute()) {
			iGroup->UpdateMute(iMute);
			iHandler.GroupMuteChanged(*iGroup);
		}
	}
}

TBool CpTopology2MediaRenderer::ParseFriendlyNameBracketed(const Brx& aFriendlyName, Brn& aRoom, Brn& aName, TChar aOpen, TChar aClose)
{
	Parser parser(aFriendlyName);
	
	Brn room = parser.Next(aOpen);
	Brn name = parser.Next(aClose);
	
	if (room.Bytes() > 0 && name.Bytes() > 0) {
		if (room.Bytes() > CpTopology2Group::kMaxRoomBytes || name.Bytes() > CpTopology2Group::kMaxNameBytes) {
			return (false);
		}
		
		aRoom.Set(room);
		aName.Set(name);
		
		return (true);
	}
	
	return (false);
}

void CpTopology2MediaRenderer::ParseFriendlyName(const Brx& aFriendlyName, Brn& aRoom, Brn& aName)
{
    if (ParseFriendlyNameBracketed(aFriendlyName, aRoom, aName, '(', ')'))
    {
        return;
    }

    if (ParseFriendlyNameBracketed(aFriendlyName, aRoom, aName, '[', ']'))
    {
        return;
    }

    if (ParseFriendlyNameBracketed(aFriendlyName, aRoom, aName, '<', '>'))
    {
        return;
    }

    if (ParseFriendlyNameBracketed(aFriendlyName, aRoom, aName, ':', ':'))
    {
        return;
    }

    if (ParseFriendlyNameBracketed(aFriendlyName, aRoom, aName, '.', '.'))
    {
        return;
    }

	if (aFriendlyName.Bytes() > CpTopology2Group::kMaxRoomBytes) {
		aRoom.Set(aFriendlyName.Split(0, CpTopology2Group::kMaxRoomBytes));
	}
	else {
		aRoom.Set(aFriendlyName);
	}
	
	if (aFriendlyName.Bytes() > CpTopology2Group::kMaxNameBytes) {
		aName.Set(aFriendlyName.Split(0, CpTopology2Group::kMaxNameBytes));
	}
	else {
		aName.Set(aFriendlyName);
	}
}
	
void CpTopology2MediaRenderer::SetSourceIndex(TUint aIndex)
{
	ASSERT(aIndex == 0);
}

void CpTopology2MediaRenderer::SetStandby(TBool aValue)
{
	iGroup->UpdateStandby(aValue); 
	iHandler.GroupStandbyChanged(*iGroup);
}

void CpTopology2MediaRenderer::SetVolume(TUint aValue)
{
	iServiceRenderingControl->BeginSetVolume(0, Brn("Master"), aValue, iFunctorSetVolume);
}

void CpTopology2MediaRenderer::CallbackSetVolume(IAsync& /*aAsync*/)
{
}

void CpTopology2MediaRenderer::SetMute(TBool aValue)
{
	iServiceRenderingControl->BeginSetMute(0, Brn("Master"), aValue, iFunctorSetMute);
}

void CpTopology2MediaRenderer::CallbackSetMute(IAsync& /*aAsync*/)
{
}
		
// CpTopology2Job

CpTopology2Job::CpTopology2Job(ICpTopology2Handler& aHandler)
{
	iHandler = &aHandler;
	iGroup = 0;
}
	
void CpTopology2Job::Set(CpTopology2Group& aGroup, ICpTopology2HandlerFunction aFunction)
{
	iGroup = &aGroup;
	iFunction = aFunction;
	iGroup->AddRef();
}

void CpTopology2Job::Execute()
{
	if (iGroup) {
		(iHandler->*iFunction)(*iGroup);
		iGroup->RemoveRef();
		iGroup = 0;
	}
	else {
		THROW(ThreadKill);
	}
}

// CpTopology2

CpTopology2::CpTopology2(ICpTopology2Handler& aHandler)
	: iFree(kMaxJobCount)
	, iReady(kMaxJobCount)
{
	for (TUint i = 0; i < kMaxJobCount; i++) {
		iFree.Write(new CpTopology2Job(aHandler));
	}
	
	iTopology1 = new CpTopology1(*this);
	
	iThread = new ThreadFunctor("TOP2", MakeFunctor(*this, &CpTopology2::Run));
	iThread->Start();
}

CpTopology2::~CpTopology2()
{
    delete (iTopology1);
    
    std::vector<CpTopology2Device*>::iterator it = iDeviceList.begin();

    while (it != iDeviceList.end()) {
        delete (*it);
        it++;
    }   

	iReady.Write(iFree.Read());

	delete (iThread);
	
	for (TUint i = 0; i < kMaxJobCount; i++) {
		delete (iFree.Read());
	}
}
    
void CpTopology2::Refresh()
{
	iTopology1->Refresh();
}

// ICpTopology1Handler
    
void CpTopology2::ProductAdded(CpDevice& aDevice)
{
    if (aDevice.Udn() == Brn("4c494e4e-0026-0f21-8335-42000004013f") || aDevice.Udn() == Brn("4c494e4e-0026-0f21-833c-90000004013f")) {
    	iDeviceList.push_back(new CpTopology2Product(aDevice, *this));
   	}
}

void CpTopology2::ProductRemoved(CpDevice& aDevice)
{
    DeviceRemoved(aDevice);
}

void CpTopology2::UpnpAdded(CpDevice& aDevice)
{
//  iDeviceList.push_back(new CpTopology2MediaRenderer(aDevice, *this));
}

void CpTopology2::UpnpRemoved(CpDevice& aDevice)
{
//  DeviceRemoved(aDevice);
}

void CpTopology2::DeviceRemoved(CpDevice& aDevice)
{
    std::vector<CpTopology2Device*>::iterator it = iDeviceList.begin();

    while (it != iDeviceList.end()) {
        if ((*it)->IsAttachedTo(aDevice)) {
            LOG(kTopology, "CpTopology2::ProductRemoved found\n");
            delete (*it);
            iDeviceList.erase(it);
            break;
        }
        it++;
    }   
}

// ICpTopology1Handler

void CpTopology2::GroupAdded(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupAdded ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupAdded);
	iReady.Write(job);
}

void CpTopology2::GroupStandbyChanged(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupStandbyChanged ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupStandbyChanged);
	iReady.Write(job);
}

void CpTopology2::GroupSourceIndexChanged(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupSourceIndexChanged ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupSourceIndexChanged);
	iReady.Write(job);
}

void CpTopology2::GroupSourceListChanged(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupSourceListChanged ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupSourceListChanged);
	iReady.Write(job);
}

void CpTopology2::GroupVolumeChanged(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupVolumeChanged ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupVolumeChanged);
	iReady.Write(job);
}

void CpTopology2::GroupMuteChanged(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupMuteChanged ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupMuteChanged);
	iReady.Write(job);
}

void CpTopology2::GroupRemoved(CpTopology2Group& aGroup)
{
    LOG(kTopology, "CpTopology2::GroupRemoved ");
    LOG(kTopology, aGroup.Room());
    LOG(kTopology, ":");
    LOG(kTopology, aGroup.Name());
    LOG(kTopology, "\n");

	CpTopology2Job* job = iFree.Read();
	job->Set(aGroup, &ICpTopology2Handler::GroupRemoved);
	iReady.Write(job);
}

void CpTopology2::Run()
{
    LOG(kTopology, "CpTopology2::Run Started\n");

    for (;;)
    {
	    LOG(kTopology, "CpTopology2::Run wait for job\n");

    	CpTopology2Job* job = iReady.Read();
    	
	    LOG(kTopology, "CpTopology2::Run execute job\n");

    	try {
	    	job->Execute();
	    	iFree.Write(job);
	    }
	    catch (ThreadKill)
	    {
	    	iFree.Write(job);
	    	break;
	    }
    }

    LOG(kTopology, "CpTopology2::Run Exiting\n");
}
