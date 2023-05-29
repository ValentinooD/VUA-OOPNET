using DAL;
using DAL.Repository;
using DAL.Settings;

namespace WinForms
{
    public partial class SettingsForm : Form
    {
        private const string HR = "hr", EN = "en";
        private Settings settings;

        public SettingsForm(Settings settings) : this()
        {
            this.settings = settings;
        }

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void InitialSettings_Load(object sender, EventArgs e)
        {
            if (settings == null)
            {
                settings = SettingsService.Load();
            }

            foreach (EnumGender gender in Enum.GetValues(typeof(EnumGender)))
            {
                cbGender.Items.Add(gender.ToString());
            }

            foreach (EnumDataRepositoryType type in Enum.GetValues(typeof(EnumDataRepositoryType)))
            {
                cbRepoType.Items.Add(type.ToString());
            }

            cbLanguage.Items.Add(HR);
            cbLanguage.Items.Add(EN);

            cbLanguage.SelectedItem = settings.Language;
            cbRepoType.SelectedIndex = (int)settings.DataRepositoryType;
            cbGender.SelectedIndex = (int)settings.Gender;
        }

        private void InitialSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            SettingsService.Save(settings);
        }

        public Settings GetSettings()
        {
            return settings;
        }

        private void cbRepoType_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.DataRepositoryType = Enum.Parse<EnumDataRepositoryType>(cbRepoType.SelectedItem.ToString());
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.Language = cbLanguage.SelectedItem.ToString();
        }

        private void cbGender_SelectedIndexChanged(object sender, EventArgs e)
        {
            settings.Gender = Enum.Parse<EnumGender>(cbGender.SelectedItem.ToString());
        }
    }
}
