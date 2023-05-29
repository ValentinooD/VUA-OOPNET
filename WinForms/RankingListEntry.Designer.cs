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
            resources.ApplyResources(lbName, "lbName");
            lbName.Name = "lbName";
            // 
            // lbPosition
            // 
            resources.ApplyResources(lbPosition, "lbPosition");
            lbPosition.Name = "lbPosition";
            // 
            // lbGoals
            // 
            resources.ApplyResources(lbGoals, "lbGoals");
            lbGoals.Name = "lbGoals";
            // 
            // lbYellowCards
            // 
            resources.ApplyResources(lbYellowCards, "lbYellowCards");
            lbYellowCards.Name = "lbYellowCards";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // pbCaptain
            // 
            resources.ApplyResources(pbCaptain, "pbCaptain");
            pbCaptain.Name = "pbCaptain";
            pbCaptain.TabStop = false;
            // 
            // pbFavourite
            // 
            resources.ApplyResources(pbFavourite, "pbFavourite");
            pbFavourite.Name = "pbFavourite";
            pbFavourite.TabStop = false;
            // 
            // pbProfile
            // 
            resources.ApplyResources(pbProfile, "pbProfile");
            pbProfile.Image = Properties.Resources.person;
            pbProfile.Name = "pbProfile";
            pbProfile.TabStop = false;
            // 
            // RankingListEntry
            // 
            resources.ApplyResources(this, "$this");
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
