public class PointerDownFromObject : CommandReturningAltElement
{
    AltUnityObject altUnityObject;
    public PointerDownFromObject(SocketSettings socketSettings, AltUnityObject altUnityObject) : base(socketSettings)
    {
        this.altUnityObject = altUnityObject;
    }
    public AltUnityObject Execute()
    {
        string altObject = Newtonsoft.Json.JsonConvert.SerializeObject(altUnityObject);
        Socket.Client.Send(System.Text.Encoding.ASCII.GetBytes(CreateCommand("pointerDownFromObject", altObject)));
        return ReceiveAltUnityObject();
    }
}