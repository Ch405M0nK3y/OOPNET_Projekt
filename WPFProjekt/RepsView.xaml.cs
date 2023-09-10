using DAL;
using DataLayer.DAL;
using DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WPFProjekt
{
    
    public partial class RepsView : Window
    {
        Config config;
        ConfigRepository configRepository = RepoFactory.GetConfigRepository();
        RepresentationRepository representationRepository = RepoFactory.GetRepresentationRepository();
        
        MatchesRepository matchesRepository = RepoFactory.GetMatchesRepository();
        Representation homeTeam=new();
        Representation awayTeam=new();
        Matches playedMatch=new();



        public RepsView(Config conf)
        {
            config = conf;
            SetCulture(config.PreferredLanguage.ToString().ToLower());
            InitializeComponent();
            SetResolution();
        }

        private void SetResolution()
        {
            this.Height = config.WPFHeight;
            this.Width = config.WPFWidth;
        }

        private static void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lblLoading.Visibility = Visibility.Visible;
            await representationRepository.Load(config.LocalPath, config.Priority, config.LoadingType, "");
            await matchesRepository.Load(config.LocalPath, config.Priority, config.LoadingType, "");

            List<Representation> representations = representationRepository.GetRepresentations();
            LoadHomeTeams(representations);

            if (config.FavoriteRepFifaCode != "")
            {
                try
                {
                    // select the favorite rep
                    cbHomeTeam.SelectedItem = representations.
                        Where(x => x.FifaCode == config.FavoriteRepFifaCode).
                        FirstOrDefault().Country + " (" + config.FavoriteRepFifaCode.ToString() + ")";
                }
                catch { config.FavoriteRepFifaCode = ""; } //handles error when switching from male/female - missing fifacode
            }
            lblLoading.Visibility = Visibility.Hidden;
        }

        private void LoadHomeTeams(List<Representation> representations)
        {
            try
            {
                foreach (Representation rep in representations)
                {
                    cbHomeTeam.Items.Add(rep.Country + " (" + rep.FifaCode + ")");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void BtnAwayInfo_Click(object sender, RoutedEventArgs e)
        {
            var infoWindow = new RepInfo(awayTeam);
            infoWindow.Show();
        }

        private void BtnHomeInfo_Click(object sender, RoutedEventArgs e)
        {
            var infoWindow = new RepInfo(homeTeam);
            infoWindow.Show();
        }

        private void CbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string home = config.FavoriteRepFifaCode;
            string away = "";
            try
            {
                away = cbAwayTeam.SelectedItem.ToString().Substring(cbAwayTeam.SelectedItem.ToString().Length - 4, 3);
                awayTeam = representationRepository.GetRep(away);
            }
            catch { }
            SetResult(home,away);
        }

        private void SetResult(string home, string away)
        {
            Matches match = matchesRepository.GetPlayedGame(home, away);
            if (match.HomeTeam.Code == home && match.AwayTeam.Code == away)
            {
                lblResult.Content = $"{match.HomeTeam.Goals}:{match.AwayTeam.Goals} ";
                playedMatch = match;
            }
            else if (match.HomeTeam.Code == away && match.AwayTeam.Code == home)
            {
                lblResult.Content = $"{match.AwayTeam.Goals}:{match.HomeTeam.Goals} ";
                playedMatch = match;
            }
            LoadStartingEleven();
        }
        
        private void LoadStartingEleven()
        {

            frField.Navigate(new StartingEleven(config, playedMatch));
            

        }

        private void CbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            config.FavoriteRepFifaCode = cbHomeTeam.SelectedItem.ToString().Substring(cbHomeTeam.SelectedItem.ToString().Length - 4, 3);
            lblLoading.Visibility = Visibility.Visible;
            cbAwayTeam.Items.Clear();
            LoadAwayRepresentations(config.FavoriteRepFifaCode);
            homeTeam = representationRepository.GetRep(config.FavoriteRepFifaCode);
            lblLoading.Visibility = Visibility.Hidden;
        }

        private void LoadAwayRepresentations(string fifacode)
        {
            List<Matches> matches = matchesRepository.GetMatches();
            foreach (var match in matches)
            {
                Representation rep = null;
                if (match.HomeTeam.Code == fifacode)
                {
                    rep = representationRepository.GetRep(match.AwayTeam.Code);
                }
                else if (match.AwayTeam.Code == fifacode)
                {
                    rep = representationRepository.GetRep(match.HomeTeam.Code);
                }

                if (rep != null)
                {
                    cbAwayTeam.Items.Add(rep.Country + " (" + rep.FifaCode + ")");
                }
            }
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to save these options?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                config.WPFWidth = this.Width;
                config.WPFHeight = this.Height;
                config.FavoriteRepFifaCode = homeTeam.FifaCode;
                configRepository.Save(config);
                this.Close();
            }
        }

        private void ButtonSettings_Click(object sender, RoutedEventArgs e)
        {
            config.WPFWidth = this.Width;
            config.WPFHeight = this.Height;
            config.IsFirstSetup = true;
            config.FavoriteRepFifaCode = homeTeam.FifaCode;
            configRepository.Save(config);
            SettingsWPF newWindow = new SettingsWPF();
            newWindow.Show();
            this.Close();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void RepsView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ButtonConfirm_Click(sender, e);
            }

            if (e.Key == Key.Escape)
            {
                ButtonCancel_Click(sender, e);
            }
        }
    }
}
