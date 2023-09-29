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
    public class SpawnBot : ICommand
    {
        public string Command { get; } = "spawndummy";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Spawns a dummy";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }

            if (arguments.Count <= 0)
            {
                response = "Not enough args: .spawndummy {id}";
                return false;
            }

            Dummy.SpawnDummy(int.Parse(arguments.At(0)));

            response = "Spawned Dummy";
            return true;
        }
    }
}
