﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 16.0.31613.86
// 
namespace Finite_Element_Analysis_Explorer.FEAE {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.intacomputers.com/Services/FEAE/", ConfigurationName="FEAE.FEAESoap")]
    public interface FEAESoap {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.intacomputers.com/Services/FEAE/ReportError", ReplyAction="*")]
        System.Threading.Tasks.Task<Finite_Element_Analysis_Explorer.FEAE.ReportErrorResponse> ReportErrorAsync(Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.intacomputers.com/Services/FEAE/ReportSession", ReplyAction="*")]
        System.Threading.Tasks.Task ReportSessionAsync(System.DateTime start, System.DateTime finish);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.intacomputers.com/Services/FEAE/ReportSession2", ReplyAction="*")]
        System.Threading.Tasks.Task ReportSession2Async(System.DateTime start, System.DateTime finish, bool isDebug);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.intacomputers.com/Services/FEAE/ReportSessionStart", ReplyAction="*")]
        System.Threading.Tasks.Task ReportSessionStartAsync();
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReportErrorRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReportError", Namespace="http://www.intacomputers.com/Services/FEAE/", Order=0)]
        public Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequestBody Body;
        
        public ReportErrorRequest() {
        }
        
        public ReportErrorRequest(Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://www.intacomputers.com/Services/FEAE/")]
    public partial class ReportErrorRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public int hResult;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string message;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string stackTrace;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=3)]
        public string targetSite;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=4)]
        public string source;
        
        public ReportErrorRequestBody() {
        }
        
        public ReportErrorRequestBody(int hResult, string message, string stackTrace, string targetSite, string source) {
            this.hResult = hResult;
            this.message = message;
            this.stackTrace = stackTrace;
            this.targetSite = targetSite;
            this.source = source;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ReportErrorResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ReportErrorResponse", Namespace="http://www.intacomputers.com/Services/FEAE/", Order=0)]
        public Finite_Element_Analysis_Explorer.FEAE.ReportErrorResponseBody Body;
        
        public ReportErrorResponse() {
        }
        
        public ReportErrorResponse(Finite_Element_Analysis_Explorer.FEAE.ReportErrorResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class ReportErrorResponseBody {
        
        public ReportErrorResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface FEAESoapChannel : Finite_Element_Analysis_Explorer.FEAE.FEAESoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class FEAESoapClient : System.ServiceModel.ClientBase<Finite_Element_Analysis_Explorer.FEAE.FEAESoap>, Finite_Element_Analysis_Explorer.FEAE.FEAESoap {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public FEAESoapClient() : 
                base(FEAESoapClient.GetDefaultBinding(), FEAESoapClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.FEAESoap.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FEAESoapClient(EndpointConfiguration endpointConfiguration) : 
                base(FEAESoapClient.GetBindingForEndpoint(endpointConfiguration), FEAESoapClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FEAESoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FEAESoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FEAESoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FEAESoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FEAESoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Finite_Element_Analysis_Explorer.FEAE.ReportErrorResponse> Finite_Element_Analysis_Explorer.FEAE.FEAESoap.ReportErrorAsync(Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequest request) {
            return base.Channel.ReportErrorAsync(request);
        }
        
        public System.Threading.Tasks.Task<Finite_Element_Analysis_Explorer.FEAE.ReportErrorResponse> ReportErrorAsync(int hResult, string message, string stackTrace, string targetSite, string source) {
            Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequest inValue = new Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequest();
            inValue.Body = new Finite_Element_Analysis_Explorer.FEAE.ReportErrorRequestBody();
            inValue.Body.hResult = hResult;
            inValue.Body.message = message;
            inValue.Body.stackTrace = stackTrace;
            inValue.Body.targetSite = targetSite;
            inValue.Body.source = source;
            return ((Finite_Element_Analysis_Explorer.FEAE.FEAESoap)(this)).ReportErrorAsync(inValue);
        }
        
        public System.Threading.Tasks.Task ReportSessionAsync(System.DateTime start, System.DateTime finish) {
            return base.Channel.ReportSessionAsync(start, finish);
        }
        
        public System.Threading.Tasks.Task ReportSession2Async(System.DateTime start, System.DateTime finish, bool isDebug) {
            return base.Channel.ReportSession2Async(start, finish, isDebug);
        }
        
        public System.Threading.Tasks.Task ReportSessionStartAsync() {
            return base.Channel.ReportSessionStartAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.FEAESoap)) {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.FEAESoap)) {
                return new System.ServiceModel.EndpointAddress("http://www.intacomputers.com/Services/FEAE.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return FEAESoapClient.GetBindingForEndpoint(EndpointConfiguration.FEAESoap);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return FEAESoapClient.GetEndpointAddress(EndpointConfiguration.FEAESoap);
        }
        
        public enum EndpointConfiguration {
            
            FEAESoap,
        }
    }
}
