// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
** 
** Classes:  NativeObjectSecurity class 
**
** 
===========================================================*/

using Microsoft.Win32;
using System; 
using System.Collections;
using System.Security.Principal; 
using System.Runtime.InteropServices; 
using System.Runtime.Versioning;
 
namespace System.Security.AccessControl
{
    using FileNotFoundException = System.IO.FileNotFoundException;
    using System.Globalization; 
    using System.Diagnostics.Contracts;
 
 
    public abstract class NativeObjectSecurity : CommonObjectSecurity
    { 
        #region Private Members

        private readonly ResourceType _resourceType;
        private ExceptionFromErrorCode _exceptionFromErrorCode = null; 
        private object _exceptionContext = null;
        private readonly uint ProtectedDiscretionaryAcl       = 0x80000000; 
        private readonly uint ProtectedSystemAcl                 = 0x40000000; 
        private readonly uint UnprotectedDiscretionaryAcl   = 0x20000000;
        private readonly uint UnprotectedSystemAcl             = 0x10000000; 



        #endregion 

        #region Delegates 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        internal protected delegate System.Exception ExceptionFromErrorCode( int errorCode, string name, SafeHandle handle, object context ); 

        #endregion

        #region Constructors 

        [System.Security.SecuritySafeCritical] // externally visitible member 
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType ) 
            : base( isContainer )
        { 
            _resourceType = resourceType;
        }

        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected NativeObjectSecurity(bool isContainer, ResourceType resourceType, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext)
            : this(isContainer, resourceType) 
        { 
            _exceptionContext = exceptionContext;
            _exceptionFromErrorCode = exceptionFromErrorCode; 
        }

        [System.Security.SecurityCritical]  // auto-generated
        internal NativeObjectSecurity( ResourceType resourceType, CommonSecurityDescriptor securityDescriptor ) 
            : this( resourceType, securityDescriptor, null )
        { 
        } 

        [System.Security.SecurityCritical]  // auto-generated 
        internal NativeObjectSecurity( ResourceType resourceType, CommonSecurityDescriptor securityDescriptor, ExceptionFromErrorCode exceptionFromErrorCode )
            : base( securityDescriptor )
        {
            _resourceType = resourceType; 
            _exceptionFromErrorCode = exceptionFromErrorCode;
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext ) 
            : this( resourceType, CreateInternal( resourceType, isContainer, name, null, includeSections, true, exceptionFromErrorCode, exceptionContext ), exceptionFromErrorCode)
        {
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections ) 
            : this( isContainer, resourceType, name, includeSections, null, null ) 
        {
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, SafeHandle handle, AccessControlSections includeSections, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext )
            : this( resourceType, CreateInternal( resourceType, isContainer, null, handle, includeSections, false, exceptionFromErrorCode, exceptionContext ), exceptionFromErrorCode) 
        {
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, SafeHandle handle, AccessControlSections includeSections ) 
            : this( isContainer, resourceType, handle, includeSections, null, null )
        {
        }
 
        #endregion
 
        #region Private Methods 

        [System.Security.SecurityCritical]  // auto-generated 
        private static CommonSecurityDescriptor CreateInternal( ResourceType resourceType, bool isContainer, string name, SafeHandle handle, AccessControlSections includeSections, bool createByName, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext )
        {
            int error;
            RawSecurityDescriptor rawSD; 

            if ( createByName && name == null ) 
            { 
                throw new ArgumentNullException( "name" );
            } 
            else if ( !createByName && handle == null )
            {
                throw new ArgumentNullException( "handle" );
            } 

            error = Win32.GetSecurityInfo( resourceType, name, handle, includeSections, out rawSD ); 
 
            if ( error != Win32Native.ERROR_SUCCESS )
            { 
                System.Exception exception = null;

                if ( exceptionFromErrorCode != null )
                { 
                    exception = exceptionFromErrorCode( error, name, handle, exceptionContext );
                } 
 
                if ( exception == null )
                { 
                    if ( error == Win32Native.ERROR_ACCESS_DENIED )
                    {
                        exception = new UnauthorizedAccessException();
                    } 
                    else if ( error == Win32Native.ERROR_INVALID_OWNER )
                    { 
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidOwner" ) ); 
                    }
                    else if ( error == Win32Native.ERROR_INVALID_PRIMARY_GROUP ) 
                    {
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidGroup" ));
                    }
                    else if ( error == Win32Native.ERROR_INVALID_PARAMETER ) 
                    {
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error )); 
                    } 
                    else if ( error == Win32Native.ERROR_INVALID_NAME )
                    { 
                        exception = new ArgumentException(
                            Environment.GetResourceString( "Argument_InvalidName" ),
                            "name" );
                    } 
                    else if ( error == Win32Native.ERROR_FILE_NOT_FOUND )
                    { 
                        exception = ( name == null ? new FileNotFoundException() : new FileNotFoundException( name )); 
                    }
                    else if ( error == Win32Native.ERROR_NO_SECURITY_ON_OBJECT ) 
                    {
                        exception = new NotSupportedException( Environment.GetResourceString( "AccessControl_NoAssociatedSecurity" ));
                    }
                    else 
                    {
                        Contract.Assert( false, string.Format( CultureInfo.InvariantCulture, "Win32GetSecurityInfo() failed with unexpected error code {0}", error )); 
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error )); 
                    }
                } 

                throw exception;
            }
 
            return new CommonSecurityDescriptor( isContainer, false /* isDS */, rawSD, true );
        } 
 
        //
        // Attempts to persist the security descriptor onto the object 
        //

        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        private void Persist( string name, SafeHandle handle, AccessControlSections includeSections, object exceptionContext ) 
        { 
            WriteLock();
 
            try
            {
                int error;
                SecurityInfos securityInfo = 0; 

                SecurityIdentifier owner = null, group = null; 
                SystemAcl sacl = null; 
                DiscretionaryAcl dacl = null;
 
                if (( includeSections & AccessControlSections.Owner ) != 0 && _securityDescriptor.Owner != null )
                {
                    securityInfo |= SecurityInfos.Owner;
                    owner = _securityDescriptor.Owner; 
                }
 
                if (( includeSections & AccessControlSections.Group ) != 0 && _securityDescriptor.Group != null ) 
                {
                    securityInfo |= SecurityInfos.Group; 
                    group = _securityDescriptor.Group;
                }

                if (( includeSections & AccessControlSections.Audit ) != 0 ) 
                {
                    securityInfo |= SecurityInfos.SystemAcl; 
                    if ( _securityDescriptor.IsSystemAclPresent && 
                         _securityDescriptor.SystemAcl != null &&
                         _securityDescriptor.SystemAcl.Count > 0 ) 
                    {
                        sacl = _securityDescriptor.SystemAcl;
                    }
                    else 
                    {
                        sacl = null; 
                    } 

                    if (( _securityDescriptor.ControlFlags & ControlFlags.SystemAclProtected ) != 0 ) 
                    {
                       securityInfo =  (SecurityInfos)((uint)securityInfo | ProtectedSystemAcl);
                    }
                    else 
                    {
                        securityInfo =  (SecurityInfos)((uint)securityInfo | UnprotectedSystemAcl); 
                    } 
                }
 
                if (( includeSections & AccessControlSections.Access ) != 0 && _securityDescriptor.IsDiscretionaryAclPresent )
                {
                    securityInfo |= SecurityInfos.DiscretionaryAcl;
 
                    // if the DACL is in fact a crafted replaced for NULL replacement, then we will persist it as NULL
                    if (_securityDescriptor.DiscretionaryAcl.EveryOneFullAccessForNullDacl) 
                    { 
                        dacl = null;
                    } 
                    else
                    {
                        dacl = _securityDescriptor.DiscretionaryAcl;
                    } 

                    if (( _securityDescriptor.ControlFlags & ControlFlags.DiscretionaryAclProtected ) != 0 ) 
                    { 
                        securityInfo =  (SecurityInfos)((uint)securityInfo | ProtectedDiscretionaryAcl);
                    } 
                    else
                    {
                        securityInfo =  (SecurityInfos)((uint)securityInfo | UnprotectedDiscretionaryAcl);
                    } 
                }
 
                if ( securityInfo == 0 ) 
                {
                    // 
                    // Nothing to persist
                    //

                    return; 
                }
 
                error = Win32.SetSecurityInfo( _resourceType, name, handle, securityInfo, owner, group, sacl, dacl ); 

                if ( error != Win32Native.ERROR_SUCCESS ) 
                {
                    System.Exception exception = null;

                    if ( _exceptionFromErrorCode != null ) 
                    {
                        exception = _exceptionFromErrorCode( error, name, handle, exceptionContext ); 
                    } 

                    if ( exception == null ) 
                    {
                        if ( error == Win32Native.ERROR_ACCESS_DENIED )
                        {
                            exception = new UnauthorizedAccessException(); 
                        }
                        else if ( error == Win32Native.ERROR_INVALID_OWNER ) 
                        { 
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidOwner" ) );
                        } 
                        else if ( error == Win32Native.ERROR_INVALID_PRIMARY_GROUP )
                        {
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidGroup" ) );
                        } 
                        else if ( error == Win32Native.ERROR_INVALID_NAME )
                        { 
                            exception = new ArgumentException( 
                                Environment.GetResourceString( "Argument_InvalidName" ),
                                "name" ); 
                        }
                        else if ( error == Win32Native.ERROR_INVALID_HANDLE )
                        {
                            exception = new NotSupportedException( Environment.GetResourceString( "AccessControl_InvalidHandle" )); 
                        }
                        else if ( error == Win32Native.ERROR_FILE_NOT_FOUND ) 
                        { 
                            exception = new FileNotFoundException();
                        } 
                        else if (error == Win32Native.ERROR_NO_SECURITY_ON_OBJECT)
                        {
                            exception = new NotSupportedException(Environment.GetResourceString("AccessControl_NoAssociatedSecurity"));
                        } 
                        else
                        { 
                            Contract.Assert( false, string.Format( CultureInfo.InvariantCulture, "Unexpected error code {0}", error )); 
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error ));
                        } 
                    }

                    throw exception;
                } 

                // 
                // Everything goes well, let us clean the modified flags. 
                // We are in proper write lock, so just go ahead
                // 

                this.OwnerModified = false;
                this.GroupModified = false;
                this.AccessRulesModified = false; 
                this.AuditRulesModified = false;
            } 
            finally 
            {
                WriteUnlock(); 
            }
        }

        #endregion 

        #region Protected Methods 
 
        //
        // Persists the changes made to the object 
        // by calling the underlying Windows API
        //
        // This overloaded method takes a name of an existing object
        // 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        protected sealed override void Persist( string name, AccessControlSections includeSections ) 
        {
            Persist(name, includeSections, _exceptionContext);
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)] 
        protected void Persist( string name, AccessControlSections includeSections, object exceptionContext )
        { 
            if (name == null)
            {
                throw new ArgumentNullException( "name" );
            } 
            Contract.EndContractBlock();
 
            Persist( name, null, includeSections, exceptionContext ); 
        }
 
        //
        // Persists the changes made to the object
        // by calling the underlying Windows API
        // 
        // This overloaded method takes a handle to an existing object
        // 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected sealed override void Persist( SafeHandle handle, AccessControlSections includeSections )
        { 
            Persist(handle, includeSections, _exceptionContext);
        }

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)] 
        protected void Persist( SafeHandle handle, AccessControlSections includeSections, object exceptionContext ) 
        {
            if (handle == null) 
            {
                throw new ArgumentNullException( "handle" );
            }
            Contract.EndContractBlock(); 

            Persist( null, handle, includeSections, exceptionContext ); 
        } 

        #endregion 
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
** Classes:  NativeObjectSecurity class 
**
** 
===========================================================*/

using Microsoft.Win32;
using System; 
using System.Collections;
using System.Security.Principal; 
using System.Runtime.InteropServices; 
using System.Runtime.Versioning;
 
namespace System.Security.AccessControl
{
    using FileNotFoundException = System.IO.FileNotFoundException;
    using System.Globalization; 
    using System.Diagnostics.Contracts;
 
 
    public abstract class NativeObjectSecurity : CommonObjectSecurity
    { 
        #region Private Members

        private readonly ResourceType _resourceType;
        private ExceptionFromErrorCode _exceptionFromErrorCode = null; 
        private object _exceptionContext = null;
        private readonly uint ProtectedDiscretionaryAcl       = 0x80000000; 
        private readonly uint ProtectedSystemAcl                 = 0x40000000; 
        private readonly uint UnprotectedDiscretionaryAcl   = 0x20000000;
        private readonly uint UnprotectedSystemAcl             = 0x10000000; 



        #endregion 

        #region Delegates 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        internal protected delegate System.Exception ExceptionFromErrorCode( int errorCode, string name, SafeHandle handle, object context ); 

        #endregion

        #region Constructors 

        [System.Security.SecuritySafeCritical] // externally visitible member 
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType ) 
            : base( isContainer )
        { 
            _resourceType = resourceType;
        }

        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected NativeObjectSecurity(bool isContainer, ResourceType resourceType, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext)
            : this(isContainer, resourceType) 
        { 
            _exceptionContext = exceptionContext;
            _exceptionFromErrorCode = exceptionFromErrorCode; 
        }

        [System.Security.SecurityCritical]  // auto-generated
        internal NativeObjectSecurity( ResourceType resourceType, CommonSecurityDescriptor securityDescriptor ) 
            : this( resourceType, securityDescriptor, null )
        { 
        } 

        [System.Security.SecurityCritical]  // auto-generated 
        internal NativeObjectSecurity( ResourceType resourceType, CommonSecurityDescriptor securityDescriptor, ExceptionFromErrorCode exceptionFromErrorCode )
            : base( securityDescriptor )
        {
            _resourceType = resourceType; 
            _exceptionFromErrorCode = exceptionFromErrorCode;
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext ) 
            : this( resourceType, CreateInternal( resourceType, isContainer, name, null, includeSections, true, exceptionFromErrorCode, exceptionContext ), exceptionFromErrorCode)
        {
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections ) 
            : this( isContainer, resourceType, name, includeSections, null, null ) 
        {
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, SafeHandle handle, AccessControlSections includeSections, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext )
            : this( resourceType, CreateInternal( resourceType, isContainer, null, handle, includeSections, false, exceptionFromErrorCode, exceptionContext ), exceptionFromErrorCode) 
        {
        } 
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        protected NativeObjectSecurity( bool isContainer, ResourceType resourceType, SafeHandle handle, AccessControlSections includeSections ) 
            : this( isContainer, resourceType, handle, includeSections, null, null )
        {
        }
 
        #endregion
 
        #region Private Methods 

        [System.Security.SecurityCritical]  // auto-generated 
        private static CommonSecurityDescriptor CreateInternal( ResourceType resourceType, bool isContainer, string name, SafeHandle handle, AccessControlSections includeSections, bool createByName, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext )
        {
            int error;
            RawSecurityDescriptor rawSD; 

            if ( createByName && name == null ) 
            { 
                throw new ArgumentNullException( "name" );
            } 
            else if ( !createByName && handle == null )
            {
                throw new ArgumentNullException( "handle" );
            } 

            error = Win32.GetSecurityInfo( resourceType, name, handle, includeSections, out rawSD ); 
 
            if ( error != Win32Native.ERROR_SUCCESS )
            { 
                System.Exception exception = null;

                if ( exceptionFromErrorCode != null )
                { 
                    exception = exceptionFromErrorCode( error, name, handle, exceptionContext );
                } 
 
                if ( exception == null )
                { 
                    if ( error == Win32Native.ERROR_ACCESS_DENIED )
                    {
                        exception = new UnauthorizedAccessException();
                    } 
                    else if ( error == Win32Native.ERROR_INVALID_OWNER )
                    { 
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidOwner" ) ); 
                    }
                    else if ( error == Win32Native.ERROR_INVALID_PRIMARY_GROUP ) 
                    {
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidGroup" ));
                    }
                    else if ( error == Win32Native.ERROR_INVALID_PARAMETER ) 
                    {
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error )); 
                    } 
                    else if ( error == Win32Native.ERROR_INVALID_NAME )
                    { 
                        exception = new ArgumentException(
                            Environment.GetResourceString( "Argument_InvalidName" ),
                            "name" );
                    } 
                    else if ( error == Win32Native.ERROR_FILE_NOT_FOUND )
                    { 
                        exception = ( name == null ? new FileNotFoundException() : new FileNotFoundException( name )); 
                    }
                    else if ( error == Win32Native.ERROR_NO_SECURITY_ON_OBJECT ) 
                    {
                        exception = new NotSupportedException( Environment.GetResourceString( "AccessControl_NoAssociatedSecurity" ));
                    }
                    else 
                    {
                        Contract.Assert( false, string.Format( CultureInfo.InvariantCulture, "Win32GetSecurityInfo() failed with unexpected error code {0}", error )); 
                        exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error )); 
                    }
                } 

                throw exception;
            }
 
            return new CommonSecurityDescriptor( isContainer, false /* isDS */, rawSD, true );
        } 
 
        //
        // Attempts to persist the security descriptor onto the object 
        //

        [System.Security.SecurityCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        private void Persist( string name, SafeHandle handle, AccessControlSections includeSections, object exceptionContext ) 
        { 
            WriteLock();
 
            try
            {
                int error;
                SecurityInfos securityInfo = 0; 

                SecurityIdentifier owner = null, group = null; 
                SystemAcl sacl = null; 
                DiscretionaryAcl dacl = null;
 
                if (( includeSections & AccessControlSections.Owner ) != 0 && _securityDescriptor.Owner != null )
                {
                    securityInfo |= SecurityInfos.Owner;
                    owner = _securityDescriptor.Owner; 
                }
 
                if (( includeSections & AccessControlSections.Group ) != 0 && _securityDescriptor.Group != null ) 
                {
                    securityInfo |= SecurityInfos.Group; 
                    group = _securityDescriptor.Group;
                }

                if (( includeSections & AccessControlSections.Audit ) != 0 ) 
                {
                    securityInfo |= SecurityInfos.SystemAcl; 
                    if ( _securityDescriptor.IsSystemAclPresent && 
                         _securityDescriptor.SystemAcl != null &&
                         _securityDescriptor.SystemAcl.Count > 0 ) 
                    {
                        sacl = _securityDescriptor.SystemAcl;
                    }
                    else 
                    {
                        sacl = null; 
                    } 

                    if (( _securityDescriptor.ControlFlags & ControlFlags.SystemAclProtected ) != 0 ) 
                    {
                       securityInfo =  (SecurityInfos)((uint)securityInfo | ProtectedSystemAcl);
                    }
                    else 
                    {
                        securityInfo =  (SecurityInfos)((uint)securityInfo | UnprotectedSystemAcl); 
                    } 
                }
 
                if (( includeSections & AccessControlSections.Access ) != 0 && _securityDescriptor.IsDiscretionaryAclPresent )
                {
                    securityInfo |= SecurityInfos.DiscretionaryAcl;
 
                    // if the DACL is in fact a crafted replaced for NULL replacement, then we will persist it as NULL
                    if (_securityDescriptor.DiscretionaryAcl.EveryOneFullAccessForNullDacl) 
                    { 
                        dacl = null;
                    } 
                    else
                    {
                        dacl = _securityDescriptor.DiscretionaryAcl;
                    } 

                    if (( _securityDescriptor.ControlFlags & ControlFlags.DiscretionaryAclProtected ) != 0 ) 
                    { 
                        securityInfo =  (SecurityInfos)((uint)securityInfo | ProtectedDiscretionaryAcl);
                    } 
                    else
                    {
                        securityInfo =  (SecurityInfos)((uint)securityInfo | UnprotectedDiscretionaryAcl);
                    } 
                }
 
                if ( securityInfo == 0 ) 
                {
                    // 
                    // Nothing to persist
                    //

                    return; 
                }
 
                error = Win32.SetSecurityInfo( _resourceType, name, handle, securityInfo, owner, group, sacl, dacl ); 

                if ( error != Win32Native.ERROR_SUCCESS ) 
                {
                    System.Exception exception = null;

                    if ( _exceptionFromErrorCode != null ) 
                    {
                        exception = _exceptionFromErrorCode( error, name, handle, exceptionContext ); 
                    } 

                    if ( exception == null ) 
                    {
                        if ( error == Win32Native.ERROR_ACCESS_DENIED )
                        {
                            exception = new UnauthorizedAccessException(); 
                        }
                        else if ( error == Win32Native.ERROR_INVALID_OWNER ) 
                        { 
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidOwner" ) );
                        } 
                        else if ( error == Win32Native.ERROR_INVALID_PRIMARY_GROUP )
                        {
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_InvalidGroup" ) );
                        } 
                        else if ( error == Win32Native.ERROR_INVALID_NAME )
                        { 
                            exception = new ArgumentException( 
                                Environment.GetResourceString( "Argument_InvalidName" ),
                                "name" ); 
                        }
                        else if ( error == Win32Native.ERROR_INVALID_HANDLE )
                        {
                            exception = new NotSupportedException( Environment.GetResourceString( "AccessControl_InvalidHandle" )); 
                        }
                        else if ( error == Win32Native.ERROR_FILE_NOT_FOUND ) 
                        { 
                            exception = new FileNotFoundException();
                        } 
                        else if (error == Win32Native.ERROR_NO_SECURITY_ON_OBJECT)
                        {
                            exception = new NotSupportedException(Environment.GetResourceString("AccessControl_NoAssociatedSecurity"));
                        } 
                        else
                        { 
                            Contract.Assert( false, string.Format( CultureInfo.InvariantCulture, "Unexpected error code {0}", error )); 
                            exception = new InvalidOperationException( Environment.GetResourceString( "AccessControl_UnexpectedError", error ));
                        } 
                    }

                    throw exception;
                } 

                // 
                // Everything goes well, let us clean the modified flags. 
                // We are in proper write lock, so just go ahead
                // 

                this.OwnerModified = false;
                this.GroupModified = false;
                this.AccessRulesModified = false; 
                this.AuditRulesModified = false;
            } 
            finally 
            {
                WriteUnlock(); 
            }
        }

        #endregion 

        #region Protected Methods 
 
        //
        // Persists the changes made to the object 
        // by calling the underlying Windows API
        //
        // This overloaded method takes a name of an existing object
        // 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)]
        protected sealed override void Persist( string name, AccessControlSections includeSections ) 
        {
            Persist(name, includeSections, _exceptionContext);
        }
 
        [System.Security.SecuritySafeCritical]  // auto-generated
        [ResourceExposure(ResourceScope.Machine)] 
        [ResourceConsumption(ResourceScope.Machine)] 
        protected void Persist( string name, AccessControlSections includeSections, object exceptionContext )
        { 
            if (name == null)
            {
                throw new ArgumentNullException( "name" );
            } 
            Contract.EndContractBlock();
 
            Persist( name, null, includeSections, exceptionContext ); 
        }
 
        //
        // Persists the changes made to the object
        // by calling the underlying Windows API
        // 
        // This overloaded method takes a handle to an existing object
        // 
        [System.Security.SecuritySafeCritical]  // auto-generated 
        protected sealed override void Persist( SafeHandle handle, AccessControlSections includeSections )
        { 
            Persist(handle, includeSections, _exceptionContext);
        }

        [System.Security.SecuritySafeCritical]  // auto-generated 
        [ResourceExposure(ResourceScope.None)]
        [ResourceConsumption(ResourceScope.Machine, ResourceScope.Machine)] 
        protected void Persist( SafeHandle handle, AccessControlSections includeSections, object exceptionContext ) 
        {
            if (handle == null) 
            {
                throw new ArgumentNullException( "handle" );
            }
            Contract.EndContractBlock(); 

            Persist( null, handle, includeSections, exceptionContext ); 
        } 

        #endregion 
    }
}

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
