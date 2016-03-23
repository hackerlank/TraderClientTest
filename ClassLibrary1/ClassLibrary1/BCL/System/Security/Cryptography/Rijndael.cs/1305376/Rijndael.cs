// ==++== 
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--== 
// <OWNER>[....]</OWNER>
// 
 
//
// Rijndael.cs 
//

namespace System.Security.Cryptography
{ 
[System.Runtime.InteropServices.ComVisible(true)]
 
    public abstract class Rijndael : SymmetricAlgorithm 
    {
        private static  KeySizes[] s_legalBlockSizes = { 
          new KeySizes(128, 256, 64)
        };

        private static  KeySizes[] s_legalKeySizes = { 
            new KeySizes(128, 256, 64)
        }; 
 
        //
        // protected constructors 
        //

        protected Rijndael() {
            KeySizeValue = 256; 
            BlockSizeValue = 128;
            FeedbackSizeValue = BlockSizeValue; 
            LegalBlockSizesValue = s_legalBlockSizes; 
            LegalKeySizesValue = s_legalKeySizes;
        } 

        //
        // public methods
        // 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        new static public Rijndael Create() { 
            return Create("System.Security.Cryptography.Rijndael");
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        new static public Rijndael Create(String algName) {
            return (Rijndael) CryptoConfig.CreateFromName(algName); 
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
 
//
// Rijndael.cs 
//

namespace System.Security.Cryptography
{ 
[System.Runtime.InteropServices.ComVisible(true)]
 
    public abstract class Rijndael : SymmetricAlgorithm 
    {
        private static  KeySizes[] s_legalBlockSizes = { 
          new KeySizes(128, 256, 64)
        };

        private static  KeySizes[] s_legalKeySizes = { 
            new KeySizes(128, 256, 64)
        }; 
 
        //
        // protected constructors 
        //

        protected Rijndael() {
            KeySizeValue = 256; 
            BlockSizeValue = 128;
            FeedbackSizeValue = BlockSizeValue; 
            LegalBlockSizesValue = s_legalBlockSizes; 
            LegalKeySizesValue = s_legalKeySizes;
        } 

        //
        // public methods
        // 

        [System.Security.SecuritySafeCritical]  // auto-generated 
        new static public Rijndael Create() { 
            return Create("System.Security.Cryptography.Rijndael");
        } 

        [System.Security.SecuritySafeCritical]  // auto-generated
        new static public Rijndael Create(String algName) {
            return (Rijndael) CryptoConfig.CreateFromName(algName); 
        }
    } 
} 

// File provided for Reference Use Only by Microsoft Corporation (c) 2007.
