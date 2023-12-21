using IT008_O14_QLKS.Connection_db;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
namespace IT008_O14_QLKS.View.Clients
{
    public partial class ClientsHome : UserControl
    {
        DB_connection connect = new DB_connection();
        public ClientsHome()
        {
            InitializeComponent();
        }
        public ClientsHome(string username)
        {
            InitializeComponent();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = "SELECT * FROM KHACHHANG WHERE USERNAME='" + username + "'";
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                this.name.Text = reader.GetString(1);
                this.username.Text = reader.GetString(2);
                this.UN2.Content = reader.GetString(2);
                this.phone.Content = reader.GetString(5);
                this.gender.Content = reader.GetString(7);
                //this.age.Content=reader.GetString(5);
                this.cccd.Content = reader.GetString(4);
                this.hang.Content = reader.GetString(9);
            }
            reader.Close();
            //load ảnh
            sqlcmd.CommandText = "SELECT AVATAR FROM KHACHHANG WHERE USERNAME='" + username + "'";
            try 
            {
                byte[] imageData = (byte[])sqlcmd.ExecuteScalar();
                MemoryStream memStream = new MemoryStream(imageData);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
                avt.ImageSource = bitmap;
                avtt.ImageSource = bitmap;
            }
            catch { }
            
            //lấy tuổi
            sqlcmd.CommandText = "SELECT NGAYSINH FROM KHACHHANG WHERE USERNAME='" + username + "'";
            DateTime saleDate = (DateTime)sqlcmd.ExecuteScalar();
            int saleYear = saleDate.Year;
            this.age.Content = (2023 - saleYear).ToString();



        }

        private void Save_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
        }

        private void Save_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));

        }

        private void Save_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));

        }

        private void Change_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Visible;
            this.Cancel.Visibility = Visibility.Visible;
            this.Change.Visibility = Visibility.Hidden;
        }

        private void Change_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));

        }

        private void Change_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void Cancel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
        }

        private void Cancel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF790B0B"));

        }

        private void Cancel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF0B0B"));

        }
    }
}