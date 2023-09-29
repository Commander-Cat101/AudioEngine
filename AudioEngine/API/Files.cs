using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Playables;

namespace AudioEngine.API
{
    public static class Files
    {
        public static void CheckForFiles()
        {
            if (!Directory.Exists(Main.Instance.Config.AudioFilePath))
            {
                Directory.CreateDirectory(Main.Instance.Config.AudioFilePath);
            }
        }
    }
}
