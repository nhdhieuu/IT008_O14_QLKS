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

namespace IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2
{
    /// <summary>
    /// Interaction logic for booked.xaml
    /// </summary>
    public partial class booked : UserControl
    {
        public booked()
        {
            InitializeComponent();
        }

        private void main_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            del_bd.Background = new SolidColorBrush(Colors.DarkRed);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            del_bd.Background = new SolidColorBrush(Colors.Red);
        }
    }
}
