using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFRoundEnded
{
    public class EventHandler
    {
        private readonly Plugin plugin;
        public EventHandler(Plugin plugin) => this.plugin = plugin;
        public void OnEndRound(RoundEndedEventArgs ev)
        {
            Server.FriendlyFire = true;
        }
    }
}
