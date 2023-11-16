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

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for ClientCardxaml.xaml
    /// </summary>
    public partial class ClientCardxaml : UserControl
    {
        public ClientCardxaml()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            bd_view.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2A0A0A0"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            bd_view.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2808080"));
        }
    }
}
