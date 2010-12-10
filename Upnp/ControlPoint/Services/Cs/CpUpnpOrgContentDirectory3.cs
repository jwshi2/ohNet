using System;
using System.Runtime.InteropServices;
using System.Text;
using Zapp;

namespace Zapp.ControlPoint.Proxies
{
    public interface ICpProxyUpnpOrgContentDirectory3 : ICpProxy, IDisposable
    {
        void SyncGetSearchCapabilities(out string aSearchCaps);
        void BeginGetSearchCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSearchCapabilities(IntPtr aAsyncHandle, out string aSearchCaps);
        void SyncGetSortCapabilities(out string aSortCaps);
        void BeginGetSortCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSortCapabilities(IntPtr aAsyncHandle, out string aSortCaps);
        void SyncGetSortExtensionCapabilities(out string aSortExtensionCaps);
        void BeginGetSortExtensionCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSortExtensionCapabilities(IntPtr aAsyncHandle, out string aSortExtensionCaps);
        void SyncGetFeatureList(out string aFeatureList);
        void BeginGetFeatureList(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetFeatureList(IntPtr aAsyncHandle, out string aFeatureList);
        void SyncGetSystemUpdateID(out uint aId);
        void BeginGetSystemUpdateID(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSystemUpdateID(IntPtr aAsyncHandle, out uint aId);
        void SyncGetServiceResetToken(out string aResetToken);
        void BeginGetServiceResetToken(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetServiceResetToken(IntPtr aAsyncHandle, out string aResetToken);
        void SyncBrowse(string aObjectID, string aBrowseFlag, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID);
        void BeginBrowse(string aObjectID, string aBrowseFlag, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, CpProxy.CallbackAsyncComplete aCallback);
        void EndBrowse(IntPtr aAsyncHandle, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID);
        void SyncSearch(string aContainerID, string aSearchCriteria, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID);
        void BeginSearch(string aContainerID, string aSearchCriteria, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, CpProxy.CallbackAsyncComplete aCallback);
        void EndSearch(IntPtr aAsyncHandle, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID);
        void SyncCreateObject(string aContainerID, string aElements, out string aObjectID, out string aResult);
        void BeginCreateObject(string aContainerID, string aElements, CpProxy.CallbackAsyncComplete aCallback);
        void EndCreateObject(IntPtr aAsyncHandle, out string aObjectID, out string aResult);
        void SyncDestroyObject(string aObjectID);
        void BeginDestroyObject(string aObjectID, CpProxy.CallbackAsyncComplete aCallback);
        void EndDestroyObject(IntPtr aAsyncHandle);
        void SyncUpdateObject(string aObjectID, string aCurrentTagValue, string aNewTagValue);
        void BeginUpdateObject(string aObjectID, string aCurrentTagValue, string aNewTagValue, CpProxy.CallbackAsyncComplete aCallback);
        void EndUpdateObject(IntPtr aAsyncHandle);
        void SyncMoveObject(string aObjectID, string aNewParentID, out string aNewObjectID);
        void BeginMoveObject(string aObjectID, string aNewParentID, CpProxy.CallbackAsyncComplete aCallback);
        void EndMoveObject(IntPtr aAsyncHandle, out string aNewObjectID);
        void SyncImportResource(string aSourceURI, string aDestinationURI, out uint aTransferID);
        void BeginImportResource(string aSourceURI, string aDestinationURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndImportResource(IntPtr aAsyncHandle, out uint aTransferID);
        void SyncExportResource(string aSourceURI, string aDestinationURI, out uint aTransferID);
        void BeginExportResource(string aSourceURI, string aDestinationURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndExportResource(IntPtr aAsyncHandle, out uint aTransferID);
        void SyncDeleteResource(string aResourceURI);
        void BeginDeleteResource(string aResourceURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndDeleteResource(IntPtr aAsyncHandle);
        void SyncStopTransferResource(uint aTransferID);
        void BeginStopTransferResource(uint aTransferID, CpProxy.CallbackAsyncComplete aCallback);
        void EndStopTransferResource(IntPtr aAsyncHandle);
        void SyncGetTransferProgress(uint aTransferID, out string aTransferStatus, out string aTransferLength, out string aTransferTotal);
        void BeginGetTransferProgress(uint aTransferID, CpProxy.CallbackAsyncComplete aCallback);
        void EndGetTransferProgress(IntPtr aAsyncHandle, out string aTransferStatus, out string aTransferLength, out string aTransferTotal);
        void SyncCreateReference(string aContainerID, string aObjectID, out string aNewID);
        void BeginCreateReference(string aContainerID, string aObjectID, CpProxy.CallbackAsyncComplete aCallback);
        void EndCreateReference(IntPtr aAsyncHandle, out string aNewID);
        void SyncFreeFormQuery(string aContainerID, uint aCDSView, string aQueryRequest, out string aQueryResult, out uint aUpdateID);
        void BeginFreeFormQuery(string aContainerID, uint aCDSView, string aQueryRequest, CpProxy.CallbackAsyncComplete aCallback);
        void EndFreeFormQuery(IntPtr aAsyncHandle, out string aQueryResult, out uint aUpdateID);
        void SyncGetFreeFormQueryCapabilities(out string aFFQCapabilities);
        void BeginGetFreeFormQueryCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetFreeFormQueryCapabilities(IntPtr aAsyncHandle, out string aFFQCapabilities);

        void SetPropertySystemUpdateIDChanged(CpProxy.CallbackPropertyChanged aSystemUpdateIDChanged);
        void PropertySystemUpdateID(out uint aSystemUpdateID);
        void SetPropertyContainerUpdateIDsChanged(CpProxy.CallbackPropertyChanged aContainerUpdateIDsChanged);
        void PropertyContainerUpdateIDs(out string aContainerUpdateIDs);
        void SetPropertyLastChangeChanged(CpProxy.CallbackPropertyChanged aLastChangeChanged);
        void PropertyLastChange(out string aLastChange);
        void SetPropertyTransferIDsChanged(CpProxy.CallbackPropertyChanged aTransferIDsChanged);
        void PropertyTransferIDs(out string aTransferIDs);
    }

    /// <summary>
    /// Proxy for the upnp.org:ContentDirectory:3 UPnP service
    /// </summary>
    public class CpProxyUpnpOrgContentDirectory3 : CpProxy, IDisposable, ICpProxyUpnpOrgContentDirectory3
    {
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern IntPtr CpProxyUpnpOrgContentDirectory3Create(IntPtr aDeviceHandle);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern void CpProxyUpnpOrgContentDirectory3Destroy(IntPtr aHandle);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetSearchCapabilities(IntPtr aHandle, char** aSearchCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetSearchCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetSearchCapabilities(IntPtr aHandle, IntPtr aAsync, char** aSearchCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetSortCapabilities(IntPtr aHandle, char** aSortCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetSortCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetSortCapabilities(IntPtr aHandle, IntPtr aAsync, char** aSortCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetSortExtensionCapabilities(IntPtr aHandle, char** aSortExtensionCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetSortExtensionCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetSortExtensionCapabilities(IntPtr aHandle, IntPtr aAsync, char** aSortExtensionCaps);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetFeatureList(IntPtr aHandle, char** aFeatureList);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetFeatureList(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetFeatureList(IntPtr aHandle, IntPtr aAsync, char** aFeatureList);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetSystemUpdateID(IntPtr aHandle, uint* aId);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetSystemUpdateID(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetSystemUpdateID(IntPtr aHandle, IntPtr aAsync, uint* aId);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetServiceResetToken(IntPtr aHandle, char** aResetToken);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetServiceResetToken(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetServiceResetToken(IntPtr aHandle, IntPtr aAsync, char** aResetToken);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncBrowse(IntPtr aHandle, char* aObjectID, char* aBrowseFlag, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginBrowse(IntPtr aHandle, char* aObjectID, char* aBrowseFlag, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndBrowse(IntPtr aHandle, IntPtr aAsync, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncSearch(IntPtr aHandle, char* aContainerID, char* aSearchCriteria, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginSearch(IntPtr aHandle, char* aContainerID, char* aSearchCriteria, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndSearch(IntPtr aHandle, IntPtr aAsync, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncCreateObject(IntPtr aHandle, char* aContainerID, char* aElements, char** aObjectID, char** aResult);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginCreateObject(IntPtr aHandle, char* aContainerID, char* aElements, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndCreateObject(IntPtr aHandle, IntPtr aAsync, char** aObjectID, char** aResult);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncDestroyObject(IntPtr aHandle, char* aObjectID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginDestroyObject(IntPtr aHandle, char* aObjectID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndDestroyObject(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncUpdateObject(IntPtr aHandle, char* aObjectID, char* aCurrentTagValue, char* aNewTagValue);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginUpdateObject(IntPtr aHandle, char* aObjectID, char* aCurrentTagValue, char* aNewTagValue, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndUpdateObject(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncMoveObject(IntPtr aHandle, char* aObjectID, char* aNewParentID, char** aNewObjectID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginMoveObject(IntPtr aHandle, char* aObjectID, char* aNewParentID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndMoveObject(IntPtr aHandle, IntPtr aAsync, char** aNewObjectID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncImportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginImportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndImportResource(IntPtr aHandle, IntPtr aAsync, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncExportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginExportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndExportResource(IntPtr aHandle, IntPtr aAsync, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncDeleteResource(IntPtr aHandle, char* aResourceURI);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginDeleteResource(IntPtr aHandle, char* aResourceURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndDeleteResource(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncStopTransferResource(IntPtr aHandle, uint aTransferID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginStopTransferResource(IntPtr aHandle, uint aTransferID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndStopTransferResource(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetTransferProgress(IntPtr aHandle, uint aTransferID, char** aTransferStatus, char** aTransferLength, char** aTransferTotal);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetTransferProgress(IntPtr aHandle, uint aTransferID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetTransferProgress(IntPtr aHandle, IntPtr aAsync, char** aTransferStatus, char** aTransferLength, char** aTransferTotal);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncCreateReference(IntPtr aHandle, char* aContainerID, char* aObjectID, char** aNewID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginCreateReference(IntPtr aHandle, char* aContainerID, char* aObjectID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndCreateReference(IntPtr aHandle, IntPtr aAsync, char** aNewID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncFreeFormQuery(IntPtr aHandle, char* aContainerID, uint aCDSView, char* aQueryRequest, char** aQueryResult, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginFreeFormQuery(IntPtr aHandle, char* aContainerID, uint aCDSView, char* aQueryRequest, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndFreeFormQuery(IntPtr aHandle, IntPtr aAsync, char** aQueryResult, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3SyncGetFreeFormQueryCapabilities(IntPtr aHandle, char** aFFQCapabilities);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3BeginGetFreeFormQueryCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory3EndGetFreeFormQueryCapabilities(IntPtr aHandle, IntPtr aAsync, char** aFFQCapabilities);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern void CpProxyUpnpOrgContentDirectory3SetPropertySystemUpdateIDChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern void CpProxyUpnpOrgContentDirectory3SetPropertyContainerUpdateIDsChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern void CpProxyUpnpOrgContentDirectory3SetPropertyLastChangeChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern void CpProxyUpnpOrgContentDirectory3SetPropertyTransferIDsChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3PropertySystemUpdateID(IntPtr aHandle, uint* aSystemUpdateID);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3PropertyContainerUpdateIDs(IntPtr aHandle, char** aContainerUpdateIDs);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3PropertyLastChange(IntPtr aHandle, char** aLastChange);
        [DllImport("CpUpnpOrgContentDirectory3")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory3PropertyTransferIDs(IntPtr aHandle, char** aTransferIDs);
        [DllImport("ZappUpnp")]
        static extern unsafe void ZappFree(void* aPtr);

        private GCHandle iGch;
        private CallbackPropertyChanged iSystemUpdateIDChanged;
        private CallbackPropertyChanged iContainerUpdateIDsChanged;
        private CallbackPropertyChanged iLastChangeChanged;
        private CallbackPropertyChanged iTransferIDsChanged;
        private Callback iCallbackSystemUpdateIDChanged;
        private Callback iCallbackContainerUpdateIDsChanged;
        private Callback iCallbackLastChangeChanged;
        private Callback iCallbackTransferIDsChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Use CpProxy::[Un]Subscribe() to enable/disable querying of state variable and reporting of their changes.</remarks>
        /// <param name="aDevice">The device to use</param>
        public CpProxyUpnpOrgContentDirectory3(CpDevice aDevice)
        {
            iHandle = CpProxyUpnpOrgContentDirectory3Create(aDevice.Handle());
            iGch = GCHandle.Alloc(this);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aSearchCaps"></param>
        public unsafe void SyncGetSearchCapabilities(out string aSearchCaps)
        {
            char* searchCaps;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetSearchCapabilities(iHandle, &searchCaps);
            }
            aSearchCaps = Marshal.PtrToStringAnsi((IntPtr)searchCaps);
            ZappFree(searchCaps);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetSearchCapabilities().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetSearchCapabilities(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetSearchCapabilities(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aSearchCaps"></param>
        public unsafe void EndGetSearchCapabilities(IntPtr aAsyncHandle, out string aSearchCaps)
        {
            char* searchCaps;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetSearchCapabilities(iHandle, aAsyncHandle, &searchCaps))
                {
                    throw(new ProxyError());
                }
            }
            aSearchCaps = Marshal.PtrToStringAnsi((IntPtr)searchCaps);
            ZappFree(searchCaps);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aSortCaps"></param>
        public unsafe void SyncGetSortCapabilities(out string aSortCaps)
        {
            char* sortCaps;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetSortCapabilities(iHandle, &sortCaps);
            }
            aSortCaps = Marshal.PtrToStringAnsi((IntPtr)sortCaps);
            ZappFree(sortCaps);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetSortCapabilities().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetSortCapabilities(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetSortCapabilities(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aSortCaps"></param>
        public unsafe void EndGetSortCapabilities(IntPtr aAsyncHandle, out string aSortCaps)
        {
            char* sortCaps;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetSortCapabilities(iHandle, aAsyncHandle, &sortCaps))
                {
                    throw(new ProxyError());
                }
            }
            aSortCaps = Marshal.PtrToStringAnsi((IntPtr)sortCaps);
            ZappFree(sortCaps);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aSortExtensionCaps"></param>
        public unsafe void SyncGetSortExtensionCapabilities(out string aSortExtensionCaps)
        {
            char* sortExtensionCaps;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetSortExtensionCapabilities(iHandle, &sortExtensionCaps);
            }
            aSortExtensionCaps = Marshal.PtrToStringAnsi((IntPtr)sortExtensionCaps);
            ZappFree(sortExtensionCaps);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetSortExtensionCapabilities().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetSortExtensionCapabilities(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetSortExtensionCapabilities(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aSortExtensionCaps"></param>
        public unsafe void EndGetSortExtensionCapabilities(IntPtr aAsyncHandle, out string aSortExtensionCaps)
        {
            char* sortExtensionCaps;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetSortExtensionCapabilities(iHandle, aAsyncHandle, &sortExtensionCaps))
                {
                    throw(new ProxyError());
                }
            }
            aSortExtensionCaps = Marshal.PtrToStringAnsi((IntPtr)sortExtensionCaps);
            ZappFree(sortExtensionCaps);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aFeatureList"></param>
        public unsafe void SyncGetFeatureList(out string aFeatureList)
        {
            char* featureList;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetFeatureList(iHandle, &featureList);
            }
            aFeatureList = Marshal.PtrToStringAnsi((IntPtr)featureList);
            ZappFree(featureList);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetFeatureList().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetFeatureList(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetFeatureList(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aFeatureList"></param>
        public unsafe void EndGetFeatureList(IntPtr aAsyncHandle, out string aFeatureList)
        {
            char* featureList;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetFeatureList(iHandle, aAsyncHandle, &featureList))
                {
                    throw(new ProxyError());
                }
            }
            aFeatureList = Marshal.PtrToStringAnsi((IntPtr)featureList);
            ZappFree(featureList);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aId"></param>
        public unsafe void SyncGetSystemUpdateID(out uint aId)
        {
            fixed (uint* id = &aId)
            {
                CpProxyUpnpOrgContentDirectory3SyncGetSystemUpdateID(iHandle, id);
            }
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetSystemUpdateID().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetSystemUpdateID(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetSystemUpdateID(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aId"></param>
        public unsafe void EndGetSystemUpdateID(IntPtr aAsyncHandle, out uint aId)
        {
            fixed (uint* id = &aId)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetSystemUpdateID(iHandle, aAsyncHandle, id))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aResetToken"></param>
        public unsafe void SyncGetServiceResetToken(out string aResetToken)
        {
            char* resetToken;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetServiceResetToken(iHandle, &resetToken);
            }
            aResetToken = Marshal.PtrToStringAnsi((IntPtr)resetToken);
            ZappFree(resetToken);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetServiceResetToken().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetServiceResetToken(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetServiceResetToken(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aResetToken"></param>
        public unsafe void EndGetServiceResetToken(IntPtr aAsyncHandle, out string aResetToken)
        {
            char* resetToken;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetServiceResetToken(iHandle, aAsyncHandle, &resetToken))
                {
                    throw(new ProxyError());
                }
            }
            aResetToken = Marshal.PtrToStringAnsi((IntPtr)resetToken);
            ZappFree(resetToken);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aBrowseFlag"></param>
        /// <param name="aFilter"></param>
        /// <param name="aStartingIndex"></param>
        /// <param name="aRequestedCount"></param>
        /// <param name="aSortCriteria"></param>
        /// <param name="aResult"></param>
        /// <param name="aNumberReturned"></param>
        /// <param name="aTotalMatches"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void SyncBrowse(string aObjectID, string aBrowseFlag, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* browseFlag = (char*)Marshal.StringToHGlobalAnsi(aBrowseFlag);
            char* filter = (char*)Marshal.StringToHGlobalAnsi(aFilter);
            char* sortCriteria = (char*)Marshal.StringToHGlobalAnsi(aSortCriteria);
            char* result;
            fixed (uint* numberReturned = &aNumberReturned)
            fixed (uint* totalMatches = &aTotalMatches)
            fixed (uint* updateID = &aUpdateID)
            {
                CpProxyUpnpOrgContentDirectory3SyncBrowse(iHandle, objectID, browseFlag, filter, aStartingIndex, aRequestedCount, sortCriteria, &result, numberReturned, totalMatches, updateID);
            }
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)browseFlag);
            Marshal.FreeHGlobal((IntPtr)filter);
            Marshal.FreeHGlobal((IntPtr)sortCriteria);
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndBrowse().</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aBrowseFlag"></param>
        /// <param name="aFilter"></param>
        /// <param name="aStartingIndex"></param>
        /// <param name="aRequestedCount"></param>
        /// <param name="aSortCriteria"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginBrowse(string aObjectID, string aBrowseFlag, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, CallbackAsyncComplete aCallback)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* browseFlag = (char*)Marshal.StringToHGlobalAnsi(aBrowseFlag);
            char* filter = (char*)Marshal.StringToHGlobalAnsi(aFilter);
            char* sortCriteria = (char*)Marshal.StringToHGlobalAnsi(aSortCriteria);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginBrowse(iHandle, objectID, browseFlag, filter, aStartingIndex, aRequestedCount, sortCriteria, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)browseFlag);
            Marshal.FreeHGlobal((IntPtr)filter);
            Marshal.FreeHGlobal((IntPtr)sortCriteria);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aResult"></param>
        /// <param name="aNumberReturned"></param>
        /// <param name="aTotalMatches"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void EndBrowse(IntPtr aAsyncHandle, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID)
        {
            char* result;
            fixed (uint* numberReturned = &aNumberReturned)
            fixed (uint* totalMatches = &aTotalMatches)
            fixed (uint* updateID = &aUpdateID)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndBrowse(iHandle, aAsyncHandle, &result, numberReturned, totalMatches, updateID))
                {
                    throw(new ProxyError());
                }
            }
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aSearchCriteria"></param>
        /// <param name="aFilter"></param>
        /// <param name="aStartingIndex"></param>
        /// <param name="aRequestedCount"></param>
        /// <param name="aSortCriteria"></param>
        /// <param name="aResult"></param>
        /// <param name="aNumberReturned"></param>
        /// <param name="aTotalMatches"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void SyncSearch(string aContainerID, string aSearchCriteria, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* searchCriteria = (char*)Marshal.StringToHGlobalAnsi(aSearchCriteria);
            char* filter = (char*)Marshal.StringToHGlobalAnsi(aFilter);
            char* sortCriteria = (char*)Marshal.StringToHGlobalAnsi(aSortCriteria);
            char* result;
            fixed (uint* numberReturned = &aNumberReturned)
            fixed (uint* totalMatches = &aTotalMatches)
            fixed (uint* updateID = &aUpdateID)
            {
                CpProxyUpnpOrgContentDirectory3SyncSearch(iHandle, containerID, searchCriteria, filter, aStartingIndex, aRequestedCount, sortCriteria, &result, numberReturned, totalMatches, updateID);
            }
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)searchCriteria);
            Marshal.FreeHGlobal((IntPtr)filter);
            Marshal.FreeHGlobal((IntPtr)sortCriteria);
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndSearch().</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aSearchCriteria"></param>
        /// <param name="aFilter"></param>
        /// <param name="aStartingIndex"></param>
        /// <param name="aRequestedCount"></param>
        /// <param name="aSortCriteria"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginSearch(string aContainerID, string aSearchCriteria, string aFilter, uint aStartingIndex, uint aRequestedCount, string aSortCriteria, CallbackAsyncComplete aCallback)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* searchCriteria = (char*)Marshal.StringToHGlobalAnsi(aSearchCriteria);
            char* filter = (char*)Marshal.StringToHGlobalAnsi(aFilter);
            char* sortCriteria = (char*)Marshal.StringToHGlobalAnsi(aSortCriteria);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginSearch(iHandle, containerID, searchCriteria, filter, aStartingIndex, aRequestedCount, sortCriteria, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)searchCriteria);
            Marshal.FreeHGlobal((IntPtr)filter);
            Marshal.FreeHGlobal((IntPtr)sortCriteria);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aResult"></param>
        /// <param name="aNumberReturned"></param>
        /// <param name="aTotalMatches"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void EndSearch(IntPtr aAsyncHandle, out string aResult, out uint aNumberReturned, out uint aTotalMatches, out uint aUpdateID)
        {
            char* result;
            fixed (uint* numberReturned = &aNumberReturned)
            fixed (uint* totalMatches = &aTotalMatches)
            fixed (uint* updateID = &aUpdateID)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndSearch(iHandle, aAsyncHandle, &result, numberReturned, totalMatches, updateID))
                {
                    throw(new ProxyError());
                }
            }
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aElements"></param>
        /// <param name="aObjectID"></param>
        /// <param name="aResult"></param>
        public unsafe void SyncCreateObject(string aContainerID, string aElements, out string aObjectID, out string aResult)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* elements = (char*)Marshal.StringToHGlobalAnsi(aElements);
            char* objectID;
            char* result;
            {
                CpProxyUpnpOrgContentDirectory3SyncCreateObject(iHandle, containerID, elements, &objectID, &result);
            }
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)elements);
            aObjectID = Marshal.PtrToStringAnsi((IntPtr)objectID);
            ZappFree(objectID);
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndCreateObject().</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aElements"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginCreateObject(string aContainerID, string aElements, CallbackAsyncComplete aCallback)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* elements = (char*)Marshal.StringToHGlobalAnsi(aElements);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginCreateObject(iHandle, containerID, elements, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)elements);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aObjectID"></param>
        /// <param name="aResult"></param>
        public unsafe void EndCreateObject(IntPtr aAsyncHandle, out string aObjectID, out string aResult)
        {
            char* objectID;
            char* result;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndCreateObject(iHandle, aAsyncHandle, &objectID, &result))
                {
                    throw(new ProxyError());
                }
            }
            aObjectID = Marshal.PtrToStringAnsi((IntPtr)objectID);
            ZappFree(objectID);
            aResult = Marshal.PtrToStringAnsi((IntPtr)result);
            ZappFree(result);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aObjectID"></param>
        public unsafe void SyncDestroyObject(string aObjectID)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            {
                CpProxyUpnpOrgContentDirectory3SyncDestroyObject(iHandle, objectID);
            }
            Marshal.FreeHGlobal((IntPtr)objectID);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndDestroyObject().</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginDestroyObject(string aObjectID, CallbackAsyncComplete aCallback)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginDestroyObject(iHandle, objectID, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)objectID);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        public unsafe void EndDestroyObject(IntPtr aAsyncHandle)
        {
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndDestroyObject(iHandle, aAsyncHandle))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aCurrentTagValue"></param>
        /// <param name="aNewTagValue"></param>
        public unsafe void SyncUpdateObject(string aObjectID, string aCurrentTagValue, string aNewTagValue)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* currentTagValue = (char*)Marshal.StringToHGlobalAnsi(aCurrentTagValue);
            char* newTagValue = (char*)Marshal.StringToHGlobalAnsi(aNewTagValue);
            {
                CpProxyUpnpOrgContentDirectory3SyncUpdateObject(iHandle, objectID, currentTagValue, newTagValue);
            }
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)currentTagValue);
            Marshal.FreeHGlobal((IntPtr)newTagValue);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndUpdateObject().</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aCurrentTagValue"></param>
        /// <param name="aNewTagValue"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginUpdateObject(string aObjectID, string aCurrentTagValue, string aNewTagValue, CallbackAsyncComplete aCallback)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* currentTagValue = (char*)Marshal.StringToHGlobalAnsi(aCurrentTagValue);
            char* newTagValue = (char*)Marshal.StringToHGlobalAnsi(aNewTagValue);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginUpdateObject(iHandle, objectID, currentTagValue, newTagValue, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)currentTagValue);
            Marshal.FreeHGlobal((IntPtr)newTagValue);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        public unsafe void EndUpdateObject(IntPtr aAsyncHandle)
        {
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndUpdateObject(iHandle, aAsyncHandle))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aNewParentID"></param>
        /// <param name="aNewObjectID"></param>
        public unsafe void SyncMoveObject(string aObjectID, string aNewParentID, out string aNewObjectID)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* newParentID = (char*)Marshal.StringToHGlobalAnsi(aNewParentID);
            char* newObjectID;
            {
                CpProxyUpnpOrgContentDirectory3SyncMoveObject(iHandle, objectID, newParentID, &newObjectID);
            }
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)newParentID);
            aNewObjectID = Marshal.PtrToStringAnsi((IntPtr)newObjectID);
            ZappFree(newObjectID);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndMoveObject().</remarks>
        /// <param name="aObjectID"></param>
        /// <param name="aNewParentID"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginMoveObject(string aObjectID, string aNewParentID, CallbackAsyncComplete aCallback)
        {
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* newParentID = (char*)Marshal.StringToHGlobalAnsi(aNewParentID);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginMoveObject(iHandle, objectID, newParentID, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)objectID);
            Marshal.FreeHGlobal((IntPtr)newParentID);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aNewObjectID"></param>
        public unsafe void EndMoveObject(IntPtr aAsyncHandle, out string aNewObjectID)
        {
            char* newObjectID;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndMoveObject(iHandle, aAsyncHandle, &newObjectID))
                {
                    throw(new ProxyError());
                }
            }
            aNewObjectID = Marshal.PtrToStringAnsi((IntPtr)newObjectID);
            ZappFree(newObjectID);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aSourceURI"></param>
        /// <param name="aDestinationURI"></param>
        /// <param name="aTransferID"></param>
        public unsafe void SyncImportResource(string aSourceURI, string aDestinationURI, out uint aTransferID)
        {
            char* sourceURI = (char*)Marshal.StringToHGlobalAnsi(aSourceURI);
            char* destinationURI = (char*)Marshal.StringToHGlobalAnsi(aDestinationURI);
            fixed (uint* transferID = &aTransferID)
            {
                CpProxyUpnpOrgContentDirectory3SyncImportResource(iHandle, sourceURI, destinationURI, transferID);
            }
            Marshal.FreeHGlobal((IntPtr)sourceURI);
            Marshal.FreeHGlobal((IntPtr)destinationURI);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndImportResource().</remarks>
        /// <param name="aSourceURI"></param>
        /// <param name="aDestinationURI"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginImportResource(string aSourceURI, string aDestinationURI, CallbackAsyncComplete aCallback)
        {
            char* sourceURI = (char*)Marshal.StringToHGlobalAnsi(aSourceURI);
            char* destinationURI = (char*)Marshal.StringToHGlobalAnsi(aDestinationURI);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginImportResource(iHandle, sourceURI, destinationURI, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)sourceURI);
            Marshal.FreeHGlobal((IntPtr)destinationURI);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aTransferID"></param>
        public unsafe void EndImportResource(IntPtr aAsyncHandle, out uint aTransferID)
        {
            fixed (uint* transferID = &aTransferID)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndImportResource(iHandle, aAsyncHandle, transferID))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aSourceURI"></param>
        /// <param name="aDestinationURI"></param>
        /// <param name="aTransferID"></param>
        public unsafe void SyncExportResource(string aSourceURI, string aDestinationURI, out uint aTransferID)
        {
            char* sourceURI = (char*)Marshal.StringToHGlobalAnsi(aSourceURI);
            char* destinationURI = (char*)Marshal.StringToHGlobalAnsi(aDestinationURI);
            fixed (uint* transferID = &aTransferID)
            {
                CpProxyUpnpOrgContentDirectory3SyncExportResource(iHandle, sourceURI, destinationURI, transferID);
            }
            Marshal.FreeHGlobal((IntPtr)sourceURI);
            Marshal.FreeHGlobal((IntPtr)destinationURI);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndExportResource().</remarks>
        /// <param name="aSourceURI"></param>
        /// <param name="aDestinationURI"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginExportResource(string aSourceURI, string aDestinationURI, CallbackAsyncComplete aCallback)
        {
            char* sourceURI = (char*)Marshal.StringToHGlobalAnsi(aSourceURI);
            char* destinationURI = (char*)Marshal.StringToHGlobalAnsi(aDestinationURI);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginExportResource(iHandle, sourceURI, destinationURI, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)sourceURI);
            Marshal.FreeHGlobal((IntPtr)destinationURI);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aTransferID"></param>
        public unsafe void EndExportResource(IntPtr aAsyncHandle, out uint aTransferID)
        {
            fixed (uint* transferID = &aTransferID)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndExportResource(iHandle, aAsyncHandle, transferID))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aResourceURI"></param>
        public unsafe void SyncDeleteResource(string aResourceURI)
        {
            char* resourceURI = (char*)Marshal.StringToHGlobalAnsi(aResourceURI);
            {
                CpProxyUpnpOrgContentDirectory3SyncDeleteResource(iHandle, resourceURI);
            }
            Marshal.FreeHGlobal((IntPtr)resourceURI);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndDeleteResource().</remarks>
        /// <param name="aResourceURI"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginDeleteResource(string aResourceURI, CallbackAsyncComplete aCallback)
        {
            char* resourceURI = (char*)Marshal.StringToHGlobalAnsi(aResourceURI);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginDeleteResource(iHandle, resourceURI, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)resourceURI);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        public unsafe void EndDeleteResource(IntPtr aAsyncHandle)
        {
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndDeleteResource(iHandle, aAsyncHandle))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aTransferID"></param>
        public unsafe void SyncStopTransferResource(uint aTransferID)
        {
            {
                CpProxyUpnpOrgContentDirectory3SyncStopTransferResource(iHandle, aTransferID);
            }
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndStopTransferResource().</remarks>
        /// <param name="aTransferID"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginStopTransferResource(uint aTransferID, CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginStopTransferResource(iHandle, aTransferID, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        public unsafe void EndStopTransferResource(IntPtr aAsyncHandle)
        {
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndStopTransferResource(iHandle, aAsyncHandle))
                {
                    throw(new ProxyError());
                }
            }
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aTransferID"></param>
        /// <param name="aTransferStatus"></param>
        /// <param name="aTransferLength"></param>
        /// <param name="aTransferTotal"></param>
        public unsafe void SyncGetTransferProgress(uint aTransferID, out string aTransferStatus, out string aTransferLength, out string aTransferTotal)
        {
            char* transferStatus;
            char* transferLength;
            char* transferTotal;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetTransferProgress(iHandle, aTransferID, &transferStatus, &transferLength, &transferTotal);
            }
            aTransferStatus = Marshal.PtrToStringAnsi((IntPtr)transferStatus);
            ZappFree(transferStatus);
            aTransferLength = Marshal.PtrToStringAnsi((IntPtr)transferLength);
            ZappFree(transferLength);
            aTransferTotal = Marshal.PtrToStringAnsi((IntPtr)transferTotal);
            ZappFree(transferTotal);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetTransferProgress().</remarks>
        /// <param name="aTransferID"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetTransferProgress(uint aTransferID, CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetTransferProgress(iHandle, aTransferID, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aTransferStatus"></param>
        /// <param name="aTransferLength"></param>
        /// <param name="aTransferTotal"></param>
        public unsafe void EndGetTransferProgress(IntPtr aAsyncHandle, out string aTransferStatus, out string aTransferLength, out string aTransferTotal)
        {
            char* transferStatus;
            char* transferLength;
            char* transferTotal;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetTransferProgress(iHandle, aAsyncHandle, &transferStatus, &transferLength, &transferTotal))
                {
                    throw(new ProxyError());
                }
            }
            aTransferStatus = Marshal.PtrToStringAnsi((IntPtr)transferStatus);
            ZappFree(transferStatus);
            aTransferLength = Marshal.PtrToStringAnsi((IntPtr)transferLength);
            ZappFree(transferLength);
            aTransferTotal = Marshal.PtrToStringAnsi((IntPtr)transferTotal);
            ZappFree(transferTotal);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aObjectID"></param>
        /// <param name="aNewID"></param>
        public unsafe void SyncCreateReference(string aContainerID, string aObjectID, out string aNewID)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* newID;
            {
                CpProxyUpnpOrgContentDirectory3SyncCreateReference(iHandle, containerID, objectID, &newID);
            }
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)objectID);
            aNewID = Marshal.PtrToStringAnsi((IntPtr)newID);
            ZappFree(newID);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndCreateReference().</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aObjectID"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginCreateReference(string aContainerID, string aObjectID, CallbackAsyncComplete aCallback)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginCreateReference(iHandle, containerID, objectID, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)objectID);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aNewID"></param>
        public unsafe void EndCreateReference(IntPtr aAsyncHandle, out string aNewID)
        {
            char* newID;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndCreateReference(iHandle, aAsyncHandle, &newID))
                {
                    throw(new ProxyError());
                }
            }
            aNewID = Marshal.PtrToStringAnsi((IntPtr)newID);
            ZappFree(newID);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aCDSView"></param>
        /// <param name="aQueryRequest"></param>
        /// <param name="aQueryResult"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void SyncFreeFormQuery(string aContainerID, uint aCDSView, string aQueryRequest, out string aQueryResult, out uint aUpdateID)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* queryRequest = (char*)Marshal.StringToHGlobalAnsi(aQueryRequest);
            char* queryResult;
            fixed (uint* updateID = &aUpdateID)
            {
                CpProxyUpnpOrgContentDirectory3SyncFreeFormQuery(iHandle, containerID, aCDSView, queryRequest, &queryResult, updateID);
            }
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)queryRequest);
            aQueryResult = Marshal.PtrToStringAnsi((IntPtr)queryResult);
            ZappFree(queryResult);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndFreeFormQuery().</remarks>
        /// <param name="aContainerID"></param>
        /// <param name="aCDSView"></param>
        /// <param name="aQueryRequest"></param>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginFreeFormQuery(string aContainerID, uint aCDSView, string aQueryRequest, CallbackAsyncComplete aCallback)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* queryRequest = (char*)Marshal.StringToHGlobalAnsi(aQueryRequest);
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginFreeFormQuery(iHandle, containerID, aCDSView, queryRequest, iActionComplete, ptr);
            Marshal.FreeHGlobal((IntPtr)containerID);
            Marshal.FreeHGlobal((IntPtr)queryRequest);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aQueryResult"></param>
        /// <param name="aUpdateID"></param>
        public unsafe void EndFreeFormQuery(IntPtr aAsyncHandle, out string aQueryResult, out uint aUpdateID)
        {
            char* queryResult;
            fixed (uint* updateID = &aUpdateID)
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndFreeFormQuery(iHandle, aAsyncHandle, &queryResult, updateID))
                {
                    throw(new ProxyError());
                }
            }
            aQueryResult = Marshal.PtrToStringAnsi((IntPtr)queryResult);
            ZappFree(queryResult);
        }

        /// <summary>
        /// Invoke the action synchronously
        /// </summary>
        /// <remarks>Blocks until the action has been processed
        /// on the device and sets any output arguments</remarks>
        /// <param name="aFFQCapabilities"></param>
        public unsafe void SyncGetFreeFormQueryCapabilities(out string aFFQCapabilities)
        {
            char* fFQCapabilities;
            {
                CpProxyUpnpOrgContentDirectory3SyncGetFreeFormQueryCapabilities(iHandle, &fFQCapabilities);
            }
            aFFQCapabilities = Marshal.PtrToStringAnsi((IntPtr)fFQCapabilities);
            ZappFree(fFQCapabilities);
        }

        /// <summary>
        /// Invoke the action asynchronously
        /// </summary>
        /// <remarks>Returns immediately and will run the client-specified callback when the action
        /// later completes.  Any output arguments can then be retrieved by calling
        /// EndGetFreeFormQueryCapabilities().</remarks>
        /// <param name="aCallback">Delegate to run when the action completes.
        /// This is guaranteed to be run but may indicate an error</param>
        public unsafe void BeginGetFreeFormQueryCapabilities(CallbackAsyncComplete aCallback)
        {
            GCHandle gch = GCHandle.Alloc(aCallback);
            IntPtr ptr = GCHandle.ToIntPtr(gch);
            CpProxyUpnpOrgContentDirectory3BeginGetFreeFormQueryCapabilities(iHandle, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        /// <param name="aFFQCapabilities"></param>
        public unsafe void EndGetFreeFormQueryCapabilities(IntPtr aAsyncHandle, out string aFFQCapabilities)
        {
            char* fFQCapabilities;
            {
                if (0 != CpProxyUpnpOrgContentDirectory3EndGetFreeFormQueryCapabilities(iHandle, aAsyncHandle, &fFQCapabilities))
                {
                    throw(new ProxyError());
                }
            }
            aFFQCapabilities = Marshal.PtrToStringAnsi((IntPtr)fFQCapabilities);
            ZappFree(fFQCapabilities);
        }

        /// <summary>
        /// Set a delegate to be run when the SystemUpdateID state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory3 instance will not overlap.</remarks>
        /// <param name="aSystemUpdateIDChanged">The delegate to run when the state variable changes</param>
        public void SetPropertySystemUpdateIDChanged(CallbackPropertyChanged aSystemUpdateIDChanged)
        {
            iSystemUpdateIDChanged = aSystemUpdateIDChanged;
            iCallbackSystemUpdateIDChanged = new Callback(PropertySystemUpdateIDChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory3SetPropertySystemUpdateIDChanged(iHandle, iCallbackSystemUpdateIDChanged, ptr);
        }

        private void PropertySystemUpdateIDChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory3 self = (CpProxyUpnpOrgContentDirectory3)gch.Target;
            self.iSystemUpdateIDChanged();
        }

        /// <summary>
        /// Set a delegate to be run when the ContainerUpdateIDs state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory3 instance will not overlap.</remarks>
        /// <param name="aContainerUpdateIDsChanged">The delegate to run when the state variable changes</param>
        public void SetPropertyContainerUpdateIDsChanged(CallbackPropertyChanged aContainerUpdateIDsChanged)
        {
            iContainerUpdateIDsChanged = aContainerUpdateIDsChanged;
            iCallbackContainerUpdateIDsChanged = new Callback(PropertyContainerUpdateIDsChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory3SetPropertyContainerUpdateIDsChanged(iHandle, iCallbackContainerUpdateIDsChanged, ptr);
        }

        private void PropertyContainerUpdateIDsChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory3 self = (CpProxyUpnpOrgContentDirectory3)gch.Target;
            self.iContainerUpdateIDsChanged();
        }

        /// <summary>
        /// Set a delegate to be run when the LastChange state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory3 instance will not overlap.</remarks>
        /// <param name="aLastChangeChanged">The delegate to run when the state variable changes</param>
        public void SetPropertyLastChangeChanged(CallbackPropertyChanged aLastChangeChanged)
        {
            iLastChangeChanged = aLastChangeChanged;
            iCallbackLastChangeChanged = new Callback(PropertyLastChangeChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory3SetPropertyLastChangeChanged(iHandle, iCallbackLastChangeChanged, ptr);
        }

        private void PropertyLastChangeChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory3 self = (CpProxyUpnpOrgContentDirectory3)gch.Target;
            self.iLastChangeChanged();
        }

        /// <summary>
        /// Set a delegate to be run when the TransferIDs state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory3 instance will not overlap.</remarks>
        /// <param name="aTransferIDsChanged">The delegate to run when the state variable changes</param>
        public void SetPropertyTransferIDsChanged(CallbackPropertyChanged aTransferIDsChanged)
        {
            iTransferIDsChanged = aTransferIDsChanged;
            iCallbackTransferIDsChanged = new Callback(PropertyTransferIDsChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory3SetPropertyTransferIDsChanged(iHandle, iCallbackTransferIDsChanged, ptr);
        }

        private void PropertyTransferIDsChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory3 self = (CpProxyUpnpOrgContentDirectory3)gch.Target;
            self.iTransferIDsChanged();
        }

        /// <summary>
        /// Query the value of the SystemUpdateID property.
        /// </summary>
        /// <remarks>This function is threadsafe and can only be called if Subscribe() has been
        /// called and a first eventing callback received more recently than any call
        /// to Unsubscribe().</remarks>
        /// <param name="aSystemUpdateID">Will be set to the value of the property</param>
        public unsafe void PropertySystemUpdateID(out uint aSystemUpdateID)
        {
            fixed (uint* systemUpdateID = &aSystemUpdateID)
            {
                CpProxyUpnpOrgContentDirectory3PropertySystemUpdateID(iHandle, systemUpdateID);
            }
        }

        /// <summary>
        /// Query the value of the ContainerUpdateIDs property.
        /// </summary>
        /// <remarks>This function is threadsafe and can only be called if Subscribe() has been
        /// called and a first eventing callback received more recently than any call
        /// to Unsubscribe().</remarks>
        /// <param name="aContainerUpdateIDs">Will be set to the value of the property</param>
        public unsafe void PropertyContainerUpdateIDs(out string aContainerUpdateIDs)
        {
            char* ptr;
            CpProxyUpnpOrgContentDirectory3PropertyContainerUpdateIDs(iHandle, &ptr);
            aContainerUpdateIDs = Marshal.PtrToStringAnsi((IntPtr)ptr);
            ZappFree(ptr);
        }

        /// <summary>
        /// Query the value of the LastChange property.
        /// </summary>
        /// <remarks>This function is threadsafe and can only be called if Subscribe() has been
        /// called and a first eventing callback received more recently than any call
        /// to Unsubscribe().</remarks>
        /// <param name="aLastChange">Will be set to the value of the property</param>
        public unsafe void PropertyLastChange(out string aLastChange)
        {
            char* ptr;
            CpProxyUpnpOrgContentDirectory3PropertyLastChange(iHandle, &ptr);
            aLastChange = Marshal.PtrToStringAnsi((IntPtr)ptr);
            ZappFree(ptr);
        }

        /// <summary>
        /// Query the value of the TransferIDs property.
        /// </summary>
        /// <remarks>This function is threadsafe and can only be called if Subscribe() has been
        /// called and a first eventing callback received more recently than any call
        /// to Unsubscribe().</remarks>
        /// <param name="aTransferIDs">Will be set to the value of the property</param>
        public unsafe void PropertyTransferIDs(out string aTransferIDs)
        {
            char* ptr;
            CpProxyUpnpOrgContentDirectory3PropertyTransferIDs(iHandle, &ptr);
            aTransferIDs = Marshal.PtrToStringAnsi((IntPtr)ptr);
            ZappFree(ptr);
        }

        /// <summary>
        /// Must be called for each class instance.  Must be called before Core.Library.Close().
        /// </summary>
        public void Dispose()
        {
            DoDispose(true);
        }

        ~CpProxyUpnpOrgContentDirectory3()
        {
            DoDispose(false);
        }

        private void DoDispose(bool aDisposing)
        {
            lock (this)
            {
                if (iHandle == IntPtr.Zero)
                {
                    return;
                }
                CpProxyUpnpOrgContentDirectory3Destroy(iHandle);
                iHandle = IntPtr.Zero;
            }
            iGch.Free();
            if (aDisposing)
            {
                GC.SuppressFinalize(this);
            }
            else
            {
                DisposeProxy();
            }
        }
    }
}

