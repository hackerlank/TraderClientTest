// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: NotSupportedException 
**
** 
** Purpose: For methods that should be implemented on subclasses.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class NotSupportedException : SystemException
    { 
        public NotSupportedException()
            : base(Environment.GetResourceString("Arg_NotSupportedException")) { 
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED); 
        }
 
        public NotSupportedException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED);
        } 

        public NotSupportedException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) {
        } 

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
** Class: NotSupportedException 
**
** 
** Purpose: For methods that should be implemented on subclasses.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class NotSupportedException : SystemException
    { 
        public NotSupportedException()
            : base(Environment.GetResourceString("Arg_NotSupportedException")) { 
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED); 
        }
 
        public NotSupportedException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED);
        } 

        public NotSupportedException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_NOTSUPPORTED);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NotSupportedException(SerializationInfo info, StreamingContext context) : base(info, context) {
        } 

    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.