using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using PlayerRoles;
using SCPSLAudioApi.AudioCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEngine
{
    public class EventHandler
    {
        internal void OnGenerated()
        {
            if (Main.Instance.Connections != null)
                Main.Instance.Connections.Clear();
        }
        internal void OnFinishedTrack(AudioPlayerBase playerBase, string track, bool directPlay, ref int nextQueuePos)
        {
            var connection = Main.Instance.Connections.First(a => a.Value.audioplayer == playerBase);
            
            if (connection.Value.Loop)
            {
                playerBase.Enqueue(track, -1);
                playerBase.Play(0);
            }
        }
        internal void Spawned(ChangingRoleEventArgs args)
        {
            if (Main.Instance.Connections.Any(a => Player.Get(a.Value.hubPlayer) == args.Player))
            {
                args.IsAllowed = false;
                
            }
        }
        internal void EndRound(EndingRoundEventArgs args)
        {
            if (args.IsRoundEnded)
            {
                foreach (var connection in Main.Instance.Connections)
                {
                    if (Player.TryGet(connection.Value.hubPlayer, out Player player))
                    {
                        connection.Value.audioplayer.Stoptrack(true);
                       
                        player.Disconnect();
                    }
                }
            }
        }
    }
}
