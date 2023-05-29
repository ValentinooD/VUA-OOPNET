using DAL.Models;
using DAL.Repository;
using DAL.Settings;

namespace WinForms
{
    public partial class RankingList : Form
    {
        private Settings settings;
        private IDataRepository repository;
        private string favouriteTeam;
        private List<RankingListEntry> players = new List<RankingListEntry>();

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

            List<RankingListEntry> players = await GetPlayersTask();
            foreach (var item in players)
            {
                flpPlayers.Controls.Add(item);
            }

            SetLoading(false);
        }

        private Task<List<RankingListEntry>> GetPlayersTask()
        {
            return Task.Run(() =>
            {
                List<Match> matches = repository.GetMatches(favouriteTeam).Result;

                repository.GetPlayers(favouriteTeam).Result.ToList().ForEach(p =>
                    {
                        players.Add(new RankingListEntry(settings, p));
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
                }

                foreach (var player in players)
                {
                    player.GoalsScored = goals.GetValueOrDefault(player.Player.Name, 0);
                    player.YellowCards = yellowCards.GetValueOrDefault(player.Player.Name, 0);
                }
                players.Sort();

                Thread.Sleep(1000);

                return players;
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
            btnPrint.Enabled = !loading;

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
            printPreviewDialog.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var x = e.MarginBounds.Left;
            var y = e.MarginBounds.Top;
            var bmp = new Bitmap(this.Size.Width, this.Size.Height);

            // each control has a defined DrawToBitmap method
            this.DrawToBitmap(bmp, new Rectangle
            {
                X = 0,
                Y = 0,
                Width = this.Size.Width,
                Height = this.Size.Height
            });
            e.Graphics?.DrawImage(bmp, x, y);
        }
    }
}
