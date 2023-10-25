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
    /// Interaction logic for room.xaml
    /// </summary>
    public partial class room : UserControl
    {
        public room()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            Clean.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E9755"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            Clean.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF66BB6A"));
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E9755"));
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF66BB6A"));
        }
    }
}