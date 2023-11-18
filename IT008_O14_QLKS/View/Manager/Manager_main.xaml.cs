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
using IT008_O14_QLKS;
namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for Manager_main.xaml
    /// </summary>
    public partial class Manager_main : Window
    {
        int main = 1;
        public Manager_main()
        {
            InitializeComponent();
            main = 1;
            DataContext = new home();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {


            Application.Current.Shutdown();


        }



        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            // animation đóng form
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush(Colors.White);
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

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

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void border1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            main = 1;
            DataContext = new home();
            text2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);


        }

        private void border2_MouseEnter(object sender, MouseEventArgs e)
        {
            
            text2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border2_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 2)
            {
                text2.Foreground = new SolidColorBrush(Colors.Black);
                border2.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void border3_MouseEnter(object sender, MouseEventArgs e)
        {
            text3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border3_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 3)
            {
                text3.Foreground = new SolidColorBrush(Colors.Black);
                border3.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
        private void border4_MouseEnter(object sender, MouseEventArgs e)
        {
            text4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border4_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 4)
            {
                text4.Foreground = new SolidColorBrush(Colors.Black);
                border4.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void border5_MouseEnter(object sender, MouseEventArgs e)
        {
            text5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border5_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 5)
            {
                text5.Foreground = new SolidColorBrush(Colors.Black);
                border5.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void border6_MouseEnter(object sender, MouseEventArgs e)
        {
            text6.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border6_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 6)
            {
                text6.Foreground = new SolidColorBrush(Colors.Black);
                border6.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void border1_MouseEnter(object sender, MouseEventArgs e)
        {

            text1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border1_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 1)
            {
                text1.Foreground = new SolidColorBrush(Colors.Black);
                border1.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

        private void border2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new room();
            text1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 2;
            border1_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);
            border7_MouseLeave(sender, e);
        }

        private void border3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new receipt();
            text3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 3;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);
            border7_MouseLeave(sender, e);
        }

        private void border4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            text4.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border4.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 4;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);
            border7_MouseLeave(sender, e);
        }

        private void border5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new staff();
            text5.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border5.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 5;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);
            border7_MouseLeave(sender, e);
        }

        private void border6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            text6.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border6.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 6;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border7_MouseLeave(sender, e);
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
          Loginn form =new Loginn();
            form.Show();
            this.Close();
        }

        private void txt_logout_MouseEnter(object sender, MouseEventArgs e)
        {
            txt_logout.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void txt_logout_MouseLeave(object sender, MouseEventArgs e)
        {
            txt_logout.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void border7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //DataContext = new Client();
            text7.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 7;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
            border4_MouseLeave(sender, e);
            border5_MouseLeave(sender, e);
            border6_MouseLeave(sender, e);
        }

        private void border7_MouseEnter(object sender, MouseEventArgs e)
        {

            text7.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border7.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
        }

        private void border7_MouseLeave(object sender, MouseEventArgs e)
        {
            if (main != 7)
            {
                text7.Foreground = new SolidColorBrush(Colors.Black);
                border7.Background = new SolidColorBrush(Colors.Transparent);
            }
        }

    }
    
}
