using Mirror;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCPSLAudioApi.AudioCore;

namespace AudioEngine.API
{
    public class Connection
    {
        public NetworkIdentity fakeConnection { get; set; }
        public ReferenceHub hubPlayer { get; set; }
        public AudioPlayerBase audioplayer { get; set; }
        public string BotName { get; set; }
        public int BotID { get; set; }

        public int Volume { get; set; }

        public bool Loop { get; set; }
    }
}
