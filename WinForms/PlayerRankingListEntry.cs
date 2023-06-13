using DAL.Models;
using DAL.Settings;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
    public partial class PlayerRankingListEntry : UserControl, IComparable<PlayerRankingListEntry>
    {
        private Settings settings;
        public Player Player { get; private set; }

        public int GoalsScored { get; set; }
        public int YellowCards { get; set; }
        public int Appearances { get; set; }

        public PlayerRankingListEntry(Settings settings, Player player)
        {
            this.settings = settings;
            this.Player = player;
            InitializeComponent();
        }

        public int CompareTo(PlayerRankingListEntry? other)
        {
            if (other == null) return 0;
            return other.GoalsScored.CompareTo(GoalsScored);
        }

        private void RankingListEntry_Load(object sender, EventArgs e)
        {
            lbName.Text = Player.Name;
            lbPosition.Text = Player.Position.ToString();

            if (settings?.ProfilePictures.ContainsKey(Player.Name) ?? false)
            {
                pbProfile.ImageLocation = settings?.ProfilePictures[Player.Name];
            }

            pbCaptain.Visible = Player.Captain;

            bool favourite = settings?.FavouritePlayerNames != null && settings.FavouritePlayerNames.Contains(Player.Name);
            pbFavourite.Visible = favourite;

            lbGoals.Text = GoalsScored + "";
            lbYellowCards.Text = YellowCards + "";
        }
    }
}
