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
    public class PlayerRepository : IRepo
    {

        public PlayerRepository(){}

        List<Player> playerList=new List<Player>();

        public async Task Load(string path, DesiredPriority desiredPriority, FileLoadingType loadingType, string FavoriteRepFifaCode)
        {
            string pathLocalOrUrl = loadingType == FileLoadingType.JSON ? 
                (path + Utils.Utils.SetPath(desiredPriority, loadingType,"matches")) : 
                (Utils.Utils.SetPath(desiredPriority, loadingType, "matches"));
            List<Matches> matches = await Utils.Utils.Load<Matches>(pathLocalOrUrl, loadingType);
            playerList = LoadPlayers(matches, FavoriteRepFifaCode);
            return;
        }

        private static List<Player> LoadPlayers(List<Matches> matches, string favoriteRepFifaCode)
        {
            List<Player> players = new List<Player>();
            Matches match = matches.FirstOrDefault(x => x.HomeTeam.Code == favoriteRepFifaCode); // Get a match where the home team is the wanted fifacode

            foreach (var player in match.HomeTeamStatistics.StartingEleven.Concat(match.HomeTeamStatistics.Substitutes)) //loop through the merged players
            {
                Player playa = new Player
                {
                    Name = player.Name,
                    Captain = (bool)player.Captain,
                    ShirtNumber = (long)player.ShirtNumber,
                    PlayedPosition = (Player.Position)player.Position
                };
                players.Add(playa);
            }
            return players;
        }

        public List<Player> GetPlayers() => playerList;

        public Player GetPlayer(string name) => playerList.FirstOrDefault(x => x.Name == name);

        public void AddPlayerToFavorite(Player player) 
        {
            player.Favorite = true;
        }

        public void RemovePlayerFromFavorite(Player player)
        {
            player.Favorite = false;
        }

    }
}
