// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*==============================================================================
** 
** Class: EntryPointNotFoundException 
**
** 
** Purpose: The exception class for some failed P/Invoke calls.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable] public class EntryPointNotFoundException : TypeLoadException {
        public EntryPointNotFoundException()
            : base(Environment.GetResourceString("Arg_EntryPointNotFoundException")) { 
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND);
        } 
 
        public EntryPointNotFoundException(String message)
            : base(message) { 
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND);
        }

        public EntryPointNotFoundException(String message, Exception inner) 
            : base(message, inner) {
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND); 
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected EntryPointNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
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
** Class: EntryPointNotFoundException 
**
** 
** Purpose: The exception class for some failed P/Invoke calls.
**
**
=============================================================================*/ 

namespace System { 
 
    using System;
    using System.Runtime.Serialization; 
[System.Runtime.InteropServices.ComVisible(true)]
    [Serializable] public class EntryPointNotFoundException : TypeLoadException {
        public EntryPointNotFoundException()
            : base(Environment.GetResourceString("Arg_EntryPointNotFoundException")) { 
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND);
        } 
 
        public EntryPointNotFoundException(String message)
            : base(message) { 
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND);
        }

        public EntryPointNotFoundException(String message, Exception inner) 
            : base(message, inner) {
            SetErrorCode(__HResults.COR_E_ENTRYPOINTNOTFOUND); 
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected EntryPointNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

 
    }
 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
