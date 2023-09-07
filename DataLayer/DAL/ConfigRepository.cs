using DAL;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class ConfigRepository
    {
        public ConfigRepository(){}

        public Config Load(string path) => Config.LoadConfig(path);
        
        public void Save(Config config) => Config.SaveConfig(config);
        
    }
}
