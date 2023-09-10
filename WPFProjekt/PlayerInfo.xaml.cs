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
    /// Interaction logic for PlayerInfo.xaml
    /// </summary>
    public partial class PlayerInfo : Window
    {
        public PlayerInfo(Player player, string imagePath)
        {
            InitializeComponent();
            LoadData(player);
            LoadImage(imagePath);
        }

        private void LoadData(Player player)
        {
            lblName.Content = player.Name;
            lblShirt.Content = player.ShirtNumber;
            lblCaptain.Content = player.Captain;
            lblPosition.Content = player.PlayedPosition.ToString();
            lblGoals.Content = "X";
            lblYellowCards.Content = "X";
        }

        private void LoadImage(string imagePath)
        {
            if (imagePath == "") return;

            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(imagePath);
            imageSource.EndInit();

            imgPlayer.Source = imageSource;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
