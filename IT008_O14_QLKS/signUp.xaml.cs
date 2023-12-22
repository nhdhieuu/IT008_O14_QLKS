using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
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
using System.Xml.Linq;
using System.IO;
using IT008_O14_QLKS.Util;

namespace IT008_O14_QLKS
{
    /// <summary>
    /// Interaction logic for signUp.xaml
    /// </summary>
    
    public partial class signUp : Window
    {
        DB_connection connect = new DB_connection();
        Image early = new Image();
        public signUp()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {


            this.Close();


        }
        bool gender = false;

        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            // animation đóng form
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

        }
      
        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            DateTime ? selectedDate = dpk.SelectedDate;
            if (name.Text == "")
            {
                bdname.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bdname.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (user.Text == "")
            {
                bduser.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bduser.BorderBrush = System.Windows.Media.Brushes.Black;
            }

            if (unpass.Text == "")
            {
                bdpass.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bdpass.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (runpass.Text == "")
            {
                brdpass.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                brdpass.BorderBrush = System.Windows.Media.Brushes.Black;
            }

            if (phone.Text == "")
            {
                bdphone.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bdphone.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if (cccd.Text == "")
            {
                bdcccd.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bdcccd.BorderBrush = System.Windows.Media.Brushes.Black;
            }
            if(selectedDate==null)
            {
                bdDate.BorderBrush = System.Windows.Media.Brushes.Red;
            }
            else
            {
                bdDate.BorderBrush = System.Windows.Media.Brushes.Black;
            }


            if (name.Text==""||user.Text==""||unpass.Text==""||runpass.Text==""||phone.Text==""||cccd.Text==""|| selectedDate==null || gender==false)
            {
                MessageBox.Show("Please complete all information");
            } 
            else
            {
                sqlcmd.CommandText = "SELECT COUNT(*) FROM KHACHHANG";
                int CountKH=(int)sqlcmd.ExecuteScalar();
                string MAKH="KH0"+(CountKH+1).ToString();
                //lưu date
                sqlcmd.Parameters.Add("@date", SqlDbType.DateTime).Value=this.dpk.SelectedDate;
                //lưu avt
                BitmapSource bitmap = avt.ImageSource as BitmapSource;
                byte[] imageData;
                using (MemoryStream memory = new MemoryStream())
                {
                    BitmapEncoder enc = new BmpBitmapEncoder(); // hoặc JpegEncoder
                    enc.Frames.Add(BitmapFrame.Create(bitmap));
                    enc.Save(memory);

                    imageData = memory.ToArray();
                }
                sqlcmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageData;
                // var hashbytes = HashPassword.CalculateSHA256(rpass.Password);
                // string hashpass = "";
                // foreach (byte item in hashbytes)
                // {
                //     hashpass += item;
                // }
                string hashpass = HashPassword.HashToHexString(HashPassword.CalculateSHA256(pass.Password));
                
                
                sqlcmd.CommandText = "INSERT INTO KHACHHANG (MAKH,TENKH,USERNAME,PASS,CCCD,SDT,NGAYSINH,GIOITINH,AVATAR,CLASS,ClassID) VALUES ('"+MAKH+"','"+this.name.Text+"','"+this.user.Text+"','"+hashpass+"','"+this.cccd.Text+"','"+this.phone.Text+"',@date,'"+GT+"',@image,'Silver',1)";
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Sucessfully");
                this.Close();
            }    
            

        }

        private void lgborder_MouseEnter(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush(Colors.Black);
        }

        private void lgborder_MouseLeave_1(object sender, MouseEventArgs e)
        {
            lgborder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            avt.ImageSource = early.Source;
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image to set avatar";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
            ofd.ShowDialog();
            avt.ImageSource = early.Source;

            if (ofd.FileName != "")
            {
                string tb_uri;
                tb_uri = ofd.FileName;
                Uri image_Path = new Uri(tb_uri);
                avt.ImageSource = new BitmapImage(image_Path);
                avt.Stretch = System.Windows.Media.Stretch.UniformToFill;
                early.Source = avt.ImageSource;

            }
            else
            {
            }
        }
   
        private void Border_MouseDownu(object sender, MouseButtonEventArgs e)
        {
            Male.Background = System.Windows.Media.Brushes.Blue;
            txtMale.Foreground = System.Windows.Media.Brushes.White;
            Male.BorderBrush = System.Windows.Media.Brushes.Blue;
            ic_male.Visibility = Visibility.Visible;
            fm.Background = System.Windows.Media.Brushes.Transparent;
            fm.BorderBrush = System.Windows.Media.Brushes.DeepPink;
            TXTfM.Foreground = System.Windows.Media.Brushes.DeepPink;
            FMIMG.Visibility = Visibility.Hidden;
           
            gender = true;
            GT = "Nam";

        }

        private void Male_MouseEnter(object sender, MouseEventArgs e)
        {
            if (Male.Background != System.Windows.Media.Brushes.Blue)
            {
                Male.Background = System.Windows.Media.Brushes.White;

            }
        }

        private void Male_MouseLeave(object sender, MouseEventArgs e)
        {
            if (Male.Background != System.Windows.Media.Brushes.Blue)
            {

                Male.Background = System.Windows.Media.Brushes.Transparent;
                Male.BorderBrush = new SolidColorBrush(Colors.Blue);


            }
        }
        string GT = "";
        private void Border_MouseDownv(object sender, MouseButtonEventArgs e)
        {
            fm.Background = System.Windows.Media.Brushes.DeepPink;
            TXTfM.Foreground = new SolidColorBrush(Colors.White);
            fm.BorderBrush = System.Windows.Media.Brushes.DeepPink;
            FMIMG.Visibility = Visibility.Visible;
            Male.Background = System.Windows.Media.Brushes.Transparent;
            Male.BorderBrush = System.Windows.Media.Brushes.Blue;
            txtMale.Foreground = System.Windows.Media.Brushes.Blue;
            ic_male.Visibility = Visibility.Hidden;
            
            gender = true;
            GT = "Nu";

        }

        private void fm_MouseEnter(object sender, MouseEventArgs e)
        {

            if (fm.Background != System.Windows.Media.Brushes.DeepPink)
            {
                fm.Background = new SolidColorBrush(Colors.White);
               
            }

        }

        private void fm_MouseLeave(object sender, MouseEventArgs e)
        {
            if (fm.Background != System.Windows.Media.Brushes.DeepPink)
            {
                fm.Background = System.Windows.Media.Brushes.Transparent;
                fm.BorderBrush = new SolidColorBrush(Colors.DeepPink);
            }
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            pass.Visibility = Visibility.Hidden;
            unpass.Visibility = Visibility.Visible;
            view.Visibility = Visibility.Hidden;
            unview.Visibility = Visibility.Visible;
            unpass.Text = pass.Password;
        }

        private void unview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            unpass.Visibility = Visibility.Hidden;
            pass.Visibility = Visibility.Visible;
            unview.Visibility = Visibility.Hidden;
            view.Visibility = Visibility.Visible;
            pass.Password = unpass.Text;
        }

        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            rpass.Visibility = Visibility.Hidden;
            runpass.Visibility = Visibility.Visible;
            rview.Visibility = Visibility.Hidden;
            runview.Visibility = Visibility.Visible;
            runpass.Text = rpass.Password;
        }

        private void unview_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            runpass.Visibility = Visibility.Hidden;
            rpass.Visibility = Visibility.Visible;
            runview.Visibility = Visibility.Hidden;
            rview.Visibility = Visibility.Visible;
            rpass.Password = runpass.Text;

        }
        private void rpass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //điều kiện để đăng ký thành công
            if (rpass.Visibility == Visibility.Visible)
                runpass.Text = rpass.Password;
            if (rpass.Password == "" && unpass.Text == "")
            {
                rptxt.Text = "repeat password";
                rptxt.Foreground = System.Windows.Media.Brushes.Black;


            }
            else
            {
                if (rpass.Password == pass.Password)
                {
                    rptxt.Text = "right password";
                    rptxt.Foreground = System.Windows.Media.Brushes.ForestGreen;

                }
                else
                {
                    rptxt.Text = "wrong password";
                    rptxt.Foreground = System.Windows.Media.Brushes.Red;
                }

            }


        }


        private void runpass_TextChanged_1(object sender, TextChangedEventArgs e)
        {

            if (runpass.Visibility == Visibility.Visible)
                rpass.Password = runpass.Text;


            if (runpass.Text == "" && unpass.Text == "")
            {
                rptxt.Text = "repeat password";
                rptxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF897C54"));

            }
            else
            {
                if (runpass.Text == pass.Password)
                {
                    rptxt.Text = "right password";
                    rptxt.Foreground = System.Windows.Media.Brushes.ForestGreen;

                }
                else
                {
                    rptxt.Text = "wrong password";
                    rptxt.Foreground = System.Windows.Media.Brushes.Red;
                }

            }
        }

        private void pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pass.Visibility == Visibility.Visible)
                unpass.Text = pass.Password;


            if (runpass.Text == "" && unpass.Text == "")
            {
                rptxt.Text = "repeat password";
                rptxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF897C54"));

            }
            else
            {
                if (runpass.Text == pass.Password)
                {
                    rptxt.Text = "right password";
                    rptxt.Foreground = System.Windows.Media.Brushes.ForestGreen;

                }
                else
                {
                    rptxt.Text = "wrong password";
                    rptxt.Foreground = System.Windows.Media.Brushes.Red;
                }

            }

        }

        private void unpass_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (unpass.Visibility == Visibility.Visible)
                pass.Password = unpass.Text;
            if (runpass.Text == "" && unpass.Text == "")
            {
                rptxt.Text = "repeat password";
                rptxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF897C54"));

            }
            else
            {
                if (runpass.Text == pass.Password)
                {
                    rptxt.Text = "right password";
                    rptxt.Foreground = System.Windows.Media.Brushes.ForestGreen;

                }
                else
                {
                    rptxt.Text = "wrong password";
                    rptxt.Foreground = System.Windows.Media.Brushes.Red;
                }

            }
        }
        string old;
        private void phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char i in phone.Text)
            {
                if ((int)i - 48 >= 0 && (int)i - 48 <= 9)
                {

                }
                else
                {
                    phone.Text = old;
                }
            }
            old = phone.Text;
        }
    }


}
