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

namespace IT008_O14_QLKS.View.Manager.FormPage.service
{
    /// <summary>
    /// Interaction logic for serviceAdd.xaml
    /// </summary>
    public partial class serviceAdd : Window
    {
        public serviceAdd()
        {
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void close_lb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void close_lb_MouseEnter(object sender, MouseEventArgs e)
        {

            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
        }
        private void close_lb_MouseLeave(object sender, MouseEventArgs e)
        {
            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9E5D9"));

            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

        }
        private void add_border_MouseEnter(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void add_border_MouseLeave(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void add_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(serviceID.Text) || string.IsNullOrEmpty(serviceAmount.Text) || string.IsNullOrEmpty(serviceName.Text) || string.IsNullOrEmpty(servicePrice.Text))
            {
                MessageBox.Show("Please complete all the information", "Notice");
            }
            else
            {
                // add service to database
                MessageBox.Show("New sservice has been added", "Notice");
                this.Close();
            }
        }
    }

}
