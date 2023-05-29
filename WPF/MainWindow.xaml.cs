using DAL.Models;
using DAL.Repository;
using DAL.Settings;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Settings settings;
        private IDataRepository repository;
        private bool loading;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            this.Closed += MainWindow_Closed;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (SettingsService.IsFirstRun())
            {
                settings = new Settings();
                SettingsWindow window = new SettingsWindow(settings);
                window.Show();
            }
            else
            {
                settings = SettingsService.Load();
            }

            repository = DataRepositoryFactory.GetRepository(settings.DataRepositoryType, settings.Gender);

            ucMatchInfo.Content = new NoMatchSelectedUserControl();

            LoadComboBoxes();
            LoadMatch();
        }

        private async void LoadMatch()
        {
            if (settings.FavouriteTeam == null || settings.FavouriteAwayTeam == null)
                return;

            SetLoading(true);

            Team home = (Team)cbHomeTeam.SelectedValue;
            Team away = (Team)cbAwayTeam.SelectedValue;

            List<Match> matches = await repository.GetMatches(settings.FavouriteTeam);
            matches = matches.Where(m => m.AwayTeam.Code.Equals(settings.FavouriteAwayTeam) || m.HomeTeam.Code.Equals(settings.FavouriteAwayTeam)).ToList();

            if (matches.Count > 0 && home != null && away != null)
            {
                ucMatchInfo.Content = new MatchInfoUserControl(home, away, matches[0]);
            }
            else
            {
                ucMatchInfo.Content = new NoMatchSelectedUserControl();
            }

            SetLoading(false);
        }

        private async void LoadComboBoxes()
        {
            SetLoading(true);

            List<Team> teams = await repository.GetTeams();
            Team? selectedHome = null;
            foreach (Team team in teams)
            {
                cbHomeTeam.Items.Add(team);

                if (team.FifaCode.Equals(settings.FavouriteTeam))
                {
                    selectedHome = team;
                }
            }

            cbHomeTeam.SelectedItem = selectedHome;

            LoadAwayTeamComboBox();

            SetLoading(false);
        }

        private async void LoadAwayTeamComboBox()
        {
            SetLoading(true);

            if (cbHomeTeam.SelectedValue == null) return;

            List<Match> matches = await repository.GetMatches(settings.FavouriteTeam);

            cbAwayTeam.Items.Clear();

            if (matches.Count == 0)
            {
                SetLoading(false);

                cbAwayTeam.IsEnabled = false;
                btnInfoAwayTeam.IsEnabled = false;
                return;
            }

            Team homeSelected = (Team) cbHomeTeam.SelectedValue;
            Team? selectedAway = null;
            foreach (Match m in matches)
            {
                Team team;

                if (m.HomeTeam.Code.Equals(homeSelected.FifaCode)) team = m.AwayTeam;
                else                            team = m.HomeTeam;
                
                cbAwayTeam.Items.Add(team);

                if (settings.FavouriteAwayTeam != null
                        && settings.FavouriteAwayTeam.Equals(team.Code))
                {
                    selectedAway = team;
                }
            }

            cbAwayTeam.SelectedItem = selectedAway;
            LoadMatch();
            
            SetLoading(false);
        }

        private void MainWindow_Closed(object? sender, EventArgs e)
        {
            SettingsService.Save(settings);
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            new SettingsWindow(settings).ShowDialog();
        }

        public void SetLoading(bool loading)
        {
            this.loading = loading;

            cbHomeTeam.IsEnabled = !loading;
            cbAwayTeam.IsEnabled = !loading;

            btnInfoHomeTeam.IsEnabled = !loading;
            btnInfoAwayTeam.IsEnabled = !loading;

            pbLoading.Value = (loading ? 0 : 101);
            pbLoading.Visibility = (loading ? Visibility.Visible : Visibility.Hidden);   
        }

        private void cbTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loading) return;

            Team team = (Team) e.AddedItems[0];

            if (team == null) return;

            if (sender == cbHomeTeam)
            {
                settings.FavouriteTeam = team.FifaCode;
                LoadAwayTeamComboBox();
            }

            if (sender == cbAwayTeam)
            {
                settings.FavouriteAwayTeam = team.Code;
                LoadMatch();
            }
        }

        private void InfoHomeButton_Click(object sender, RoutedEventArgs e)
        {
            if (loading) return;
            Team team = (Team) cbHomeTeam.SelectedItem;
            if (team == null) return;
            new TeamInfoWindow(team, repository).ShowDialog();
        }

        private void InfoAwayButton_Click(object sender, RoutedEventArgs e)
        {
            if (loading) return;
            Team team = (Team) cbAwayTeam.SelectedItem;
            if (team == null) return;
            new TeamInfoWindow(team, repository).ShowDialog();
        }
    }
}
