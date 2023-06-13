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
    public partial class MatchRankingListEntry : UserControl, IComparable<MatchRankingListEntry>
    {
        public Match Match { get; private set; }

        public MatchRankingListEntry(Match match)
        {
            this.Match = match;
            InitializeComponent();
        }

        public int CompareTo(MatchRankingListEntry? other)
        {
            if (other == null) return 0;
            return Match.Attendance.CompareTo(other.Match.Attendance);
        }

        private void RankingListEntry_Load(object sender, EventArgs e)
        {
            lbHomeTeam.Text = Match.HomeTeam.ToString();
            lbAwayTeam.Text = Match.AwayTeam.ToString();

            lbAttendance.Text = Match.Attendance.ToString();
            lbWinner.Text = Match.Winner;
            lbLocation.Text = Match.Location;
        }
    }
}
