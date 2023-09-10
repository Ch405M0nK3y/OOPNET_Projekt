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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFProjekt
{
    /// <summary>
    /// Interaction logic for PlayerUserControl.xaml
    /// </summary>
    public partial class PlayerUserControl : UserControl
    {
        Player playa;
        String imagepathcurrent;
        public PlayerUserControl(Player player,string imagePath)
        {
            InitializeComponent();
            playa = player;
            lblName.Text = player.Name;
            imagepathcurrent=LoadImage(imagePath);
        }

        private string LoadImage(string imagePath)
        {
            if (imagePath=="")return "";
            
            BitmapImage imageSource = new BitmapImage();
            imageSource.BeginInit();
            imageSource.UriSource = new Uri(imagePath);
            imageSource.EndInit();
            imgPlayer.Source = imageSource;
            return imagePath;
        }

        private void PlayerUserControlOpenPlayerInfo_Click(object sender, RoutedEventArgs e)
        {
            var infoWindow = new PlayerInfo(playa, imagepathcurrent);
            infoWindow.Show();
        }

    }
}
