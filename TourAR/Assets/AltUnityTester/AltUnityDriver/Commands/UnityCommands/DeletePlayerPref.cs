public class DeletePlayerPref : AltBaseCommand
{
    public DeletePlayerPref(SocketSettings socketSettings) : base(socketSettings)
    {
    }
    public void Execute()
    {
        Socket.Client.Send(toBytes(CreateCommand("deletePlayerPref")));
        var data = Recvall();
        if (data.Equals("Ok"))
            return;
        HandleErrors(data);
    }
}