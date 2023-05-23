namespace WinForms
{
    partial class RankingListEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingListEntry));
            lbName = new Label();
            lbPosition = new Label();
            lbGoals = new Label();
            lbYellowCards = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            pbCaptain = new PictureBox();
            pbFavourite = new PictureBox();
            pbProfile = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbCaptain).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbFavourite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProfile).BeginInit();
            SuspendLayout();
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(70, 4);
            lbName.Name = "lbName";
            lbName.Size = new Size(38, 15);
            lbName.TabIndex = 0;
            lbName.Text = "label1";
            // 
            // lbPosition
            // 
            lbPosition.AutoSize = true;
            lbPosition.Location = new Point(150, 19);
            lbPosition.Name = "lbPosition";
            lbPosition.Size = new Size(38, 15);
            lbPosition.TabIndex = 1;
            lbPosition.Text = "label1";
            // 
            // lbGoals
            // 
            lbGoals.AutoSize = true;
            lbGoals.Location = new Point(150, 34);
            lbGoals.Name = "lbGoals";
            lbGoals.Size = new Size(38, 15);
            lbGoals.TabIndex = 2;
            lbGoals.Text = "label1";
            // 
            // lbYellowCards
            // 
            lbYellowCards.AutoSize = true;
            lbYellowCards.Location = new Point(150, 49);
            lbYellowCards.Name = "lbYellowCards";
            lbYellowCards.Size = new Size(38, 15);
            lbYellowCards.TabIndex = 3;
            lbYellowCards.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 19);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 5;
            label1.Text = "Position:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 34);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 6;
            label2.Text = "Goals:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(70, 49);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 7;
            label3.Text = "Yellow cards:";
            // 
            // pbCaptain
            // 
            pbCaptain.Image = (Image)resources.GetObject("pbCaptain.Image");
            pbCaptain.InitialImage = (Image)resources.GetObject("pbCaptain.InitialImage");
            pbCaptain.Location = new Point(285, 3);
            pbCaptain.Name = "pbCaptain";
            pbCaptain.Size = new Size(25, 25);
            pbCaptain.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCaptain.TabIndex = 8;
            pbCaptain.TabStop = false;
            // 
            // pbFavourite
            // 
            pbFavourite.Image = (Image)resources.GetObject("pbFavourite.Image");
            pbFavourite.InitialImage = (Image)resources.GetObject("pbFavourite.InitialImage");
            pbFavourite.Location = new Point(285, 34);
            pbFavourite.Name = "pbFavourite";
            pbFavourite.Size = new Size(25, 25);
            pbFavourite.SizeMode = PictureBoxSizeMode.StretchImage;
            pbFavourite.TabIndex = 9;
            pbFavourite.TabStop = false;
            // 
            // pbProfile
            // 
            pbProfile.Image = Properties.Resources.person;
            pbProfile.InitialImage = (Image)resources.GetObject("pbProfile.InitialImage");
            pbProfile.Location = new Point(4, 4);
            pbProfile.Name = "pbProfile";
            pbProfile.Size = new Size(60, 60);
            pbProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProfile.TabIndex = 10;
            pbProfile.TabStop = false;
            // 
            // RankingListEntry
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbProfile);
            Controls.Add(pbFavourite);
            Controls.Add(pbCaptain);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lbYellowCards);
            Controls.Add(lbGoals);
            Controls.Add(lbPosition);
            Controls.Add(lbName);
            Name = "RankingListEntry";
            Size = new Size(313, 70);
            Load += RankingListEntry_Load;
            ((System.ComponentModel.ISupportInitialize)pbCaptain).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbFavourite).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProfile).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbName;
        private Label lbPosition;
        private Label lbGoals;
        private Label lbYellowCards;
        private Label label1;
        private Label label2;
        private Label label3;
        private PictureBox pbCaptain;
        private PictureBox pbFavourite;
        private PictureBox pbProfile;
    }
}
