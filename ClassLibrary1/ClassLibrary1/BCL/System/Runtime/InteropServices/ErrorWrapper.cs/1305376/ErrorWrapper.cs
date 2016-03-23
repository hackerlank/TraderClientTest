// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: ErrorWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_ERROR.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security.Permissions; 

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
    public sealed class ErrorWrapper 
    {
        public ErrorWrapper(int errorCode) 
        { 
            m_ErrorCode = errorCode;
        } 

        public ErrorWrapper(Object errorCode)
        {
            if (!(errorCode is int)) 
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"), "errorCode");
            m_ErrorCode = (int)errorCode; 
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
        public ErrorWrapper(Exception e)
        {
            m_ErrorCode = Marshal.GetHRForException(e); 
        }
 
        public int ErrorCode 
        {
            get 
            {
                return m_ErrorCode;
            }
        } 

        private int m_ErrorCode; 
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
** Class: ErrorWrapper. 
**
** 
** Purpose: Wrapper that is converted to a variant with VT_ERROR.
**
**
=============================================================================*/ 

namespace System.Runtime.InteropServices { 
 
    using System;
    using System.Security.Permissions; 

    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)]
    public sealed class ErrorWrapper 
    {
        public ErrorWrapper(int errorCode) 
        { 
            m_ErrorCode = errorCode;
        } 

        public ErrorWrapper(Object errorCode)
        {
            if (!(errorCode is int)) 
                throw new ArgumentException(Environment.GetResourceString("Arg_MustBeInt32"), "errorCode");
            m_ErrorCode = (int)errorCode; 
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags=SecurityPermissionFlag.UnmanagedCode)]
        public ErrorWrapper(Exception e)
        {
            m_ErrorCode = Marshal.GetHRForException(e); 
        }
 
        public int ErrorCode 
        {
            get 
            {
                return m_ErrorCode;
            }
        } 

        private int m_ErrorCode; 
    } 
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
