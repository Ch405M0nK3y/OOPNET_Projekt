using DAL;
using DataLayer.DAL;
using System.Globalization;
using System.IO;
//using System.Reflection;

namespace WFormsProjekt
{
    public partial class Settings : Form
    {
        private string PATH;
        Config config;
        ConfigRepository configRepository = RepoFactory.GetConfigRepository();

        public Settings()
        {
            try
            {
                PATH = Path.Combine(Directory.GetParent(Path.GetDirectoryName(Application.StartupPath)).Parent.Parent.Parent.FullName, "DataLayer\\Resources");
                /*
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string relativePath = Path.Combine(baseDirectory, "Resources");
                */
                config = configRepository.Load(PATH);
                SetCulture(config.PreferredLanguage.ToString().ToLower());
            }
            catch (Exception e)
            {
                MessageBox.Show($"Error occured when trying to access config file. {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
            SetCheckboxes();
        }
        private void Settings_Load(object sender, EventArgs e)
        {
            if (!config.IsFirstSetup)
            {
                Thread newThread = new Thread(OpenFavoriteTeamPickerForm);
                newThread.Start();
                this.Close();
            }
        }

        private void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;
        }

        private void OpenFavoriteTeamPickerForm()
        {
            Form newForm = new FavoriteTeamPicker(config);
            Application.Run(newForm);
        }

        private void SetCheckboxes()
        {

            if (config.Priority == DesiredPriority.Men)
            {
                chbMale.Checked = true;
            }
            else
            {
                chbFemale.Checked = true;
            }

            if (config.PreferredLanguage == Language.HR)
            {
                chbCroatian.Checked = true;
            }
            else
            {
                chbEnglish.Checked = true;
            }

            if (config.LoadingType == FileLoadingType.WEB)
            {
                chbWeb.Checked = true;
            }
            else
            {
                chbLocalJSON.Checked = true;
                cbPathJSON.Text = config.LocalPath;
            }
        }

        private void Checkboxes_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckbox = sender as CheckBox;

            if (clickedCheckbox.Parent is GroupBox parentGroupbox)
            {
                foreach (Control control in parentGroupbox.Controls)
                {
                    if (control is CheckBox checkbox && checkbox != clickedCheckbox)
                    {
                        checkbox.CheckedChanged -= Checkboxes_CheckedChanged; // avoid loop caused by this eventhandler
                        checkbox.Checked = false;
                        checkbox.CheckedChanged += Checkboxes_CheckedChanged;
                    }
                }
            }
        }

        private void btnBrowsePath_Click(object sender, EventArgs e) => LoadPath();

        private void LoadPath()
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select a folder";
            fbd.SelectedPath = Application.StartupPath;

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                if (CheckFolderValidity(fbd.SelectedPath))
                {
                    cbPathJSON.Text = fbd.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Invalid path", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private bool CheckFolderValidity(string folderPath)
        {
            bool pass = false;
            foreach (var path in Directory.GetDirectories(folderPath))
            {
                if (Path.GetFileNameWithoutExtension(path) == "men" || Path.GetFileNameWithoutExtension(path) == "women")
                {
                    pass = true;
                }
            }
            return pass;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to save these options?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                config.LoadingType = chbWeb.Checked ? FileLoadingType.WEB : FileLoadingType.JSON;
                config.PreferredLanguage = chbEnglish.Checked ? Language.EN : Language.HR;
                config.Priority = chbMale.Checked ? DesiredPriority.Men : DesiredPriority.Women;
                config.LocalPath = cbPathJSON.Text;
                config.IsFirstSetup = false;

                configRepository.Save(config);

                Thread newThread = new Thread(OpenFavoriteTeamPickerForm);
                newThread.Start();
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close this window?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void Settings_KeyDown(object sender, KeyEventArgs e)
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
    }
}
