using AudioEngine.API;
using CommandSystem;
using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEngine.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class StopSound : ICommand
    {
        public string Command { get; } = "stop";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Plays a sound";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }

            if (arguments.Count <= 0)
            {
                response = "Not enough args: .stop {id}";
                return false;
            }

            if (Main.Instance.Connections.TryGetValue(int.Parse(arguments.At(0)), out Connection value))
            {
                value.audioplayer.Stoptrack(true);
            }


            response = "Stopped";
            return true;
        }
    }
}
