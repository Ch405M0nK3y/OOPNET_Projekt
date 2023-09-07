using DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFormsProjekt
{
    public partial class PlayerPanel : UserControl
    {
        public PlayerPanel(Player player, string imagePath)
        {
            InitializeComponent();
            Init(player, imagePath);
        }

        private void Init(Player player, string imagePath)
        {
            lblName.Text = player.Name;
            lblNumber.Text = player.ShirtNumber.ToString();
            lblPosition.Text = player.PlayedPosition.ToString();
            lblCaptain.Text = player.Captain == true ? "Yes" : "No";
            pbFavorite.Visible = false;
            if (imagePath != "")
            {
                pbPicture.ImageLocation = imagePath;
            }
            if (player.Favorite)
            {
                pbFavorite.Visible = true;
            }
        }

        public Player GetPlayer()
        {
            Player playa = new Player
            {
                Name = lblName.Text,
            };
            return playa;
        }
    }
}
