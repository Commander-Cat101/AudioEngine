using Exiled.API.Features;
using PluginAPI.Events;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoiceChat;

namespace AudioEngine.API
{
    public static class Sounds
    {
        public static void PlayAudioFromFile(string path, bool loop = false, float volume = 100, VoiceChatChannel channel = (VoiceChatChannel)6, int id = 99)
        {
            string fileloc = Path.Combine(Main.Instance.Config.AudioFilePath, path);
            fileloc += ".ogg";

            if (Main.Instance.Connections.TryGetValue(id, out Connection hub))
            {
                var audioPlayer = hub.audioplayer;
                audioPlayer.BroadcastChannel = channel;
                audioPlayer.Volume = hub.Volume;
                audioPlayer.Loop = hub.Loop;
                audioPlayer.Shuffle = false;
                audioPlayer.Continue = false;
                audioPlayer.LogDebug = false; //Welcome to Error spam ZONE!
                audioPlayer.Enqueue(fileloc, -1);
                audioPlayer.Play(0);
            }
        }
    }
}
