using DAL.Models;
using DAL.Settings;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WPF.UserControls.Field;

namespace WPF.UserControls
{
    public partial class FootballFieldUserControl : UserControl
    {
        private Settings settings;
        private Team home;
        private Team away;
        private Match match;

        public FootballFieldUserControl(Settings settings, Team home, Team away, Match match)
        {
            this.settings = settings;
            this.home = home;
            this.away = away;
            this.match = match;

            InitializeComponent();

            this.Loaded += UserControl_Loaded;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Player[] homeTeam = (home.Country.Equals(match.HomeTeamStatistics.Country) ?
                match.HomeTeamStatistics.StartingEleven : match.AwayTeamStatistics.StartingEleven);

            Player[] awayTeam = (away.Country.Equals(match.AwayTeamStatistics.Country) ?
                match.AwayTeamStatistics.StartingEleven : match.HomeTeamStatistics.StartingEleven);


            foreach (Player player in homeTeam)
            {
                PlayerBubbleUserControl ctrl = new PlayerBubbleUserControl(player, true);
                ctrl.MouseDown += HomePlayerBubbleClicked;

                if (player.Position == Position.Goalie)
                {
                    spLeftGoalie.Children.Add(ctrl);
                } else if (player.Position == Position.Defender)
                {
                    spLeftDefender.Children.Add(ctrl);
                } else if (player.Position == Position.Midfield)
                {
                    spLeftMidfield.Children.Add(ctrl);
                } else if (player.Position == Position.Forward)
                {
                    spLeftForward.Children.Add(ctrl);
                }
            }

            foreach (Player player in awayTeam)
            {
                PlayerBubbleUserControl ctrl = new PlayerBubbleUserControl(player, false);
                ctrl.MouseDown += AwayPlayerBubbleClicked;

                if (player.Position == Position.Goalie)
                {
                    spRightGoalie.Children.Add(ctrl);
                } else if (player.Position == Position.Defender)
                {
                    spRightDefender.Children.Add(ctrl);
                } else if (player.Position == Position.Midfield)
                {
                    spRightMidfield.Children.Add(ctrl);
                } else if (player.Position == Position.Forward)
                {
                    spRightForward.Children.Add(ctrl);
                }
            }
        }

        private void HomePlayerBubbleClicked(object sender, MouseButtonEventArgs e)
        {
            PlayerBubbleUserControl ctrl = (PlayerBubbleUserControl)e.Source;
            PlayerInfoWindow window = new PlayerInfoWindow(
                    settings,
                    home,
                    match.HomeTeamStatistics,
                    ctrl.Player
                );
            window.ShowDialog();
        }

        private void AwayPlayerBubbleClicked(object sender, MouseButtonEventArgs e)
        {
            PlayerBubbleUserControl ctrl = (PlayerBubbleUserControl)e.Source;
            PlayerInfoWindow window = new PlayerInfoWindow(
                    settings,
                    away,
                    match.AwayTeamStatistics,
                    ctrl.Player
                );
            window.ShowDialog();
        }
    }
}
