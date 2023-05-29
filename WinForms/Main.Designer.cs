namespace WinForms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            cbFavTeam = new ComboBox();
            label5 = new Label();
            flpPlayers = new FlowLayoutPanel();
            flpFavouritePlayers = new FlowLayoutPanel();
            btnRankingList = new Button();
            menuStrip1 = new MenuStrip();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // cbFavTeam
            // 
            resources.ApplyResources(cbFavTeam, "cbFavTeam");
            cbFavTeam.FormattingEnabled = true;
            cbFavTeam.Name = "cbFavTeam";
            cbFavTeam.SelectedIndexChanged += cbFavTeam_SelectedIndexChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // flpPlayers
            // 
            resources.ApplyResources(flpPlayers, "flpPlayers");
            flpPlayers.AllowDrop = true;
            flpPlayers.BorderStyle = BorderStyle.FixedSingle;
            flpPlayers.Name = "flpPlayers";
            flpPlayers.DragDrop += flpPlayers_DragDrop;
            flpPlayers.DragEnter += flp_DragEnter;
            // 
            // flpFavouritePlayers
            // 
            resources.ApplyResources(flpFavouritePlayers, "flpFavouritePlayers");
            flpFavouritePlayers.AllowDrop = true;
            flpFavouritePlayers.BorderStyle = BorderStyle.FixedSingle;
            flpFavouritePlayers.Name = "flpFavouritePlayers";
            flpFavouritePlayers.DragDrop += flpFavouritePlayers_DragDrop;
            flpFavouritePlayers.DragEnter += flp_DragEnter;
            // 
            // btnRankingList
            // 
            resources.ApplyResources(btnRankingList, "btnRankingList");
            btnRankingList.Name = "btnRankingList";
            btnRankingList.UseVisualStyleBackColor = true;
            btnRankingList.Click += btnRankingList_Click;
            // 
            // menuStrip1
            // 
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Items.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            menuStrip1.Name = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            resources.ApplyResources(settingsToolStripMenuItem, "settingsToolStripMenuItem");
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem1, exitToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            // 
            // settingsToolStripMenuItem1
            // 
            resources.ApplyResources(settingsToolStripMenuItem1, "settingsToolStripMenuItem1");
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem1_Click;
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // Main
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRankingList);
            Controls.Add(flpFavouritePlayers);
            Controls.Add(flpPlayers);
            Controls.Add(label5);
            Controls.Add(cbFavTeam);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Main";
            FormClosing += Main_FormClosing;
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbFavTeam;
        private Label label5;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flpFavouritePlayers;
        private Button btnRankingList;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
    }
}