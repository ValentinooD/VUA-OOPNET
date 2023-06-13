using DAL.Models;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WPF.UserControls;

namespace WPF
{
    public partial class MatchInfoUserControl : UserControl
    {
        private Settings settings;
        private Team home;
        private Team away;
        private Match match;

        public MatchInfoUserControl(Settings settings, Team home, Team away, Match match)
        {
            this.settings = settings;
            this.home = home;
            this.away = away;
            this.match = match;

            InitializeComponent();

            this.Loaded += UserControl_Loaded;
        }

        public Match Match { 
            set { 
                this.match = value;

                Load();
            } 
        }

        private void Load()
        {
            if (match == null)
            {
                lbHomeTeam.Content = "match is null";
                return;
            }
             
            lbHomeTeam.Content = home.Country;
            lbAwayTeam.Content = away.Country;

            lbHomeScore.Content = (home == match.HomeTeam ? match.HomeTeam.Goals : match.AwayTeam.Goals);
            lbAwayScore.Content = (away == match.AwayTeam ? match.AwayTeam.Goals : match.HomeTeam.Goals);

            ucFootballField.Content = new FootballFieldUserControl(settings, home, away, match);
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Load();
        }
    }
}
