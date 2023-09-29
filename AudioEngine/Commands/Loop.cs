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
    public class Loop : ICommand
    {
        public string Command { get; } = "loop";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Toggles looping for a bot";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }


            if (arguments.Count <= 0)
            {
                response = "Not enough args: .loop {id}";
                return false;
            }

            if (Main.Instance.Connections.TryGetValue(int.Parse(arguments.At(0)), out Connection value))
            {
                switch (value.Loop)
                {
                    case true:
                        value.Loop = false;
                        break;
                    case false:
                        value.Loop = true;
                        break;
                }
            }

            response = "Toggled Loop";
            return true;
        }
    }
}
