using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IRepoConfig
    {
        public Config Load(string path);
        public void Save(Config config);
    }
}
