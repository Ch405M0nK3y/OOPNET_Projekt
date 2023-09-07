namespace WFormsProjekt
{
    partial class PlayerPanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblName = new Label();
            lblPosition = new Label();
            lblNametext = new Label();
            lblPositiontext = new Label();
            lblNumbertext = new Label();
            lblNumber = new Label();
            lblCaptain = new Label();
            lblCaptaintext = new Label();
            pbPicture = new PictureBox();
            pbFavorite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFavorite).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Enabled = false;
            lblName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(183, 6);
            lblName.Name = "lblName";
            lblName.Size = new Size(118, 21);
            lblName.TabIndex = 0;
            lblName.Tag = "Bop";
            lblName.Text = "Milica Krmpotic";
            lblName.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPosition
            // 
            lblPosition.AutoSize = true;
            lblPosition.Enabled = false;
            lblPosition.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblPosition.Location = new Point(184, 27);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(54, 21);
            lblPosition.TabIndex = 1;
            lblPosition.Text = "Straga";
            lblPosition.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNametext
            // 
            lblNametext.AutoSize = true;
            lblNametext.Enabled = false;
            lblNametext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNametext.Location = new Point(100, 6);
            lblNametext.Name = "lblNametext";
            lblNametext.Size = new Size(60, 21);
            lblNametext.TabIndex = 2;
            lblNametext.Text = "Name:";
            lblNametext.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblPositiontext
            // 
            lblPositiontext.AutoSize = true;
            lblPositiontext.Enabled = false;
            lblPositiontext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblPositiontext.Location = new Point(100, 27);
            lblPositiontext.Name = "lblPositiontext";
            lblPositiontext.Size = new Size(77, 21);
            lblPositiontext.TabIndex = 3;
            lblPositiontext.Text = "Position:";
            lblPositiontext.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNumbertext
            // 
            lblNumbertext.AutoSize = true;
            lblNumbertext.Enabled = false;
            lblNumbertext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblNumbertext.Location = new Point(100, 48);
            lblNumbertext.Name = "lblNumbertext";
            lblNumbertext.Size = new Size(78, 21);
            lblNumbertext.TabIndex = 4;
            lblNumbertext.Text = "Number:";
            lblNumbertext.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblNumber
            // 
            lblNumber.AutoSize = true;
            lblNumber.Enabled = false;
            lblNumber.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblNumber.Location = new Point(184, 48);
            lblNumber.Name = "lblNumber";
            lblNumber.Size = new Size(70, 21);
            lblNumber.TabIndex = 5;
            lblNumber.Text = "Nekibroj";
            lblNumber.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCaptain
            // 
            lblCaptain.AutoSize = true;
            lblCaptain.Enabled = false;
            lblCaptain.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblCaptain.Location = new Point(184, 69);
            lblCaptain.Name = "lblCaptain";
            lblCaptain.Size = new Size(78, 21);
            lblCaptain.TabIndex = 8;
            lblCaptain.Text = "Mosmislit";
            lblCaptain.TextAlign = ContentAlignment.TopCenter;
            // 
            // lblCaptaintext
            // 
            lblCaptaintext.AutoSize = true;
            lblCaptaintext.Enabled = false;
            lblCaptaintext.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblCaptaintext.Location = new Point(100, 69);
            lblCaptaintext.Name = "lblCaptaintext";
            lblCaptaintext.Size = new Size(73, 21);
            lblCaptaintext.TabIndex = 7;
            lblCaptaintext.Text = "Captain:";
            lblCaptaintext.TextAlign = ContentAlignment.TopCenter;
            // 
            // pbPicture
            // 
            pbPicture.Enabled = false;
            pbPicture.Image = Properties.Resources.najboljiigrac;
            pbPicture.InitialImage = null;
            pbPicture.Location = new Point(3, 3);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(91, 87);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 9;
            pbPicture.TabStop = false;
            pbPicture.Tag = "Bip";
            // 
            // pbFavorite
            // 
            pbFavorite.Enabled = false;
            pbFavorite.Image = Properties.Resources.star_icon;
            pbFavorite.Location = new Point(379, 19);
            pbFavorite.Name = "pbFavorite";
            pbFavorite.Size = new Size(56, 50);
            pbFavorite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFavorite.TabIndex = 11;
            pbFavorite.TabStop = false;
            // 
            // PlayerPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbFavorite);
            Controls.Add(pbPicture);
            Controls.Add(lblCaptain);
            Controls.Add(lblCaptaintext);
            Controls.Add(lblNumber);
            Controls.Add(lblNumbertext);
            Controls.Add(lblPositiontext);
            Controls.Add(lblNametext);
            Controls.Add(lblPosition);
            Controls.Add(lblName);
            Name = "PlayerPanel";
            Size = new Size(438, 93);
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFavorite).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label lblPosition;
        private Label lblNametext;
        private Label lblPositiontext;
        private Label lblNumbertext;
        private Label lblNumber;
        private Label lblCaptain;
        private Label lblCaptaintext;
        private PictureBox pbPicture;
        private PictureBox pbFavorite;
    }
}
