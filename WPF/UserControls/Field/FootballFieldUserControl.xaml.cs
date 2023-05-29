using DAL.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.UserControls.Field;

namespace WPF.UserControls
{
    /// <summary>
    /// Interaction logic for FootballFieldUserControl.xaml
    /// </summary>
    public partial class FootballFieldUserControl : UserControl
    {
        private Team home;
        private Team away;
        private Match match;

        public FootballFieldUserControl(Team home, Team away, Match match)
        {
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
                if (player.Position == Position.Goalie)
                {
                    spLeftGoalie.Children.Add(new PlayerBubbleUserControl(player, true));
                } else if (player.Position == Position.Defender)
                {
                    spLeftDefender.Children.Add(new PlayerBubbleUserControl(player, true));
                } else if (player.Position == Position.Midfield)
                {
                    spLeftMidfield.Children.Add(new PlayerBubbleUserControl(player, true));
                } else if (player.Position == Position.Forward)
                {
                    spLeftForward.Children.Add(new PlayerBubbleUserControl(player, true));
                }
            }

            foreach (Player player in awayTeam)
            {
                if (player.Position == Position.Goalie)
                {
                    spRightGoalie.Children.Add(new PlayerBubbleUserControl(player, false));
                } else if (player.Position == Position.Defender)
                {
                    spRightDefender.Children.Add(new PlayerBubbleUserControl(player, false));
                } else if (player.Position == Position.Midfield)
                {
                    spRightMidfield.Children.Add(new PlayerBubbleUserControl(player, false));
                } else if (player.Position == Position.Forward)
                {
                    spRightForward.Children.Add(new PlayerBubbleUserControl(player, false));
                }
            }
        }
    }
}
