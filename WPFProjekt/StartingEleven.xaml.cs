using DAL;
using DataLayer.DAL;
using DataLayer.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFProjekt
{
    /// <summary>
    /// Interaction logic for StartingEleven.xaml
    /// </summary>
    public partial class StartingEleven : Page
    {
        Config config;
        ConfigRepository configRepository = new ConfigRepository();
        public StartingEleven(Config conf,Matches playedMatch)
        {
            config = conf;
            InitializeComponent();
            LoadData(playedMatch);
        }

        private void LoadData(Matches playedMatch)
        {
            LoadHomeTeam(playedMatch.HomeTeamStatistics.StartingEleven, playedMatch.HomeTeamStatistics.Tactics);
            LoadAwayTeam(playedMatch.AwayTeamStatistics.StartingEleven, playedMatch.AwayTeamStatistics.Tactics);
        }

        private void LoadHomeTeam(List<DataLayer.Model.StartingEleven> startingEleven, string tactics)
        {
            Tactics tactic=ParseTactics(tactics);
            foreach (var player in startingEleven)
            {
                Player playa = new Player 
                {
                    Name=player.Name,
                    Captain=player.Captain,
                    ShirtNumber=player.ShirtNumber,
                    PlayedPosition= (Player.Position)player.Position
                };

                PlayerUserControl playerUserControl = new PlayerUserControl(playa, configRepository.GetImage(config.ImagePaths,player.Name));
                StackPanel stackPanel = new StackPanel();
                
                stackPanel.Children.Add(playerUserControl);
                int row = 0;
                int column = 0;

                if (tactic.TacticLength == 3)
                {
                    switch (playa.PlayedPosition.ToString())
                    {
                        case "Defender":
                            row = tactic.Defender--;
                            column = 2;
                            break;
                        case "Forward":
                            row = tactic.Forward--;
                            column = 5;
                            break;
                        case "Goalie":
                            row = 3;
                            column = 1;
                            break;
                        case "Midfield":
                            row = tactic.Midfield--;
                            column = 3;
                            break;
                    }
                }
                if (tactic.TacticLength == 4)
                {
                    switch (playa.PlayedPosition.ToString())
                    {
                        case "Defender":
                            row = tactic.Defender--;
                            column = 2;
                            break;
                        case "Forward":
                            if (tactic.Forward < 0)
                            {
                                row = tactic.Midfield2--;
                                column = 5;
                                break;
                            }
                            row = tactic.Forward--;
                            column = 5;
                            break;
                        case "Goalie":
                            row = 3;
                            column = 1;
                            break;
                        case "Midfield":
                            if (tactic.Midfield < 0)
                            {
                                row = tactic.Midfield2--;
                                column = 4;
                                break;
                            }
                            row = tactic.Midfield--;
                            column = 3;
                            break;
                    }
                }

                Grid.SetRow(stackPanel, row);
                Grid.SetColumn(stackPanel, column);
                gridField.Children.Add(stackPanel);
                
            }
        }
        private void LoadAwayTeam(List<DataLayer.Model.StartingEleven> startingEleven, string tactics)
        {
            Tactics tactic = ParseTactics(tactics);
            foreach (var player in startingEleven)
            {
                Player playa = new Player
                {
                    Name = player.Name,
                    Captain = player.Captain,
                    ShirtNumber = player.ShirtNumber,
                    PlayedPosition = (Player.Position)player.Position
                };

                PlayerUserControl playerUserControl = new PlayerUserControl(playa, configRepository.GetImage(config.ImagePaths, player.Name));
                StackPanel stackPanel = new StackPanel();
                stackPanel.Children.Add(playerUserControl);
                int row = 0;
                int column = 0;

                if (tactic.TacticLength == 3)
                {
                    switch (playa.PlayedPosition.ToString())
                    {
                        case "Defender":
                            row = tactic.Defender--;
                            column = 9;
                            break;
                        case "Forward":
                            row = tactic.Forward--;
                            column = 6;
                            break;
                        case "Goalie":
                            row = 3;
                            column = 10;
                            break;
                        case "Midfield":
                            row = tactic.Midfield--;
                            column = 8;
                            break;
                    }
                }
                if (tactic.TacticLength == 4)
                {
                    switch (playa.PlayedPosition.ToString())
                    {
                        case "Defender":
                            row = tactic.Defender--;
                            column = 9;
                            break;
                        case "Forward":
                            row = tactic.Forward--;
                            column = 6;
                            if (tactic.Forward<0)
                            {
                                row = tactic.Midfield2--;
                                column = 7;
                                break;
                            }
                            break;
                        case "Goalie":
                            row = 3;
                            column = 10;
                            break;
                        case "Midfield":
                            if (tactic.Midfield < 0)
                            {
                                row = tactic.Midfield2--;
                                column = 7;
                                break;
                            }
                            row = tactic.Midfield--;
                            column = 8;
                            break;
                    }
                }

                Grid.SetRow(stackPanel, row);
                Grid.SetColumn(stackPanel, column);
                gridField.Children.Add(stackPanel);
            }
        }
        private Tactics ParseTactics(string tactics)
        {
            string[] parts = tactics.Split('-');

            int[] numbers = new int[parts.Length];

            Tactics tactic = new();
            tactic.TacticLength = parts.Length;

            for (int i = 0; i < parts.Length; i++)
            {
                if (int.TryParse(parts[i], out int number))
                {
                    numbers[i] = number;
                }
            }

            if (parts.Length == 3)
            {
                tactic.Defender = numbers[0];
                tactic.Midfield = numbers[1];
                tactic.Forward = numbers[2];
            }
            else if (parts.Length == 4)
            {
                tactic.Defender = numbers[0];
                tactic.Midfield = numbers[1];
                tactic.Midfield2 = numbers[2];
                tactic.Forward = numbers[3];
            }

            return tactic;
        }
    }
}
