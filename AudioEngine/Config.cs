using Exiled.API.Features;
using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioEngine
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
        public string AudioFilePath { get; set; } = Path.Combine(Paths.Configs, @"AudioEngine");

        public List<string> Perms { get; set; } = new List<string>()
        {
            "owner", "pluginteam", "headofstaff"
        };
    }
}
