#ifndef HEADER_DVUPNPORGCONNECTIONMANAGER1CPP
#define HEADER_DVUPNPORGCONNECTIONMANAGER1CPP

#include <ZappTypes.h>
#include <Buffer.h>
#include <Std/DvDevice.h>
#include <DvProvider.h>

#include <string>

namespace Zapp {

class IDviInvocation;
class PropertyInt;
class PropertyUint;
class PropertyBool;
class PropertyString;
class PropertyBinary;

/**
 * Base Device for upnp.org:ConnectionManager:1
 */
class DvProviderUpnpOrgConnectionManager1Cpp : public DvProvider
{
public:
    virtual ~DvProviderUpnpOrgConnectionManager1Cpp() {}
    bool SetPropertySourceProtocolInfo(const std::string& aValue);
    void GetPropertySourceProtocolInfo(std::string& aValue);
    bool SetPropertySinkProtocolInfo(const std::string& aValue);
    void GetPropertySinkProtocolInfo(std::string& aValue);
    bool SetPropertyCurrentConnectionIDs(const std::string& aValue);
    void GetPropertyCurrentConnectionIDs(std::string& aValue);
protected:
    DvProviderUpnpOrgConnectionManager1Cpp(DvDeviceStd& aDevice);
    void EnableActionGetProtocolInfo();
    void EnableActionPrepareForConnection();
    void EnableActionConnectionComplete();
    void EnableActionGetCurrentConnectionIDs();
    void EnableActionGetCurrentConnectionInfo();
private:
    virtual void GetProtocolInfo(uint32_t aVersion, std::string& aSource, std::string& aSink);
    virtual void PrepareForConnection(uint32_t aVersion, const std::string& aRemoteProtocolInfo, const std::string& aPeerConnectionManager, int32_t aPeerConnectionID, const std::string& aDirection, int32_t& aConnectionID, int32_t& aAVTransportID, int32_t& aRcsID);
    virtual void ConnectionComplete(uint32_t aVersion, int32_t aConnectionID);
    virtual void GetCurrentConnectionIDs(uint32_t aVersion, std::string& aConnectionIDs);
    virtual void GetCurrentConnectionInfo(uint32_t aVersion, int32_t aConnectionID, int32_t& aRcsID, int32_t& aAVTransportID, std::string& aProtocolInfo, std::string& aPeerConnectionManager, int32_t& aPeerConnectionID, std::string& aDirection, std::string& aStatus);
private:
    DvProviderUpnpOrgConnectionManager1Cpp();
    void DoGetProtocolInfo(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoPrepareForConnection(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoConnectionComplete(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoGetCurrentConnectionIDs(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoGetCurrentConnectionInfo(IDviInvocation& aInvocation, uint32_t aVersion);
private:
    PropertyString* iPropertySourceProtocolInfo;
    PropertyString* iPropertySinkProtocolInfo;
    PropertyString* iPropertyCurrentConnectionIDs;
};

} // namespace Zapp

#endif // HEADER_DVUPNPORGCONNECTIONMANAGER1CPP

