using DAL;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Player
    {
        public enum Position { Defender, Forward, Goalie, Midfield };

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position PlayedPosition { get; set; }

        public bool Favorite { get; set; }

        public string? ImagePath { get; set; }

        public static List<Player> LoadPlayers(List<Matches> matches, string favoriteRepFifaCode)
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

        public static string SetPath(DesiredPriority priority, FileLoadingType loadingType)
        {
            string path;
            string prio = priority.ToString().ToLower();

            if (loadingType == FileLoadingType.JSON)
            {
                path = "\\" + prio + "\\matches.json";
            }
            else
            {
                path = prio + "/matches";
            }
            return path;
        }
    }
}
