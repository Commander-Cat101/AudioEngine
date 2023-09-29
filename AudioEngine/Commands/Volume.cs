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
    public class Volume : ICommand
    {
        public string Command { get; } = "volume";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Changes the volume of a bot";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }


            if (arguments.Count <= 1)
            {
                response = "Not enough args: .volume {id} {volume}";
                return false;
            }

            if (Main.Instance.Connections.TryGetValue(int.Parse(arguments.At(0)), out Connection value))
            {
                value.Volume = int.Parse(arguments.At(1));
            }

            response = "Changed Volume";
            return true;
        }
    }
}
