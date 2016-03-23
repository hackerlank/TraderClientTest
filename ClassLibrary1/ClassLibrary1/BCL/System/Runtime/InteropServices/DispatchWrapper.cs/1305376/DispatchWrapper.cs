// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: DispatchWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_DISPATCH.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security; 
    using System.Security.Permissions;

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class DispatchWrapper
    { 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand,Flags=SecurityPermissionFlag.UnmanagedCode)]
        public DispatchWrapper(Object obj) 
        {
            if (obj != null)
            {
                // Make sure this guy has an IDispatch 
                IntPtr pdisp = Marshal.GetIDispatchForObject(obj);
 
                // If we got here without throwing an exception, the QI for IDispatch succeeded. 
                Marshal.Release(pdisp);
            } 
            m_WrappedObject = obj;
        }

        public Object WrappedObject 
        {
            get 
            { 
                return m_WrappedObject;
            } 
        }

        private Object m_WrappedObject;
    } 
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: DispatchWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_DISPATCH.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security; 
    using System.Security.Permissions;

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class DispatchWrapper
    { 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand,Flags=SecurityPermissionFlag.UnmanagedCode)]
        public DispatchWrapper(Object obj) 
        {
            if (obj != null)
            {
                // Make sure this guy has an IDispatch 
                IntPtr pdisp = Marshal.GetIDispatchForObject(obj);
 
                // If we got here without throwing an exception, the QI for IDispatch succeeded. 
                Marshal.Release(pdisp);
            } 
            m_WrappedObject = obj;
        }

        public Object WrappedObject 
        {
            get 
            { 
                return m_WrappedObject;
            } 
        }

        private Object m_WrappedObject;
    } 
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
