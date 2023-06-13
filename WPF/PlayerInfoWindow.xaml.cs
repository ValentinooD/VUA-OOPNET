using DAL.Models;
using DAL.Settings;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
using WPF.Properties;

namespace WPF
{
    public partial class PlayerInfoWindow : Window
    {
        private Player player;
        private Team team;
        private TeamStatistics stats;
        private Settings settings;
        
        public PlayerInfoWindow(Settings settings, Team team, TeamStatistics stats, Player player)
        {
            this.settings = settings;
            this.team = team;
            this.stats = stats;
            this.player = player;

            InitializeComponent();
            this.Loaded += Window_Loaded;            
            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetLoading(true);

            long? goalsScored = team.Goals;
            long? yellowCards = stats.YellowCards;

            if (settings?.ProfilePictures.ContainsKey(player.Name) ?? false)
            {
                Uri uri = new Uri(settings?.ProfilePictures[player.Name], UriKind.Absolute);
                picture.Source = new BitmapImage(uri);
            }

            SetLoading(false);

            lbFullName.Content = player.Name + " (" + player.ShirtNumber + ")";
            lbCaptain.Content = (player.Captain ? Properties.Resources.yes : Properties.Resources.no);
            lbGoalsScored.Content = (goalsScored.HasValue ? goalsScored.Value : "0") + "";
            lbYellowCards.Content = (yellowCards.HasValue ? yellowCards.Value : "0") + "";
            lbPosition.Content = player.Position;
        }

        private void SetLoading(bool loading)
        {
            if (loading)
                SetAllText(Properties.Resources.loading);
            else
                SetAllText(Properties.Resources.not_available);
        }

        private void SetAllText(string str)
        {
            lbFullName.Content = str;
            lbCaptain.Content = str;
            lbGoalsScored.Content = str;
            lbYellowCards.Content = str;
            lbPosition.Content = str;
        }
    }
}
