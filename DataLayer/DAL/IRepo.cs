using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public interface IRepo
    {
        public Task Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType, string FavoriteRepFifaCode);
    }
}
