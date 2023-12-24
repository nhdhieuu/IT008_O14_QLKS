using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using IT008_O14_QLKS.Util;

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for ChangePass.xaml
    /// </summary>
    public partial class ChangePass : Window
    {
        DB_connection connect = new DB_connection();
        SqlCommand sqlcmd = new SqlCommand();
        public string username;
        public string currentpass;
        string Role;
        string table;
        public ChangePass(string username, string Role)
        {
            InitializeComponent(); 
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            this.username= username;
            
            if (Role == "Client")
                table = "KHACHHANG";
            else
                table = "QUANLI";
            sqlcmd.CommandText = "SELECT PASS FROM "+table+" WHERE USERNAME='" + username + "'";
             currentpass = sqlcmd.ExecuteScalar().ToString();
            
        }

        
        private void Cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cancel.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF830F0F"));
        }

        private void Cancel_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cancel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC60303"));
        }

        
        private void unpass_TextChanged(object sender, TextChangedEventArgs e)
        {
            pass.Password = unpass.Text;
        }

        private void eyeopen_MouseDown(object sender, MouseButtonEventArgs e)
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

        private void unpass2_TextChanged(object sender, TextChangedEventArgs e)
        {
            pass2.Password = unpass2.Text;
        }

        private void eyeopen2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyeopen2.Visibility = Visibility.Hidden;
            eyedown2.Visibility = Visibility.Visible;
            pass2.Visibility = Visibility.Hidden;
            unpass2.Visibility = Visibility.Visible;
            unpass2.Text = pass2.Password;
        }

        private void eyedown2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyedown2.Visibility = Visibility.Hidden;
            eyeopen2.Visibility = Visibility.Visible;
            pass2.Visibility = Visibility.Visible;
            unpass2.Visibility = Visibility.Hidden;
        }

        private void unpass3_TextChanged(object sender, TextChangedEventArgs e)
        {
            pass3.Password = unpass3.Text;
        }

        private void eyeopen3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyeopen3.Visibility = Visibility.Hidden;
            eyedown3.Visibility = Visibility.Visible;
            pass3.Visibility = Visibility.Hidden;
            unpass3.Visibility = Visibility.Visible;
            unpass3.Text = pass3.Password;
        }

        private void eyedown3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            eyedown3.Visibility = Visibility.Hidden;
            eyeopen3.Visibility = Visibility.Visible;
            pass3.Visibility = Visibility.Visible;
            unpass3.Visibility = Visibility.Hidden;
        }

        private void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if((string)this.correct.Content == "Correct" && (string)this.correct2.Content == "Correct")
            {
                string hasspass3 = HashPassword.HashToHexString(HashPassword.CalculateSHA256(pass3.Password));
                sqlcmd.CommandText = "UPDATE "+table+" SET PASS='" + hasspass3 + "' WHERE USERNAME='" + username + "'";
                sqlcmd.ExecuteNonQuery();
                this.Close();
            }    
            
        }

        private void Save_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Save.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF906E05"));
        }

        private void Save_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC6980A"));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.correct.Visibility= Visibility.Visible;
            string haspass = HashPassword.HashToHexString(HashPassword.CalculateSHA256(this.pass.Password));
            if (haspass == currentpass)
            {
                this.correct.Content= "Correct";
                this.correct.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17BB32"));
            }
            else
            {
                this.correct.Content = "Incorrect";
                this.correct.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1818"));

            }
        }

        private void pass3_PasswordChanged(object sender, RoutedEventArgs e)
        {
            this.correct2.Visibility = Visibility.Visible;
            if (this.pass3.Password == this.pass2.Password)
            {
                this.correct2.Content = "Correct";
                this.correct2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17BB32"));
            }
            else
            {
                this.correct2.Content = "Incorrect";
                this.correct2.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEB1818"));

            }
        }
    }
}
