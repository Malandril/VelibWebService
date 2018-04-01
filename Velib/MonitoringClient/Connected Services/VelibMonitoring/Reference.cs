﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VelibMonitoringClient.VelibMonitoring {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="VelibMonitoring.IMonitoring")]
    public interface IMonitoring {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNbClientCalls", ReplyAction="http://tempuri.org/IMonitoring/GetNbClientCallsResponse")]
        int GetNbClientCalls(int n);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNbClientCalls", ReplyAction="http://tempuri.org/IMonitoring/GetNbClientCallsResponse")]
        System.Threading.Tasks.Task<int> GetNbClientCallsAsync(int n);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNbDistantRequest", ReplyAction="http://tempuri.org/IMonitoring/GetNbDistantRequestResponse")]
        int GetNbDistantRequest(int n);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNbDistantRequest", ReplyAction="http://tempuri.org/IMonitoring/GetNbDistantRequestResponse")]
        System.Threading.Tasks.Task<int> GetNbDistantRequestAsync(int n);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNamesOfCachedItems", ReplyAction="http://tempuri.org/IMonitoring/GetNamesOfCachedItemsResponse")]
        string[] GetNamesOfCachedItems();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMonitoring/GetNamesOfCachedItems", ReplyAction="http://tempuri.org/IMonitoring/GetNamesOfCachedItemsResponse")]
        System.Threading.Tasks.Task<string[]> GetNamesOfCachedItemsAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMonitoringChannel : VelibMonitoringClient.VelibMonitoring.IMonitoring, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MonitoringClient : System.ServiceModel.ClientBase<VelibMonitoringClient.VelibMonitoring.IMonitoring>, VelibMonitoringClient.VelibMonitoring.IMonitoring {
        
        public MonitoringClient() {
        }
        
        public MonitoringClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MonitoringClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonitoringClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MonitoringClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int GetNbClientCalls(int n) {
            return base.Channel.GetNbClientCalls(n);
        }
        
        public System.Threading.Tasks.Task<int> GetNbClientCallsAsync(int n) {
            return base.Channel.GetNbClientCallsAsync(n);
        }
        
        public int GetNbDistantRequest(int n) {
            return base.Channel.GetNbDistantRequest(n);
        }
        
        public System.Threading.Tasks.Task<int> GetNbDistantRequestAsync(int n) {
            return base.Channel.GetNbDistantRequestAsync(n);
        }
        
        public string[] GetNamesOfCachedItems() {
            return base.Channel.GetNamesOfCachedItems();
        }
        
        public System.Threading.Tasks.Task<string[]> GetNamesOfCachedItemsAsync() {
            return base.Channel.GetNamesOfCachedItemsAsync();
        }
    }
}
