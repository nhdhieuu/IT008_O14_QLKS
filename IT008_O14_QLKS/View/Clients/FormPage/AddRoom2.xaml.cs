﻿using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.IO;

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for AddRoom2.xaml
    /// </summary>
    public partial class AddRoom2 : UserControl
    {
        public string RoomName;
        DB_connection connect = new DB_connection();
        public string MaKH;
        public string MP;
        public string KQUA;
        public string MATP;
        addRoom1 ar;
        string hdcaonhat;
        public AddRoom2(string RoomName, Decimal PriceTong, string MAKH, addRoom1 ar)
        {
            InitializeComponent();
            this.RoomName = RoomName;
            this.MP = "M" + RoomName;
            this.KQUA = "Dang Thue";
            this.ar=ar;
            this.Price_txbl.Text= PriceTong.ToString()+" VND";
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT * FROM PHONG WHERE TENPHONG='{RoomName}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while(reader.Read())
            {
                roomcard2 rc = new roomcard2(RoomName,reader.GetString(2),reader.GetInt32(11),"Client");
                this.roomcard.Content = rc.Content;
                this.bed.Text = this.bed.Text+" "+reader.GetInt16(3).ToString();
                if (reader.GetString(5) == "Co")
                    this.bathtub.Text = this.bathtub.Text+ " 1";
                else
                    this.bathtub.Text = this.bathtub.Text+ " 0";
                if (reader.GetString(8) == "Co")
                    this.pool.Text = this.pool.Text+ " 1";
                else
                    this.pool.Text = this.pool.Text+ " 0";
                if (reader.GetString(7) == "Cao")
                    this.internet.Text = this.internet.Text+ " High";
                if (reader.GetString(7) == "Trung Binh")
                    this.internet.Text = this.internet.Text+ " Mid";
                if (reader.GetString(7) == "Thap")
                    this.internet.Text = this.internet.Text+ " Low";
                this.style.Text = this.style.Text+" "+reader.GetString(6);
                this.equip.Text = this.equip.Text+" "+ reader.GetString(14);
                this.PriceHour.Text = Math.Truncate(reader.GetDecimal(9)).ToString() + " VND";
                this.PriceDay.Text = Math.Truncate(reader.GetDecimal(10)).ToString()+" VND";
            }
            reader.Close();

            sqlcmd.CommandText = "SELECT ILLUS FROM PHONG WHERE TENPHONG='" + RoomName + "'";
            sqlcmd.Connection = connect.sqlCon;
            try
            {
                byte[] imageData = (byte[])sqlcmd.ExecuteScalar();
                MemoryStream memStream = new MemoryStream(imageData);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
                Illus.ImageSource = bitmap;
            }
            catch { }

            sqlcmd.CommandText = $"SELECT TOP 1 MATHUEPHONG FROM THUEPHONG ORDER BY MATHUEPHONG DESC";
            SqlDataReader reader1 = sqlcmd.ExecuteReader();

            while (reader1.Read())
            {

                hdcaonhat = reader1.GetString(0);
                MATP = GenerateNextString(hdcaonhat);
            }
            reader1.Close();






            this.MaKH = MAKH;
            string from= ((DateTime)ar.from.Value).ToString("dd/MM/yyyy HH:mm:ss");
            string to= ((DateTime)ar.to.Value).ToString("dd/MM/yyyy HH:mm:ss");
            this.from_date_txbl.Text = from; 
            this.to_date_txbl.Text = to;

            TimeSpan diff = (DateTime)ar.to.Value - (DateTime)ar.from.Value;
            int distance = diff.Days;
            if (distance < 1)
            {
                this.type_time_txbl.Text = "Hours";
                this.time_txbl.Text= diff.Hours.ToString();
            }
            else
            {
                this.type_time_txbl.Text = "Days";
                this.time_txbl.Text = diff.Days.ToString();
            }

        }
        static string GenerateNextString(string inputStr)
        {
            // Kiểm tra xem chuỗi có đúng định dạng không
            if (!inputStr.StartsWith("TP"))
            {
                inputStr = "TP00";
            }

            // Lấy phần số trong chuỗi
            string numberStr = inputStr.Substring(2);

            // Chuyển số thành một số nguyên
            int number = int.Parse(numberStr);

            // Tăng giá trị số lên 1
            int nextNumber = number + 1;

            // Tạo chuỗi tiếp theo
            string nextStr = "TP" + nextNumber.ToString("D2");

            return nextStr;
        }
        private void reserve_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            //Còn mỗi câu truy vấn là xong hjhj
            sqlcmd.Parameters.Add("@from", SqlDbType.DateTime).Value = DateTime.ParseExact(this.from_date_txbl.Text, "dd/MM/yyyy HH:mm:ss",
                              CultureInfo.InvariantCulture);
            sqlcmd.Parameters.Add("@to", SqlDbType.DateTime).Value = DateTime.ParseExact(this.to_date_txbl.Text, "dd/MM/yyyy HH:mm:ss",
                              CultureInfo.InvariantCulture);
            sqlcmd.CommandText = $"INSERT INTO THUEPHONG (MATHUEPHONG,MAKH, MAPHONG, NGAYBD, NGAYKT, KQUATHUE) VALUES ('{MATP}','{MaKH}','{MP}',@from,@to,'{KQUA}')";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();
            addRoom1 a;
            a = new addRoom1(ar.ar, MaKH);
            ar.ar.main_content.Content = a;
        }

        private void reserve_MouseEnter(object sender, MouseEventArgs e)
        {
            reserve.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E9755"));
        }

        private void reserve_MouseLeave(object sender, MouseEventArgs e)
        {
            reserve.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF12CE69"));
        }
    }
}
