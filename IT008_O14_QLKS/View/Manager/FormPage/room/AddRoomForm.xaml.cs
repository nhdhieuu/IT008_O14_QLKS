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
using Microsoft.Win32;
using System.IO;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for AddRoomForm.xaml
    /// </summary>
    public partial class AddRoomForm : Window
    {
        DB_connection connect = new DB_connection();
        int style;
        int equip;
        int internet;
        int cleaning;
        int maintain;
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
            sqlcmd.CommandText = "SELECT COUNT (*) FROM PHONG WHERE TENPHONG='" + this.number.Content.ToString() + "'";
            sqlcmd.Connection = connect.sqlCon;
            int count = (int)sqlcmd.ExecuteScalar();
            string Bontam, Hoboi;
            if (this.BathTub.IsChecked == true)
                Bontam = "Co";
            else
                Bontam = "Khong";
            if (this.Pool.IsChecked == true)
                Hoboi = "Co";
            else
                Hoboi = "Khong";
            equip = this.Equip.SelectedIndex;
            internet = this.Internet.SelectedIndex;

            string InternetTemp = "";
            if (internet == 0)
            {
                InternetTemp = "Cao";
            }
            if (internet == 1)
            {
                InternetTemp = "Trung Binh";
            }
            if (internet == 2)
            {
                InternetTemp = "Thap";
            }
            string EquipTemp = "";
            if (equip == 1)
                EquipTemp = "Minibar";
            else
                EquipTemp = "Fridge";
            decimal giagio = int.Parse(this.GiaTheoGio.Text);
            sqlcmd.Parameters.Add("@GiaGio", SqlDbType.Money).Value = giagio;
            decimal giangay = int.Parse(this.GiaTheoNgay.Text);
            sqlcmd.Parameters.Add("@GiaNgay", SqlDbType.Money).Value = giangay;
            BitmapSource bitmap = Ilus.ImageSource as BitmapSource;
            byte[] imageData;
            using (MemoryStream memory = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder(); // hoặc JpegEncoder
                enc.Frames.Add(BitmapFrame.Create(bitmap));
                enc.Save(memory);

                imageData = memory.ToArray();
            }
            sqlcmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageData;

            sqlcmd.CommandText = "INSERT INTO PHONG (MAPHONG,TENPHONG,LOAIPHONG,SOGIUONG,TRANGTHAI,BONTAM,STYLE,INTERNET,HOBOI,GIATHEOGIO,GIATHEONGAY,NGUOI,CLEANING, MAINTAIN,EQUIP, ILLUS) VALUES ('M" + this.number.Content + "','" + this.number.Content + "','" + this.type_cbb.SelectionBoxItem.ToString() + "'," + this.SoGiuong.Text + ",'" + "Available" + "','" + Bontam + "','" + this.Style.SelectionBoxItem.ToString() + "','" + InternetTemp + "','" + Hoboi + "',@GiaGio,@GiaNgay," + this.people.Content + ",'" + this.Cleaning.SelectionBoxItem.ToString() + "','" + this.Maintain.SelectionBoxItem.ToString() + "','" + EquipTemp + "',@image);";
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





        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        public void Load()
        {
            string TenPhong = "P";
            TenPhong += this.floor_cbb.Text;
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
            this.Convert.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF80807B"));
        }

        private void Convert_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Convert.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF252525"));
        }
        Image early = new Image();
        private void Load_Ilus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ilus.ImageSource = early.Source;
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image to set avatar";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
            ofd.ShowDialog();
            Ilus.ImageSource = early.Source;

            if (ofd.FileName != "")
            {
                string tb_uri;
                tb_uri = ofd.FileName;
                Uri image_Path = new Uri(tb_uri);
                Ilus.ImageSource = new BitmapImage(image_Path);
                Ilus.Stretch = System.Windows.Media.Stretch.UniformToFill;
                early.Source = Ilus.ImageSource;

            }
            else
            {
            }
        }
    }
}
