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

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void accept_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void accept_butt_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void accept_butt_MouseLeave(object sender, MouseEventArgs e)
        {

        }

        private void cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.cancel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF830F0F"));

        }

        private void cancel_MouseLeave(object sender, MouseEventArgs e)
        {

            this.cancel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFED1B1B"));

        }
    }
}
