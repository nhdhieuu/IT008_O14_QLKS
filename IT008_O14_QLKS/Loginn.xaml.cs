﻿using IT008_O14_QLKS.View.Manager;
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

namespace IT008_O14_QLKS
{
    /// <summary>
    /// Interaction logic for Loginn.xaml
    /// </summary>
    public partial class Loginn : Window
    {
        public Loginn()
        {
            InitializeComponent();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //tao form manager_main

            Manager_main main = new Manager_main();
            main.Show();
            this.Close();

        }


        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void minibtn_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void minibtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            minibtn_text.Foreground = new SolidColorBrush(Colors.Gray);
        }

        private void minibtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            minibtn_text.Foreground = new SolidColorBrush(Colors.Black);
        }



        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {

            delbtn_border.Background = new SolidColorBrush(Colors.White);
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Border_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {

        }

        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            Manager_main main = new Manager_main();
            main.Show();
            this.Close();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void lgborder_MouseLeave(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void lgborder_MouseEnter(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush(Colors.Black);
        }

        private void lgborder_MouseLeave_1(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            fgpw.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            fgpw.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void TextBlock_MouseEnter_1(object sender, MouseEventArgs e)
        {
            su.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void TextBlock_MouseLeave_1(object sender, MouseEventArgs e)
        {
            su.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyeopen.Visibility = Visibility.Hidden;
            eyedown.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Hidden;
            unpass.Visibility = Visibility.Visible;
            unpass.Text = pass.Password;
        }

        private void eyedown_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyedown.Visibility = Visibility.Hidden;
            eyeopen.Visibility = Visibility.Visible;
            pass.Visibility = Visibility.Visible;
            unpass.Visibility = Visibility.Hidden;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
       
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            pass.Password = unpass.Text;
        }
    }
    }
