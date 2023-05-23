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
            lbName.AutoSize = true;
            lbName.Location = new Point(69, 3);
            lbName.Name = "lbName";
            lbName.Size = new Size(38, 15);
            lbName.TabIndex = 0;
            lbName.Text = "label1";
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(69, 28);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(38, 15);
            lbPosition.TabIndex = 1;
            lbPosition.Text = "label1";
            // 
            // pbFavourite
            // 
            pbFavourite.Image = (Image)resources.GetObject("pbFavourite.Image");
            pbFavourite.InitialImage = (Image)resources.GetObject("pbFavourite.InitialImage");
            pbFavourite.Location = new Point(249, 3);
            pbFavourite.Name = "pbFavourite";
            pbFavourite.Size = new Size(25, 25);
            pbFavourite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFavourite.TabIndex = 2;
            pbFavourite.TabStop = false;
            // 
            // pbCaptain
            // 
            pbCaptain.Image = (Image)resources.GetObject("pbCaptain.Image");
            pbCaptain.InitialImage = (Image)resources.GetObject("pbCaptain.InitialImage");
            pbCaptain.Location = new Point(218, 3);
            pbCaptain.Name = "pbCaptain";
            pbCaptain.Size = new Size(25, 25);
            pbCaptain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCaptain.TabIndex = 3;
            pbCaptain.TabStop = false;
            // 
            // pbProfile
            // 
            pbProfile.Image = Properties.Resources.person;
            pbProfile.InitialImage = (Image)resources.GetObject("pbProfile.InitialImage");
            pbProfile.Location = new Point(3, 3);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(60, 60);
            pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProfile.TabIndex = 4;
            pbProfile.TabStop = false;
            // 
            // cms
            // 
            cms.Items.AddRange(new ToolStripItem[] { changePictureToolStripMenuItem, removePictureToolStripMenuItem });
            cms.Name = "contextMenuStrip1";
            cms.Size = new Size(158, 48);
            // 
            // changePictureToolStripMenuItem
            // 
            changePictureToolStripMenuItem.Name = "changePictureToolStripMenuItem";
            changePictureToolStripMenuItem.Size = new Size(157, 22);
            changePictureToolStripMenuItem.Text = "Change picture";
            changePictureToolStripMenuItem.Click += changePictureToolStripMenuItem_Click;
            // 
            // removePictureToolStripMenuItem
            // 
            removePictureToolStripMenuItem.Name = "removePictureToolStripMenuItem";
            removePictureToolStripMenuItem.Size = new Size(157, 22);
            removePictureToolStripMenuItem.Text = "Remove picture";
            removePictureToolStripMenuItem.Click += removePictureToolStripMenuItem_Click;
            // 
            // PlayerInfoUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbProfile);
            Controls.Add(pbCaptain);
            Controls.Add(pbFavourite);
            Controls.Add(lbPosition);
            Controls.Add(lbName);
            Name = "PlayerInfoUserControl";
            Size = new Size(277, 67);
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
