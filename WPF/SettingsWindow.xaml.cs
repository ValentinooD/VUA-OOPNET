using DAL.Repository;
using DAL;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        private const string HR = "hr", EN = "en";
        private Settings settings;

        public SettingsWindow(Settings settings)
        {
            this.settings = settings;
            InitializeComponent();

            if (settings.Resolution == null)
            {
                settings.Resolution = new Resolution();
            }

            cbLanguage.Items.Add(HR);
            cbLanguage.Items.Add(EN);

            foreach (EnumGender gender in Enum.GetValues(typeof(EnumGender)))
            {
                cbGender.Items.Add(gender.ToString());
            }

            foreach (EnumDataRepositoryType type in Enum.GetValues(typeof(EnumDataRepositoryType)))
            {
                cbRepoType.Items.Add(type.ToString());
            }

            foreach (Resolution.WindowState state in Enum.GetValues(typeof(Resolution.WindowState)))
            {
                cbWindowMode.Items.Add(state.ToString());
            }

            cbLanguage.SelectedItem = settings.Language;
            cbRepoType.SelectedIndex = (int) settings.DataRepositoryType;
            cbGender.SelectedIndex = (int) settings.Gender;
            cbWindowMode.SelectedIndex = (int) settings.Resolution.State;
        }

        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = e.AddedItems[0].ToString();
            settings.Language = selection;
        }

        private void cbRepoType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = e.AddedItems[0].ToString();
            settings.DataRepositoryType = Enum.Parse<EnumDataRepositoryType>(selection);
        }

        private void cbGender_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = e.AddedItems[0].ToString();
            settings.Gender = Enum.Parse<EnumGender>(selection);
        }
        
        private void cbWindowState_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selection = e.AddedItems[0].ToString();
            settings.Resolution.State = Enum.Parse<Resolution.WindowState>(selection);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsService.Save(settings);
            Close();
        }
    }
}
