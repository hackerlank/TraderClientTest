// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
** 
** Class: SafeLibraryHandle 
**
============================================================*/ 
namespace Microsoft.Win32 {
    using Microsoft.Win32;
    using Microsoft.Win32.SafeHandles;
    using System; 
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution; 
    using System.Runtime.InteropServices; 
    using System.Runtime.Serialization;
    using System.Runtime.Versioning; 
    using System.Security;
    using System.Security.Permissions;
    using System.Text;
 
    [System.Security.SecurityCritical]  // auto-generated
    [HostProtectionAttribute(MayLeakOnAbort = true)] 
    sealed internal class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid { 
        internal SafeLibraryHandle() : base(true) {}
 
        [System.Security.SecurityCritical]
        override protected bool ReleaseHandle()
        {
            return UnsafeNativeMethods.FreeLibrary(handle); 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
** 
** Class: SafeLibraryHandle 
**
============================================================*/ 
namespace Microsoft.Win32 {
    using Microsoft.Win32;
    using Microsoft.Win32.SafeHandles;
    using System; 
    using System.Runtime.CompilerServices;
    using System.Runtime.ConstrainedExecution; 
    using System.Runtime.InteropServices; 
    using System.Runtime.Serialization;
    using System.Runtime.Versioning; 
    using System.Security;
    using System.Security.Permissions;
    using System.Text;
 
    [System.Security.SecurityCritical]  // auto-generated
    [HostProtectionAttribute(MayLeakOnAbort = true)] 
    sealed internal class SafeLibraryHandle : SafeHandleZeroOrMinusOneIsInvalid { 
        internal SafeLibraryHandle() : base(true) {}
 
        [System.Security.SecurityCritical]
        override protected bool ReleaseHandle()
        {
            return UnsafeNativeMethods.FreeLibrary(handle); 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
