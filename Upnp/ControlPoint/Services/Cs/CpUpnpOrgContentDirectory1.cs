using System;
using System.Runtime.InteropServices;
using System.Text;
using Zapp;

namespace Zapp.ControlPoint.Proxies
{
    public interface ICpProxyUpnpOrgContentDirectory1 : ICpProxy, IDisposable
    {
        void SyncGetSearchCapabilities(out string aSearchCaps);
        void BeginGetSearchCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSearchCapabilities(IntPtr aAsyncHandle, out string aSearchCaps);
        void SyncGetSortCapabilities(out string aSortCaps);
        void BeginGetSortCapabilities(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSortCapabilities(IntPtr aAsyncHandle, out string aSortCaps);
        void SyncGetSystemUpdateID(out uint aId);
        void BeginGetSystemUpdateID(CpProxy.CallbackAsyncComplete aCallback);
        void EndGetSystemUpdateID(IntPtr aAsyncHandle, out uint aId);
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
        void SyncImportResource(string aSourceURI, string aDestinationURI, out uint aTransferID);
        void BeginImportResource(string aSourceURI, string aDestinationURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndImportResource(IntPtr aAsyncHandle, out uint aTransferID);
        void SyncExportResource(string aSourceURI, string aDestinationURI, out uint aTransferID);
        void BeginExportResource(string aSourceURI, string aDestinationURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndExportResource(IntPtr aAsyncHandle, out uint aTransferID);
        void SyncStopTransferResource(uint aTransferID);
        void BeginStopTransferResource(uint aTransferID, CpProxy.CallbackAsyncComplete aCallback);
        void EndStopTransferResource(IntPtr aAsyncHandle);
        void SyncGetTransferProgress(uint aTransferID, out string aTransferStatus, out string aTransferLength, out string aTransferTotal);
        void BeginGetTransferProgress(uint aTransferID, CpProxy.CallbackAsyncComplete aCallback);
        void EndGetTransferProgress(IntPtr aAsyncHandle, out string aTransferStatus, out string aTransferLength, out string aTransferTotal);
        void SyncDeleteResource(string aResourceURI);
        void BeginDeleteResource(string aResourceURI, CpProxy.CallbackAsyncComplete aCallback);
        void EndDeleteResource(IntPtr aAsyncHandle);
        void SyncCreateReference(string aContainerID, string aObjectID, out string aNewID);
        void BeginCreateReference(string aContainerID, string aObjectID, CpProxy.CallbackAsyncComplete aCallback);
        void EndCreateReference(IntPtr aAsyncHandle, out string aNewID);

        void SetPropertyTransferIDsChanged(CpProxy.CallbackPropertyChanged aTransferIDsChanged);
        void PropertyTransferIDs(out string aTransferIDs);
        void SetPropertySystemUpdateIDChanged(CpProxy.CallbackPropertyChanged aSystemUpdateIDChanged);
        void PropertySystemUpdateID(out uint aSystemUpdateID);
        void SetPropertyContainerUpdateIDsChanged(CpProxy.CallbackPropertyChanged aContainerUpdateIDsChanged);
        void PropertyContainerUpdateIDs(out string aContainerUpdateIDs);
    }

    /// <summary>
    /// Proxy for the upnp.org:ContentDirectory:1 UPnP service
    /// </summary>
    public class CpProxyUpnpOrgContentDirectory1 : CpProxy, IDisposable, ICpProxyUpnpOrgContentDirectory1
    {
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern IntPtr CpProxyUpnpOrgContentDirectory1Create(IntPtr aDeviceHandle);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern void CpProxyUpnpOrgContentDirectory1Destroy(IntPtr aHandle);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncGetSearchCapabilities(IntPtr aHandle, char** aSearchCaps);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginGetSearchCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndGetSearchCapabilities(IntPtr aHandle, IntPtr aAsync, char** aSearchCaps);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncGetSortCapabilities(IntPtr aHandle, char** aSortCaps);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginGetSortCapabilities(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndGetSortCapabilities(IntPtr aHandle, IntPtr aAsync, char** aSortCaps);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncGetSystemUpdateID(IntPtr aHandle, uint* aId);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginGetSystemUpdateID(IntPtr aHandle, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndGetSystemUpdateID(IntPtr aHandle, IntPtr aAsync, uint* aId);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncBrowse(IntPtr aHandle, char* aObjectID, char* aBrowseFlag, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginBrowse(IntPtr aHandle, char* aObjectID, char* aBrowseFlag, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndBrowse(IntPtr aHandle, IntPtr aAsync, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncSearch(IntPtr aHandle, char* aContainerID, char* aSearchCriteria, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginSearch(IntPtr aHandle, char* aContainerID, char* aSearchCriteria, char* aFilter, uint aStartingIndex, uint aRequestedCount, char* aSortCriteria, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndSearch(IntPtr aHandle, IntPtr aAsync, char** aResult, uint* aNumberReturned, uint* aTotalMatches, uint* aUpdateID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncCreateObject(IntPtr aHandle, char* aContainerID, char* aElements, char** aObjectID, char** aResult);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginCreateObject(IntPtr aHandle, char* aContainerID, char* aElements, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndCreateObject(IntPtr aHandle, IntPtr aAsync, char** aObjectID, char** aResult);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncDestroyObject(IntPtr aHandle, char* aObjectID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginDestroyObject(IntPtr aHandle, char* aObjectID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndDestroyObject(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncUpdateObject(IntPtr aHandle, char* aObjectID, char* aCurrentTagValue, char* aNewTagValue);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginUpdateObject(IntPtr aHandle, char* aObjectID, char* aCurrentTagValue, char* aNewTagValue, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndUpdateObject(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncImportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginImportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndImportResource(IntPtr aHandle, IntPtr aAsync, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncExportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginExportResource(IntPtr aHandle, char* aSourceURI, char* aDestinationURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndExportResource(IntPtr aHandle, IntPtr aAsync, uint* aTransferID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncStopTransferResource(IntPtr aHandle, uint aTransferID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginStopTransferResource(IntPtr aHandle, uint aTransferID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndStopTransferResource(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncGetTransferProgress(IntPtr aHandle, uint aTransferID, char** aTransferStatus, char** aTransferLength, char** aTransferTotal);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginGetTransferProgress(IntPtr aHandle, uint aTransferID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndGetTransferProgress(IntPtr aHandle, IntPtr aAsync, char** aTransferStatus, char** aTransferLength, char** aTransferTotal);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncDeleteResource(IntPtr aHandle, char* aResourceURI);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginDeleteResource(IntPtr aHandle, char* aResourceURI, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndDeleteResource(IntPtr aHandle, IntPtr aAsync);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1SyncCreateReference(IntPtr aHandle, char* aContainerID, char* aObjectID, char** aNewID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1BeginCreateReference(IntPtr aHandle, char* aContainerID, char* aObjectID, CallbackActionComplete aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe int CpProxyUpnpOrgContentDirectory1EndCreateReference(IntPtr aHandle, IntPtr aAsync, char** aNewID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern void CpProxyUpnpOrgContentDirectory1SetPropertyTransferIDsChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern void CpProxyUpnpOrgContentDirectory1SetPropertySystemUpdateIDChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern void CpProxyUpnpOrgContentDirectory1SetPropertyContainerUpdateIDsChanged(IntPtr aHandle, Callback aCallback, IntPtr aPtr);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1PropertyTransferIDs(IntPtr aHandle, char** aTransferIDs);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1PropertySystemUpdateID(IntPtr aHandle, uint* aSystemUpdateID);
        [DllImport("CpUpnpOrgContentDirectory1")]
        static extern unsafe void CpProxyUpnpOrgContentDirectory1PropertyContainerUpdateIDs(IntPtr aHandle, char** aContainerUpdateIDs);
        [DllImport("ZappUpnp")]
        static extern unsafe void ZappFree(void* aPtr);

        private GCHandle iGch;
        private CallbackPropertyChanged iTransferIDsChanged;
        private CallbackPropertyChanged iSystemUpdateIDChanged;
        private CallbackPropertyChanged iContainerUpdateIDsChanged;
        private Callback iCallbackTransferIDsChanged;
        private Callback iCallbackSystemUpdateIDChanged;
        private Callback iCallbackContainerUpdateIDsChanged;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks>Use CpProxy::[Un]Subscribe() to enable/disable querying of state variable and reporting of their changes.</remarks>
        /// <param name="aDevice">The device to use</param>
        public CpProxyUpnpOrgContentDirectory1(CpDevice aDevice)
        {
            iHandle = CpProxyUpnpOrgContentDirectory1Create(aDevice.Handle());
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
                CpProxyUpnpOrgContentDirectory1SyncGetSearchCapabilities(iHandle, &searchCaps);
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
            CpProxyUpnpOrgContentDirectory1BeginGetSearchCapabilities(iHandle, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndGetSearchCapabilities(iHandle, aAsyncHandle, &searchCaps))
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
                CpProxyUpnpOrgContentDirectory1SyncGetSortCapabilities(iHandle, &sortCaps);
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
            CpProxyUpnpOrgContentDirectory1BeginGetSortCapabilities(iHandle, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndGetSortCapabilities(iHandle, aAsyncHandle, &sortCaps))
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
        /// <param name="aId"></param>
        public unsafe void SyncGetSystemUpdateID(out uint aId)
        {
            fixed (uint* id = &aId)
            {
                CpProxyUpnpOrgContentDirectory1SyncGetSystemUpdateID(iHandle, id);
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
            CpProxyUpnpOrgContentDirectory1BeginGetSystemUpdateID(iHandle, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndGetSystemUpdateID(iHandle, aAsyncHandle, id))
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
                CpProxyUpnpOrgContentDirectory1SyncBrowse(iHandle, objectID, browseFlag, filter, aStartingIndex, aRequestedCount, sortCriteria, &result, numberReturned, totalMatches, updateID);
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
            CpProxyUpnpOrgContentDirectory1BeginBrowse(iHandle, objectID, browseFlag, filter, aStartingIndex, aRequestedCount, sortCriteria, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndBrowse(iHandle, aAsyncHandle, &result, numberReturned, totalMatches, updateID))
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
                CpProxyUpnpOrgContentDirectory1SyncSearch(iHandle, containerID, searchCriteria, filter, aStartingIndex, aRequestedCount, sortCriteria, &result, numberReturned, totalMatches, updateID);
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
            CpProxyUpnpOrgContentDirectory1BeginSearch(iHandle, containerID, searchCriteria, filter, aStartingIndex, aRequestedCount, sortCriteria, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndSearch(iHandle, aAsyncHandle, &result, numberReturned, totalMatches, updateID))
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
                CpProxyUpnpOrgContentDirectory1SyncCreateObject(iHandle, containerID, elements, &objectID, &result);
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
            CpProxyUpnpOrgContentDirectory1BeginCreateObject(iHandle, containerID, elements, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndCreateObject(iHandle, aAsyncHandle, &objectID, &result))
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
                CpProxyUpnpOrgContentDirectory1SyncDestroyObject(iHandle, objectID);
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
            CpProxyUpnpOrgContentDirectory1BeginDestroyObject(iHandle, objectID, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndDestroyObject(iHandle, aAsyncHandle))
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
                CpProxyUpnpOrgContentDirectory1SyncUpdateObject(iHandle, objectID, currentTagValue, newTagValue);
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
            CpProxyUpnpOrgContentDirectory1BeginUpdateObject(iHandle, objectID, currentTagValue, newTagValue, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndUpdateObject(iHandle, aAsyncHandle))
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
        public unsafe void SyncImportResource(string aSourceURI, string aDestinationURI, out uint aTransferID)
        {
            char* sourceURI = (char*)Marshal.StringToHGlobalAnsi(aSourceURI);
            char* destinationURI = (char*)Marshal.StringToHGlobalAnsi(aDestinationURI);
            fixed (uint* transferID = &aTransferID)
            {
                CpProxyUpnpOrgContentDirectory1SyncImportResource(iHandle, sourceURI, destinationURI, transferID);
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
            CpProxyUpnpOrgContentDirectory1BeginImportResource(iHandle, sourceURI, destinationURI, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndImportResource(iHandle, aAsyncHandle, transferID))
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
                CpProxyUpnpOrgContentDirectory1SyncExportResource(iHandle, sourceURI, destinationURI, transferID);
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
            CpProxyUpnpOrgContentDirectory1BeginExportResource(iHandle, sourceURI, destinationURI, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndExportResource(iHandle, aAsyncHandle, transferID))
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
                CpProxyUpnpOrgContentDirectory1SyncStopTransferResource(iHandle, aTransferID);
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
            CpProxyUpnpOrgContentDirectory1BeginStopTransferResource(iHandle, aTransferID, iActionComplete, ptr);
        }

        /// <summary>
        /// Retrieve the output arguments from an asynchronously invoked action.
        /// </summary>
        /// <remarks>This may only be called from the callback set in the above Begin function.</remarks>
        /// <param name="aAsyncHandle">Argument passed to the delegate set in the above Begin function</param>
        public unsafe void EndStopTransferResource(IntPtr aAsyncHandle)
        {
            {
                if (0 != CpProxyUpnpOrgContentDirectory1EndStopTransferResource(iHandle, aAsyncHandle))
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
                CpProxyUpnpOrgContentDirectory1SyncGetTransferProgress(iHandle, aTransferID, &transferStatus, &transferLength, &transferTotal);
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
            CpProxyUpnpOrgContentDirectory1BeginGetTransferProgress(iHandle, aTransferID, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndGetTransferProgress(iHandle, aAsyncHandle, &transferStatus, &transferLength, &transferTotal))
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
        /// <param name="aResourceURI"></param>
        public unsafe void SyncDeleteResource(string aResourceURI)
        {
            char* resourceURI = (char*)Marshal.StringToHGlobalAnsi(aResourceURI);
            {
                CpProxyUpnpOrgContentDirectory1SyncDeleteResource(iHandle, resourceURI);
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
            CpProxyUpnpOrgContentDirectory1BeginDeleteResource(iHandle, resourceURI, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndDeleteResource(iHandle, aAsyncHandle))
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
        /// <param name="aContainerID"></param>
        /// <param name="aObjectID"></param>
        /// <param name="aNewID"></param>
        public unsafe void SyncCreateReference(string aContainerID, string aObjectID, out string aNewID)
        {
            char* containerID = (char*)Marshal.StringToHGlobalAnsi(aContainerID);
            char* objectID = (char*)Marshal.StringToHGlobalAnsi(aObjectID);
            char* newID;
            {
                CpProxyUpnpOrgContentDirectory1SyncCreateReference(iHandle, containerID, objectID, &newID);
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
            CpProxyUpnpOrgContentDirectory1BeginCreateReference(iHandle, containerID, objectID, iActionComplete, ptr);
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
                if (0 != CpProxyUpnpOrgContentDirectory1EndCreateReference(iHandle, aAsyncHandle, &newID))
                {
                    throw(new ProxyError());
                }
            }
            aNewID = Marshal.PtrToStringAnsi((IntPtr)newID);
            ZappFree(newID);
        }

        /// <summary>
        /// Set a delegate to be run when the TransferIDs state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory1 instance will not overlap.</remarks>
        /// <param name="aTransferIDsChanged">The delegate to run when the state variable changes</param>
        public void SetPropertyTransferIDsChanged(CallbackPropertyChanged aTransferIDsChanged)
        {
            iTransferIDsChanged = aTransferIDsChanged;
            iCallbackTransferIDsChanged = new Callback(PropertyTransferIDsChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory1SetPropertyTransferIDsChanged(iHandle, iCallbackTransferIDsChanged, ptr);
        }

        private void PropertyTransferIDsChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory1 self = (CpProxyUpnpOrgContentDirectory1)gch.Target;
            self.iTransferIDsChanged();
        }

        /// <summary>
        /// Set a delegate to be run when the SystemUpdateID state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory1 instance will not overlap.</remarks>
        /// <param name="aSystemUpdateIDChanged">The delegate to run when the state variable changes</param>
        public void SetPropertySystemUpdateIDChanged(CallbackPropertyChanged aSystemUpdateIDChanged)
        {
            iSystemUpdateIDChanged = aSystemUpdateIDChanged;
            iCallbackSystemUpdateIDChanged = new Callback(PropertySystemUpdateIDChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory1SetPropertySystemUpdateIDChanged(iHandle, iCallbackSystemUpdateIDChanged, ptr);
        }

        private void PropertySystemUpdateIDChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory1 self = (CpProxyUpnpOrgContentDirectory1)gch.Target;
            self.iSystemUpdateIDChanged();
        }

        /// <summary>
        /// Set a delegate to be run when the ContainerUpdateIDs state variable changes.
        /// </summary>
        /// <remarks>Callbacks may be run in different threads but callbacks for a
        /// CpProxyUpnpOrgContentDirectory1 instance will not overlap.</remarks>
        /// <param name="aContainerUpdateIDsChanged">The delegate to run when the state variable changes</param>
        public void SetPropertyContainerUpdateIDsChanged(CallbackPropertyChanged aContainerUpdateIDsChanged)
        {
            iContainerUpdateIDsChanged = aContainerUpdateIDsChanged;
            iCallbackContainerUpdateIDsChanged = new Callback(PropertyContainerUpdateIDsChanged);
            IntPtr ptr = GCHandle.ToIntPtr(iGch);
            CpProxyUpnpOrgContentDirectory1SetPropertyContainerUpdateIDsChanged(iHandle, iCallbackContainerUpdateIDsChanged, ptr);
        }

        private void PropertyContainerUpdateIDsChanged(IntPtr aPtr)
        {
            GCHandle gch = GCHandle.FromIntPtr(aPtr);
            CpProxyUpnpOrgContentDirectory1 self = (CpProxyUpnpOrgContentDirectory1)gch.Target;
            self.iContainerUpdateIDsChanged();
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
            CpProxyUpnpOrgContentDirectory1PropertyTransferIDs(iHandle, &ptr);
            aTransferIDs = Marshal.PtrToStringAnsi((IntPtr)ptr);
            ZappFree(ptr);
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
                CpProxyUpnpOrgContentDirectory1PropertySystemUpdateID(iHandle, systemUpdateID);
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
            CpProxyUpnpOrgContentDirectory1PropertyContainerUpdateIDs(iHandle, &ptr);
            aContainerUpdateIDs = Marshal.PtrToStringAnsi((IntPtr)ptr);
            ZappFree(ptr);
        }

        /// <summary>
        /// Must be called for each class instance.  Must be called before Core.Library.Close().
        /// </summary>
        public void Dispose()
        {
            DoDispose(true);
        }

        ~CpProxyUpnpOrgContentDirectory1()
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
                CpProxyUpnpOrgContentDirectory1Destroy(iHandle);
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

