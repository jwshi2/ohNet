#ifndef HEADER_DVLINNCOUKDEBUG2CPP
#define HEADER_DVLINNCOUKDEBUG2CPP

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
 * Base Device for linn.co.uk:Debug:2
 */
class DvProviderLinnCoUkDebug2Cpp : public DvProvider
{
public:
    virtual ~DvProviderLinnCoUkDebug2Cpp() {}
protected:
    DvProviderLinnCoUkDebug2Cpp(DvDeviceStd& aDevice);
    void EnableActionSetDebugLevel();
    void EnableActionDebugLevel();
    void EnableActionMemWrite();
private:
    virtual void SetDebugLevel(uint32_t aVersion, uint32_t aaDebugLevel);
    virtual void DebugLevel(uint32_t aVersion, uint32_t& aaDebugLevel);
    virtual void MemWrite(uint32_t aVersion, uint32_t aaMemAddress, const std::string& aaMemData);
private:
    DvProviderLinnCoUkDebug2Cpp();
    void DoSetDebugLevel(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoDebugLevel(IDviInvocation& aInvocation, uint32_t aVersion);
    void DoMemWrite(IDviInvocation& aInvocation, uint32_t aVersion);
private:
};

} // namespace Zapp

#endif // HEADER_DVLINNCOUKDEBUG2CPP

