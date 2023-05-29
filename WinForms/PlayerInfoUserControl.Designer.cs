namespace WinForms
{
    partial class PlayerInfoUserControl
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerInfoUserControl));
            lbName = new Label();
            lbPosition = new Label();
            pbFavourite = new PictureBox();
            pbCaptain = new PictureBox();
            pbProfile = new PictureBox();
            cms = new ContextMenuStrip(components);
            changePictureToolStripMenuItem = new ToolStripMenuItem();
            removePictureToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)pbFavourite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            cms.SuspendLayout();
            SuspendLayout();
            // 
            // lbName
            // 
            resources.ApplyResources(lbName, "lbName");
            lbName.Name = "lbName";
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.Name = "lbPosition";
            // 
            // pbFavourite
            // 
            resources.ApplyResources(pbFavourite, "pbFavourite");
            pbFavourite.Name = "pbFavourite";
            pbFavourite.TabStop = false;
            // 
            // pbCaptain
            // 
            resources.ApplyResources(pbCaptain, "pbCaptain");
            pbCaptain.Name = "pbCaptain";
            pbCaptain.TabStop = false;
            // 
            // pbProfile
            // 
            resources.ApplyResources(pbProfile, "pbProfile");
            pbProfile.Image = Properties.Resources.person;
            pbProfile.Name = "pbProfile";
            pbProfile.TabStop = false;
            // 
            // cms
            // 
            resources.ApplyResources(cms, "cms");
            cms.Items.AddRange(new ToolStripItem[] { changePictureToolStripMenuItem, removePictureToolStripMenuItem });
            cms.Name = "contextMenuStrip1";
            // 
            // changePictureToolStripMenuItem
            // 
            resources.ApplyResources(changePictureToolStripMenuItem, "changePictureToolStripMenuItem");
            changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            changePictureToolStripMenuItem.Click += changePictureToolStripMenuItem_Click;
            // 
            // removePictureToolStripMenuItem
            // 
            resources.ApplyResources(removePictureToolStripMenuItem, "removePictureToolStripMenuItem");
            removePictureToolStripMenuItem.Name = "removePictureToolStripMenuItem";
            removePictureToolStripMenuItem.Click += removePictureToolStripMenuItem_Click;
            // 
            // PlayerInfoUserControl
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbProfile);
            Controls.Add(pbCaptain);
            Controls.Add(pbFavourite);
            Controls.Add(lbPosition);
            Controls.Add(lbName);
            Name = "PlayerInfoUserControl";
            MouseDown += PlayerInfoUserControl_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pbFavourite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            cms.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbName;
        private Label lbPosition;
        private PictureBox pbFavourite;
        private PictureBox pbCaptain;
        private PictureBox pbProfile;
        private ContextMenuStrip cms;
        private ToolStripMenuItem changePictureToolStripMenuItem;
        private ToolStripMenuItem removePictureToolStripMenuItem;
    }
}
