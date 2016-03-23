// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
/*============================================================
** 
** Class:  NeutralResourcesLanguageAttribute 
**
** <OWNER>[....]</OWNER> 
**
**
** Purpose: Tells the ResourceManager what language your main
**          assembly's resources are written in.  The 
**          ResourceManager won't try loading a satellite
**          assembly for that culture, which helps perf. 
** 
**
===========================================================*/ 

namespace System.Resources {
    using System;
    using System.Diagnostics.Contracts; 

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false)] 
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class NeutralResourcesLanguageAttribute : Attribute
    { 
        private String _culture;
        private UltimateResourceFallbackLocation _fallbackLoc;

        public NeutralResourcesLanguageAttribute(String cultureName) 
        {
            if (cultureName == null) 
                throw new ArgumentNullException("cultureName"); 
            Contract.EndContractBlock();
 
            _culture = cultureName;
            _fallbackLoc = UltimateResourceFallbackLocation.MainAssembly;
        }
 
        public NeutralResourcesLanguageAttribute(String cultureName, UltimateResourceFallbackLocation location)
        { 
            if (cultureName == null) 
                throw new ArgumentNullException("cultureName");
            if (!Enum.IsDefined(typeof(UltimateResourceFallbackLocation), location)) 
                throw new ArgumentException(Environment.GetResourceString("Arg_InvalidNeutralResourcesLanguage_FallbackLoc", location));
            Contract.EndContractBlock();

            _culture = cultureName; 
            _fallbackLoc = location;
        } 
 
        public String CultureName {
            get { return _culture; } 
        }

        public UltimateResourceFallbackLocation Location {
            get { return _fallbackLoc; } 
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
** Class:  NeutralResourcesLanguageAttribute 
**
** <OWNER>[....]</OWNER> 
**
**
** Purpose: Tells the ResourceManager what language your main
**          assembly's resources are written in.  The 
**          ResourceManager won't try loading a satellite
**          assembly for that culture, which helps perf. 
** 
**
===========================================================*/ 

namespace System.Resources {
    using System;
    using System.Diagnostics.Contracts; 

    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple=false)] 
[System.Runtime.InteropServices.ComVisible(true)] 
    public sealed class NeutralResourcesLanguageAttribute : Attribute
    { 
        private String _culture;
        private UltimateResourceFallbackLocation _fallbackLoc;

        public NeutralResourcesLanguageAttribute(String cultureName) 
        {
            if (cultureName == null) 
                throw new ArgumentNullException("cultureName"); 
            Contract.EndContractBlock();
 
            _culture = cultureName;
            _fallbackLoc = UltimateResourceFallbackLocation.MainAssembly;
        }
 
        public NeutralResourcesLanguageAttribute(String cultureName, UltimateResourceFallbackLocation location)
        { 
            if (cultureName == null) 
                throw new ArgumentNullException("cultureName");
            if (!Enum.IsDefined(typeof(UltimateResourceFallbackLocation), location)) 
                throw new ArgumentException(Environment.GetResourceString("Arg_InvalidNeutralResourcesLanguage_FallbackLoc", location));
            Contract.EndContractBlock();

            _culture = cultureName; 
            _fallbackLoc = location;
        } 
 
        public String CultureName {
            get { return _culture; } 
        }

        public UltimateResourceFallbackLocation Location {
            get { return _fallbackLoc; } 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.