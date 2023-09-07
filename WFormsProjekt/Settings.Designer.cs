namespace WFormsProjekt
{
    partial class Settings
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            chbMale = new CheckBox();
            chbFemale = new CheckBox();
            chbCroatian = new CheckBox();
            chbEnglish = new CheckBox();
            chbWeb = new CheckBox();
            chbLocalJSON = new CheckBox();
            cbPathJSON = new ComboBox();
            lbl4 = new Label();
            gboxPriority = new GroupBox();
            gboxLanguage = new GroupBox();
            gboxLoading = new GroupBox();
            btnBrowsePath = new Button();
            btnConfirm = new Button();
            btnCancel = new Button();
            gboxPriority.SuspendLayout();
            gboxLanguage.SuspendLayout();
            gboxLoading.SuspendLayout();
            SuspendLayout();
            // 
            // chbMale
            // 
            resources.ApplyResources(chbMale, "chbMale");
            chbMale.Name = "chbMale";
            chbMale.UseVisualStyleBackColor = true;
            chbMale.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // chbFemale
            // 
            resources.ApplyResources(chbFemale, "chbFemale");
            chbFemale.Name = "chbFemale";
            chbFemale.UseVisualStyleBackColor = true;
            chbFemale.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // chbCroatian
            // 
            resources.ApplyResources(chbCroatian, "chbCroatian");
            chbCroatian.Name = "chbCroatian";
            chbCroatian.UseVisualStyleBackColor = true;
            chbCroatian.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // chbEnglish
            // 
            resources.ApplyResources(chbEnglish, "chbEnglish");
            chbEnglish.Name = "chbEnglish";
            chbEnglish.UseVisualStyleBackColor = true;
            chbEnglish.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // chbWeb
            // 
            resources.ApplyResources(chbWeb, "chbWeb");
            chbWeb.Name = "chbWeb";
            chbWeb.UseVisualStyleBackColor = true;
            chbWeb.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // chbLocalJSON
            // 
            resources.ApplyResources(chbLocalJSON, "chbLocalJSON");
            chbLocalJSON.Name = "chbLocalJSON";
            chbLocalJSON.UseVisualStyleBackColor = true;
            chbLocalJSON.CheckedChanged += Checkboxes_CheckedChanged;
            // 
            // cbPathJSON
            // 
            resources.ApplyResources(cbPathJSON, "cbPathJSON");
            cbPathJSON.FormattingEnabled = true;
            cbPathJSON.Name = "cbPathJSON";
            // 
            // lbl4
            // 
            resources.ApplyResources(lbl4, "lbl4");
            lbl4.ForeColor = Color.Red;
            lbl4.Name = "lbl4";
            // 
            // gboxPriority
            // 
            resources.ApplyResources(gboxPriority, "gboxPriority");
            gboxPriority.Controls.Add(chbMale);
            gboxPriority.Controls.Add(chbFemale);
            gboxPriority.Name = "gboxPriority";
            gboxPriority.TabStop = false;
            // 
            // gboxLanguage
            // 
            resources.ApplyResources(gboxLanguage, "gboxLanguage");
            gboxLanguage.Controls.Add(chbEnglish);
            gboxLanguage.Controls.Add(chbCroatian);
            gboxLanguage.Name = "gboxLanguage";
            gboxLanguage.TabStop = false;
            // 
            // gboxLoading
            // 
            resources.ApplyResources(gboxLoading, "gboxLoading");
            gboxLoading.Controls.Add(btnBrowsePath);
            gboxLoading.Controls.Add(chbWeb);
            gboxLoading.Controls.Add(chbLocalJSON);
            gboxLoading.Controls.Add(cbPathJSON);
            gboxLoading.Controls.Add(lbl4);
            gboxLoading.Name = "gboxLoading";
            gboxLoading.TabStop = false;
            // 
            // btnBrowsePath
            // 
            resources.ApplyResources(btnBrowsePath, "btnBrowsePath");
            btnBrowsePath.Name = "btnBrowsePath";
            btnBrowsePath.UseVisualStyleBackColor = true;
            btnBrowsePath.Click += btnBrowsePath_Click;
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.KeyDown += Settings_KeyDown;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            btnCancel.KeyDown += Settings_KeyDown;
            // 
            // Settings
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancel);
            Controls.Add(btnConfirm);
            Controls.Add(gboxLoading);
            Controls.Add(gboxLanguage);
            Controls.Add(gboxPriority);
            Name = "Settings";
            Load += Settings_Load;
            KeyDown += Settings_KeyDown;
            gboxPriority.ResumeLayout(false);
            gboxPriority.PerformLayout();
            gboxLanguage.ResumeLayout(false);
            gboxLanguage.PerformLayout();
            gboxLoading.ResumeLayout(false);
            gboxLoading.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private CheckBox chbMale;
        private CheckBox chbFemale;
        private CheckBox chbCroatian;
        private CheckBox chbEnglish;
        private CheckBox chbWeb;
        private CheckBox chbLocalJSON;
        private ComboBox cbPathJSON;
        private Label lbl4;
        private GroupBox gboxPriority;
        private GroupBox gboxLanguage;
        private GroupBox gboxLoading;
        private Button btnBrowsePath;
        private Button btnConfirm;
        private Button btnCancel;
    }
}