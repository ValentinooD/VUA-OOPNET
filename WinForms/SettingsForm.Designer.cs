namespace WinForms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
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
            resources.ApplyResources(cbLanguage, "cbLanguage");
            cbLanguage.FormattingEnabled = true;
            cbLanguage.Name = "cbLanguage";
            cbLanguage.SelectedIndexChanged += cbLanguage_SelectedIndexChanged;
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
            // cbGender
            // 
            resources.ApplyResources(cbGender, "cbGender");
            cbGender.FormattingEnabled = true;
            cbGender.Name = "cbGender";
            cbGender.SelectedIndexChanged += cbGender_SelectedIndexChanged;
            // 
            // btnConfirm
            // 
            resources.ApplyResources(btnConfirm, "btnConfirm");
            btnConfirm.DialogResult = DialogResult.OK;
            btnConfirm.Name = "btnConfirm";
            btnConfirm.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // cbRepoType
            // 
            resources.ApplyResources(cbRepoType, "cbRepoType");
            cbRepoType.FormattingEnabled = true;
            cbRepoType.Name = "cbRepoType";
            cbRepoType.SelectedIndexChanged += cbRepoType_SelectedIndexChanged;
            // 
            // SettingsForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label3);
            Controls.Add(cbRepoType);
            Controls.Add(btnConfirm);
            Controls.Add(label2);
            Controls.Add(cbGender);
            Controls.Add(label1);
            Controls.Add(cbLanguage);
            Name = "SettingsForm";
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