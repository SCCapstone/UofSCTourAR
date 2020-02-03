public class GetCurrentScene : AltBaseCommand
{
    public GetCurrentScene(SocketSettings socketSettings) : base(socketSettings)
    {
    }
    public string Execute(){
        Socket.Client.Send(toBytes(CreateCommand("getCurrentScene")));
        string data = Recvall();
        if (!data.Contains("error:")) return Newtonsoft.Json.JsonConvert.DeserializeObject<AltUnityObject>(data).name;
        HandleErrors(data);
        return null;
    }
}