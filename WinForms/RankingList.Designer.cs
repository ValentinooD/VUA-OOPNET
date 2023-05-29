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
            resources.ApplyResources(flpPlayers, "flpPlayers");
            flpPlayers.AllowDrop = true;
            flpPlayers.Name = "flpPlayers";
            // 
            // btnPrint
            // 
            resources.ApplyResources(btnPrint, "btnPrint");
            btnPrint.Name = "btnPrint";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // pnlMain
            // 
            resources.ApplyResources(pnlMain, "pnlMain");
            pnlMain.Controls.Add(btnPrint);
            pnlMain.Controls.Add(flpPlayers);
            pnlMain.Name = "pnlMain";
            // 
            // printPreviewDialog
            // 
            resources.ApplyResources(printPreviewDialog, "printPreviewDialog");
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.Name = "printPreviewDialog1";
            // 
            // printDocument
            // 
            printDocument.PrintPage += printDocument1_PrintPage;
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

        private FlowLayoutPanel flpPlayers;
        private Button btnPrint;
        private Panel pnlMain;
        private PrintPreviewDialog printPreviewDialog;
        private System.Drawing.Printing.PrintDocument printDocument;
    }
}