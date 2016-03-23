// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
namespace System {
    using System; 
    using System.Runtime.Serialization; 
    using System.Globalization;
    using System.Security.Permissions; 

    /// <devdoc>
    ///    <para> The exception that is thrown when accessing an object that was
    ///       disposed.</para> 
    /// </devdoc>
[System.Runtime.InteropServices.ComVisible(true)] 
    [Serializable] 
    public class ObjectDisposedException : InvalidOperationException {
        private String objectName; 

        // This constructor should only be called by the EE (COMPlusThrow)
        private ObjectDisposedException() :
            this(null ,Environment.GetResourceString("ObjectDisposed_Generic")) { 
        }
 
        public ObjectDisposedException(String objectName) : 
            this(objectName, Environment.GetResourceString("ObjectDisposed_Generic")) {
        } 

        public ObjectDisposedException(String objectName, String message) : base(message) {
            SetErrorCode(__HResults.COR_E_OBJECTDISPOSED);
            this.objectName = objectName; 
        }
 
        public ObjectDisposedException(String message, Exception innerException) 
            : base(message, innerException) {
            SetErrorCode(__HResults.COR_E_OBJECTDISPOSED); 
        }

        /// <devdoc>
        ///    <para>Gets the text for the message for this exception.</para> 
        /// </devdoc>
        public override String Message { 
            [System.Security.SecuritySafeCritical]  // auto-generated 
            get {
                String name = ObjectName; 
                if (name == null || name.Length == 0)
                    return base.Message;

                String objectDisposed = Environment.GetResourceString("ObjectDisposed_ObjectName_Name", name); 
                return base.Message + Environment.NewLine + objectDisposed;
            } 
        } 

        public String ObjectName { 
            get {
                if (objectName == null)
                    return String.Empty;
                return objectName; 
            }
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected ObjectDisposedException(SerializationInfo info, StreamingContext context) : base(info, context) { 
            objectName = info.GetString("ObjectName");
        }

        [System.Security.SecurityCritical]  // auto-generated_required 
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context); 
            info.AddValue("ObjectName",ObjectName,typeof(String)); 
        }
 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
namespace System {
    using System; 
    using System.Runtime.Serialization; 
    using System.Globalization;
    using System.Security.Permissions; 

    /// <devdoc>
    ///    <para> The exception that is thrown when accessing an object that was
    ///       disposed.</para> 
    /// </devdoc>
[System.Runtime.InteropServices.ComVisible(true)] 
    [Serializable] 
    public class ObjectDisposedException : InvalidOperationException {
        private String objectName; 

        // This constructor should only be called by the EE (COMPlusThrow)
        private ObjectDisposedException() :
            this(null ,Environment.GetResourceString("ObjectDisposed_Generic")) { 
        }
 
        public ObjectDisposedException(String objectName) : 
            this(objectName, Environment.GetResourceString("ObjectDisposed_Generic")) {
        } 

        public ObjectDisposedException(String objectName, String message) : base(message) {
            SetErrorCode(__HResults.COR_E_OBJECTDISPOSED);
            this.objectName = objectName; 
        }
 
        public ObjectDisposedException(String message, Exception innerException) 
            : base(message, innerException) {
            SetErrorCode(__HResults.COR_E_OBJECTDISPOSED); 
        }

        /// <devdoc>
        ///    <para>Gets the text for the message for this exception.</para> 
        /// </devdoc>
        public override String Message { 
            [System.Security.SecuritySafeCritical]  // auto-generated 
            get {
                String name = ObjectName; 
                if (name == null || name.Length == 0)
                    return base.Message;

                String objectDisposed = Environment.GetResourceString("ObjectDisposed_ObjectName_Name", name); 
                return base.Message + Environment.NewLine + objectDisposed;
            } 
        } 

        public String ObjectName { 
            get {
                if (objectName == null)
                    return String.Empty;
                return objectName; 
            }
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected ObjectDisposedException(SerializationInfo info, StreamingContext context) : base(info, context) { 
            objectName = info.GetString("ObjectName");
        }

        [System.Security.SecurityCritical]  // auto-generated_required 
        public override void GetObjectData(SerializationInfo info, StreamingContext context) {
            base.GetObjectData(info, context); 
            info.AddValue("ObjectName",ObjectName,typeof(String)); 
        }
 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.