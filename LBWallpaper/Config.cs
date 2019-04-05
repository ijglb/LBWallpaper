using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBWallpaper
{
    public class Config
    {
        public int ChangeInterval { get; set; } = 60 * 5 * 1000;

        public int CacheSize { get; set; } = 100;

        public string SpecailWallpaper { get; set; }

        public bool IsSpecailWallpaper { get; set; } = false;

        private string _ConfigPath { get { return Path.Combine(Application.UserAppDataPath, "config.json"); } }

        public void ReadConfig()
        {
            if (!File.Exists(_ConfigPath))
            {
                WriteConfig();
            }
            else
            {
                var temp = JsonConvert.DeserializeObject<Config>(File.ReadAllText(_ConfigPath));
                this.ChangeInterval = temp.ChangeInterval;
            }
        }

        public void WriteConfig()
        {
            File.WriteAllText(_ConfigPath, JsonConvert.SerializeObject(this));
        }
    }
}
