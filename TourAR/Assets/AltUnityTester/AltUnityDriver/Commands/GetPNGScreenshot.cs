
    public class GetPNGScreenshot: AltBaseCommand
    {
        string path;
        public GetPNGScreenshot(SocketSettings socketSettings,string path) : base(socketSettings)
        {
            this.path = path;
        }
        public void Execute()
        {
            Socket.Client.Send(toBytes(CreateCommand("getPNGScreenshot")));
            var message=Recvall();
            string screenshotData="";
            if (message == "Ok")
            {
                screenshotData = Recvall();
            }
            System.IO.File.WriteAllBytes(path, System.Convert.FromBase64String(screenshotData));
        }
    }
