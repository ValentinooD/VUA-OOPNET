using DAL.Models;
using DAL.Repository;
using RestSharp;
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
    /// Interaction logic for TeamInfoWindow.xaml
    /// </summary>
    public partial class TeamInfoWindow : Window
    {
        private Team team;
        private IDataRepository repository;

        private Result? result;
        private List<Player> players;
        
        public TeamInfoWindow(Team team, IDataRepository repository)
        {
            this.team = team;
            this.repository = repository;

            InitializeComponent();

            this.Loaded += Window_Loaded;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetLoading(true);

            string? code = team.FifaCode;
            if (team.FifaCode == null) code = team.Code;

            result = await repository.GetTeamResult(code);
            players = (await repository.GetPlayers(code)).ToList();

            SetLoading(false);

            this.Title = "Team Information - " + team.ToString();
            lbCountry.Content = team.ToString();

            if (result == null)
            {
                SetAllText("Not available");
                return;
            }

            lbWins.Content = result.Wins;
            lbDraws.Content = result.Draws;
            lbLosses.Content = result.Losses;

            lbGamesPlayed.Content = result.GamesPlayed;
                
            lbPoints.Content = result.Points;
            lbGoalsAgainst.Content = result.GoalsAgainst;
                
            lbGoalsFor.Content = result.GoalsFor;
            lbGoalsAgainst.Content = result.GoalsAgainst;
            lbGoalsDiff.Content = result.GoalDifferential;

            foreach (Player player in players)
            {
                Label lbl = new Label();
                lbl.Content = player.Name + " (" + player.ShirtNumber + ")";
                lbl.Height = 28;
                lbl.HorizontalAlignment = HorizontalAlignment.Stretch;
                
                spPlayerList.Children.Add(lbl);
            }
        }

        private void SetLoading(bool loading)
        {
            if (loading)
                SetAllText("Loading...");
            else
                SetAllText("Not available");
        }

        private void SetAllText(string str)
        {
            lbWins.Content = str;
            lbDraws.Content = str;
            lbLosses.Content = str;

            lbGamesPlayed.Content = str;

            lbPoints.Content = str;
            lbGoalsAgainst.Content = str;

            lbGoalsFor.Content = str;
            lbGoalsAgainst.Content = str;
            lbGoalsDiff.Content = str;
        }
    }
}
