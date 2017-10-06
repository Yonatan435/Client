﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IServer", CallbackContract=typeof(IServerCallback))]
public interface IServer
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Authenticate", ReplyAction="http://tempuri.org/IServer/AuthenticateResponse")]
    bool Authenticate(string userName, string password);
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServer/Authenticate", ReplyAction="http://tempuri.org/IServer/AuthenticateResponse")]
    System.Threading.Tasks.Task<bool> AuthenticateAsync(string userName, string password);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StartDataTransfer")]
    void StartDataTransfer();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StartDataTransfer")]
    System.Threading.Tasks.Task StartDataTransferAsync();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StopDataTransfer")]
    void StopDataTransfer();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/StopDataTransfer")]
    System.Threading.Tasks.Task StopDataTransferAsync();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/Logout")]
    void Logout();
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/Logout")]
    System.Threading.Tasks.Task LogoutAsync();
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerCallback
{
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/ReceiveInt")]
    void ReceiveInt(int number);
    
    [System.ServiceModel.OperationContractAttribute(IsOneWay=true, Action="http://tempuri.org/IServer/ReceiveData")]
    void ReceiveData(byte[] data);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public interface IServerChannel : IServer, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
public partial class ServerClient : System.ServiceModel.DuplexClientBase<IServer>, IServer
{
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance) : 
            base(callbackInstance)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) : 
            base(callbackInstance, endpointConfigurationName)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, endpointConfigurationName, remoteAddress)
    {
    }
    
    public ServerClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(callbackInstance, binding, remoteAddress)
    {
    }
    
    public bool Authenticate(string userName, string password)
    {
        return base.Channel.Authenticate(userName, password);
    }
    
    public System.Threading.Tasks.Task<bool> AuthenticateAsync(string userName, string password)
    {
        return base.Channel.AuthenticateAsync(userName, password);
    }
    
    public void StartDataTransfer()
    {
        base.Channel.StartDataTransfer();
    }
    
    public System.Threading.Tasks.Task StartDataTransferAsync()
    {
        return base.Channel.StartDataTransferAsync();
    }
    
    public void StopDataTransfer()
    {
        base.Channel.StopDataTransfer();
    }
    
    public System.Threading.Tasks.Task StopDataTransferAsync()
    {
        return base.Channel.StopDataTransferAsync();
    }
    
    public void Logout()
    {
        base.Channel.Logout();
    }
    
    public System.Threading.Tasks.Task LogoutAsync()
    {
        return base.Channel.LogoutAsync();
    }
}
