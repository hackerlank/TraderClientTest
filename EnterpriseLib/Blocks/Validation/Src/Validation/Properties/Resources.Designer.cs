﻿//===============================================================================
// Microsoft patterns & practices Enterprise Library
// Validation Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Microsoft.Practices.EnterpriseLibrary.Validation.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enterprise Library Validation Application Block.
        /// </summary>
        public static string BlockName {
            get {
                return ResourceManager.GetString("BlockName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Errors reading configuration for Enterprise Library Validation Application Block.
        /// </summary>
        public static string ConfigurationErrorMessage {
            get {
                return ResourceManager.GetString("ConfigurationErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not contain the characters in &quot;{3}&quot; with mode &quot;{4}&quot;..
        /// </summary>
        public static string ContainsCharactersNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("ContainsCharactersNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must contain the characters in &quot;{3}&quot; with mode &quot;{4}&quot;. .
        /// </summary>
        public static string ContainsCharactersNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("ContainsCharactersNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not belong to the domain..
        /// </summary>
        public static string DomainNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("DomainNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value does not belong to the domain..
        /// </summary>
        public static string DomainNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("DomainNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not be defined in the &quot;{3}&quot; enum type..
        /// </summary>
        public static string EnumConversionNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("EnumConversionNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be defined in the &quot;{3}&quot; enum type..
        /// </summary>
        public static string EnumConversionNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("EnumConversionNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied value could not be converted to the target property type..
        /// </summary>
        public static string ErrorCannotPerfomDefaultConversion {
            get {
                return ResourceManager.GetString("ErrorCannotPerfomDefaultConversion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value for &quot;{0}&quot; could not be accessed from an instance of &quot;{1}&quot;..
        /// </summary>
        public static string ErrorValueAccessInvalidType {
            get {
                return ResourceManager.GetString("ErrorValueAccessInvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value for &quot;{0}&quot; could not be accessed from null..
        /// </summary>
        public static string ErrorValueAccessNull {
            get {
                return ResourceManager.GetString("ErrorValueAccessNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Attempted to retrieve value from instance of wrong type..
        /// </summary>
        public static string ExceptionAttemptedValueAccessForInstanceOfInvalidType {
            get {
                return ResourceManager.GetString("ExceptionAttemptedValueAccessForInstanceOfInvalidType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied bound type is not compatible with IComparable..
        /// </summary>
        public static string ExceptionBoundTypeNotIComparable {
            get {
                return ResourceManager.GetString("ExceptionBoundTypeNotIComparable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The string representing the bound value could not be converted to the bound type..
        /// </summary>
        public static string ExceptionCannotConvertBound {
            get {
                return ResourceManager.GetString("ExceptionCannotConvertBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to At most one range bound can be ignored..
        /// </summary>
        public static string ExceptionCannotIgnoreBothBoundariesInRange {
            get {
                return ResourceManager.GetString("ExceptionCannotIgnoreBothBoundariesInRange", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A message template has been set already, resource based message templates are not allowed..
        /// </summary>
        public static string ExceptionCannotSetResourceBasedMessageTemplatesIfTemplateIsSet {
            get {
                return ResourceManager.GetString("ExceptionCannotSetResourceBasedMessageTemplatesIfTemplateIsSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A message template resource has been set already; template override is not allowed..
        /// </summary>
        public static string ExceptionCannotSetResourceMessageTemplatesIfResourceTemplateIsSet {
            get {
                return ResourceManager.GetString("ExceptionCannotSetResourceMessageTemplatesIfResourceTemplateIsSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Enumerable contains null elements..
        /// </summary>
        public static string ExceptionContainsNullElements {
            get {
                return ResourceManager.GetString("ExceptionContainsNullElements", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property name required to retrieve validation information for integration is not found..
        /// </summary>
        public static string ExceptionIntegrationValidatedPropertyNameNotAvailable {
            get {
                return ResourceManager.GetString("ExceptionIntegrationValidatedPropertyNameNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property name required to retrieve validation information for integration is invalid or does not belong to a public property..
        /// </summary>
        public static string ExceptionIntegrationValidatedPropertyNotExists {
            get {
                return ResourceManager.GetString("ExceptionIntegrationValidatedPropertyNotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property name required to retrieve validation information for integration refers to nonreadable property..
        /// </summary>
        public static string ExceptionIntegrationValidatedPropertyNotReadable {
            get {
                return ResourceManager.GetString("ExceptionIntegrationValidatedPropertyNotReadable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type required to retrieve validation information for integration is not found..
        /// </summary>
        public static string ExceptionIntegrationValidatedTypeNotAvailable {
            get {
                return ResourceManager.GetString("ExceptionIntegrationValidatedTypeNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied string is not a valid date representation..
        /// </summary>
        public static string ExceptionInvalidDate {
            get {
                return ResourceManager.GetString("ExceptionInvalidDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The field &quot;{0}&quot; on type &quot;{1}&quot; is either missing or non public..
        /// </summary>
        public static string ExceptionInvalidField {
            get {
                return ResourceManager.GetString("ExceptionInvalidField", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The method &quot;{0}&quot; on type &quot;{1}&quot; is either missing, non public, void or has parameters..
        /// </summary>
        public static string ExceptionInvalidMethod {
            get {
                return ResourceManager.GetString("ExceptionInvalidMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The property &quot;{0}&quot; on type &quot;{1}&quot; is either missing, non public or read-only..
        /// </summary>
        public static string ExceptionInvalidProperty {
            get {
                return ResourceManager.GetString("ExceptionInvalidProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value to validate is not of the expected type: expected {0} but got {1} instead..
        /// </summary>
        public static string ExceptionInvalidTargetType {
            get {
                return ResourceManager.GetString("ExceptionInvalidTargetType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The lower bound cannot be null unless it&apos;s type is Ingore..
        /// </summary>
        public static string ExceptionLowerBoundNull {
            get {
                return ResourceManager.GetString("ExceptionLowerBoundNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method to access value does not have a return value..
        /// </summary>
        public static string ExceptionMethodHasNoReturnValue {
            get {
                return ResourceManager.GetString("ExceptionMethodHasNoReturnValue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Method to access value has parameters..
        /// </summary>
        public static string ExceptionMethodHasParameters {
            get {
                return ResourceManager.GetString("ExceptionMethodHasParameters", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The target element type has not been set in the configuration..
        /// </summary>
        public static string ExceptionObjectCollectionValidatorDataTargetTypeNotSet {
            get {
                return ResourceManager.GetString("ExceptionObjectCollectionValidatorDataTargetTypeNotSet", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Both resource name and resource type must be defined to retrieve the message template..
        /// </summary>
        public static string ExceptionPartiallyDefinedResourceForMessageTemplate {
            get {
                return ResourceManager.GetString("ExceptionPartiallyDefinedResourceForMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source property to request validators from does not exist..
        /// </summary>
        public static string ExceptionPropertyNotFound {
            get {
                return ResourceManager.GetString("ExceptionPropertyNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source property to request validators from is not readable..
        /// </summary>
        public static string ExceptionPropertyNotReadable {
            get {
                return ResourceManager.GetString("ExceptionPropertyNotReadable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to No public readable property with name &quot;{0}&quot; could be found for type &quot;{1}&quot;..
        /// </summary>
        public static string ExceptionPropertyToCompareNotFound {
            get {
                return ResourceManager.GetString("ExceptionPropertyToCompareNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The name for the property to compare is null for PropertyComparisonValidator..
        /// </summary>
        public static string ExceptionPropertyToCompareNull {
            get {
                return ResourceManager.GetString("ExceptionPropertyToCompareNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The self validation method has an invalid signature. It should be &quot;void [method name](ValidationResults)&quot;..
        /// </summary>
        public static string ExceptionSelfValidationMethodWithInvalidSignature {
            get {
                return ResourceManager.GetString("ExceptionSelfValidationMethodWithInvalidSignature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This method should not have been called..
        /// </summary>
        public static string ExceptionShouldNotCall {
            get {
                return ResourceManager.GetString("ExceptionShouldNotCall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The source type to request validators from has not been found..
        /// </summary>
        public static string ExceptionTypeNotFound {
            get {
                return ResourceManager.GetString("ExceptionTypeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Range bounds must have the same type..
        /// </summary>
        public static string ExceptionTypeOfBoundsMustMatch {
            get {
                return ResourceManager.GetString("ExceptionTypeOfBoundsMustMatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Upper bound cannot be lower than lower bound..
        /// </summary>
        public static string ExceptionUpperBoundLowerThanLowerBound {
            get {
                return ResourceManager.GetString("ExceptionUpperBoundLowerThanLowerBound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The upper bound cannot be null unless it&apos;s type is Ingore..
        /// </summary>
        public static string ExceptionUpperBoundNull {
            get {
                return ResourceManager.GetString("ExceptionUpperBoundNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value to validate is null but expected an instance of the non-reference type {0}..
        /// </summary>
        public static string ExceptionValidatingNullOnValueType {
            get {
                return ResourceManager.GetString("ExceptionValidatingNullOnValueType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A validation attribute of type {0} cannot be used to validate values..
        /// </summary>
        public static string ExceptionValidationAttributeNotSupported {
            get {
                return ResourceManager.GetString("ExceptionValidationAttributeNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value is not null and failed all its validation rules for key &quot;{1}&quot;..
        /// </summary>
        public static string IgnoreNullsDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("IgnoreNullsDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The InjectionValidationSource may only be used to configure generic Enterprise Library validator classes..
        /// </summary>
        public static string IllegalUseOfInjectionValidationSource {
            get {
                return ResourceManager.GetString("IllegalUseOfInjectionValidationSource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The ValidationDependencyAttribute was applied to a dependency of type {0}, which is a generic Enterprise Library validator class..
        /// </summary>
        public static string IllegalUseOfValidationDependencyAttribute {
            get {
                return ResourceManager.GetString("IllegalUseOfValidationDependencyAttribute", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Validation Specification Source {0} is invalid..
        /// </summary>
        public static string InvalidValidationSpecificationSource {
            get {
                return ResourceManager.GetString("InvalidValidationSpecificationSource", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to InvariantCulture cannot be used to deserialize configuration..
        /// </summary>
        public static string InvariantCultureCannotBeUsedToDeserializeConfiguration {
            get {
                return ResourceManager.GetString("InvariantCultureCannotBeUsedToDeserializeConfiguration", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The operation must be implemented by a subclass..
        /// </summary>
        public static string MustImplementOperation {
            get {
                return ResourceManager.GetString("MustImplementOperation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be null..
        /// </summary>
        public static string NonNullNegatedValidatorDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("NonNullNegatedValidatorDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value cannot be null..
        /// </summary>
        public static string NonNullNonNegatedValidatorDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("NonNullNonNegatedValidatorDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The element in the validated collection is not compatible with the expected type..
        /// </summary>
        public static string ObjectCollectionValidatorIncompatibleElementInTargetCollection {
            get {
                return ResourceManager.GetString("ObjectCollectionValidatorIncompatibleElementInTargetCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied object is not a collection..
        /// </summary>
        public static string ObjectCollectionValidatorTargetNotCollection {
            get {
                return ResourceManager.GetString("ObjectCollectionValidatorTargetNotCollection", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The supplied object is not compatible with the expected type..
        /// </summary>
        public static string ObjectValidatorInvalidTargetType {
            get {
                return ResourceManager.GetString("ObjectValidatorInvalidTargetType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to All validators failed for key &quot;{1}&quot;..
        /// </summary>
        public static string OrCompositeValidatorDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("OrCompositeValidatorDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6})..
        /// </summary>
        public static string RangeValidatorNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RangeValidatorNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6})..
        /// </summary>
        public static string RangeValidatorNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RangeValidatorNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not match the regular expression &quot;{3}&quot; with options &quot;{4}&quot;..
        /// </summary>
        public static string RegexValidatorNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RegexValidatorNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must match the regular expression &quot;{3}&quot; with options &quot;{4}&quot;..
        /// </summary>
        public static string RegexValidatorNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RegexValidatorNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6}) relative to now..
        /// </summary>
        public static string RelativeDateTimeNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RelativeDateTimeNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6}) relative to now..
        /// </summary>
        public static string RelativeDateTimeNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("RelativeDateTimeNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to It&apos;s not possible to specify a None DateTime unit if a BoundaryType different from Ignore is used..
        /// </summary>
        public static string RelativeDateTimeValidatorNotValidDateTimeUnit {
            get {
                return ResourceManager.GetString("RelativeDateTimeValidatorNotValidDateTimeUnit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The self validation method thrown an exception while evaluating..
        /// </summary>
        public static string SelfValidationMethodThrownMessage {
            get {
                return ResourceManager.GetString("SelfValidationMethodThrownMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The reference provided to the self validation method is either null or references an instance of a non-compatible type..
        /// </summary>
        public static string SelfValidationValidatorMessage {
            get {
                return ResourceManager.GetString("SelfValidationValidatorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length of the value must not fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6})..
        /// </summary>
        public static string StringLengthValidatorNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("StringLengthValidatorNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The length of the value must fall within the range &quot;{3}&quot; ({4}) - &quot;{5}&quot; ({6})..
        /// </summary>
        public static string StringLengthValidatorNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("StringLengthValidatorNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must not be convertible to type &quot;{3}&quot;..
        /// </summary>
        public static string TypeConversionNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("TypeConversionNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value must be convertible to type &quot;{3}&quot;..
        /// </summary>
        public static string TypeConversionNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("TypeConversionNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validation using {0} threw an exception: {1}.
        /// </summary>
        public static string ValidationAttributeFailed {
            get {
                return ResourceManager.GetString("ValidationAttributeFailed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Parameter validation failed.
        /// </summary>
        public static string ValidationFailedMessage {
            get {
                return ResourceManager.GetString("ValidationFailedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Validation results:.
        /// </summary>
        public static string ValidationResultsHeader {
            get {
                return ResourceManager.GetString("ValidationResultsHeader", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     Result: {0} Message: {1}.
        /// </summary>
        public static string ValidationResultTemplate {
            get {
                return ResourceManager.GetString("ValidationResultTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to     Result: {0} Key: {2} Message: {1}.
        /// </summary>
        public static string ValidationResultWithKeyTemplate {
            get {
                return ResourceManager.GetString("ValidationResultWithKeyTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failure to retrieve comparand for key &quot;{0}&quot;: {1}..
        /// </summary>
        public static string ValueAccessComparisonValidatorFailureToRetrieveComparand {
            get {
                return ResourceManager.GetString("ValueAccessComparisonValidatorFailureToRetrieveComparand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value should not have succeeded in the comparison with value for key &quot;{4}&quot; using operator &quot;{5}&quot;..
        /// </summary>
        public static string ValueAccessComparisonValidatorNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("ValueAccessComparisonValidatorNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The value failed the comparison with value for key &quot;{4}&quot; using operator &quot;{5}&quot;..
        /// </summary>
        public static string ValueAccessComparisonValidatorNonNegatedDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("ValueAccessComparisonValidatorNonNegatedDefaultMessageTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Value Validator.
        /// </summary>
        public static string ValueValidatorDefaultMessageTemplate {
            get {
                return ResourceManager.GetString("ValueValidatorDefaultMessageTemplate", resourceCulture);
            }
        }
    }
}
