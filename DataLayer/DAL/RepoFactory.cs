using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class RepoFactory
    {
        public static PlayerRepository GetPlayerRepository() => new PlayerRepository();
        public static RepresentationRepository GetRepresentationRepository() => new RepresentationRepository();
        public static ConfigRepository GetConfigRepository() => new ConfigRepository();
        public static MatchesRepository GetMatchesRepository() => new MatchesRepository();
    }
}
