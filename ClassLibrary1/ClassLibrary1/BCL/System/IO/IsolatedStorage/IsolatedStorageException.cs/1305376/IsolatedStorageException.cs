// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
 * 
 * Class:  IsolatedStorageException 
//
// <OWNER>[....]</OWNER> 
 *
 *
 * Purpose: The exceptions in IsolatedStorage
 * 
 * Date:  Feb 15, 2000
 * 
 ===========================================================*/ 
namespace System.IO.IsolatedStorage {
 
    using System;
    using System.Runtime.Serialization;
    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public class IsolatedStorageException : Exception
    { 
        public IsolatedStorageException() 
            : base(Environment.GetResourceString("IsolatedStorage_Exception"))
        { 
            SetErrorCode(__HResults.COR_E_ISOSTORE);
        }

        public IsolatedStorageException(String message) 
            : base(message)
        { 
            SetErrorCode(__HResults.COR_E_ISOSTORE); 
        }
 
        public IsolatedStorageException(String message, Exception inner)
            : base(message, inner)
        {
            SetErrorCode(__HResults.COR_E_ISOSTORE); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected IsolatedStorageException(SerializationInfo info, StreamingContext context) : base (info, context) {
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
 * 
 * Class:  IsolatedStorageException 
//
// <OWNER>[....]</OWNER> 
 *
 *
 * Purpose: The exceptions in IsolatedStorage
 * 
 * Date:  Feb 15, 2000
 * 
 ===========================================================*/ 
namespace System.IO.IsolatedStorage {
 
    using System;
    using System.Runtime.Serialization;
    [Serializable]
[System.Runtime.InteropServices.ComVisible(true)] 
    public class IsolatedStorageException : Exception
    { 
        public IsolatedStorageException() 
            : base(Environment.GetResourceString("IsolatedStorage_Exception"))
        { 
            SetErrorCode(__HResults.COR_E_ISOSTORE);
        }

        public IsolatedStorageException(String message) 
            : base(message)
        { 
            SetErrorCode(__HResults.COR_E_ISOSTORE); 
        }
 
        public IsolatedStorageException(String message, Exception inner)
            : base(message, inner)
        {
            SetErrorCode(__HResults.COR_E_ISOSTORE); 
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected IsolatedStorageException(SerializationInfo info, StreamingContext context) : base (info, context) {
        } 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
