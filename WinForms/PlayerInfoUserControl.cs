using DAL.Models;
using DAL.Settings;

namespace WinForms
{
    public partial class PlayerInfoUserControl : UserControl
    {
        private Player player;
        private Settings? settings;

        public PlayerInfoUserControl(Player player) : this(null, player, false) { }

        public PlayerInfoUserControl(Player player, bool favourite) : this(null, player, favourite) { }

        public PlayerInfoUserControl(Settings? settings, Player player) : this(settings, player, false) { }

        public PlayerInfoUserControl(Settings? settings, Player player, bool favourite)
        {
            this.player = player;
            this.settings = settings;

            InitializeComponent();

            lbName.Text = player.Name + " (" + player.ShirtNumber + ")";
            lbPosition.Text = player.Position.ToString();
            pbCaptain.Visible = player.Captain;
            pbFavourite.Visible = favourite;

            pbProfile.ContextMenuStrip = cms;

            if (settings?.ProfilePictures.ContainsKey(player.Name) ?? false)
            {
                pbProfile.ImageLocation = settings?.ProfilePictures[player.Name];
            }
            else
            {
                cms.Items[1].Enabled = false;
            }
        }

        private void PlayerInfoUserControl_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop(sender, DragDropEffects.Move);
        }

        public void SetFavourite(bool state)
        {
            pbFavourite.Visible = state;
        }

        public bool IsFavourite()
        {
            return pbFavourite.Visible;
        }

        public Player GetPlayer()
        {
            return player;
        }

        private void changePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbProfile.ImageLocation = ofd.FileName;

                cms.Items[1].Enabled = true;
                (settings?.ProfilePictures)[player.Name] = ofd.FileName;
            }
        }

        private void removePictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pbProfile.Image = pbProfile.InitialImage;

            cms.Items[1].Enabled = false;
            settings?.ProfilePictures.Remove(player.Name);
        }
    }
}
