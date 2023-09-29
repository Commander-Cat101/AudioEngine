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
    public class Name : ICommand
    {
        public string Command { get; } = "name";

        public string[] Aliases { get; } = new string[] { string.Empty };

        public string Description { get; } = "Changes the name of a dummy";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Main.Instance.Config.Perms.Any(a => a == Player.Get(sender).GroupName))
            {
                response = "No Permissions";
                return false;
            }


            if (arguments.Count <= 1)
            {
                response = "Not enough args: .name {id} {name}";
                return false;
            }

            if (Main.Instance.Connections.TryGetValue(int.Parse(arguments.At(0)), out Connection value))
            {
                value.BotName = value.hubPlayer.nicknameSync.Network_myNickSync = arguments.At(1);
            }

            response = "Changed Name";
            return true;
        }
    }
}
