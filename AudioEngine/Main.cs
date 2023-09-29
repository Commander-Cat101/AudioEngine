using AudioEngine.API;
using Exiled.API.Features;
using Exiled.API.Features.Components;
using SCPSLAudioApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AudioEngine
{
    public class Main : Plugin<Config>
    {
        public override string Name => "AudioEngine";

        public override string Author => "Commander__Cat";

        public static Main Instance;

        public Dictionary<int, Connection> Connections = new Dictionary<int, Connection>();

        EventHandler handler;
        public override void OnEnabled()
        {
            handler = new EventHandler();
            Instance = this;
            Files.CheckForFiles();
            Exiled.Events.Handlers.Map.Generated += handler.OnGenerated;
            Exiled.Events.Handlers.Player.ChangingRole += handler.Spawned;
            Exiled.Events.Handlers.Server.EndingRound += handler.EndRound;

            SCPSLAudioApi.AudioCore.AudioPlayerBase.OnFinishedTrack += handler.OnFinishedTrack;
            Startup.SetupDependencies();
        }
        public override void OnDisabled()
        {
            Instance = null;
            Exiled.Events.Handlers.Map.Generated -= handler.OnGenerated;
            Exiled.Events.Handlers.Player.ChangingRole -= handler.Spawned;
            Exiled.Events.Handlers.Server.EndingRound -= handler.EndRound;

            SCPSLAudioApi.AudioCore.AudioPlayerBase.OnFinishedTrack -= handler.OnFinishedTrack;
        }
        
    }
}
