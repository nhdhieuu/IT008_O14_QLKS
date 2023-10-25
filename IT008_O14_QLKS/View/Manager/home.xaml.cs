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

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void View_more_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void View_more_MouseEnter(object sender, MouseEventArgs e)
        {
            View_more.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));
        }

        private void View_more_MouseLeave(object sender, MouseEventArgs e)
        {
            View_more.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void Change_pass_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Change_pass_MouseEnter(object sender, MouseEventArgs e)
        {
            Change_pass.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));
        }

        private void Change_pass_MouseLeave(object sender, MouseEventArgs e)
        {
            Change_pass.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void avt_load_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

    }
}
