using Exiled.API.Features;
using System.Runtime.InteropServices;
using System;


namespace FFRoundEnded
{
    public class Plugin : Plugin<Config>
    {
        public EventHandler Event;
        public override void OnEnabled()
        {
            Event = new EventHandler(this);

            Exiled.Events.Handlers.Server.RoundEnded += Event.OnEndRound;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= Event.OnEndRound;
            Event = null;
            base.OnDisabled();
        }
    }
}
