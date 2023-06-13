using DAL.Models;
using DAL.Repository;
using DAL.Settings;
using System.Drawing.Printing;

namespace WinForms
{
    public partial class RankingList : Form
    {
        private Settings settings;
        private IDataRepository repository;
        private string favouriteTeam;
        private List<Player> players = new List<Player>();
        private List<Match> matches = new List<Match>();
        private List<PlayerRankingListEntry> playersEntriesList = new List<PlayerRankingListEntry>();
        private List<MatchRankingListEntry> matchesEntriesList = new List<MatchRankingListEntry>();

        public RankingList(Settings settings, IDataRepository repository, string favouriteTeam)
        {
            this.settings = settings;
            this.repository = repository;
            this.favouriteTeam = favouriteTeam;

            InitializeComponent();
        }

        private async void RankingList_Load(object sender, EventArgs e)
        {
            SetLoading(true);

            await GetPlayersTask();

            cbWhat.Items.Add("Players");
            cbWhat.Items.Add("Matches");

            SetLoading(false);

            cbWhat.SelectedIndex = 0;
        }

        private void cbWhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            flpContainer.Controls.Clear();

            if (cbWhat.SelectedIndex == 0)
            {
                foreach (PlayerRankingListEntry item in playersEntriesList)
                {
                    flpContainer.Controls.Add(item);
                }
            }
            else
            {
                foreach (MatchRankingListEntry item in matchesEntriesList)
                {
                    flpContainer.Controls.Add(item);
                }
            }
        }

        private Task<List<PlayerRankingListEntry>> GetPlayersTask()
        {
            return Task.Run(() =>
            {
                matches = repository.GetMatches(favouriteTeam).Result;

                players = repository.GetPlayers(favouriteTeam).Result.ToList();
                players.Sort();

                players.ForEach(p =>
                    {
                        playersEntriesList.Add(new PlayerRankingListEntry(settings, p));
                    });

                Dictionary<string, int> goals = new Dictionary<string, int>();
                Dictionary<string, int> yellowCards = new Dictionary<string, int>();
                Dictionary<string, int> appearances = new Dictionary<string, int>();
                foreach (var match in matches)
                {
                    CalculateEventOccurrances(goals, match.HomeTeamEvents, TypeOfEvent.Goal);
                    CalculateEventOccurrances(goals, match.AwayTeamEvents, TypeOfEvent.Goal);

                    CalculateEventOccurrances(yellowCards, match.HomeTeamEvents, TypeOfEvent.YellowCard, TypeOfEvent.YellowCardSecond);
                    CalculateEventOccurrances(yellowCards, match.AwayTeamEvents, TypeOfEvent.YellowCard, TypeOfEvent.YellowCardSecond);

                    matchesEntriesList.Add(new MatchRankingListEntry(match));
                }

                foreach (var player in playersEntriesList)
                {
                    player.GoalsScored = goals.GetValueOrDefault(player.Player.Name, 0);
                    player.YellowCards = yellowCards.GetValueOrDefault(player.Player.Name, 0);
                }
                playersEntriesList.Sort();

                return playersEntriesList;
            });
        }

        private void CalculateEventOccurrances(Dictionary<string, int> dict, TeamEvent[] events, params TypeOfEvent[] types)
        {
            foreach (var evt in events)
            {
                if (!types.Contains(evt.TypeOfEvent)) continue;

                int val = dict.GetValueOrDefault(evt.Player, 0) + 1;
                dict[evt.Player] = val;
            }
        }

        public void SetLoading(bool loading)
        {
            btnPrintPlayers.Enabled = !loading;

            if (loading)
            {
                Controls.Clear();

                Label label = new Label()
                {
                    Text = Resource.loading,
                    Font = new Font("Arial", 24),
                    ForeColor = Color.YellowGreen,
                    AutoSize = true
                };
                label.Location = new Point(
                    Size.Width / 2 - label.Size.Width,
                    Size.Height / 2 - label.Size.Height
                );
                Controls.Add(label);

            }
            else
            {
                Controls.Clear();
                Controls.Add(pnlMain);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += Document_Players;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            printPreviewDialog.ShowDialog();
        }

        private void btnPrintMatches_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += Document_Matches;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            printPreviewDialog.ShowDialog();
        }

        private void Document_Matches(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            Graphics graphics = e.Graphics;
            float currentY = 10;

            // Print match results
            graphics.DrawString("Matches", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new PointF(100, currentY));
            currentY += 30;

            foreach (Match match in matches)
            {
                graphics.DrawString(match.HomeTeam.ToString() + " vs " + match.AwayTeam.ToString(), new Font("Arial", 12), Brushes.Black, new PointF(20, currentY));

                currentY += 20;

                graphics.DrawString("Attendance: " + match.Attendance, new Font("Arial", 12), Brushes.Black, new PointF(40, currentY));

                graphics.DrawString("Winner: " + match.Winner, new Font("Arial", 12), Brushes.Black, new PointF(300, currentY));

                graphics.DrawString("Location: " + match.Location, new Font("Arial", 12), Brushes.Black, new PointF(500, currentY));

                currentY += 25;
            }
        }

        private void Document_Players(object sender, PrintPageEventArgs e)
        {
            if (e.Graphics == null) return;

            Graphics graphics = e.Graphics;
            float currentY = 10;

            // Print match results
            graphics.DrawString("Players", new Font("Arial", 18, FontStyle.Bold), Brushes.Black, new PointF(100, currentY));
            currentY += 30;

            foreach (PlayerRankingListEntry entry in playersEntriesList)
            {
                Player player = entry.Player;

                graphics.DrawString(player.Name + " (" + player.ShirtNumber + ")", new Font("Arial", 12), Brushes.Black, new PointF(20, currentY));

                graphics.DrawString(player.Position + "", new Font("Arial", 12), Brushes.Black, new PointF(300, currentY));

                graphics.DrawString("Captain: " + (player.Captain ? "yes" : "no"), new Font("Arial", 12), Brushes.Black, new PointF(500, currentY));

                currentY += 20;

                graphics.DrawString("Goals scored: " + entry.GoalsScored, new Font("Arial", 12), Brushes.Black, new PointF(300, currentY));

                graphics.DrawString("Appearances: " + entry.Appearances, new Font("Arial", 12), Brushes.Black, new PointF(500, currentY));

                graphics.DrawString("Yellow cards: " + entry.YellowCards, new Font("Arial", 12), Brushes.Black, new PointF(700, currentY));

                currentY += 25;
            }
        }
    }
}
