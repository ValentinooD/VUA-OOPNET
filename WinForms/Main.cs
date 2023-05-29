using DAL;
using DAL.Models;
using DAL.Repository;
using DAL.Settings;
using System.Globalization;

namespace WinForms
{
    public partial class Main : Form
    {
        private Settings settings;
        private IDataRepository repository;

        public Main()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            if (SettingsService.IsFirstRun())
            {
                SettingsForm initial = new SettingsForm();
                initial.ShowDialog();

                settings = initial.GetSettings();
            }
            else
            {
                settings = SettingsService.Load();
            }

            SetCulture(settings.Language);

            repository = DataRepositoryFactory.GetRepository(settings.DataRepositoryType, settings.Gender);

            LoadComboBox();
        }

        private async void LoadComboBox()
        {
            cbFavTeam.Items.Clear();

            SetLoading(true);

            List<Team> teams = await repository.GetTeams();
            Team? selected = null;
            foreach (Team team in teams)
            {
                cbFavTeam.Items.Add(team);

                if (team.FifaCode.Equals(settings.FavouriteTeam))
                {
                    selected = team;
                }
            }
            cbFavTeam.SelectedItem = selected; // This calls LoadPlayers()

            // Since LoadPlayers() isn't called, we have to reset the loading state here
            if (selected == null)
            {
                settings.FavouriteTeam = null;
                cbFavTeam.SelectedIndex = -1; // also remove selection from ComboBox
                SetLoading(false);
            }
        }

        private async void LoadPlayers()
        {
            flpPlayers.Controls.Clear();
            flpFavouritePlayers.Controls.Clear();

            SetLoading(true);

            HashSet<Player> players = await repository.GetPlayers(settings.FavouriteTeam);

            SetLoading(false);

            foreach (Player player in players)
            {
                bool favourite = settings.FavouritePlayerNames != null && settings.FavouritePlayerNames.Contains(player.Name);
                PlayerInfoUserControl ctrl = new PlayerInfoUserControl(settings, player, favourite);

                if (favourite)
                {
                    flpFavouritePlayers.Controls.Add(ctrl);
                }
                else
                {
                    flpPlayers.Controls.Add(ctrl);
                }
            }
        }

        private void SetLoading(bool loading)
        {
            cbFavTeam.Enabled = !loading;
            btnRankingList.Enabled = !loading;
            UseWaitCursor = loading;
        }

        private void SetCulture(string lang)
        {
            var culture = new CultureInfo(lang);

            Thread.CurrentThread.CurrentUICulture = culture;
            Thread.CurrentThread.CurrentCulture = culture;

            this.Controls.Clear();
            InitializeComponent();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (settings != null)
            {
                SettingsService.Save(settings); // save one last time
            }
        }

        private void cbFavTeam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;

            if (box.SelectedItem == null)
            {
                settings.FavouriteTeam = null;
                return;
            }

            settings.FavouriteTeam = ((Team)box.SelectedItem).FifaCode;

            LoadPlayers();
        }

        private void flpPlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerInfoUserControl ctrl = (PlayerInfoUserControl)e.Data.GetData(typeof(PlayerInfoUserControl));

            SetFavourite(ctrl, false);
        }

        private void flpFavouritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            PlayerInfoUserControl ctrl = (PlayerInfoUserControl)e.Data.GetData(typeof(PlayerInfoUserControl));

            SetFavourite(ctrl, true);
        }

        private void flp_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private async void SetFavourite(PlayerInfoUserControl ctrl, bool favourite)
        {

            if (favourite)
            {
                if ((await GetPlayerCount()) >= 3)
                {
                    return;
                }

                settings.FavouritePlayerNames.Add(ctrl.GetPlayer().Name);

                flpPlayers.Controls.Remove(ctrl);
                flpFavouritePlayers.Controls.Add(ctrl);
            }
            else
            {
                settings.FavouritePlayerNames.Remove(ctrl.GetPlayer().Name);

                flpFavouritePlayers.Controls.Remove(ctrl);
                flpPlayers.Controls.Add(ctrl);
            }

            ctrl.SetFavourite(favourite);
        }

        private Task<int> GetPlayerCount()
        {
            return Task.Run(() =>
            {
                int count = 0;
                HashSet<Player> players = repository.GetPlayers(settings.FavouriteTeam).Result;
                foreach (Player player in players)
                {
                    if (settings.FavouritePlayerNames.Contains(player.Name))
                        count++;
                }

                return count;
            });
        }

        private void btnRankingList_Click(object sender, EventArgs e)
        {
            if (settings.FavouriteTeam == null)
            {
                MessageBox.Show(Resource.err_no_selection);
                return;
            }

            RankingList list = new RankingList(settings, repository, settings.FavouriteTeam);
            list.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SettingsForm sett = new SettingsForm(settings);
            sett.ShowDialog();

            settings = sett.GetSettings();

            SetCulture(settings.Language);

            repository = DataRepositoryFactory.GetRepository(settings.DataRepositoryType, settings.Gender);

            flpPlayers.Controls.Clear();
            flpFavouritePlayers.Controls.Clear();

            LoadComboBox();
        }
    }
}