using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataLayer.DAL
{
    public class PlayerRepository
    {

        public PlayerRepository(){}

        public async Task<List<Player>> Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType, string FavoriteRepFifaCode)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ? 
                (path + Player.SetPath(desiredPriority, loadingType)) : 
                (Player.SetPath(desiredPriority, loadingType));
            List<Matches> matches = await Utils.Utils.Load<Matches>(pathLocalOrUrl, loadingType);
            List<Player> playerList = Player.LoadPlayers(matches, FavoriteRepFifaCode);
            return playerList;
        }
    }
}
