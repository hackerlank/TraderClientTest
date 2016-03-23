// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: OutOfMemoryException 
**
** 
** Purpose: The exception class for OOM.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 

    [System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class OutOfMemoryException : SystemException { 
        public OutOfMemoryException()
            : base(GetMessageFromNativeResources(ExceptionMessageKind.OutOfMemory)) { 
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY); 
        }
 
        public OutOfMemoryException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY);
        } 

        public OutOfMemoryException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected OutOfMemoryException(SerializationInfo info, StreamingContext context) : base(info, context) {
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
** Class: OutOfMemoryException 
**
** 
** Purpose: The exception class for OOM.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 

    [System.Runtime.InteropServices.ComVisible(true)]
    [Serializable]
    public class OutOfMemoryException : SystemException { 
        public OutOfMemoryException()
            : base(GetMessageFromNativeResources(ExceptionMessageKind.OutOfMemory)) { 
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY); 
        }
 
        public OutOfMemoryException(String message)
            : base(message) {
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY);
        } 

        public OutOfMemoryException(String message, Exception innerException) 
            : base(message, innerException) { 
            SetErrorCode(__HResults.COR_E_OUTOFMEMORY);
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected OutOfMemoryException(SerializationInfo info, StreamingContext context) : base(info, context) {
        } 
    }
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
