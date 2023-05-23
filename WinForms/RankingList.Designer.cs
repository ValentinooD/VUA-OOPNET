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
            flpPlayers = new FlowLayoutPanel();
            btnPrint = new Button();
            pnlMain = new Panel();
            printPreviewDialog = new PrintPreviewDialog();
            printDocument = new System.Drawing.Printing.PrintDocument();
            pnlMain.SuspendLayout();
            SuspendLayout();
            // 
            // flpPlayers
            // 
            flpPlayers.AllowDrop = true;
            flpPlayers.AutoScroll = true;
            flpPlayers.Location = new Point(11, 55);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(369, 408);
            flpPlayers.TabIndex = 0;
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(12, 12);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(368, 34);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // pnlMain
            // 
            pnlMain.Controls.Add(btnPrint);
            pnlMain.Controls.Add(flpPlayers);
            pnlMain.Location = new Point(1, 0);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(393, 466);
            pnlMain.TabIndex = 2;
            // 
            // printPreviewDialog
            // 
            printPreviewDialog.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog.ClientSize = new Size(400, 300);
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Enabled = true;
            printPreviewDialog.Icon = (Icon)resources.GetObject("printPreviewDialog.Icon");
            printPreviewDialog.Name = "printPreviewDialog1";
            printPreviewDialog.Visible = false;
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument1_PrintPage;
            // 
            // RankingList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(389, 467);
            Controls.Add(pnlMain);
            Name = "RankingList";
            Text = "Ranking List";
            Load += RankingList_Load;
            pnlMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flpPlayers;
        private Button btnPrint;
        private Panel pnlMain;
        private PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}