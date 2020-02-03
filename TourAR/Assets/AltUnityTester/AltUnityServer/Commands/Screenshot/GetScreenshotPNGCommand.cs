using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class GetScreenshotPNGCommand:Command
    {
        AltClientSocketHandler handler;

        public GetScreenshotPNGCommand(AltClientSocketHandler handler)
        {
            this.handler = handler;
        }

        public override string Execute()
        {
            AltUnityRunner._altUnityRunner.LogMessage("getScreenshotPNG");
            AltUnityRunner._altUnityRunner.StartCoroutine(AltUnityRunner._altUnityRunner.TakeScreenshot(handler));
            return "Ok";
        }
    }
}
