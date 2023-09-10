using DataLayer.Model;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WPFProjekt
{
    /// <summary>
    /// Interaction logic for RepInfo.xaml
    /// </summary>
    public partial class RepInfo : Window
    {
        public RepInfo(Representation rep)
        {
            InitializeComponent();
            FillData(rep);
        }

        private void FillData(Representation rep)
        {
            lblName.Content = rep.Country;
            lblFifaCode.Content = rep.FifaCode;
            lblPlayed.Content = rep.GamesPlayed;
            lblWins.Content = rep.Wins;
            lblLoses.Content = rep.Losses;
            lblDraws.Content = rep.Draws;
            lblGoalsScored.Content = rep.GoalsFor;
            lblGoalsTaken.Content = rep.GoalsAgainst;
            lblGoalsDifference.Content = rep.GoalDifferential;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
