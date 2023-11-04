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


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void View_more_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void View_more_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void View_more_MouseLeave(object sender, MouseEventArgs e)
        {


        }

        private void Change_pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Change_pass.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Visible;
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

        private void Change_pass2_MouseEnter(object sender, MouseEventArgs e)
        {
            Change_pass2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF063792"));
        }

        private void Change_pass2_MouseLeave(object sender, MouseEventArgs e)
        {
            Change_pass2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0A4CC6"));
        }

        private void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Save.Visibility = Visibility.Hidden;
            Change_pass.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;
        }

        private void Save_MouseEnter(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));
        }

        private void Save_MouseLeave(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));
        }

        private void Change_pass_Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            Stop.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFAC0D0D"));
        }

        private void Change_pass_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            Stop.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC90303"));
        }

        private void Stop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Save.Visibility = Visibility.Hidden;
            Change_pass.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;
        }
    }
}
