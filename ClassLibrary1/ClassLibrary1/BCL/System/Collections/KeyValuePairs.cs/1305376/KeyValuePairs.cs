// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
** 
** Class:  KeyValuePairs 
**
** <OWNER>[....]</OWNER> 
**
**
** Purpose: KeyValuePairs to display items in collection class under debugger
** 
**
===========================================================*/ 
 
namespace System.Collections {
    using System.Diagnostics; 

    [DebuggerDisplay("{value}", Name = "[{key}]", Type = "" )]
#if FEATURE_CORECLR
    [Obsolete("Non-generic collections have been deprecated. Please use collections in System.Collections.Generic.")] 
#endif
    internal class KeyValuePairs { 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
        private object key;
 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object value;

        public KeyValuePairs(object key, object value) { 
            this.value = value;
            this.key = key; 
        } 

        public object Key { 
            get { return key; }
        }

        public object Value { 
            get { return value; }
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
** 
** Class:  KeyValuePairs 
**
** <OWNER>[....]</OWNER> 
**
**
** Purpose: KeyValuePairs to display items in collection class under debugger
** 
**
===========================================================*/ 
 
namespace System.Collections {
    using System.Diagnostics; 

    [DebuggerDisplay("{value}", Name = "[{key}]", Type = "" )]
#if FEATURE_CORECLR
    [Obsolete("Non-generic collections have been deprecated. Please use collections in System.Collections.Generic.")] 
#endif
    internal class KeyValuePairs { 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] 
        private object key;
 
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private object value;

        public KeyValuePairs(object key, object value) { 
            this.value = value;
            this.key = key; 
        } 

        public object Key { 
            get { return key; }
        }

        public object Value { 
            get { return value; }
        } 
    } 
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
