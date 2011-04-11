using System;
using System.Runtime.InteropServices;

namespace Zapp.Core
{
    /// <summary>
    /// Initialisation options
    /// </summary>
    /// <remarks>Most options apply equally to Control Point and Device stacks.
    /// Any functions that are specific to a particular stack include either 'Cp' or 'Dv'</remarks>
    public class InitParams
    {
        public delegate void ZappCallback(IntPtr aPtr);
        public delegate void ZappCallbackMsg(IntPtr aPtr, string aMsg);
        public delegate void ZappCallbackAsync(IntPtr aPtr, IntPtr aAsyncHandle);

        public ZappCallbackMsg LogOutput { get; set; }
        /// <summary>
        /// A callback which will be run if the library encounters an error it cannot recover from
        /// </summary>
        /// <remarks>Suggested action if this is called is to exit the process and restart the library and its owning application.
        /// 
        /// The string passed to the callback is an error message so would be useful to log.</remarks>
        public ZappCallbackMsg FatalErrorHandler { get; set; }
        public ZappCallbackAsync AsyncBeginHandler { get; set; }
        public ZappCallbackAsync AsyncEndHandler { get; set; }
        public ZappCallbackAsync AsyncErrorHandler { get; set; }
        public uint DefaultSubnet { get; set; }
        public ZappCallback SubnetChangedListener { get; set; }

        /// <summary>
        /// A timeout for TCP connections in milliseconds. Must be >0
        /// </summary>
        public uint TcpConnectTimeoutMs { get; set; }

        /// <summary>
        /// The time in seconds that msearch responses should be spread out over. Should be between 1 and 5 (inclusive).
        /// </summary>
        public uint MsearchTimeSecs { get; set; }

        /// <summary>
        /// Set the time-to-live value for msearches
        /// </summary>
        public uint MsearchTtl { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to eventing (handling updates
        /// to subscribed state variables).
        /// </summary>
        public uint NumEventSessionThreads { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to fetching device/service XML
        /// </summary>
        /// <remarks>A higher number of threads will allow faster population of device lists but
        /// will also require more system resources</remarks>
        public uint NumXmlFetcherThreads { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to invoking actions on devices
        /// </summary>
        /// <remarks>A higher number of threads will allow faster population of device lists
        /// but will also require more system resources</remarks>
        public uint NumActionInvokerThreads { get; set; }

        /// <summary>
        /// Set the number of invocations (actions) which should be pre-allocated
        /// </summary>
        /// <remarks>If more that this number are pending, the additional attempted invocations
        /// will block until a pre-allocated slot becomes clear.
        /// 
        /// A higher number of invocations will decrease the likelihood and duration of
        /// any UI-level delays but will also increase the peaks in RAM requirements.</remarks>
        public uint NumInvocations { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to (un)subscribing
        /// to state variables on a service + device
        /// </summary>
        /// <remarks>A higher number of threads will allow faster population of device lists
        /// but will also require more system resources</remarks>
        public uint NumSubscriberThreads { get; set; }

        /// <summary>
        /// Set the maximim time in milliseconds to wait before rejecting an event update from
        /// an unknown source
        /// </summary>
        /// <remarks>It is possible for initial information on state variables to arrive before
        /// a subscription is noted as complete.  Waiting a short while before rejecting events
        /// from unknown sources decreases the chances of missing the initial event from a subscription</remarks>
        public uint PendingSubscriptionTimeoutMs { get; set; }

        /// <summary>
        /// Set the maximum time in seconds between device announcements for the device stack
        /// </summary>
        /// <remarks>This value will appear in the maxage header for UPnP advertisements</remarks>
        public uint DvMaxUpdateTimeSecs { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to processing
        /// control/eventing/presentation requests.
        /// </summary>
        /// <remarks>A higher number of threads may allow faster response to multiple clients
        /// making concurrent requests but will also require more system resources.</remarks>
        public uint DvNumServerThreads { get; set; }

        /// <summary>
        /// Set the number of threads which should be dedicated to publishing
        /// changes to state variables on a service + device
        /// </summary>
        /// <remarks>A higher number of threads will allow faster publication of changes
        /// but will also require more system resources</remarks>
        public uint DvNumPublisherThreads { get; set; }

        /// <summary>
        /// Set the number of threads which will be dedicated to published
        /// changes to state variables via WebSockets
        /// </summary>
        /// <remarks>One thread will be used per active (web browser) connection so a higher
        /// number of threads will allow more concurrent clients but will also
        /// require more system resources. Can be 0 for clients who do not require HTML5
        /// support</remarks>
        public uint DvNumWebSocketThreads { get; set; }

        /// <summary>
        /// Limit the library to using only the loopback network interface
        /// </summary>
        /// <remarks>Useful for testing but not expected to be used in production code</remarks>
        public bool UseLoopbackNetworkInterface { get; set; }

        /// <summary>
        /// Enable use of Bonjour.
        /// </summary>
        /// <remarks>All DvDevice instances with an IResourceManager will be published using Bonjour.
        /// If a device sets the "Upnp.MdnsHostName" attribute, its presentation will be available via http://[hostname].local.
        /// Behaviour when more than one DvDevice sets the "MdnsHostName" attribute is undefined.
        /// Note that enabling Bonjour will cause the device stack to run a http server on port 80, requiring root privileges on linux.</remarks>
        public bool DvEnableBonjour { get; set; }

        [DllImport ("ZappUpnp")]
        static extern IntPtr ZappInitParamsCreate();
        [DllImport ("ZappUpnp")]
        static extern void ZappInitParamsDestroy(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetLogOutput(IntPtr aParams, ZappCallbackMsg aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetFatalErrorHandler(IntPtr aParams, ZappCallbackMsg aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetAsyncBeginHandler(IntPtr aParams, ZappCallbackAsync aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetAsyncEndHandler(IntPtr aParams, ZappCallbackAsync aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetAsyncErrorHandler(IntPtr aParams, ZappCallbackAsync aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDefaultSubnet(IntPtr aParams, uint aSubnet);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetSubnetChangedListener(IntPtr aParams, ZappCallback aCallback, IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetTcpConnectTimeout(IntPtr aParams, uint aTimeoutMs);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetMsearchTime(IntPtr aParams, uint aSecs);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetMsearchTtl(IntPtr aParams, uint aTtl);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetNumEventSessionThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetNumXmlFetcherThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetNumActionInvokerThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetNumInvocations(IntPtr aParams, uint aNumInvocations);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetNumSubscriberThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetPendingSubscriptionTimeout(IntPtr aParams, uint aTimeoutMs);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDvMaxUpdateTime(IntPtr aParams, uint aSecs);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDvNumServerThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDvNumPublisherThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDvNumWebSocketThreads(IntPtr aParams, uint aNumThreads);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetDvEnableBonjour(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetUseLoopbackNetworkInterface(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsTcpConnectTimeoutMs(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsMsearchTimeSecs(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsMsearchTtl(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsNumEventSessionThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsNumXmlFetcherThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsNumActionInvokerThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsNumInvocations(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsNumSubscriberThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsPendingSubscriptionTimeoutMs(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsDvMaxUpdateTimeSecs(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsDvNumServerThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsDvNumPublisherThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsDvNumWebSocketThreads(IntPtr aParams);
        [DllImport("ZappUpnp")]
        static extern uint ZappInitParamsDvIsBonjourEnabled(IntPtr aParams);

        public InitParams()
        {
            IntPtr defaultParams = ZappInitParamsCreate();
            
            DefaultSubnet = 0; // FIXME: No getter?
            TcpConnectTimeoutMs = ZappInitParamsTcpConnectTimeoutMs(defaultParams); 
            MsearchTimeSecs = ZappInitParamsMsearchTimeSecs(defaultParams); 
            MsearchTtl = ZappInitParamsMsearchTtl(defaultParams); 
            NumEventSessionThreads = ZappInitParamsNumEventSessionThreads(defaultParams); 
            NumXmlFetcherThreads = ZappInitParamsNumXmlFetcherThreads(defaultParams); 
            NumActionInvokerThreads = ZappInitParamsNumActionInvokerThreads(defaultParams); 
            NumInvocations = ZappInitParamsNumInvocations(defaultParams); 
            NumSubscriberThreads = ZappInitParamsNumSubscriberThreads(defaultParams); 
            PendingSubscriptionTimeoutMs = ZappInitParamsPendingSubscriptionTimeoutMs(defaultParams); 
            DvMaxUpdateTimeSecs = ZappInitParamsDvMaxUpdateTimeSecs(defaultParams); 
            DvNumServerThreads = ZappInitParamsDvNumServerThreads(defaultParams); 
            DvNumPublisherThreads = ZappInitParamsDvNumPublisherThreads(defaultParams); 
            DvNumWebSocketThreads = ZappInitParamsDvNumWebSocketThreads(defaultParams); 
            UseLoopbackNetworkInterface = false; // FIXME: No getter?
            DvEnableBonjour = ZappInitParamsDvIsBonjourEnabled(defaultParams) != 0; 

            ZappInitParamsDestroy(defaultParams);
        }
        internal IntPtr AllocNativeInitParams(IntPtr aCallbackPtr)
        {
            IntPtr nativeParams = ZappInitParamsCreate();

            ZappInitParamsSetLogOutput(nativeParams, LogOutput, aCallbackPtr);
            if (FatalErrorHandler != null)
            {
                ZappInitParamsSetFatalErrorHandler(nativeParams, FatalErrorHandler, aCallbackPtr);
            }
            if (AsyncBeginHandler != null)
            {
                ZappInitParamsSetAsyncBeginHandler(nativeParams, AsyncBeginHandler, aCallbackPtr);
            }
            if (AsyncEndHandler != null)
            {
                ZappInitParamsSetAsyncEndHandler(nativeParams, AsyncEndHandler, aCallbackPtr);
            }
            if (AsyncErrorHandler != null)
            {
                ZappInitParamsSetAsyncErrorHandler(nativeParams, AsyncErrorHandler, aCallbackPtr);
            }
            ZappInitParamsSetDefaultSubnet(nativeParams, DefaultSubnet);
            if (SubnetChangedListener != null)
            {
                ZappInitParamsSetSubnetChangedListener(nativeParams, SubnetChangedListener, aCallbackPtr);
            }
            ZappInitParamsSetTcpConnectTimeout(nativeParams, TcpConnectTimeoutMs);
            ZappInitParamsSetMsearchTime(nativeParams, MsearchTimeSecs);
            ZappInitParamsSetMsearchTtl(nativeParams, MsearchTtl);
            ZappInitParamsSetNumEventSessionThreads(nativeParams, NumEventSessionThreads);
            ZappInitParamsSetNumXmlFetcherThreads(nativeParams, NumXmlFetcherThreads);
            ZappInitParamsSetNumActionInvokerThreads(nativeParams, NumActionInvokerThreads);
            ZappInitParamsSetNumInvocations(nativeParams, NumInvocations);
            ZappInitParamsSetNumSubscriberThreads(nativeParams, NumSubscriberThreads);
            ZappInitParamsSetPendingSubscriptionTimeout(nativeParams, PendingSubscriptionTimeoutMs);
            ZappInitParamsSetDvMaxUpdateTime(nativeParams, DvMaxUpdateTimeSecs);
            ZappInitParamsSetDvNumServerThreads(nativeParams, DvNumServerThreads);
            ZappInitParamsSetDvNumPublisherThreads(nativeParams, DvNumPublisherThreads);
            ZappInitParamsSetDvNumWebSocketThreads(nativeParams, DvNumWebSocketThreads);
            if (DvEnableBonjour)
            {
                ZappInitParamsSetDvEnableBonjour(nativeParams);
            }
            if (UseLoopbackNetworkInterface)
            {
                ZappInitParamsSetUseLoopbackNetworkInterface(nativeParams);
            }
            ZappInitParamsSetUseLoopbackNetworkInterface(nativeParams);
            return nativeParams;
        }
        internal static void FreeNativeInitParams(IntPtr aNativeInitParams)
        {
            ZappInitParamsDestroy(aNativeInitParams);
        }
    }

    [Serializable]
    public class LibraryException : Exception
    {
        public LibraryException() { }
        public LibraryException(string message) : base(message) { }
        public LibraryException(string message, Exception inner) : base(message, inner) { }
        protected LibraryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }



    /// <summary>
    /// A control-point stack. Pre-requisite for creating a device-list
    /// factory.
    /// </summary>
    public class ControlPointStack
    {
        // Constructor is not public - obtain an instance from Library.
        internal ControlPointStack()
        {
        }
    }

    /// <summary>
    /// A device stack. Pre-requisite for creating a device factory.
    /// </summary>
    public class DeviceStack
    {
        // Constructor is not public - obtain an instance from Library.
        internal DeviceStack()
        {
        }
    }

    /// <summary>
    /// Combined control-point and device stacks.
    /// </summary>
    public class CombinedStack
    {
        /// <summary>
        /// Provides access to the ControlPointStack to create a device-list
        /// factory.
        /// </summary>
        public ControlPointStack ControlPointStack { get; private set; }

        /// <summary>
        /// Provides access to the DeviceStack to create a device factory.
        /// </summary>
        public DeviceStack DeviceStack { get; private set; }

        // Constructor is not public - obtain an instance from Library.
        internal CombinedStack()
        {
            ControlPointStack = new ControlPointStack();
            DeviceStack = new DeviceStack();
        }
    }

    /// <summary>
    /// Initialisation and finalisation of this library, plus utility functions
    /// </summary>
    public class Library : IDisposable
    {
        [DllImport ("ZappUpnp")]
        static extern int ZappLibraryInitialise(IntPtr aInitParams);
        [DllImport("ZappUpnp")]
        static extern int ZappLibraryInitialiseMinimal(IntPtr aInitParams);
        [DllImport ("ZappUpnp")]
        static extern void ZappLibraryStartCp();
        [DllImport ("ZappUpnp")]
        static extern void ZappLibraryStartDv();
        [DllImport ("ZappUpnp")]
        static extern void ZappLibraryStartCombined();
        [DllImport ("ZappUpnp")]
        static extern void ZappLibraryClose();
        [DllImport("ZappUpnp")]
        static extern void ZappFree(IntPtr aPtr);
        [DllImport("ZappUpnp")]
        static extern uint ZappNetworkInterfaceAddress(IntPtr aNif);
        [DllImport("ZappUpnp")]
        static extern uint ZappNetworkInterfaceSubnet(IntPtr aNif);
        [DllImport("ZappUpnp", CallingConvention = CallingConvention.StdCall, EntryPoint = "ZappNetworkInterfaceName", ExactSpelling = false)]
        static extern IntPtr ZappNetworkInterfaceName(IntPtr aNif);
        [DllImport("ZappUpnp")]
        static extern IntPtr ZappSubnetListCreate();
        [DllImport("ZappUpnp")]
        static extern uint ZappSubnetListSize(IntPtr aList);
        [DllImport("ZappUpnp")]
        static extern uint ZappSubnetAt(IntPtr aList, uint aIndex);
        [DllImport("ZappUpnp")]
        static extern void ZappSubnetListDestroy(IntPtr aList);
        [DllImport("ZappUpnp")]
        static extern void ZappSetCurrentSubnet(uint aSubnet);
        [DllImport("ZappUpnp")]
        static extern void ZappSetDefaultSubnet();
        [DllImport("ZappUpnp")]
        static extern void ZappInitParamsSetFreeExternalCallback(IntPtr aParams, CallbackFreeMemory aCallback);

        private bool iIsDisposed;

        private delegate void CallbackFreeMemory(IntPtr aPtr);

        private CallbackFreeMemory iCallbackFreeMemory;

        /// <summary>
        /// Initialise the library
        /// </summary>
        /// <remarks>Must be called before any other library function.</remarks>
        public void Initialise(InitParams aParams)
        {
            IntPtr nativeInitParams = aParams.AllocNativeInitParams(IntPtr.Zero);
            iCallbackFreeMemory = new CallbackFreeMemory(FreeMemory);
            ZappInitParamsSetFreeExternalCallback(nativeInitParams, iCallbackFreeMemory);
            if (0 != ZappLibraryInitialise(nativeInitParams))
            {
                InitParams.FreeNativeInitParams(nativeInitParams);
                throw new LibraryException();
            }
        }

        public static Library Create(InitParams aParams)
        {
            Library instance = new Library();
            instance.Initialise(aParams);
            return instance;
        }

        /// <summary>
        /// Lightweight alternative to UpnpLibraryInitialise
        /// </summary>
        /// <remarks>Intended for unit tests which are useful to platform porting only.
        /// 
        /// No class APIs other than Close() can be called if this is used.</remarks>
        /// <param name="aInitParams">Initialisation options.  Ownership of these passes to the library.</param>
        public void InitialiseMinimal(IntPtr aInitParams)
        {
            if (0 != ZappLibraryInitialiseMinimal(aInitParams))
            {
                throw new LibraryException();
            }
        }

        /// <summary>
        /// Start the library as a UPnP control point stack
        /// </summary>
        /// <returns>
        /// A control-point stack. Can be used to create device list factories.
        /// </returns>
        public ControlPointStack StartCp()
        {
            ZappLibraryStartCp();
            return new ControlPointStack();
        }

        /// <summary>
        /// Start the library as a UPnP device stack
        /// </summary>
        /// <returns>
        /// A device stack. Can be used to create device factories.
        /// </returns>
        public DeviceStack StartDv()
        {
            ZappLibraryStartDv();
            return new DeviceStack();
        }

        /// <summary>
        /// Start the library as both UPnP control point and device stacks
        /// </summary>
        public CombinedStack StartCombined()
        {
            ZappLibraryStartCombined();
            return new CombinedStack();
        }

        /// <summary>
        /// Close the UPnP library
        /// </summary>
        /// <remarks>No more library functions should be called after this.</remarks>
        public void Close()
        {
            ZappLibraryClose();
        }

        /// <summary>
        /// Free memory returned by native code
        /// </summary>
        /// <param name="aPtr">IntPtr returned by native code which is documented as requiring explicit destruction</param>
        public void Free(IntPtr aPtr)
        {
            ZappFree(aPtr);
        }

        /// <summary>
        /// Get the ip address for a given network interface
        /// </summary>
        /// <param name="aNif">Handle returned by SubnetAt()</param>
        /// <returns>IPv4 address in network byte order</returns>
        public uint NetworkInterfaceAddress(IntPtr aNif)
        {
            return ZappNetworkInterfaceAddress(aNif);
        }

        /// <summary>
        /// Get the subnet address for a given network interface
        /// </summary>
        /// <param name="aNif">Handle returned by SubnetAt()</param>
        /// <returns>IPv4 address in network byte order</returns>
        public uint NetworkInterfaceSubnet(IntPtr aNif)
        {
            return ZappNetworkInterfaceSubnet(aNif);
        }

        /// <summary>
        /// Get the name for a given network interface
        /// </summary>
        /// <param name="aNif">Handle returned by SubnetAt()</param>
        /// <returns>Pointer to a nul-terminated character array.  Caller is responsible for Free()ing this</returns>
        public IntPtr NetworkInterfaceName(IntPtr aNif)
        {
            return ZappNetworkInterfaceName(aNif);
        }

        /// <summary>
        /// Create a vector of the available subnets
        /// </summary>
        /// <returns>Subnet list handle.  Caller must later call SubnetListDestroy()</returns>
        public IntPtr SubnetListCreate()
        {
            return ZappSubnetListCreate();
        }

        /// <summary>
        /// Query the number of items in a subnet list
        /// </summary>
        /// <param name="aList">Subnet list handle returned by SubnetListCreate()</param>
        /// <returns>The number of items in the subnet</returns>
        public uint SubnetListSize(IntPtr aList)
        {
            return ZappSubnetListSize(aList);
        }

        /// <summary>
        /// Get a handle to a particular subnet from a subnet list
        /// </summary>
        /// <param name="aList">Subnet list handle returned by SubnetListCreate()</param>
        /// <param name="aIndex">Index of the list item to get a handle to (0..SubnetListSize()-1)</param>
        /// <returns>Handle to the subnet</returns>
        public uint SubnetAt(IntPtr aList, uint aIndex)
        {
            return ZappSubnetAt(aList, aIndex);
        }

        /// <summary>
        /// Destroy a subnet list
        /// </summary>
        /// <param name="aList">Subnet list handle returned by SubnetListCreate()</param>
        public void SubnetListDestroy(IntPtr aList)
        {
            ZappSubnetListDestroy(aList);
        }

        /// <summary>
        /// Set which subnet the library should use
        /// </summary>
        /// <remarks>Override any value set via InitialisationParams::SetDefaultSubnet.
        /// 
        /// Device lists and subscriptions will be automatically updated.
        /// 
        /// No other subnet will be selected if aSubnet is not available</remarks>
        /// <param name="aSubnet">Handle returned by SubnetAt()</param>
        public void SetCurrentSubnet(uint aSubnet)
        {
            ZappSetCurrentSubnet(aSubnet);
        }

        /// <summary>
        /// Clear any subnet previously specified using SetCurrentSubnet() or InitialisationParams::SetDefaultSubnet().
        /// OS-specified defaults will be used instead
        /// </summary>
        /// <remarks>Device lists and subscriptions will be automatically updated if necessary</remarks>
        public void SetDefaultSubnet()
        {
            ZappSetDefaultSubnet();
        }

        private void FreeMemory(IntPtr aPtr)
        {
            Marshal.FreeHGlobal(aPtr);
        }

        public void Dispose()
        {
            if (!iIsDisposed)
            {
                iIsDisposed = true;
                Close();
            }
        }
    }
}
