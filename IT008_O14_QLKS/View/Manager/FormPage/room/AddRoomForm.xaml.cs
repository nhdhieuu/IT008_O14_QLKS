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

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for AddRoomForm.xaml
    /// </summary>
    public partial class AddRoomForm : Window
    {
        DB_connection connect = new DB_connection();
        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void Close_Butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Close_Butt_MouseEnter(object sender, MouseEventArgs e)
        {
            Close_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            CloseTXT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Close_Butt_MouseLeave(object sender, MouseEventArgs e)
        {
            Close_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
            CloseTXT.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Accept_Butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT COUNT (*) FROM PHONG WHERE TENPHONG='"+ this.number.Content.ToString()+"'";
            sqlcmd.Connection = connect.sqlCon;
            int count = (int)sqlcmd.ExecuteScalar();
            string Bontam,Hoboi;
            if (this.BathTub.IsChecked == true)
                Bontam = "Co";
            else
                Bontam = "Khong";
            if (this.Pool.IsChecked == true)
                Hoboi = "Co";
            else
                Hoboi = "Khong";

            sqlcmd.CommandText = "INSERT INTO PHONG (MAPHONG,TENPHONG,LOAIPHONG,SOGIUONG,TRANGTHAI,BONTAM,STYLE,INTERNET,HOBOI,GIATHEOGIO,GIATHEONGAY,NGUOI,CLEANING, MAINTAIN,EQUIP) VALUES ('M" + this.number.Content + "','" + this.number.Content + "','" + this.type_cbb.Text + "'," + this.SoGiuong.Text + ",'" + "Empty" + "','" +Bontam + "','"+this.Style.Text+"','"+this.Internet.Text+ "','"+Hoboi+"',"+"1000"+","+"1000"+","+this.people.Content+",'"+this.Cleaning.Text+"','"+this.Maintain.Text+"','"+this.Equip.Text+"');";
            if (count == 1)
                MessageBox.Show("This room already exists!");
            else
            {
                sqlcmd.ExecuteNonQuery();
                this.Close();
            }    
            
        }
       

        private void Accept_Butt_MouseEnter(object sender, MouseEventArgs e)
        {
           Accept_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF685111"));
        }

        private void Accept_Butt_MouseLeave(object sender, MouseEventArgs e)
        {
            Accept_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC6980A"));
        }

        private void add_buttt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));
        }

        private void add_buttt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void add_buttt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        
        public void Load()
        {
            string TenPhong = "P";
            TenPhong += this.floor_cbb.Text ;
            TenPhong += this.number_cbb.Text;
            this.number.Content = TenPhong;
            this.people.Content = this.people_cbb.Text;
            if (this.type_cbb.Text == "Standard")
                this.type.Content = "STD";
            if (this.type_cbb.Text == "Superior")
                this.type.Content = "SUP";
            if (this.type_cbb.Text == "Deluxe")
                this.type.Content = "DLX";
            if (this.type_cbb.Text == "Suite")
                this.type.Content = "SUT";
        }
        

        private void Convert_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Load();
        }

        private void Convert_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Convert.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF80807B"));
        }

        private void Convert_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Convert.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF252525"));
        }
    }
}
