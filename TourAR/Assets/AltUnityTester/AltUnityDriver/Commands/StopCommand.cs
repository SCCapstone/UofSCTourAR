public class StopCommand : AltBaseCommand
{
    public StopCommand(SocketSettings socketSettings) : base(socketSettings)
    {
    }
    public void Execute(){
        Socket.Client.Send(toBytes(CreateCommand("closeConnection")));
        System.Threading.Thread.Sleep(1000);
        Socket.Close();
    }
}