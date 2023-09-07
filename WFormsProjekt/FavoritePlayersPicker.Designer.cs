namespace WFormsProjekt
{
    partial class FavoritePlayersPicker
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FavoritePlayersPicker));
            btnConfirm = new Button();
            btnAdd = new Button();
            btnRemove = new Button();
            pnlPlayer = new Panel();
            pnlFavoritePlayer = new Panel();
            btnChangeImage = new Button();
            btnSettings = new Button();
            btnCancel = new Button();
            cmsPlayer = new ContextMenuStrip(components);
            addPlayerToFavoritesToolStripMenuItem = new ToolStripMenuItem();
            cmsFavoritePlayer = new ContextMenuStrip(components);
            removePlayerFromFavoritesToolStripMenuItem = new ToolStripMenuItem();
            lblLoading = new Label();
            cmsPlayer.SuspendLayout();
            cmsFavoritePlayer.SuspendLayout();
            SuspendLayout();
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            btnConfirm.KeyDown += FavoritePlayersPicker_KeyDown;
            // 
            // btnAdd
            // 
            resources.ApplyResources(btnAdd, "btnAdd");
            btnAdd.Name = "btnAdd";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnRemove
            // 
            resources.ApplyResources(btnRemove, "btnRemove");
            btnRemove.Name = "btnRemove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // pnlPlayer
            // 
            resources.ApplyResources(pnlPlayer, "pnlPlayer");
            pnlPlayer.BorderStyle = BorderStyle.FixedSingle;
            pnlPlayer.Name = "pnlPlayer";
            pnlPlayer.Tag = "PlayerPanel";
            // 
            // pnlFavoritePlayer
            // 
            resources.ApplyResources(pnlFavoritePlayer, "pnlFavoritePlayer");
            pnlFavoritePlayer.BorderStyle = BorderStyle.FixedSingle;
            pnlFavoritePlayer.Name = "pnlFavoritePlayer";
            pnlFavoritePlayer.Tag = "FavoritePanel";
            // 
            // btnChangeImage
            // 
            resources.ApplyResources(btnChangeImage, "btnChangeImage");
            btnChangeImage.Name = "btnChangeImage";
            btnChangeImage.UseVisualStyleBackColor = true;
            btnChangeImage.Click += btnChangeImage_Click;
            // 
            // btnSettings
            // 
            resources.ApplyResources(btnSettings, "btnSettings");
            btnSettings.Name = "btnSettings";
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btnSettings_Click;
            // 
            // btnCancel
            // 
            resources.ApplyResources(btnCancel, "btnCancel");
            btnCancel.Name = "btnCancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmsPlayer
            // 
            resources.ApplyResources(cmsPlayer, "cmsPlayer");
            cmsPlayer.Items.AddRange(new ToolStripItem[] { addPlayerToFavoritesToolStripMenuItem });
            cmsPlayer.Name = "cmsPlayer";
            // 
            // addPlayerToFavoritesToolStripMenuItem
            // 
            resources.ApplyResources(addPlayerToFavoritesToolStripMenuItem, "addPlayerToFavoritesToolStripMenuItem");
            addPlayerToFavoritesToolStripMenuItem.Name = "addPlayerToFavoritesToolStripMenuItem";
            addPlayerToFavoritesToolStripMenuItem.Click += addToFavoriteToolStripMenuItem_Click;
            // 
            // cmsFavoritePlayer
            // 
            resources.ApplyResources(cmsFavoritePlayer, "cmsFavoritePlayer");
            cmsFavoritePlayer.Items.AddRange(new ToolStripItem[] { removePlayerFromFavoritesToolStripMenuItem });
            cmsFavoritePlayer.Name = "cmsFavoritePlayer";
            // 
            // removePlayerFromFavoritesToolStripMenuItem
            // 
            resources.ApplyResources(removePlayerFromFavoritesToolStripMenuItem, "removePlayerFromFavoritesToolStripMenuItem");
            removePlayerFromFavoritesToolStripMenuItem.Name = "removePlayerFromFavoritesToolStripMenuItem";
            removePlayerFromFavoritesToolStripMenuItem.Click += removeFromFavoriteToolStripMenuItem_Click;
            // 
            // lblLoading
            // 
            resources.ApplyResources(lblLoading, "lblLoading");
            lblLoading.ForeColor = Color.Red;
            lblLoading.Name = "lblLoading";
            // 
            // FavoritePlayersPicker
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblLoading);
            Controls.Add(btnCancel);
            Controls.Add(btnSettings);
            Controls.Add(btnChangeImage);
            Controls.Add(pnlFavoritePlayer);
            Controls.Add(pnlPlayer);
            Controls.Add(btnRemove);
            Controls.Add(btnAdd);
            Controls.Add(btnConfirm);
            Name = "FavoritePlayersPicker";
            Load += FavoritePlayersPicker_Load;
            cmsPlayer.ResumeLayout(false);
            cmsFavoritePlayer.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnConfirm;
        private Button btnAdd;
        private Button btnRemove;
        private Panel pnlPlayer;
        private Panel pnlFavoritePlayer;
        private Button btnChangeImage;
        private Button btnSettings;
        private Button btnCancel;
        private ContextMenuStrip cmsPlayer;
        private ToolStripMenuItem addPlayerToFavoritesToolStripMenuItem;
        private ContextMenuStrip cmsFavoritePlayer;
        private ToolStripMenuItem removePlayerFromFavoritesToolStripMenuItem;
        private Label lblLoading;
    }
}