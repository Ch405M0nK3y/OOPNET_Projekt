using DAL;
using DataLayer.DAL;
using DataLayer.Model;
using System.Globalization;
using System.Security.Cryptography;

namespace WFormsProjekt
{
    public partial class FavoriteTeamPicker : Form
    {
        Config config;
        List<Representation> representations;
        ConfigRepository configRepository = RepoFactory.GetConfigRepository();
        RepresentationRepository representationRepository = RepoFactory.GetRepresentationRepository();

        public FavoriteTeamPicker(DAL.Config conf)
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

        private async void FavoriteTeamPicker_Load(object sender, EventArgs e)
        {
            lblLoading.Visible = true;
            await LoadRepresentationsRepo();
            cbTeamPicker.DropDownHeight = cbTeamPicker.ItemHeight * cbTeamPicker.MaxDropDownItems;
            LoadTeams();
            if (config.FavoriteRepFifaCode != "")
            {
                try
                {
                    cbTeamPicker.Text = representations.
                        Where(x => x.FifaCode == config.FavoriteRepFifaCode).
                        FirstOrDefault().Country + " (" + config.FavoriteRepFifaCode.ToString() + ")";
                }
                catch { } //handles error when switching from male/female - missing fifacode
            }
            lblLoading.Visible = false;
        }

        private async Task LoadRepresentationsRepo()
        {
            representations = await representationRepository.Load(config.LocalPath, config.Priority, config.LoadingType);
        }
        private void LoadTeams()
        {
            try
            {
                foreach (Representation rep in representations)
                {
                    cbTeamPicker.Items.Add(rep.Country + " (" + rep.FifaCode.ToString() + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OpenFavoritePlayersPickerForm(Config config)
        {
            Thread thread = new Thread(() => Application.Run(new FavoritePlayersPicker(config))); // New Thread with STA to avoid dragdrop exceptions
            thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
            thread.Start();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            config.FavoriteRepFifaCode = cbTeamPicker.Tag.ToString();

            configRepository.Save(config);

            OpenFavoritePlayersPickerForm(config);

            this.Close();
        }

        private void cbTeamPicker_SelectedValueChanged(object sender, EventArgs e)
        {
            int length = cbTeamPicker.Text.Length;
            cbTeamPicker.Tag = cbTeamPicker.Text.Substring(length - 4, 3);
        }

        private void FavoriteTeamPicker_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                btnConfirm.PerformClick();
            }
        }


    }
}