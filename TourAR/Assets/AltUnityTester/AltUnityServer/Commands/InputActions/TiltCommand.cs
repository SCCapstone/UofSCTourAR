﻿namespace Assets.AltUnityTester.AltUnityServer.Commands
{
    class TiltCommand:Command
    {
        UnityEngine.Vector3 acceleration;

        public TiltCommand(UnityEngine.Vector3 acceleration)
        {
            this.acceleration = acceleration;
        }

        public override string Execute()
        {
#if ALTUNITYTESTER
            AltUnityRunner._altUnityRunner.LogMessage("Tilt device with: " + acceleration);
            Input.acceleration = acceleration;
            return "OK";
#endif
            return null;
        }
    }
}
