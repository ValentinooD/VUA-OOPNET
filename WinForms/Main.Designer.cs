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
            cbFavTeam = new ComboBox();
            label5 = new Label();
            flpPlayers = new FlowLayoutPanel();
            flpFavouritePlayers = new FlowLayoutPanel();
            btnRankingList = new Button();
            SuspendLayout();
            // 
            // cbFavTeam
            // 
            cbFavTeam.FormattingEnabled = true;
            cbFavTeam.Location = new Point(12, 32);
            cbFavTeam.Name = "cbFavTeam";
            cbFavTeam.Size = new Size(190, 23);
            cbFavTeam.TabIndex = 5;
            cbFavTeam.SelectedIndexChanged += cbFavTeam_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(89, 15);
            label5.TabIndex = 6;
            label5.Text = "Favourite team:";
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            flpPlayers.AutoScroll = true;
            flpPlayers.BorderStyle = BorderStyle.FixedSingle;
            flpPlayers.Location = new Point(12, 61);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(350, 370);
            flpPlayers.TabIndex = 7;
            flpPlayers.DragDrop += flpPlayers_DragDrop;
            flpPlayers.DragEnter += flp_DragEnter;
            // 
            // flpFavouritePlayers
            // 
            flpFavouritePlayers.AllowDrop = true;
            flpFavouritePlayers.AutoScroll = true;
            flpFavouritePlayers.BorderStyle = BorderStyle.FixedSingle;
            flpFavouritePlayers.Location = new Point(438, 61);
            flpFavouritePlayers.Name = "flpFavouritePlayers";
            flpFavouritePlayers.Size = new Size(350, 370);
            flpFavouritePlayers.TabIndex = 8;
            flpFavouritePlayers.DragDrop += flpFavouritePlayers_DragDrop;
            flpFavouritePlayers.DragEnter += flp_DragEnter;
            // 
            // btnRankingList
            // 
            btnRankingList.Location = new Point(658, 31);
            btnRankingList.Name = "btnRankingList";
            btnRankingList.Size = new Size(130, 23);
            btnRankingList.TabIndex = 9;
            btnRankingList.Text = "Show ranking list";
            btnRankingList.UseVisualStyleBackColor = true;
            btnRankingList.Click += btnRankingList_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRankingList);
            Controls.Add(flpFavouritePlayers);
            Controls.Add(flpPlayers);
            Controls.Add(label5);
            Controls.Add(cbFavTeam);
            Name = "Main";
            Text = "OOP NET";
            FormClosing += Main_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ComboBox cbFavTeam;
        private Label label5;
        private FlowLayoutPanel flpPlayers;
        private FlowLayoutPanel flpFavouritePlayers;
        private Button btnRankingList;
    }
}