﻿using DAL;
using DataLayer.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

namespace WPFProjekt
{
    /// <summary>
    /// Interaction logic for SettingsWPF.xaml
    /// </summary>
    public partial class SettingsWPF : Window
    {

        private string PATH;
        Config config;
        ConfigRepository configRepository = RepoFactory.GetConfigRepository();
        private double width;
        private double height;

        public SettingsWPF()
        {
            try
            {
                PATH = Path.Combine(Directory.GetParent(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)).Parent.Parent.Parent.FullName, "DataLayer\\Resources");
                config = configRepository.Load(PATH);
                SetCulture(config.PreferredLanguage.ToString().ToLower());
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error occured when trying to access config file. {e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
            InitializeComponent();
            Init();
        }

        private void Init() 
        {
            if (!config.IsFirstSetup)
            {
                OpenRepsViewWindow();
            }
            SetResolution();
            SetCheckboxes();
        }

        private void SetResolution()
        {
            this.Height = config.WPFHeight;
            this.Width = config.WPFWidth;
        }

        private void OpenRepsViewWindow()
        {
            RepsView newWindow = new RepsView(config);
            newWindow.Show();
            this.Close();
            //Application.Current.Dispatcher.Invoke(() => this.Close());
        }

        private void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void SetCheckboxes()
        {

            if (config.Priority == DesiredPriority.Men)
            {
                rbtnMen.IsChecked = true;
            }
            else
            {
                rbtnWomen.IsChecked = true;
            }

            if (config.PreferredLanguage == DAL.Language.HR)
            {
                rbtnCroatian.IsChecked = true;
            }
            else
            {
                rbtnEnglish.IsChecked = true;
            }

            if (config.WPFWidth == 800 && config.WPFHeight == 600)
            {
                rbtnRes1.IsChecked = true;
            }
            else if (config.WPFWidth == 1024 && config.WPFHeight == 768)
            {
                rbtnRes2.IsChecked = true;
            }
            else if (config.WPFWidth == 1280 && config.WPFHeight == 800)
            {
                rbtnRes3.IsChecked = true;
            }
            else if (config.WPFWidth == SystemParameters.PrimaryScreenWidth && config.WPFHeight == SystemParameters.PrimaryScreenHeight)
            {
                rbtnResFull.IsChecked = true;
            }
            else 
            {
                rbtnResCustom.IsChecked = true;
            }
        }
        
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e) 
        {
            if (MessageBox.Show("Do you want to save these options?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                config.PreferredLanguage = rbtnEnglish.IsChecked.HasValue && rbtnEnglish.IsChecked.Value ? DAL.Language.EN : DAL.Language.HR;
                config.Priority = rbtnMen.IsChecked.HasValue && rbtnMen.IsChecked.Value ? DesiredPriority.Men : DesiredPriority.Women;
                ResolutionCheck();
                config.WPFWidth = width;
                config.WPFHeight = height;
                config.IsFirstSetup = false;
                configRepository.Save(config);
                OpenRepsViewWindow();
            }
        }

        private bool ResolutionCheck()
        {
            foreach (var btn in spResolution.Children)
            {
                RadioButton rbtn = btn as RadioButton;
                if (rbtn.IsChecked.HasValue && rbtn.IsChecked.Value)
                {
                    if (rbtn.Content.ToString() == "Fullscreen")
                    {
                        width = SystemParameters.PrimaryScreenWidth;
                        height = SystemParameters.PrimaryScreenHeight;
                        return true;
                    }
                    else if (rbtn.Content.ToString() == "Custom")
                    {
                        width = this.ActualWidth;
                        height = this.ActualHeight;
                        return true;
                    }
                    string content=rbtn.Content.ToString();
                    string[] contentsplit = content.Split('x');
                    int.TryParse(contentsplit[0],out int rbtnwidth);
                    width = rbtnwidth;
                    int.TryParse(contentsplit[1],out int rbtnheight);
                    height = rbtnheight;
                    return true;
                } 
            }
            return false;
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
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
