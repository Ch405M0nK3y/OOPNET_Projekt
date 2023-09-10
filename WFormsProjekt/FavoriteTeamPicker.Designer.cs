namespace WFormsProjekt
{
    partial class FavoriteTeamPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoriteTeamPicker));
            cbTeamPicker = new ComboBox();
            lbl1 = new Label();
            btnConfirm = new Button();
            lblLoading = new Label();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // cbTeamPicker
            // 
            resources.ApplyResources(cbTeamPicker, "cbTeamPicker");
            cbTeamPicker.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTeamPicker.FormattingEnabled = true;
            cbTeamPicker.Name = "cbTeamPicker";
            cbTeamPicker.SelectedValueChanged += cbTeamPicker_SelectedValueChanged;
            // 
            // lbl1
            // 
            resources.ApplyResources(lbl1, "lbl1");
            lbl1.Name = "lbl1";
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.KeyDown += FavoriteTeamPicker_KeyDown;
            // 
            // lblLoading
            // 
            resources.ApplyResources(lblLoading, "lblLoading");
            lblLoading.ForeColor = Color.Red;
            lblLoading.Name = "lblLoading";
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // FavoriteTeamPicker
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnCancel);
            Controls.Add(lblLoading);
            Controls.Add(btnConfirm);
            Controls.Add(lbl1);
            Controls.Add(cbTeamPicker);
            Name = "FavoriteTeamPicker";
            Load += FavoriteTeamPicker_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbTeamPicker;
        private Label lbl1;
        private Button btnConfirm;
        private Label lblLoading;
        private Button btnCancel;
    }
}