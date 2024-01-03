using IT008_O14_QLKS.View.Manager;
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
using IT008_O14_QLKS.View.Clients;
using IT008_O14_QLKS.Connection_db;
using System.Data.SqlClient;
using System.Data;
using IT008_O14_QLKS.Util;
using IT008_O14_QLKS.Send_Email;
using System.Net.Mail;

namespace IT008_O14_QLKS
{
    /// <summary>
    /// Interaction logic for Loginn.xaml
    /// </summary>
    public partial class Loginn : Window
    {
        DB_connection connect = new DB_connection();

        public Loginn()
        {
            InitializeComponent();
            this.Loaded += LoginWindow_OnLoaded;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //tao form manager_main

            Manager_main main = new Manager_main(this.UserTextBox.Text);
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
        //Dang nhap
        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            try
            {
            string hashpass = HashPassword.HashToHexString(HashPassword.CalculateSHA256(pass.Password));
            
            string role="";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = "SELECT COUNT(*) FROM QUANLI WHERE USERNAME='"+this.UserTextBox.Text+"'";
            int CountQL=(int)sqlcmd.ExecuteScalar();
            if (CountQL == 1)
                role = "QL";
            else
            {
                sqlcmd.CommandText = "SELECT COUNT(*) FROM KHACHHANG WHERE USERNAME='" + this.UserTextBox.Text + "'";
                int CountKH = (int)sqlcmd.ExecuteScalar();
                if (CountKH == 1)
                    role = "KH";
            }
            if(role=="")
                pssbox.BorderBrush = new SolidColorBrush(Colors.Red);
            else
            {
                if(role == "QL")
                {
                    sqlcmd.CommandText = "SELECT PASS FROM QUANLI WHERE USERNAME='" + this.UserTextBox.Text + "'";
                    if(hashpass==(string)sqlcmd.ExecuteScalar())
                    {
                        Manager_main main = new Manager_main(this.UserTextBox.Text);
                        main.Show();
                        this.Close();
                        if (RememberMeCheckBox.IsChecked != null && RememberMeCheckBox.IsChecked.Value)
                        {
                            Properties.Settings.Default.UserName = UserTextBox.Text;
                            Properties.Settings.Default.PassWord = pass.Password;
                            Properties.Settings.Default.RememberMe = true;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.UserName = "";
                            Properties.Settings.Default.PassWord = "";
                            Properties.Settings.Default.RememberMe = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                    else
                    {
                        pssbox.BorderBrush = new SolidColorBrush(Colors.Red);

                    }
                }
                if (role == "KH")
                {
                    sqlcmd.CommandText = "SELECT PASS FROM KHACHHANG WHERE USERNAME='" + this.UserTextBox.Text + "'";
                    if (hashpass == (string)sqlcmd.ExecuteScalar())
                    {
                        ClientsMain clientControl = new ClientsMain(this.UserTextBox.Text);
                        clientControl.Show();
                        this.Close();
                        if (RememberMeCheckBox.IsChecked != null && RememberMeCheckBox.IsChecked.Value)
                        {
                            Properties.Settings.Default.UserName = UserTextBox.Text;
                            Properties.Settings.Default.PassWord = pass.Password;
                            Properties.Settings.Default.RememberMe = true;
                            Properties.Settings.Default.Save();
                        }
                        else
                        {
                            Properties.Settings.Default.UserName = "";
                            Properties.Settings.Default.PassWord = "";
                            Properties.Settings.Default.RememberMe = false;
                            Properties.Settings.Default.Save();
                        }
                    }
                    else
                    {
                        pssbox.BorderBrush = new SolidColorBrush(Colors.Red);

                    }
                }
            }
            }
            catch (Exception exception)
            {
                // MessageBox.Show(exception.Message);
            }
            
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
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6D0D"));
        }

        private void lgborder_MouseLeave_1(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            fgpw.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6D0D"));
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            fgpw.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void TextBlock_MouseEnter_1(object sender, MouseEventArgs e)
        {
            su.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6D0D"));
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

        private void su_MouseDown(object sender, MouseButtonEventArgs e)
        {
            signUp su= new signUp();
            su.ShowDialog();
        }

        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {
            usrbox.Background = new SolidColorBrush(Colors.White);
        }

     

        private void pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            usrbox.Background = new SolidColorBrush(Colors.White);
        }

        private void TextBox_MouseMove(object sender, MouseEventArgs e)
        {
        
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
            {
                string hashpass = HashPassword.HashToHexString(HashPassword.CalculateSHA256(pass.Password));

                string role = "";
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.Connection = connect.sqlCon;
                
                
                
                sqlcmd.CommandText = "SELECT COUNT(*) FROM QUANLI WHERE USERNAME='" + this.UserTextBox.Text + "'";
                int CountQL = (int)sqlcmd.ExecuteScalar();
                if (CountQL == 1)
                    role = "QL";
                else
                {
                    sqlcmd.CommandText = "SELECT COUNT(*) FROM KHACHHANG WHERE USERNAME='" + this.UserTextBox.Text + "'";
                    int CountKH = (int)sqlcmd.ExecuteScalar();
                    if (CountKH == 1)
                        role = "KH";
                }
                if (role == "")
                    pssbox.BorderBrush = new SolidColorBrush(Colors.Red);

                else
                {
                    if (role == "QL")
                    {
                        sqlcmd.CommandText = "SELECT PASS FROM QUANLI WHERE USERNAME='" + this.UserTextBox.Text + "'";
                        if (hashpass == (string)sqlcmd.ExecuteScalar())
                        {
                            Manager_main main = new Manager_main(this.UserTextBox.Text);
                            main.Show();
                            this.Close();
                            if (RememberMeCheckBox.IsChecked != null && RememberMeCheckBox.IsChecked.Value)
                            {
                                Properties.Settings.Default.UserName = UserTextBox.Text;
                                Properties.Settings.Default.PassWord = pass.Password;
                                Properties.Settings.Default.RememberMe = true;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.UserName = "";
                                Properties.Settings.Default.PassWord = "";
                                Properties.Settings.Default.RememberMe = false;
                                Properties.Settings.Default.Save();
                            }
                            
                            
                        }
                        else
                        {
                            pssbox.BorderBrush = new SolidColorBrush(Colors.Red);

                            
                        }
                    }
                    if (role == "KH")
                    {
                        sqlcmd.CommandText = "SELECT PASS FROM KHACHHANG WHERE USERNAME='" + this.UserTextBox.Text + "'";
                        if (hashpass == (string)sqlcmd.ExecuteScalar())
                        {
                            ClientsMain clientControl = new ClientsMain(this.UserTextBox.Text);
                            clientControl.Show();
                            this.Close();
                            if (RememberMeCheckBox.IsChecked !=  null && RememberMeCheckBox.IsChecked.Value)
                            {
                                Properties.Settings.Default.UserName = UserTextBox.Text;
                                Properties.Settings.Default.PassWord = pass.Password;
                                Properties.Settings.Default.RememberMe = true;
                                Properties.Settings.Default.Save();
                            }
                            else
                            {
                                Properties.Settings.Default.UserName = "";
                                Properties.Settings.Default.PassWord = "";
                                Properties.Settings.Default.RememberMe = false;
                                Properties.Settings.Default.Save();
                            }
                            
                        }
                        else
                        {
                            pssbox.BorderBrush = new SolidColorBrush(Colors.Red);

                        }
                    }
                }
            }
            
        }
        private void LoginWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (Properties.Settings.Default.RememberMe)
            {
                RememberMeCheckBox.IsChecked = true;
                UserTextBox.Text = Properties.Settings.Default.UserName;
                pass.Password = Properties.Settings.Default.PassWord;
            }
            
        }

        private void fgpw_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sendemail a = new sendemail();
            a.ShowDialog();

        }

        private void fgpw_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            sendemail a = new sendemail();
            a.ShowDialog();
        }
    }
    }

