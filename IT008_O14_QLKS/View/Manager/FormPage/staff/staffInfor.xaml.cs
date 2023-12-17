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

namespace IT008_O14_QLKS.View.Manager.FormPage.staff
{
    /// <summary>
    /// Interaction logic for staffInfor.xaml
    /// </summary>
    public partial class staffInfor : Window
    {
        public staffInfor()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void close_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void close_b_MouseEnter(object sender, MouseEventArgs e)
        {
            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
        }

        private void close_b_MouseLeave(object sender, MouseEventArgs e)
        {
            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D9D9D9"));

            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            adjust_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            adjust_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

        }

        private void adjust_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!staffID.IsEnabled)
            {
                notice_lb.Visibility = Visibility.Hidden;
                staffID.IsEnabled = true;
                staffName.IsEnabled = true;
                staffBirthday.IsEnabled = true;
                staffCCCD.IsEnabled = true;
                staffPhone.IsEnabled = true;
                staffGender.IsEnabled = true;
                staffPostion.IsEnabled = true;
                adjust_lb.Content = "save";
            }
            else
            {
                if (string.IsNullOrEmpty(staffID.Text) || string.IsNullOrEmpty(staffName.Text) || string.IsNullOrEmpty(staffPhone.Text) ||
                    string.IsNullOrEmpty(staffGender.Text) || string.IsNullOrEmpty(staffPostion.Text) || string.IsNullOrWhiteSpace(staffBirthday.Text) || string.IsNullOrEmpty(staffCCCD.Text))
                {
                    notice_lb.Visibility = Visibility.Visible;
                    return;
                }
                notice_lb.Visibility = Visibility.Hidden;
                staffID.IsEnabled = false;
                staffName.IsEnabled = false;
                staffBirthday.IsEnabled = false;
                staffCCCD.IsEnabled = false;
                staffPhone.IsEnabled = false;
                staffGender.IsEnabled = false;
                staffPostion.IsEnabled = false;
                adjust_lb.Content = "adjust";
            }
        }
    }
}
