using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace WPF.UserControls.Field
{
    /// <summary>
    /// Interaction logic for PlayerBubbleUserControl.xaml
    /// </summary>
    public partial class PlayerBubbleUserControl : UserControl
    {
        private const string IMG_SHIRT_HOME = "shirt_white.png";
        private const string IMG_SHIRT_AWAY = "shirt_black.png";

        private Player player;

        public PlayerBubbleUserControl(Player player, bool homeTeam)
        {
            this.player = player;
            InitializeComponent();

            tbName.Text = player.Name;
            lbShirtNumber.Content = player.ShirtNumber;

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;

            string imgSrc = (homeTeam ? IMG_SHIRT_HOME : IMG_SHIRT_AWAY);
            imgShirt.ImageSource = new BitmapImage(new Uri(BaseUriHelper.GetBaseUri(this), imgSrc));
            
            if (homeTeam)
            {
                lbShirtNumber.Foreground = new SolidColorBrush(Colors.Black);
            } else
            {
                lbShirtNumber.Foreground = new SolidColorBrush(Colors.White);
            }
        }
    }
}
