using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class MatchesRepository : IRepo
    {
        public MatchesRepository() { }
       
        private List<Matches> matches=new List<Matches>();

        public async Task Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType, string FavoriteRepFifaCode)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ?
                (path + Utils.Utils.SetPath(desiredPriority, loadingType, "matches")) :
                (Utils.Utils.SetPath(desiredPriority, loadingType, "matches"));
            matches = await Utils.Utils.Load<Matches>(pathLocalOrUrl, loadingType);
            return;
        }

        public List<Matches> GetMatches() { return matches; }

        public Matches GetPlayedGame(string home, string away)
        {
            Matches playedMatch=new();
            foreach (var match in matches)
            {
                if (match.HomeTeam.Code == home && match.AwayTeam.Code == away)
                {
                    playedMatch= match;
                    break;
                }
                else if (match.HomeTeam.Code == away && match.AwayTeam.Code == home)
                {
                    playedMatch = match;
                    break;
                }
            }
            return playedMatch;
        }
    }
}
