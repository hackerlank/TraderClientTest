﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.239
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.239.
// 
#pragma warning disable 1591

namespace WindowsFormsApplication2.localhost {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="FaxEmailServiceSoap", Namespace="http://tempuri.org/")]
    public partial class FaxEmailService : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback NotifyOrderExecutedOperationCompleted;
        
        private System.Threading.SendOrPostCallback NotifyResetStatementOperationCompleted;
        
        private System.Threading.SendOrPostCallback NotifyRiskLevelChangedOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public FaxEmailService() {
            this.Url = global::WindowsFormsApplication2.Properties.Settings.Default.WindowsFormsApplication2_localhost_FaxEmailService;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event NotifyOrderExecutedCompletedEventHandler NotifyOrderExecutedCompleted;
        
        /// <remarks/>
        public event NotifyResetStatementCompletedEventHandler NotifyResetStatementCompleted;
        
        /// <remarks/>
        public event NotifyRiskLevelChangedCompletedEventHandler NotifyRiskLevelChangedCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NotifyOrderExecuted", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void NotifyOrderExecuted(System.Guid orderId) {
            this.Invoke("NotifyOrderExecuted", new object[] {
                        orderId});
        }
        
        /// <remarks/>
        public void NotifyOrderExecutedAsync(System.Guid orderId) {
            this.NotifyOrderExecutedAsync(orderId, null);
        }
        
        /// <remarks/>
        public void NotifyOrderExecutedAsync(System.Guid orderId, object userState) {
            if ((this.NotifyOrderExecutedOperationCompleted == null)) {
                this.NotifyOrderExecutedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyOrderExecutedOperationCompleted);
            }
            this.InvokeAsync("NotifyOrderExecuted", new object[] {
                        orderId}, this.NotifyOrderExecutedOperationCompleted, userState);
        }
        
        private void OnNotifyOrderExecutedOperationCompleted(object arg) {
            if ((this.NotifyOrderExecutedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyOrderExecutedCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NotifyResetStatement", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void NotifyResetStatement(System.DateTime tradeDay) {
            this.Invoke("NotifyResetStatement", new object[] {
                        tradeDay});
        }
        
        /// <remarks/>
        public void NotifyResetStatementAsync(System.DateTime tradeDay) {
            this.NotifyResetStatementAsync(tradeDay, null);
        }
        
        /// <remarks/>
        public void NotifyResetStatementAsync(System.DateTime tradeDay, object userState) {
            if ((this.NotifyResetStatementOperationCompleted == null)) {
                this.NotifyResetStatementOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyResetStatementOperationCompleted);
            }
            this.InvokeAsync("NotifyResetStatement", new object[] {
                        tradeDay}, this.NotifyResetStatementOperationCompleted, userState);
        }
        
        private void OnNotifyResetStatementOperationCompleted(object arg) {
            if ((this.NotifyResetStatementCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyResetStatementCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/NotifyRiskLevelChanged", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public void NotifyRiskLevelChanged(System.Guid accountId, System.DateTime tradeDay, int riskLevel) {
            this.Invoke("NotifyRiskLevelChanged", new object[] {
                        accountId,
                        tradeDay,
                        riskLevel});
        }
        
        /// <remarks/>
        public void NotifyRiskLevelChangedAsync(System.Guid accountId, System.DateTime tradeDay, int riskLevel) {
            this.NotifyRiskLevelChangedAsync(accountId, tradeDay, riskLevel, null);
        }
        
        /// <remarks/>
        public void NotifyRiskLevelChangedAsync(System.Guid accountId, System.DateTime tradeDay, int riskLevel, object userState) {
            if ((this.NotifyRiskLevelChangedOperationCompleted == null)) {
                this.NotifyRiskLevelChangedOperationCompleted = new System.Threading.SendOrPostCallback(this.OnNotifyRiskLevelChangedOperationCompleted);
            }
            this.InvokeAsync("NotifyRiskLevelChanged", new object[] {
                        accountId,
                        tradeDay,
                        riskLevel}, this.NotifyRiskLevelChangedOperationCompleted, userState);
        }
        
        private void OnNotifyRiskLevelChangedOperationCompleted(object arg) {
            if ((this.NotifyRiskLevelChangedCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.NotifyRiskLevelChangedCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void NotifyOrderExecutedCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void NotifyResetStatementCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.0.30319.1")]
    public delegate void NotifyRiskLevelChangedCompletedEventHandler(object sender, System.ComponentModel.AsyncCompletedEventArgs e);
}

#pragma warning restore 1591