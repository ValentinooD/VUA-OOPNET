namespace WinForms
{
    partial class RankingList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RankingList));
            flpContainer = new FlowLayoutPanel();
            btnPrintPlayers = new Button();
            pnlMain = new Panel();
            cbWhat = new ComboBox();
            btnPrintMatches = new Button();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // flpContainer
            // 
            flpContainer.AllowDrop = true;
            resources.ApplyResources(flpContainer, "flpContainer");
            flpContainer.Name = "flpContainer";
            // 
            // btnPrintPlayers
            // 
            resources.ApplyResources(btnPrintPlayers, "btnPrintPlayers");
            btnPrintPlayers.Name = "btnPrintPlayers";
            btnPrintPlayers.UseVisualStyleBackColor = true;
            btnPrintPlayers.Click += btnPrint_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(cbWhat);
            pnlMain.Controls.Add(btnPrintMatches);
            pnlMain.Controls.Add(btnPrintPlayers);
            pnlMain.Controls.Add(flpContainer);
            resources.ApplyResources(pnlMain, "pnlMain");
            pnlMain.Name = "pnlMain";
            // 
            // cbWhat
            // 
            cbWhat.FormattingEnabled = true;
            resources.ApplyResources(cbWhat, "cbWhat");
            cbWhat.Name = "cbWhat";
            cbWhat.SelectedIndexChanged += cbWhat_SelectedIndexChanged;
            // 
            // btnPrintMatches
            // 
            resources.ApplyResources(btnPrintMatches, "btnPrintMatches");
            btnPrintMatches.Name = "btnPrintMatches";
            btnPrintMatches.UseVisualStyleBackColor = true;
            btnPrintMatches.Click += btnPrintMatches_Click;
            // 
            // RankingList
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlMain);
            Name = "RankingList";
            Load += RankingList_Load;
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpContainer;
        private Button btnPrintPlayers;
        private Panel pnlMain;
        private Button btnPrintMatches;
        private ComboBox cbWhat;
    }
}