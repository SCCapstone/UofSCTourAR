public class FindElementsByComponent : CommandReturningAltElement
{
    string componentName;
    string assemblyName;
    string cameraName;
    bool enabled;
    public FindElementsByComponent(SocketSettings socketSettings, string componentName, string assemblyName, string cameraName, bool enabled) : base(socketSettings)
    {
        this.componentName = componentName;
        this.assemblyName = assemblyName;
        this.cameraName = cameraName;
        this.enabled = enabled;
    }
    public System.Collections.Generic.List<AltUnityObject> Execute()
    {
        Socket.Client.Send(toBytes(CreateCommand("findObjectsByComponent", assemblyName, componentName, cameraName, enabled.ToString())));
        return ReceiveListOfAltUnityObjects();
    }
}