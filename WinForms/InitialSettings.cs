using DAL;
using DAL.Repository;
using DAL.Settings;

namespace WinForms
{
    public partial class InitialSettings : Form
    {
        private const string HR = "hr", EN = "en";
        private Settings settings;

        public InitialSettings()
        {
            InitializeComponent();
        }

        private void InitialSettings_Load(object sender, EventArgs e)
        {
            settings = SettingsService.Load();

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
            settings.Language = cbLanguage.SelectedItem.ToString();
            settings.DataRepositoryType = Enum.Parse<EnumDataRepositoryType>(cbRepoType.SelectedItem.ToString());
            settings.Gender = Enum.Parse<EnumGender>(cbGender.SelectedItem.ToString());

            SettingsService.Save(settings);
        }

        public Settings GetSettings()
        {
            return settings;
        }
    }
}
