// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: OverflowException 
**
** 
** Purpose: Exception class for Arthimatic Overflows.
**
**
=============================================================================*/ 

namespace System { 
 

    using System; 
    using System.Runtime.Serialization;
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class OverflowException : ArithmeticException { 
        public OverflowException()
            : base(Environment.GetResourceString("Arg_OverflowException")) { 
            SetErrorCode(__HResults.COR_E_OVERFLOW); 
        }
 
        public OverflowException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_OVERFLOW);
        } 

        public OverflowException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_OVERFLOW);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected OverflowException(SerializationInfo info, StreamingContext context) : base(info, context) {
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
** Class: OverflowException 
**
** 
** Purpose: Exception class for Arthimatic Overflows.
**
**
=============================================================================*/ 

namespace System { 
 

    using System; 
    using System.Runtime.Serialization;
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class OverflowException : ArithmeticException { 
        public OverflowException()
            : base(Environment.GetResourceString("Arg_OverflowException")) { 
            SetErrorCode(__HResults.COR_E_OVERFLOW); 
        }
 
        public OverflowException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_OVERFLOW);
        } 

        public OverflowException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_OVERFLOW);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected OverflowException(SerializationInfo info, StreamingContext context) : base(info, context) {
        } 

    } 
 
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
