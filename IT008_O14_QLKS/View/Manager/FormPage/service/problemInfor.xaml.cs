﻿using System;
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
    /// Interaction logic for problemInfor.xaml
    /// </summary>
    public partial class problemInfor : Window
    {
        public problemInfor()
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
        private void adjust_border_MouseEnter(object sender, MouseEventArgs e)
        {
            adjust_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void adjust_border_MouseLeave(object sender, MouseEventArgs e)
        {
            adjust_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void adjust_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (adjust_lb.Content.ToString() == "save")
            {
                if (string.IsNullOrEmpty(problemID.Text)  || string.IsNullOrEmpty(problemName.Text) || string.IsNullOrEmpty(problemPrice.Text))
                {
                    MessageBox.Show("Please complete all the information", "Notice");
                }
                else
                {
                    /* add database code here */


                    MessageBox.Show("Saved", "Notice");
                    problemID.IsEnabled = false;
                    problemName.IsEnabled = false;
                    problemPrice.IsEnabled = false;
                    adjust_lb.Content = "adjust";
                }
            }
            else if (adjust_lb.Content.ToString() == "adjust")
            {
                problemID.IsEnabled = true;
                problemName.IsEnabled = true;
                problemPrice.IsEnabled = true;
                adjust_lb.Content = "save";
            }
        }

        private void del_border_MouseEnter(object sender, MouseEventArgs e)
        {
            del_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void del_border_MouseLeave(object sender, MouseEventArgs e)
        {
            del_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BF0B0B"));
        }

        private void del_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult boxResult= MessageBox.Show("Do you want to delete this problem?", "Notice",MessageBoxButton.YesNo);
            if(boxResult == MessageBoxResult.Yes)
            {
                // code delete problem from database

                MessageBox.Show("Problem has been deleted.", "Notice");
                this.Close();
            }
            
        }
    }
}
