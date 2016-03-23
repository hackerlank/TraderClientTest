// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
// <OWNER>[....]</OWNER>
// 
 
namespace System.Security {
    using System.Security; 
    using System;
    using System.Runtime.Serialization;

    [System.Runtime.InteropServices.ComVisible(true)] 
    [Serializable] public class VerificationException : SystemException {
        public VerificationException() 
            : base(Environment.GetResourceString("Verification_Exception")) { 
            SetErrorCode(__HResults.COR_E_VERIFICATION);
        } 

        public VerificationException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_VERIFICATION); 
        }
 
        public VerificationException(String message, Exception innerException) 
            : base(message, innerException) {
            SetErrorCode(__HResults.COR_E_VERIFICATION); 
        }

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected VerificationException(SerializationInfo info, StreamingContext context) : base(info, context) { 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
// <OWNER>[....]</OWNER>
// 
 
namespace System.Security {
    using System.Security; 
    using System;
    using System.Runtime.Serialization;

    [System.Runtime.InteropServices.ComVisible(true)] 
    [Serializable] public class VerificationException : SystemException {
        public VerificationException() 
            : base(Environment.GetResourceString("Verification_Exception")) { 
            SetErrorCode(__HResults.COR_E_VERIFICATION);
        } 

        public VerificationException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_VERIFICATION); 
        }
 
        public VerificationException(String message, Exception innerException) 
            : base(message, innerException) {
            SetErrorCode(__HResults.COR_E_VERIFICATION); 
        }

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected VerificationException(SerializationInfo info, StreamingContext context) : base(info, context) { 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
