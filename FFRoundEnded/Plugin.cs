using Exiled.API.Features;
using System.Runtime.InteropServices;
using System;


namespace FFRoundEnded
{
    public class Plugin : Plugin<Config>
    {
        public EventHandler Event;
        public static Plugin Instance { get; private set; } = new();
        public override void OnEnabled()
        {
            Event = new EventHandler(this);

            Exiled.Events.Handlers.Server.RoundEnded += Event.OnEndRound;
            Exiled.Events.Handlers.Player.Died += Event.OnPlayerDied;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Server.RoundEnded -= Event.OnEndRound;
            Exiled.Events.Handlers.Player.Died -= Event.OnPlayerDied;
            Event = null;
            base.OnDisabled();
        }
    }
}
