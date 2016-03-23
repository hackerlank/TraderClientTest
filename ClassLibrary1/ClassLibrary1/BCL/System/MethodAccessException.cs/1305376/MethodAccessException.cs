// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: MethodAccessException 
**
** Purpose: The exception class for class loading failures. 
**
=============================================================================*/

namespace System { 

    using System; 
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable] public class MethodAccessException : MemberAccessException { 
        public MethodAccessException()
            : base(Environment.GetResourceString("Arg_MethodAccessException")) {
            SetErrorCode(__HResults.COR_E_METHODACCESS);
        } 

        public MethodAccessException(String message) 
            : base(message) { 
            SetErrorCode(__HResults.COR_E_METHODACCESS);
        } 

        public MethodAccessException(String message, Exception inner)
            : base(message, inner) {
            SetErrorCode(__HResults.COR_E_METHODACCESS); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected MethodAccessException(SerializationInfo info, StreamingContext context) : base(info, context) {
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
** Class: MethodAccessException 
**
** Purpose: The exception class for class loading failures. 
**
=============================================================================*/

namespace System { 

    using System; 
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable] public class MethodAccessException : MemberAccessException { 
        public MethodAccessException()
            : base(Environment.GetResourceString("Arg_MethodAccessException")) {
            SetErrorCode(__HResults.COR_E_METHODACCESS);
        } 

        public MethodAccessException(String message) 
            : base(message) { 
            SetErrorCode(__HResults.COR_E_METHODACCESS);
        } 

        public MethodAccessException(String message, Exception inner)
            : base(message, inner) {
            SetErrorCode(__HResults.COR_E_METHODACCESS); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected MethodAccessException(SerializationInfo info, StreamingContext context) : base(info, context) {
        } 

    }

} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
