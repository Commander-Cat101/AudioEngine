using AudioEngine.API;
using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEngine.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class PlaySound : ICommand
    {
        public string Command { get; } = "play";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Plays a sound";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }
                

            if (arguments.Count <= 1)
            {
                response = "Not enough args: .play {id} {clipname}";
                return false;
            }
            string path = string.Join(" ", arguments.Where(x => arguments.At(0) != x));

            if (Main.Instance.Connections.TryGetValue(int.Parse(arguments.At(0)), out Connection value))
            {
                Sounds.PlayAudioFromFile(path, id: int.Parse(arguments.At(0)));
            }

            response = "Played";
            return true;
        }
    }
}
