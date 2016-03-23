// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: BStrWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_BSTR.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security; 
    using System.Security.Permissions;

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class BStrWrapper
    { 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand,Flags=SecurityPermissionFlag.UnmanagedCode)]
        public BStrWrapper(String value) 
        {
            m_WrappedObject = value;
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)] 
        public BStrWrapper(Object value) 
        {
            m_WrappedObject = (String)value; 
        }

        public String WrappedObject
        { 
            get
            { 
                return m_WrappedObject; 
            }
        } 

        private String m_WrappedObject;
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
** Class: BStrWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_BSTR.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security; 
    using System.Security.Permissions;

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class BStrWrapper
    { 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand,Flags=SecurityPermissionFlag.UnmanagedCode)]
        public BStrWrapper(String value) 
        {
            m_WrappedObject = value;
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)] 
        public BStrWrapper(Object value) 
        {
            m_WrappedObject = (String)value; 
        }

        public String WrappedObject
        { 
            get
            { 
                return m_WrappedObject; 
            }
        } 

        private String m_WrappedObject;
    }
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
