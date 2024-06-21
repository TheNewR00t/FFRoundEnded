using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
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
        private Dictionary<Player, int> killCounts = new Dictionary<Player, int>();
        public void OnEndRound(RoundEndedEventArgs ev)
        {
            
            Server.FriendlyFire = true;

            if (killCounts.Count > 0)
            {
                var topKiller = GetTopKiller();
                if (topKiller != null)
                {
                    foreach (Player player in Player.List)
                    {
                        player.Broadcast(50, $"<color=red>{Plugin.Instance.Config.MVP1} {topKiller.Nickname} {Plugin.Instance.Config.MVP2} {killCounts[topKiller]} {Plugin.Instance.Config.MVP3}</color>");
                    }
                }
            }
            killCounts.Clear();
        }

        public void OnPlayerDied(DiedEventArgs ev)
        {
            if (ev.Attacker != null)
            {
                if (killCounts.ContainsKey(ev.Attacker))
                {
                    killCounts[ev.Attacker]++;
                }
                else
                {
                    killCounts[ev.Attacker] = 1;
                }
            }
        }
        private Player GetTopKiller()
        {
            Player topKiller = null;
            int maxKills = 0;

            foreach (var kvp in killCounts)
            {
                if (kvp.Value > maxKills)
                {
                    topKiller = kvp.Key;
                    maxKills = kvp.Value;
                }
            }

            return topKiller;
        }
    }
}
