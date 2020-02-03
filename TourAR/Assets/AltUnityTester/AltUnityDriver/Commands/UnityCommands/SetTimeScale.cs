public class SetTimeScale : AltBaseCommand
{
    float timeScale;

    public SetTimeScale(SocketSettings socketSettings, float timescale) : base(socketSettings)
    {
        this.timeScale = timescale;
    }
    public void Execute()
    {
        Socket.Client.Send(toBytes(CreateCommand("setTimeScale", Newtonsoft.Json.JsonConvert.SerializeObject(timeScale))));
        var data = Recvall();
        if (data.Equals("Ok"))
            return;
        HandleErrors(data);

    }
}