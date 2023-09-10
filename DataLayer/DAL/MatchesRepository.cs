using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class MatchesRepository
    {
        public MatchesRepository() { }

        public async Task<List<Matches>> Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ?
                (path + Player.SetPath(desiredPriority, loadingType)) :
                (Player.SetPath(desiredPriority, loadingType));
            List<Matches> matches = await Utils.Utils.Load<Matches>(pathLocalOrUrl, loadingType);
            return matches;
        }
    }
}
