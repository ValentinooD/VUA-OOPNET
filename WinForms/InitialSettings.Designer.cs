namespace WinForms
{
    partial class InitialSettings
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
            cbLanguage = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbGender = new ComboBox();
            btnConfirm = new Button();
            label3 = new Label();
            cbRepoType = new ComboBox();
            SuspendLayout();
            // 
            // cbLanguage
            // 
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Location = new Point(14, 31);
            cbLanguage.Name = "cbLanguage";
            cbLanguage.Size = new Size(121, 23);
            cbLanguage.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 1;
            label1.Text = "Language:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 69);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 3;
            label2.Text = "Gender:";
            // 
            // cbGender
            // 
            cbGender.FormattingEnabled = true;
            cbGender.Location = new Point(12, 87);
            cbGender.Name = "cbGender";
            cbGender.Size = new Size(121, 23);
            cbGender.TabIndex = 2;
            // 
            // btnConfirm
            // 
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Location = new Point(227, 69);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(121, 41);
            btnConfirm.TabIndex = 4;
            btnConfirm.Text = "Confirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 13);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 6;
            label3.Text = "Repository type";
            // 
            // cbRepoType
            // 
            cbRepoType.FormattingEnabled = true;
            cbRepoType.Location = new Point(227, 31);
            cbRepoType.Name = "cbRepoType";
            cbRepoType.Size = new Size(121, 23);
            cbRepoType.TabIndex = 5;
            // 
            // InitialSettings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(366, 133);
            Controls.Add(label3);
            Controls.Add(cbRepoType);
            Controls.Add(btnConfirm);
            Controls.Add(label2);
            Controls.Add(cbGender);
            Controls.Add(label1);
            Controls.Add(cbLanguage);
            Name = "InitialSettings";
            Text = "Settings";
            FormClosed += InitialSettings_FormClosed;
            Load += InitialSettings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbLanguage;
        private Label label1;
        private Label label2;
        private ComboBox cbGender;
        private Button btnConfirm;
        private Label label3;
        private ComboBox cbRepoType;
    }
}