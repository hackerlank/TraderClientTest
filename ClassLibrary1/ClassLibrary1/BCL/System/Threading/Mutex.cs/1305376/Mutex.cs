// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
//
// <OWNER>[....]</OWNER> 
/*============================================================================== 
**
** Class: Mutex 
**
**
** Purpose: synchronization primitive that can also be used for interprocess synchronization
** 
**
=============================================================================*/ 
namespace System.Threading 
{
    using System; 
    using System.Threading;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.IO; 
    using Microsoft.Win32;
    using Microsoft.Win32.SafeHandles; 
    using System.Runtime.InteropServices; 
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.Versioning; 
    using System.Security.Principal;
    using System.Security;
    using System.Diagnostics.Contracts;
 
#if !FEATURE_PAL && FEATURE_MACL
    using System.Security.AccessControl; 
#endif 

    [HostProtection(Synchronization=true, ExternalThreading=true)] 
    [ComVisible(true)]
    public sealed class Mutex : WaitHandle
    {
        static bool dummyBool; 

#if !FEATURE_PAL && FEATURE_MACL 
        // Enables workaround for known OS bug at 
        // http://support.microsoft.com/default.aspx?scid=kb;en-us;889318
        // Calls to OpenMutex and CloseHandle on a mutex must essentially be serialized 
        // to avoid a bug in which the mutex allows multiple entries.
        static Mutex s_ReservedMutex = null;

        // an arbitrary, reserved name. 
        //
        const string c_ReservedMutexName = "Global\\CLR_RESERVED_MUTEX_NAME"; 
#endif 

        [System.Security.SecurityCritical]  // auto-generated_required 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        public Mutex(bool initiallyOwned, String name, out bool createdNew) 
            : this(initiallyOwned, name, out createdNew, null)
        { 
        } 

#if FEATURE_PAL || !FEATURE_MACL 
        public class MutexSecurity
        {
        }
#endif 

        [System.Security.SecurityCritical]  // auto-generated_required 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)] 
        public unsafe Mutex(bool initiallyOwned, String name, out bool createdNew, MutexSecurity mutexSecurity)
        {
            if(null != name && System.IO.Path.MAX_PATH < name.Length)
            { 
                throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong",name));
            } 
            Contract.EndContractBlock(); 
            Win32Native.SECURITY_ATTRIBUTES secAttrs = null;
#if !FEATURE_PAL && FEATURE_MACL 
            // For ACL's, get the security descriptor from the MutexSecurity.
            if (mutexSecurity != null) {

                secAttrs = new Win32Native.SECURITY_ATTRIBUTES(); 
                secAttrs.nLength = (int)Marshal.SizeOf(secAttrs);
 
                byte[] sd = mutexSecurity.GetSecurityDescriptorBinaryForm(); 
                byte* pSecDescriptor = stackalloc byte[sd.Length];
                Buffer.memcpy(sd, 0, pSecDescriptor, 0, sd.Length); 
                secAttrs.pSecurityDescriptor = pSecDescriptor;
            }
#endif
 

            RuntimeHelpers.CleanupCode cleanupCode = new RuntimeHelpers.CleanupCode(MutexCleanupCode); 
            MutexCleanupInfo cleanupInfo = new MutexCleanupInfo(null, false); 
            MutexTryCodeHelper tryCodeHelper = new MutexTryCodeHelper(initiallyOwned, cleanupInfo, name, secAttrs, this);
            RuntimeHelpers.TryCode tryCode = new RuntimeHelpers.TryCode(tryCodeHelper.MutexTryCode); 
            RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(
                tryCode,
                cleanupCode,
                cleanupInfo); 
                createdNew = tryCodeHelper.m_newMutex;
 
        } 

        internal class MutexTryCodeHelper 
        {
            bool m_initiallyOwned;
            MutexCleanupInfo m_cleanupInfo;
            internal bool m_newMutex; 
            String m_name;
            [System.Security.SecurityCritical /*auto-generated*/] 
            Win32Native.SECURITY_ATTRIBUTES m_secAttrs; 
            Mutex m_mutex;
 
            [System.Security.SecurityCritical]  // auto-generated
            [PrePrepareMethod]
            internal MutexTryCodeHelper(bool initiallyOwned,MutexCleanupInfo cleanupInfo, String name, Win32Native.SECURITY_ATTRIBUTES secAttrs, Mutex mutex)
            { 
                m_initiallyOwned = initiallyOwned;
                m_cleanupInfo = cleanupInfo; 
                m_name = name; 
                m_secAttrs = secAttrs;
                m_mutex = mutex; 
            }

            [System.Security.SecurityCritical]  // auto-generated
            [PrePrepareMethod] 
            internal void MutexTryCode(object userData)
            { 
                SafeWaitHandle mutexHandle = null; 
                // try block
                RuntimeHelpers.PrepareConstrainedRegions(); 
                try
                {
                }
                finally 
                {
                    if (m_initiallyOwned) 
                    { 
                        m_cleanupInfo.inCriticalRegion = true;
                        Thread.BeginThreadAffinity(); 
                        Thread.BeginCriticalRegion();
                    }
                }
 
                int errorCode = 0;
                RuntimeHelpers.PrepareConstrainedRegions(); 
                try 
                {
                } 
                finally
                {
                    errorCode = CreateMutexHandle(m_initiallyOwned, m_name, m_secAttrs, out mutexHandle);
                } 

                if (mutexHandle.IsInvalid) 
                { 
                    mutexHandle.SetHandleAsInvalid();
                    if(null != m_name && 0 != m_name.Length && Win32Native.ERROR_INVALID_HANDLE == errorCode) 
                        throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", m_name));
                    __Error.WinIOError(errorCode, m_name);
                }
                m_newMutex = errorCode != Win32Native.ERROR_ALREADY_EXISTS; 
                m_mutex.SetHandleInternal(mutexHandle);
                mutexHandle.SetAsMutex(); 
 
                m_mutex.hasThreadAffinity = true;
 
            }
        }

        [System.Security.SecurityCritical]  // auto-generated 
        [PrePrepareMethod]
        private void MutexCleanupCode(Object userData, bool exceptionThrown) 
        { 
            MutexCleanupInfo cleanupInfo = (MutexCleanupInfo) userData;
 
            // If hasThreadAffinity isn't true, we've thrown an exception in the above try, and we must free the mutex
            // on this OS thread before ending our thread affninity.
            if(!hasThreadAffinity) {
                if (cleanupInfo.mutexHandle != null && !cleanupInfo.mutexHandle.IsInvalid) { 
                    if( cleanupInfo.inCriticalRegion) {
                        Win32Native.ReleaseMutex(cleanupInfo.mutexHandle); 
                    } 
                    cleanupInfo.mutexHandle.Dispose();
 
                }

                if( cleanupInfo.inCriticalRegion) {
                    Thread.EndCriticalRegion(); 
                    Thread.EndThreadAffinity();
                } 
            } 
        }
 
        internal class MutexCleanupInfo
        {
            [System.Security.SecurityCritical /*auto-generated*/]
            internal SafeWaitHandle mutexHandle; 
            internal bool inCriticalRegion;
            [System.Security.SecurityCritical]  // auto-generated 
            internal MutexCleanupInfo(SafeWaitHandle mutexHandle, bool inCriticalRegion) 
            {
                this.mutexHandle = mutexHandle; 
                this.inCriticalRegion = inCriticalRegion;
            }
        }
 
        [System.Security.SecurityCritical]  // auto-generated_required
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public Mutex(bool initiallyOwned, String name) : this(initiallyOwned, name, out dummyBool) { 
        }

        [System.Security.SecuritySafeCritical]  // auto-generated
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)] 
        public Mutex(bool initiallyOwned) : this(initiallyOwned, null, out dummyBool) 
        {
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.None)] 
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        public Mutex() : this(false, null, out dummyBool) 
        { 
        }
 
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        private Mutex(SafeWaitHandle handle)
        { 
            SetHandleInternal(handle); 
            handle.SetAsMutex();
            hasThreadAffinity = true; 
        }

        [System.Security.SecurityCritical]  // auto-generated_required
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public static Mutex OpenExisting(string name) 
        { 
#if FEATURE_PAL || !FEATURE_MACL
            return OpenExisting(name, (MutexRights) 0); 
#else // FEATURE_PAL
            return OpenExisting(name, MutexRights.Modify | MutexRights.Synchronize);
#endif // FEATURE_PAL
        } 

#if FEATURE_PAL || !FEATURE_MACL 
        public enum MutexRights 
        {
        } 
#endif

        [System.Security.SecurityCritical]  // auto-generated_required
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public static Mutex OpenExisting(string name, MutexRights rights) 
        { 
            if (name == null)
            { 
                throw new ArgumentNullException("name", Environment.GetResourceString("ArgumentNull_WithParamName"));
            }

            if(name.Length  == 0) 
            {
                throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name"); 
            } 
            if(System.IO.Path.MAX_PATH < name.Length)
            { 
                throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong",name));
            }
            Contract.EndContractBlock();
 
            // To allow users to view & edit the ACL's, call OpenMutex
            // with parameters to allow us to view & edit the ACL.  This will 
            // fail if we don't have permission to view or edit the ACL's. 
            // If that happens, ask for less permissions.
#if !FEATURE_PAL && FEATURE_MACL 
            SafeWaitHandle myHandle = Win32Native.OpenMutex((int) rights, false, name);
#else
            SafeWaitHandle myHandle = Win32Native.OpenMutex(Win32Native.MUTEX_MODIFY_STATE | Win32Native.SYNCHRONIZE, false, name);
#endif 

            int errorCode = 0; 
            if (myHandle.IsInvalid) 
            {
                errorCode = Marshal.GetLastWin32Error(); 

                if(Win32Native.ERROR_FILE_NOT_FOUND == errorCode || Win32Native.ERROR_INVALID_NAME == errorCode)
                {
                    throw new WaitHandleCannotBeOpenedException(); 
                }
 
                if(null != name && 0 != name.Length && Win32Native.ERROR_INVALID_HANDLE == errorCode) 
                {
                    throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", name)); 
                }

                // this is for passed through Win32Native Errors
                __Error.WinIOError(errorCode,name); 
            }
 
            return new Mutex(myHandle); 
        }
 
        // Note: To call ReleaseMutex, you must have an ACL granting you
        // MUTEX_MODIFY_STATE rights (0x0001).  The other interesting value
        // in a Mutex's ACL is MUTEX_ALL_ACCESS (0x1F0001).
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void ReleaseMutex() 
        { 
            if (Win32Native.ReleaseMutex(safeWaitHandle))
            { 
                Thread.EndCriticalRegion();
                Thread.EndThreadAffinity();
            }
            else 
            {
#if FEATURE_CORECLR 
                throw new Exception(Environment.GetResourceString("Arg_SynchronizationLockException")); 
#else
                throw new ApplicationException(Environment.GetResourceString("Arg_SynchronizationLockException")); 
#endif // FEATURE_CORECLR
            }
        }
 
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)] 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        static int CreateMutexHandle(bool initiallyOwned, String name, Win32Native.SECURITY_ATTRIBUTES securityAttribute, out SafeWaitHandle mutexHandle) { 
            int errorCode;
            bool fReservedMutexObtained = false;
            bool fAffinity = false;
 
            while(true) {
                mutexHandle = Win32Native.CreateMutex(securityAttribute, initiallyOwned, name); 
                errorCode = Marshal.GetLastWin32Error(); 
                if( !mutexHandle.IsInvalid) {
                    break; 
                }

                if( errorCode == Win32Native.ERROR_ACCESS_DENIED) {
                    // If a mutex with the name already exists, OS will try to open it with FullAccess. 
                    // It might fail if we don't have enough access. In that case, we try to open the mutex will modify and synchronize access.
                    // 
 
                    RuntimeHelpers.PrepareConstrainedRegions();
                    try 
                    {
                        try
                        {
                        } 
                        finally
                        { 
                            Thread.BeginThreadAffinity(); 
                            fAffinity = true;
                        } 
                        AcquireReservedMutex(ref fReservedMutexObtained);
                        mutexHandle = Win32Native.OpenMutex(Win32Native.MUTEX_MODIFY_STATE | Win32Native.SYNCHRONIZE, false, name);
                        if(!mutexHandle.IsInvalid)
                        { 
                            errorCode = Win32Native.ERROR_ALREADY_EXISTS;
                        } 
                        else 
                        {
                            errorCode = Marshal.GetLastWin32Error(); 
                        }
                    }
                    finally
                    { 
                        if (fReservedMutexObtained)
                            ReleaseReservedMutex(); 
                        if (fAffinity) 
                            Thread.EndThreadAffinity();
                    } 

                    // There could be a ---- here, the other owner of the mutex can free the mutex,
                    // We need to retry creation in that case.
                    if( errorCode != Win32Native.ERROR_FILE_NOT_FOUND) { 
                        if( errorCode == Win32Native.ERROR_SUCCESS) {
                            errorCode =  Win32Native.ERROR_ALREADY_EXISTS; 
                        } 
                        break;
                    } 
                }
                else {
                    break;
                } 
            }
            return errorCode; 
        } 

#if !FEATURE_PAL && FEATURE_MACL 
        [System.Security.SecuritySafeCritical]  // auto-generated
        public MutexSecurity GetAccessControl()
        {
            return new MutexSecurity(safeWaitHandle, AccessControlSections.Access | AccessControlSections.Owner | AccessControlSections.Group); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        public void SetAccessControl(MutexSecurity mutexSecurity)
        { 
            if (mutexSecurity == null)
                throw new ArgumentNullException("mutexSecurity");
            Contract.EndContractBlock();
 
            mutexSecurity.Persist(safeWaitHandle);
        } 
#endif 

        // Enables workaround for known OS bug at 
        // http://support.microsoft.com/default.aspx?scid=kb;en-us;889318
        // One machine-wide mutex serializes all OpenMutex and CloseHandle operations.
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)] 
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [SecurityPermission(SecurityAction.Assert, ControlPrincipal = true)] 
        internal static unsafe void AcquireReservedMutex(ref bool bHandleObtained)
        { 
#if !FEATURE_PAL && FEATURE_MACL
            SafeWaitHandle mutexHandle = null;
            int errorCode;
 
            bHandleObtained = false;
 
            if (!Environment.IsW2k3) { 
                return;
            } 

            if (s_ReservedMutex == null) {

                // Create a maximally-permissive security descriptor, to ensure we never get an 
                // ACCESS_DENIED error when calling CreateMutex
                MutexSecurity sec = new MutexSecurity(); 
                SecurityIdentifier everyoneSid = new SecurityIdentifier(WellKnownSidType.WorldSid, null); 
                sec.AddAccessRule(new MutexAccessRule(everyoneSid, MutexRights.FullControl, AccessControlType.Allow));
 
                // For ACL's, get the security descriptor from the MutexSecurity.
                Win32Native.SECURITY_ATTRIBUTES secAttrs = new Win32Native.SECURITY_ATTRIBUTES();
                secAttrs.nLength = (int)Marshal.SizeOf(secAttrs);
 
                byte[] sd = sec.GetSecurityDescriptorBinaryForm();
                byte * bytesOnStack = stackalloc byte[sd.Length]; 
                Buffer.memcpy(sd, 0, bytesOnStack, 0, sd.Length); 
                secAttrs.pSecurityDescriptor = bytesOnStack;
 
                RuntimeHelpers.PrepareConstrainedRegions();
                try {}
                finally {
                    mutexHandle = Win32Native.CreateMutex(secAttrs, false, c_ReservedMutexName); 

                    // need to set specially, since this mutex cannot lock on itself while closing itself. 
                    mutexHandle.SetAsReservedMutex(); 
                }
 
                errorCode = Marshal.GetLastWin32Error();
                if (mutexHandle.IsInvalid) {
                    mutexHandle.SetHandleAsInvalid();
                    __Error.WinIOError(errorCode, c_ReservedMutexName); 
                }
 
                Mutex m = new Mutex(mutexHandle); 
                Interlocked.CompareExchange(ref s_ReservedMutex, m, null);
 
            }


            RuntimeHelpers.PrepareConstrainedRegions(); 
            try { }
            finally { 
                 try { 
                     s_ReservedMutex.WaitOne();
                     bHandleObtained = true; 
                 }
                 catch (AbandonedMutexException)
                 {
                     // we don't care if another process holding the Mutex was killed 
                     bHandleObtained = true;
                 } 
            } 
#else
            bHandleObtained = true; 
#endif
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        internal static void ReleaseReservedMutex()
        { 
#if !FEATURE_PAL && FEATURE_MACL 
            if (!Environment.IsW2k3)
            { 
                return;
            }

            Contract.Assert(s_ReservedMutex != null, 
                "ReleaseReservedMutex called without prior call to AcquireReservedMutex!");
 
            s_ReservedMutex.ReleaseMutex(); 
#endif
        } 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
//
// <OWNER>[....]</OWNER> 
/*============================================================================== 
**
** Class: Mutex 
**
**
** Purpose: synchronization primitive that can also be used for interprocess synchronization
** 
**
=============================================================================*/ 
namespace System.Threading 
{
    using System; 
    using System.Threading;
    using System.Runtime.CompilerServices;
    using System.Security.Permissions;
    using System.IO; 
    using Microsoft.Win32;
    using Microsoft.Win32.SafeHandles; 
    using System.Runtime.InteropServices; 
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.Versioning; 
    using System.Security.Principal;
    using System.Security;
    using System.Diagnostics.Contracts;
 
#if !FEATURE_PAL && FEATURE_MACL
    using System.Security.AccessControl; 
#endif 

    [HostProtection(Synchronization=true, ExternalThreading=true)] 
    [ComVisible(true)]
    public sealed class Mutex : WaitHandle
    {
        static bool dummyBool; 

#if !FEATURE_PAL && FEATURE_MACL 
        // Enables workaround for known OS bug at 
        // http://support.microsoft.com/default.aspx?scid=kb;en-us;889318
        // Calls to OpenMutex and CloseHandle on a mutex must essentially be serialized 
        // to avoid a bug in which the mutex allows multiple entries.
        static Mutex s_ReservedMutex = null;

        // an arbitrary, reserved name. 
        //
        const string c_ReservedMutexName = "Global\\CLR_RESERVED_MUTEX_NAME"; 
#endif 

        [System.Security.SecurityCritical]  // auto-generated_required 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        public Mutex(bool initiallyOwned, String name, out bool createdNew) 
            : this(initiallyOwned, name, out createdNew, null)
        { 
        } 

#if FEATURE_PAL || !FEATURE_MACL 
        public class MutexSecurity
        {
        }
#endif 

        [System.Security.SecurityCritical]  // auto-generated_required 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)] 
        public unsafe Mutex(bool initiallyOwned, String name, out bool createdNew, MutexSecurity mutexSecurity)
        {
            if(null != name && System.IO.Path.MAX_PATH < name.Length)
            { 
                throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong",name));
            } 
            Contract.EndContractBlock(); 
            Win32Native.SECURITY_ATTRIBUTES secAttrs = null;
#if !FEATURE_PAL && FEATURE_MACL 
            // For ACL's, get the security descriptor from the MutexSecurity.
            if (mutexSecurity != null) {

                secAttrs = new Win32Native.SECURITY_ATTRIBUTES(); 
                secAttrs.nLength = (int)Marshal.SizeOf(secAttrs);
 
                byte[] sd = mutexSecurity.GetSecurityDescriptorBinaryForm(); 
                byte* pSecDescriptor = stackalloc byte[sd.Length];
                Buffer.memcpy(sd, 0, pSecDescriptor, 0, sd.Length); 
                secAttrs.pSecurityDescriptor = pSecDescriptor;
            }
#endif
 

            RuntimeHelpers.CleanupCode cleanupCode = new RuntimeHelpers.CleanupCode(MutexCleanupCode); 
            MutexCleanupInfo cleanupInfo = new MutexCleanupInfo(null, false); 
            MutexTryCodeHelper tryCodeHelper = new MutexTryCodeHelper(initiallyOwned, cleanupInfo, name, secAttrs, this);
            RuntimeHelpers.TryCode tryCode = new RuntimeHelpers.TryCode(tryCodeHelper.MutexTryCode); 
            RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup(
                tryCode,
                cleanupCode,
                cleanupInfo); 
                createdNew = tryCodeHelper.m_newMutex;
 
        } 

        internal class MutexTryCodeHelper 
        {
            bool m_initiallyOwned;
            MutexCleanupInfo m_cleanupInfo;
            internal bool m_newMutex; 
            String m_name;
            [System.Security.SecurityCritical /*auto-generated*/] 
            Win32Native.SECURITY_ATTRIBUTES m_secAttrs; 
            Mutex m_mutex;
 
            [System.Security.SecurityCritical]  // auto-generated
            [PrePrepareMethod]
            internal MutexTryCodeHelper(bool initiallyOwned,MutexCleanupInfo cleanupInfo, String name, Win32Native.SECURITY_ATTRIBUTES secAttrs, Mutex mutex)
            { 
                m_initiallyOwned = initiallyOwned;
                m_cleanupInfo = cleanupInfo; 
                m_name = name; 
                m_secAttrs = secAttrs;
                m_mutex = mutex; 
            }

            [System.Security.SecurityCritical]  // auto-generated
            [PrePrepareMethod] 
            internal void MutexTryCode(object userData)
            { 
                SafeWaitHandle mutexHandle = null; 
                // try block
                RuntimeHelpers.PrepareConstrainedRegions(); 
                try
                {
                }
                finally 
                {
                    if (m_initiallyOwned) 
                    { 
                        m_cleanupInfo.inCriticalRegion = true;
                        Thread.BeginThreadAffinity(); 
                        Thread.BeginCriticalRegion();
                    }
                }
 
                int errorCode = 0;
                RuntimeHelpers.PrepareConstrainedRegions(); 
                try 
                {
                } 
                finally
                {
                    errorCode = CreateMutexHandle(m_initiallyOwned, m_name, m_secAttrs, out mutexHandle);
                } 

                if (mutexHandle.IsInvalid) 
                { 
                    mutexHandle.SetHandleAsInvalid();
                    if(null != m_name && 0 != m_name.Length && Win32Native.ERROR_INVALID_HANDLE == errorCode) 
                        throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", m_name));
                    __Error.WinIOError(errorCode, m_name);
                }
                m_newMutex = errorCode != Win32Native.ERROR_ALREADY_EXISTS; 
                m_mutex.SetHandleInternal(mutexHandle);
                mutexHandle.SetAsMutex(); 
 
                m_mutex.hasThreadAffinity = true;
 
            }
        }

        [System.Security.SecurityCritical]  // auto-generated 
        [PrePrepareMethod]
        private void MutexCleanupCode(Object userData, bool exceptionThrown) 
        { 
            MutexCleanupInfo cleanupInfo = (MutexCleanupInfo) userData;
 
            // If hasThreadAffinity isn't true, we've thrown an exception in the above try, and we must free the mutex
            // on this OS thread before ending our thread affninity.
            if(!hasThreadAffinity) {
                if (cleanupInfo.mutexHandle != null && !cleanupInfo.mutexHandle.IsInvalid) { 
                    if( cleanupInfo.inCriticalRegion) {
                        Win32Native.ReleaseMutex(cleanupInfo.mutexHandle); 
                    } 
                    cleanupInfo.mutexHandle.Dispose();
 
                }

                if( cleanupInfo.inCriticalRegion) {
                    Thread.EndCriticalRegion(); 
                    Thread.EndThreadAffinity();
                } 
            } 
        }
 
        internal class MutexCleanupInfo
        {
            [System.Security.SecurityCritical /*auto-generated*/]
            internal SafeWaitHandle mutexHandle; 
            internal bool inCriticalRegion;
            [System.Security.SecurityCritical]  // auto-generated 
            internal MutexCleanupInfo(SafeWaitHandle mutexHandle, bool inCriticalRegion) 
            {
                this.mutexHandle = mutexHandle; 
                this.inCriticalRegion = inCriticalRegion;
            }
        }
 
        [System.Security.SecurityCritical]  // auto-generated_required
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public Mutex(bool initiallyOwned, String name) : this(initiallyOwned, name, out dummyBool) { 
        }

        [System.Security.SecuritySafeCritical]  // auto-generated
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)] 
        public Mutex(bool initiallyOwned) : this(initiallyOwned, null, out dummyBool) 
        {
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        [ResourceExposure(ResourceScope.None)] 
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        public Mutex() : this(false, null, out dummyBool) 
        { 
        }
 
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)]
        [ResourceConsumption(ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        private Mutex(SafeWaitHandle handle)
        { 
            SetHandleInternal(handle); 
            handle.SetAsMutex();
            hasThreadAffinity = true; 
        }

        [System.Security.SecurityCritical]  // auto-generated_required
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public static Mutex OpenExisting(string name) 
        { 
#if FEATURE_PAL || !FEATURE_MACL
            return OpenExisting(name, (MutexRights) 0); 
#else // FEATURE_PAL
            return OpenExisting(name, MutexRights.Modify | MutexRights.Synchronize);
#endif // FEATURE_PAL
        } 

#if FEATURE_PAL || !FEATURE_MACL 
        public enum MutexRights 
        {
        } 
#endif

        [System.Security.SecurityCritical]  // auto-generated_required
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        public static Mutex OpenExisting(string name, MutexRights rights) 
        { 
            if (name == null)
            { 
                throw new ArgumentNullException("name", Environment.GetResourceString("ArgumentNull_WithParamName"));
            }

            if(name.Length  == 0) 
            {
                throw new ArgumentException(Environment.GetResourceString("Argument_EmptyName"), "name"); 
            } 
            if(System.IO.Path.MAX_PATH < name.Length)
            { 
                throw new ArgumentException(Environment.GetResourceString("Argument_WaitHandleNameTooLong",name));
            }
            Contract.EndContractBlock();
 
            // To allow users to view & edit the ACL's, call OpenMutex
            // with parameters to allow us to view & edit the ACL.  This will 
            // fail if we don't have permission to view or edit the ACL's. 
            // If that happens, ask for less permissions.
#if !FEATURE_PAL && FEATURE_MACL 
            SafeWaitHandle myHandle = Win32Native.OpenMutex((int) rights, false, name);
#else
            SafeWaitHandle myHandle = Win32Native.OpenMutex(Win32Native.MUTEX_MODIFY_STATE | Win32Native.SYNCHRONIZE, false, name);
#endif 

            int errorCode = 0; 
            if (myHandle.IsInvalid) 
            {
                errorCode = Marshal.GetLastWin32Error(); 

                if(Win32Native.ERROR_FILE_NOT_FOUND == errorCode || Win32Native.ERROR_INVALID_NAME == errorCode)
                {
                    throw new WaitHandleCannotBeOpenedException(); 
                }
 
                if(null != name && 0 != name.Length && Win32Native.ERROR_INVALID_HANDLE == errorCode) 
                {
                    throw new WaitHandleCannotBeOpenedException(Environment.GetResourceString("Threading.WaitHandleCannotBeOpenedException_InvalidHandle", name)); 
                }

                // this is for passed through Win32Native Errors
                __Error.WinIOError(errorCode,name); 
            }
 
            return new Mutex(myHandle); 
        }
 
        // Note: To call ReleaseMutex, you must have an ACL granting you
        // MUTEX_MODIFY_STATE rights (0x0001).  The other interesting value
        // in a Mutex's ACL is MUTEX_ALL_ACCESS (0x1F0001).
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        public void ReleaseMutex() 
        { 
            if (Win32Native.ReleaseMutex(safeWaitHandle))
            { 
                Thread.EndCriticalRegion();
                Thread.EndThreadAffinity();
            }
            else 
            {
#if FEATURE_CORECLR 
                throw new Exception(Environment.GetResourceString("Arg_SynchronizationLockException")); 
#else
                throw new ApplicationException(Environment.GetResourceString("Arg_SynchronizationLockException")); 
#endif // FEATURE_CORECLR
            }
        }
 
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)] 
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
        static int CreateMutexHandle(bool initiallyOwned, String name, Win32Native.SECURITY_ATTRIBUTES securityAttribute, out SafeWaitHandle mutexHandle) { 
            int errorCode;
            bool fReservedMutexObtained = false;
            bool fAffinity = false;
 
            while(true) {
                mutexHandle = Win32Native.CreateMutex(securityAttribute, initiallyOwned, name); 
                errorCode = Marshal.GetLastWin32Error(); 
                if( !mutexHandle.IsInvalid) {
                    break; 
                }

                if( errorCode == Win32Native.ERROR_ACCESS_DENIED) {
                    // If a mutex with the name already exists, OS will try to open it with FullAccess. 
                    // It might fail if we don't have enough access. In that case, we try to open the mutex will modify and synchronize access.
                    // 
 
                    RuntimeHelpers.PrepareConstrainedRegions();
                    try 
                    {
                        try
                        {
                        } 
                        finally
                        { 
                            Thread.BeginThreadAffinity(); 
                            fAffinity = true;
                        } 
                        AcquireReservedMutex(ref fReservedMutexObtained);
                        mutexHandle = Win32Native.OpenMutex(Win32Native.MUTEX_MODIFY_STATE | Win32Native.SYNCHRONIZE, false, name);
                        if(!mutexHandle.IsInvalid)
                        { 
                            errorCode = Win32Native.ERROR_ALREADY_EXISTS;
                        } 
                        else 
                        {
                            errorCode = Marshal.GetLastWin32Error(); 
                        }
                    }
                    finally
                    { 
                        if (fReservedMutexObtained)
                            ReleaseReservedMutex(); 
                        if (fAffinity) 
                            Thread.EndThreadAffinity();
                    } 

                    // There could be a ---- here, the other owner of the mutex can free the mutex,
                    // We need to retry creation in that case.
                    if( errorCode != Win32Native.ERROR_FILE_NOT_FOUND) { 
                        if( errorCode == Win32Native.ERROR_SUCCESS) {
                            errorCode =  Win32Native.ERROR_ALREADY_EXISTS; 
                        } 
                        break;
                    } 
                }
                else {
                    break;
                } 
            }
            return errorCode; 
        } 

#if !FEATURE_PAL && FEATURE_MACL 
        [System.Security.SecuritySafeCritical]  // auto-generated
        public MutexSecurity GetAccessControl()
        {
            return new MutexSecurity(safeWaitHandle, AccessControlSections.Access | AccessControlSections.Owner | AccessControlSections.Group); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        public void SetAccessControl(MutexSecurity mutexSecurity)
        { 
            if (mutexSecurity == null)
                throw new ArgumentNullException("mutexSecurity");
            Contract.EndContractBlock();
 
            mutexSecurity.Persist(safeWaitHandle);
        } 
#endif 

        // Enables workaround for known OS bug at 
        // http://support.microsoft.com/default.aspx?scid=kb;en-us;889318
        // One machine-wide mutex serializes all OpenMutex and CloseHandle operations.
        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.None)] 
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        [SecurityPermission(SecurityAction.Assert, ControlPrincipal = true)] 
        internal static unsafe void AcquireReservedMutex(ref bool bHandleObtained)
        { 
#if !FEATURE_PAL && FEATURE_MACL
            SafeWaitHandle mutexHandle = null;
            int errorCode;
 
            bHandleObtained = false;
 
            if (!Environment.IsW2k3) { 
                return;
            } 

            if (s_ReservedMutex == null) {

                // Create a maximally-permissive security descriptor, to ensure we never get an 
                // ACCESS_DENIED error when calling CreateMutex
                MutexSecurity sec = new MutexSecurity(); 
                SecurityIdentifier everyoneSid = new SecurityIdentifier(WellKnownSidType.WorldSid, null); 
                sec.AddAccessRule(new MutexAccessRule(everyoneSid, MutexRights.FullControl, AccessControlType.Allow));
 
                // For ACL's, get the security descriptor from the MutexSecurity.
                Win32Native.SECURITY_ATTRIBUTES secAttrs = new Win32Native.SECURITY_ATTRIBUTES();
                secAttrs.nLength = (int)Marshal.SizeOf(secAttrs);
 
                byte[] sd = sec.GetSecurityDescriptorBinaryForm();
                byte * bytesOnStack = stackalloc byte[sd.Length]; 
                Buffer.memcpy(sd, 0, bytesOnStack, 0, sd.Length); 
                secAttrs.pSecurityDescriptor = bytesOnStack;
 
                RuntimeHelpers.PrepareConstrainedRegions();
                try {}
                finally {
                    mutexHandle = Win32Native.CreateMutex(secAttrs, false, c_ReservedMutexName); 

                    // need to set specially, since this mutex cannot lock on itself while closing itself. 
                    mutexHandle.SetAsReservedMutex(); 
                }
 
                errorCode = Marshal.GetLastWin32Error();
                if (mutexHandle.IsInvalid) {
                    mutexHandle.SetHandleAsInvalid();
                    __Error.WinIOError(errorCode, c_ReservedMutexName); 
                }
 
                Mutex m = new Mutex(mutexHandle); 
                Interlocked.CompareExchange(ref s_ReservedMutex, m, null);
 
            }


            RuntimeHelpers.PrepareConstrainedRegions(); 
            try { }
            finally { 
                 try { 
                     s_ReservedMutex.WaitOne();
                     bHandleObtained = true; 
                 }
                 catch (AbandonedMutexException)
                 {
                     // we don't care if another process holding the Mutex was killed 
                     bHandleObtained = true;
                 } 
            } 
#else
            bHandleObtained = true; 
#endif
        }

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)] 
        internal static void ReleaseReservedMutex()
        { 
#if !FEATURE_PAL && FEATURE_MACL 
            if (!Environment.IsW2k3)
            { 
                return;
            }

            Contract.Assert(s_ReservedMutex != null, 
                "ReleaseReservedMutex called without prior call to AcquireReservedMutex!");
 
            s_ReservedMutex.ReleaseMutex(); 
#endif
        } 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
