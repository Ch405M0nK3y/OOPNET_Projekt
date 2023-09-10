using DAL;
using DataLayer.DAL;
using DataLayer.Model;
using System.Globalization;
using System.Numerics;
using System.Security.Cryptography;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace WFormsProjekt
{
    public partial class FavoritePlayersPicker : Form
    {
        Config config;
        ConfigRepository configRepository = RepoFactory.GetConfigRepository();
        PlayerRepository playerRepository = RepoFactory.GetPlayerRepository();

        private int favoriteCount = 0;
        private PlayerPanel selectedPerson;
        private FlowLayoutPanel flpPlayers = new FlowLayoutPanel();
        private FlowLayoutPanel flpFavoritePlayers = new FlowLayoutPanel();
        private Panel target;
        public FavoritePlayersPicker(DAL.Config conf)
        {
            config = conf;
            SetCulture(config.PreferredLanguage.ToString().ToLower());
            InitializeComponent();

        }
        private void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private async void FavoritePlayersPicker_Load(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            await playerRepository.Load(config.LocalPath, config.Priority, config.LoadingType, config.FavoriteRepFifaCode);
            AddFLP();
            InitDnD();
            LoadFavoritePlayers();
            LoadPlayers();
            lblLoading.Visible = false;
        }
        private void AddFLP()
        {
            flpPlayers.AutoSize = true;
            flpPlayers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpPlayers.FlowDirection = FlowDirection.TopDown;

            flpFavoritePlayers.AutoSize = true;
            flpFavoritePlayers.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpFavoritePlayers.FlowDirection = FlowDirection.TopDown;

            flpPlayers.AllowDrop = true;
            flpPlayers.DragEnter += playerPanel_DragEnter;
            flpPlayers.DragDrop += playerPanel_DragDrop;

            flpFavoritePlayers.AllowDrop = true;
            flpFavoritePlayers.DragEnter += playerPanel_DragEnter;
            flpFavoritePlayers.DragDrop += playerPanel_DragDrop;

            pnlPlayer.Controls.Add(flpPlayers);
            pnlFavoritePlayer.Controls.Add(flpFavoritePlayers);
        }

        private void InitDnD()
        {
            pnlPlayer.AllowDrop = true;
            pnlPlayer.DragEnter += playerPanel_DragEnter;
            pnlPlayer.DragDrop += playerPanel_DragDrop;

            pnlFavoritePlayer.AllowDrop = true;
            pnlFavoritePlayer.DragEnter += playerPanel_DragEnter;
            pnlFavoritePlayer.DragDrop += playerPanel_DragDrop;
        }

        private void LoadFavoritePlayers()
        {
            if (config.FavoritePlayers.Count == 0) return;

            foreach (var player in config.FavoritePlayers)
            {
                var favoritePlayer = playerRepository.GetPlayer(player);
                if (favoritePlayer != null)
                {
                    playerRepository.AddPlayerToFavorite(favoritePlayer);
                    favoriteCount++;
                }
            }
        }

        private void LoadPlayers()
        {
            flpPlayers.Controls.Clear();
            flpFavoritePlayers.Controls.Clear();
            LoadPlayersLoop();
        }

        private void LoadPlayersLoop()
        {
            List<Player> players = playerRepository.GetPlayers();
            foreach (var player in players)
            {
                PlayerPanel playerPanel = new PlayerPanel(player, configRepository.GetImage(config.ImagePaths,player.Name));

                playerPanel.Click += playerPanel_Click;
                playerPanel.AllowDrop = true;
                playerPanel.MouseDown += playerPanel_MouseDown;
                playerPanel.DragEnter += playerPanel_DragEnter;
                playerPanel.DragDrop += playerPanel_DragDrop;

                if (player.Favorite)
                {
                    playerPanel.ContextMenuStrip = cmsFavoritePlayer;
                    flpFavoritePlayers.Controls.Add(playerPanel);
                }
                else
                {
                    playerPanel.ContextMenuStrip = cmsPlayer;
                    flpPlayers.Controls.Add(playerPanel);
                }
            }
        }

        private void playerPanel_Click(object sender, EventArgs e)
        {
            if (selectedPerson != null)
                selectedPerson.BackColor = SystemColors.Control;

            if (sender is PlayerPanel)
                selectedPerson = sender as PlayerPanel;
            else if (sender is Label || sender is PictureBox)
                selectedPerson = ((Control)sender).Parent as PlayerPanel;

            selectedPerson.BackColor = Color.Aqua;
        }

        private void btnAdd_Click(object sender, EventArgs e) => AddToFavorite();

        private void btnRemove_Click(object sender, EventArgs e) => RemoveFromFavorite();

        private void AddToFavorite()
        {
            if (selectedPerson is null) return;

            Player selectedPlayer = selectedPerson.GetPlayer();
            Player favoritePlayer = playerRepository.GetPlayer(selectedPlayer.Name); //find the player by name

            if (!favoritePlayer.Favorite)
            {
                if (favoriteCount == 3)
                {
                    MessageBox.Show("Maximum number of favorite players has been reached", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                playerRepository.AddPlayerToFavorite(favoritePlayer);
                favoriteCount++;
                LoadPlayers();
            }
        }

        private void RemoveFromFavorite()
        {
            if (selectedPerson is null) return;

            Player selectedPlayer = selectedPerson.GetPlayer();
            var favoritePlayer = playerRepository.GetPlayer(selectedPlayer.Name); //find the player by name

            if (favoritePlayer.Favorite)
            {
                playerRepository.RemovePlayerFromFavorite(favoritePlayer);
                favoriteCount--;
                LoadPlayers();
            }
        }

        private void SaveFavoritePlayers()
        {
            List<string> favoritePlayers = new();
            List<Player> players = playerRepository.GetPlayers();
            foreach (var player in players)
            {
                if (player.Favorite && favoritePlayers.Count <= 3)
                {
                    favoritePlayers.Add(player.Name);
                }
            }
            config.FavoritePlayers = favoritePlayers;
            configRepository.Save(config);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save and close this application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                config.FavoritePlayers.Clear();
                SaveFavoritePlayers();
                this.Close();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            config.IsFirstSetup = true;
            SaveFavoritePlayers();
            Thread newThread = new Thread(OpenSettingsForm);
            newThread.Start();
            this.Close();
        }

        private void OpenSettingsForm() => Application.Run(new Settings());

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void FavoritePlayersPicker_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
            if (e.KeyCode == Keys.Escape)
            {
                btnCancel.PerformClick();
            }
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            string fileName = OpenDialog();

            if (fileName != "")
            {
                foreach (Control control in selectedPerson.Controls)
                {
                    if (control is PictureBox && (string)control.Tag == "Bip")
                    {
                        (control as PictureBox).ImageLocation = fileName;
                    }
                    if (control is Label && (string)control.Tag == "Bop")
                    {
                        config.ImagePaths = configRepository.AddImage(config.ImagePaths, control.Text, fileName);
                    }
                }
            }
        }

        private string OpenDialog()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;
            DialogResult isDialogOK = DialogResult.Cancel;

            Thread thread = new Thread(() => isDialogOK = ofd.ShowDialog()); // New Thread with STA to avoid exceptions
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
            thread.Join();

            if (isDialogOK == DialogResult.OK)
            {
                return ofd.FileName;
            }
            return "";
        }

        private void playerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                playerPanel_Click(sender, e);
                this.DoDragDrop((sender as PlayerPanel).GetPlayer(), DragDropEffects.Move);
            }
        }

        private void playerPanel_DragEnter(object sender, DragEventArgs e) => e.Effect = DragDropEffects.Move;

        private void playerPanel_DragDrop(object sender, DragEventArgs e)
        {
            Player player = selectedPerson.GetPlayer();

            // Finding the target Panel depending on the mouse position and checking them by Tags
            if (sender is Panel)
            {
                target = sender as Panel;
            }
            else if (sender is FlowLayoutPanel)
            {
                FlowLayoutPanel flowLayoutPanel = sender as FlowLayoutPanel;
                target = flowLayoutPanel.Parent as Panel;
            }
            else if (sender is PlayerPanel)
            {
                PlayerPanel playerPanel = sender as PlayerPanel;
                target = playerPanel.Parent.Parent as Panel;
            }

            if (!player.Favorite && target.Tag == "FavoritePanel")
            {
                AddToFavorite();
            }
            else if (target.Tag == "PlayerPanel")
            {
                RemoveFromFavorite();
            }


        }

        private void addToFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolstrip = sender as ToolStripMenuItem;
            ContextMenuStrip owner = toolstrip.Owner as ContextMenuStrip;
            playerPanel_Click(owner.SourceControl, e); //sourcecontrol gets the playerpanel to select it
            AddToFavorite();
        }

        private void removeFromFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolstrip = sender as ToolStripMenuItem;
            ContextMenuStrip owner = toolstrip.Owner as ContextMenuStrip;
            playerPanel_Click(owner.SourceControl, e); //sourcecontrol gets the playerpanel to select it
            RemoveFromFavorite();
        }

    }
}