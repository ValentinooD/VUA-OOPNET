namespace WinForms
{
    partial class MatchRankingListEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MatchRankingListEntry));
            lbHomeTeam = new Label();
            lbAwayTeam = new Label();
            lbVs = new Label();
            lbTextAttendance = new Label();
            lbAttendance = new Label();
            lbTextWinner = new Label();
            lbWinner = new Label();
            lbTextLocation = new Label();
            lbLocation = new Label();
            SuspendLayout();
            // 
            // lbHomeTeam
            // 
            resources.ApplyResources(lbHomeTeam, "lbHomeTeam");
            lbHomeTeam.Name = "lbHomeTeam";
            // 
            // lbAwayTeam
            // 
            resources.ApplyResources(lbAwayTeam, "lbAwayTeam");
            lbAwayTeam.Name = "lbAwayTeam";
            // 
            // lbVs
            // 
            resources.ApplyResources(lbVs, "lbVs");
            lbVs.Name = "lbVs";
            // 
            // lbTextAttendance
            // 
            resources.ApplyResources(lbTextAttendance, "lbTextAttendance");
            lbTextAttendance.Name = "lbTextAttendance";
            // 
            // lbAttendance
            // 
            resources.ApplyResources(lbAttendance, "lbAttendance");
            lbAttendance.Name = "lbAttendance";
            // 
            // lbTextWinner
            // 
            resources.ApplyResources(lbTextWinner, "lbTextWinner");
            lbTextWinner.Name = "lbTextWinner";
            // 
            // lbWinner
            // 
            resources.ApplyResources(lbWinner, "lbWinner");
            lbWinner.Name = "lbWinner";
            // 
            // lbTextLocation
            // 
            resources.ApplyResources(lbTextLocation, "lbTextLocation");
            lbTextLocation.Name = "lbTextLocation";
            // 
            // lbLocation
            // 
            resources.ApplyResources(lbLocation, "lbLocation");
            lbLocation.Name = "lbLocation";
            // 
            // MatchRankingListEntry
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lbLocation);
            Controls.Add(lbTextLocation);
            Controls.Add(lbWinner);
            Controls.Add(lbTextWinner);
            Controls.Add(lbAttendance);
            Controls.Add(lbTextAttendance);
            Controls.Add(lbVs);
            Controls.Add(lbAwayTeam);
            Controls.Add(lbHomeTeam);
            Name = "MatchRankingListEntry";
            Load += RankingListEntry_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbHomeTeam;
        private Label lbAwayTeam;
        private Label lbVs;
        private Label lbTextAttendance;
        private Label lbAttendance;
        private Label lbTextWinner;
        private Label lbWinner;
        private Label lbTextLocation;
        private Label lbLocation;
    }
}
