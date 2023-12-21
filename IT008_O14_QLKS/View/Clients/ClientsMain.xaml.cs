using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using IT008_O14_QLKS.View.Manager;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Clients
{
    public partial class ClientsMain : Window
    {
        string username;
        public ClientsMain()
        {
            InitializeComponent();
        }
        public ClientsMain(string username)
        {
            this.username = username;
            InitializeComponent();
            main = 1;
            DataContext = new ClientsHome(username);
        }
        int main = 1;
        

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
            DataContext = new ClientsHome();
            text2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            border2_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);


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
            DataContext = new ClientsRoom();
            text1.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 2;
            border1_MouseLeave(sender, e);
            border3_MouseLeave(sender, e);
        }

        private void border3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = new receipt();
            text3.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
            border3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            main = 3;
            border1_MouseLeave(sender, e);
            border2_MouseLeave(sender, e);
        }

        

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
          Loginn form =new Loginn();
            form.Show();
            this.Close();
        }


    }
}
