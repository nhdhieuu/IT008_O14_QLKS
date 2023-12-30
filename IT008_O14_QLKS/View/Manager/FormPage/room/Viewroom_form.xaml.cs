using IT008_O14_QLKS.View.Manager.Card;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
using IT008_O14_QLKS.Connection_db;
using System.Data.SqlTypes;
using System.Windows.Forms;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using Microsoft.Win32;
using System.IO;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for Viewroom_form.xaml
    /// </summary>
    public partial class Viewroom_form : Window
    {
        DB_connection connect = new DB_connection();
        string bed;
        string bath = "Khong";
        string pool = "Khong";
        int style;
        int equip;
        int internet;
        int cleaning;
        int maintain;
        string TenPhong;
        string matp;
        public Viewroom_form(string IDroom)
        {
            InitializeComponent();
            TenPhong = IDroom;
            string MaPhong = "M" + IDroom;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM PHONG WHERE TENPHONG='" + IDroom + "'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            roomcard2 rc = new roomcard2();
            while (reader.Read())
            {
                rc = new roomcard2(reader.GetString(1), reader.GetString(2), reader.GetInt32(11), "RoomInfor");
                int sogiuong = reader.GetInt16(3);
                this.bed_tbx.Text = sogiuong.ToString();
                bed = bed_tbx.Text;
                if (reader.GetString(5) == "Co")
                {
                    this.bathtub_chbx.IsChecked = true;
                    bath = "Co";
                }

                if (reader.GetString(8) == "Co")
                {
                    this.pool_chbx.IsChecked = true;
                    pool = "Co";
                }
                this.style_cbx.SelectedIndex = 0;
                if (reader.GetString(7) == "Cao")
                {
                    this.internet_cbx.SelectedIndex = 0;
                }
                if (reader.GetString(7) == "Trung Binh")
                {
                    this.internet_cbx.SelectedIndex = 1;
                }
                if (reader.GetString(7) == "Thap")
                {
                    this.internet_cbx.SelectedIndex = 2;
                }
                internet = this.internet_cbx.SelectedIndex;
                this.type_lbl.Content = reader.GetString(15);
                if (this.type_lbl.Content.ToString() == "Empty")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6BCB77"));
                    this.type_background2.Visibility = Visibility.Collapsed;
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;


                }
                if (this.type_lbl.Content.ToString() == "Booking")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D96FF"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D96FF"));
                    this.da_o_lbl.Content = "2 days";
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;
                }
                if (this.type_lbl.Content.ToString() == "Rented")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                    this.TenKH_lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
                    this.type_lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
                }
                if (this.type_lbl.Content.ToString() == "Unavailable")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DA5C53"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DA5C53"));
                    this.TenKH_lbl.Content = "cleaning";
                    this.denngay_lbl.Visibility = Visibility.Hidden;
                    this.da_o_lbl.Visibility = Visibility.Hidden;
                    this.tungay_lbl.Content = "Mo ta bla bla";
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;
                }
                if (reader.GetString(12) == "Daily")
                    this.cleaning_cbx.SelectedIndex = 0;
                if (reader.GetString(12) == "Weekly")
                    this.cleaning_cbx.SelectedIndex = 1;
                if (reader.GetString(12) == "Monthly")
                    this.cleaning_cbx.SelectedIndex = 2;
                if (reader.GetString(13) == "Daily")
                    this.maintain_cbx.SelectedIndex = 0;
                if (reader.GetString(13) == "Weekly")
                    this.maintain_cbx.SelectedIndex = 1;
                if (reader.GetString(13) == "Monthly")
                    this.maintain_cbx.SelectedIndex = 2;
                if (reader.GetString(14) == "Minibar")
                    this.equip_cbx.SelectedIndex = 1;
                if (reader.GetString(14) == "Fridge")
                    this.equip_cbx.SelectedIndex = 0;
                equip = this.equip_cbx.SelectedIndex;
                cleaning = this.cleaning_cbx.SelectedIndex;
                maintain = this.maintain_cbx.SelectedIndex; 
            }
            reader.Close();
            //Load illus
            sqlcmd.CommandText = "SELECT ILLUS FROM PHONG WHERE TENPHONG='" + IDroom + "'";
            sqlcmd.Connection = connect.sqlCon;
            try
            {
                byte[] imageData = (byte[])sqlcmd.ExecuteScalar();
                MemoryStream memStream = new MemoryStream(imageData);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
                Ilus.ImageSource = bitmap;
            }
            catch { }

            sqlcmd.CommandText = "SELECT TENKH FROM THUEPHONG T INNER JOIN KHACHHANG K ON T.MAKH=K.MAKH WHERE MAPHONG='" + MaPhong + "'";
            this.TenKH_lbl.Content = sqlcmd.ExecuteScalar();
            if ((string)type_lbl.Content == "Rented" || (string)type_lbl.Content == "Booking")
            {
                sqlcmd.Parameters.Add("@now", SqlDbType.DateTime).Value = DateTime.Now;
                sqlcmd.CommandText = "SELECT NGAYBD FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "' AND KQUATHUE='Thanh Cong' AND NGAYBD<=@now AND NGAYKT>=@now";
                object value = sqlcmd.ExecuteScalar();
                DateTime date = (DateTime)value;
                this.tungay_lbl.Content = date.ToString("dd/MM/yyyy");
                sqlcmd.CommandText = "SELECT NGAYKT FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "' AND KQUATHUE='Thanh Cong' AND NGAYBD<=@now AND NGAYKT>=@now";
                object value2 = sqlcmd.ExecuteScalar();
                DateTime date2 = (DateTime)value2;
                this.denngay_lbl.Content = date2.ToString("dd/MM/yyyy");
                sqlcmd.CommandText = "SELECT GIATHEOGIO FROM PHONG WHERE MAPHONG='" + MaPhong + "'";
                Decimal value3 = Math.Truncate((Decimal)sqlcmd.ExecuteScalar());
                this.GiaTheoGio.Content = value3.ToString() + " VND";
                sqlcmd.CommandText = "SELECT GIATHEONGAY FROM PHONG WHERE MAPHONG='" + MaPhong + "'";
                Decimal value4 = Math.Truncate((Decimal)sqlcmd.ExecuteScalar());
                this.GiaTheoNgay.Content = value4.ToString() + " VND";

            }
            this.RoomCardCtrl.Content = rc.Content;

            sqlcmd.CommandText = "SELECT MATHUEPHONG FROM THUEPHONG T INNER JOIN PHONG K ON T.MAPHONG=K.MAPHONG WHERE T.MAPHONG='" + MaPhong + "'";
            matp = sqlcmd.ExecuteScalar().ToString();
            LoadService();
            LoadProb();
        }
        public Viewroom_form(string IDroom, string day)
        {
            InitializeComponent();
            TenPhong = IDroom;
            string MaPhong = "M" + IDroom;
            this.da_o_lbl.Content = day;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM PHONG WHERE TENPHONG='" + IDroom + "'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            roomcard2 rc = new roomcard2();
            while (reader.Read())
            {
                rc = new roomcard2(reader.GetString(1), reader.GetString(2), reader.GetInt32(11), "RoomInfor");
                int sogiuong = reader.GetInt16(3);
                this.bed_tbx.Text = sogiuong.ToString();
                bed = bed_tbx.Text;
                if (reader.GetString(5) == "Co")
                {
                    this.bathtub_chbx.IsChecked = true;
                    bath = "Co";
                }

                if (reader.GetString(8) == "Co")
                {
                    this.pool_chbx.IsChecked = true;
                    pool = "Co";
                }
                this.style_cbx.SelectedIndex = 0;
                if (reader.GetString(7) == "Cao")
                {
                    this.internet_cbx.SelectedIndex = 0;
                }
                if (reader.GetString(7) == "Trung Binh")
                {
                    this.internet_cbx.SelectedIndex = 1;
                }
                if (reader.GetString(7) == "Thap")
                {
                    this.internet_cbx.SelectedIndex = 2;
                }
                internet = this.internet_cbx.SelectedIndex;
                this.type_lbl.Content = reader.GetString(15);
                if (this.type_lbl.Content.ToString() == "Empty")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6BCB77"));
                    this.type_background2.Visibility = Visibility.Collapsed;
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;


                }
                if (this.type_lbl.Content.ToString() == "Booking")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D96FF"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D96FF"));
                    this.da_o_lbl.Content = "2 days";
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;
                }
                if (this.type_lbl.Content.ToString() == "Rented")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
                    this.TenKH_lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
                    this.type_lbl.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
                }
                if (this.type_lbl.Content.ToString() == "Unavailable")
                {
                    this.type_background.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DA5C53"));
                    this.type_background2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DA5C53"));
                    this.TenKH_lbl.Content = "cleaning";
                    this.denngay_lbl.Visibility = Visibility.Hidden;
                    this.da_o_lbl.Visibility = Visibility.Hidden;
                    this.tungay_lbl.Content = "Mo ta bla bla";
                    this.DV_KhachDat.Visibility = Visibility.Hidden;
                    this.problem.Visibility = Visibility.Hidden;
                    this.DV_TaiPhong_Scrl.Height = 250;
                }
                if (reader.GetString(12) == "Daily")
                    this.cleaning_cbx.SelectedIndex = 0;
                if (reader.GetString(12) == "Weekly")
                    this.cleaning_cbx.SelectedIndex = 1;
                if (reader.GetString(12) == "Monthly")
                    this.cleaning_cbx.SelectedIndex = 2;
                if (reader.GetString(13) == "Daily")
                    this.maintain_cbx.SelectedIndex = 0;
                if (reader.GetString(13) == "Weekly")
                    this.maintain_cbx.SelectedIndex = 1;
                if (reader.GetString(13) == "Monthly")
                    this.maintain_cbx.SelectedIndex = 2;
                if (reader.GetString(14) == "Minibar")
                    this.equip_cbx.SelectedIndex = 1;
                if (reader.GetString(14) == "Fridge")
                    this.equip_cbx.SelectedIndex = 0;
                equip = this.equip_cbx.SelectedIndex;
                cleaning = this.cleaning_cbx.SelectedIndex;
                maintain = this.maintain_cbx.SelectedIndex;
            }
            reader.Close();
            sqlcmd.CommandText = "SELECT ILLUS FROM PHONG WHERE TENPHONG='" + IDroom + "'";
            sqlcmd.Connection = connect.sqlCon;
            try
            {
                byte[] imageData = (byte[])sqlcmd.ExecuteScalar();
                MemoryStream memStream = new MemoryStream(imageData);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
                Ilus.ImageSource = bitmap;
            }
            catch { }
            sqlcmd.CommandText = "SELECT TENKH FROM THUEPHONG T INNER JOIN KHACHHANG K ON T.MAKH=K.MAKH WHERE MAPHONG='" + MaPhong + "'";
            this.TenKH_lbl.Content = sqlcmd.ExecuteScalar();
            if ((string)type_lbl.Content == "Rented" || (string)type_lbl.Content == "Booking")
            {
                sqlcmd.Parameters.Add("@now", SqlDbType.DateTime).Value = DateTime.Now;
                sqlcmd.CommandText = "SELECT NGAYBD FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "' AND KQUATHUE='Thanh Cong' AND NGAYBD<=@now AND NGAYKT>=@now";
                object value = sqlcmd.ExecuteScalar();
                DateTime date = (DateTime)value;
                this.tungay_lbl.Content = date.ToString("dd/MM/yyyy");
                sqlcmd.CommandText = "SELECT NGAYKT FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "' AND KQUATHUE='Thanh Cong' AND NGAYBD<=@now AND NGAYKT>=@now";
                object value2 = sqlcmd.ExecuteScalar();
                DateTime date2 = (DateTime)value2;
                this.denngay_lbl.Content = date2.ToString("dd/MM/yyyy");
                sqlcmd.CommandText = "SELECT GIATHEOGIO FROM PHONG WHERE MAPHONG='" + MaPhong + "'";
                Decimal value3 = Math.Truncate((Decimal)sqlcmd.ExecuteScalar());
                this.GiaTheoGio.Content = value3.ToString() + " VND";
                sqlcmd.CommandText = "SELECT GIATHEONGAY FROM PHONG WHERE MAPHONG='" + MaPhong + "'";
                Decimal value4 = Math.Truncate((Decimal)sqlcmd.ExecuteScalar());
                this.GiaTheoNgay.Content = value4.ToString() + " VND";

            }
            this.RoomCardCtrl.Content = rc.Content;

            sqlcmd.CommandText = "SELECT MATHUEPHONG FROM THUEPHONG T INNER JOIN PHONG K ON T.MAPHONG=K.MAPHONG WHERE T.MAPHONG='" + MaPhong + "'";
            matp = sqlcmd.ExecuteScalar().ToString();
            LoadService();
            LoadProb();
        }
        public void LoadService()
        {
            ServicePannel.Children.Clear();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = $"SELECT * FROM CHITIETDV WHERE MATHUEPHONG='{matp}'";
            SqlDataReader reader2 = sqlcmd.ExecuteReader();
            while (reader2.Read())
            {
                ServiceCard sc = new ServiceCard(reader2.GetString(1), reader2.GetDateTime(4), reader2.GetDecimal(3), reader2.GetInt32(2).ToString());
                ContentControl cc = new ContentControl();
                cc.Height = 42;
                cc.Width = 375;
                cc.Content = sc.Content;
                ServicePannel.Children.Add(cc);
            }
            reader2.Close();
        }
        public void LoadProb()
        {
            PRPanel.Children.Clear();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = $"SELECT * FROM CHITIETPR WHERE MATHUEPHONG='{matp}'";
            SqlDataReader reader3 = sqlcmd.ExecuteReader();
            while (reader3.Read())
            {
                ProblemCard2 sc = new ProblemCard2(reader3.GetString(1), reader3.GetDateTime(4), reader3.GetDecimal(3));
                ContentControl cc = new ContentControl();
                cc.Height = 42;
                cc.Width = 375;
                cc.Content = sc.Content;
                PRPanel.Children.Add(cc);
            }
            reader3.Close();
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ViewRoomWD.Close();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            CLoseTXT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
            CLoseTXT.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void ViewRoomWD_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void add_butt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));
        }

        private void add_butt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));
        }



        private void add_buttt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));

        }

        private void add_buttt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));

        }

        private void Change_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Visible;
            this.Cancel.Visibility = Visibility.Visible;
            this.Change.Visibility = Visibility.Hidden;
            this.bed_tbx.IsEnabled = true;
            this.bathtub_chbx.IsEnabled = true;
            this.pool_chbx.IsEnabled = true;
            this.style_cbx.IsEnabled = true;
            this.equip_cbx.IsEnabled = true;
            this.internet_cbx.IsEnabled = true;
            cleaning_cbx.IsEnabled = true;
            maintain_cbx.IsEnabled = true;
            Load_Ilus.IsEnabled= true;
        }

        private void Change_MouseEnter(object sender, MouseEventArgs e)
        {
            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));
        }

        private void Change_MouseLeave(object sender, MouseEventArgs e)
        {
            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
            this.bed_tbx.IsEnabled = false;
            this.bathtub_chbx.IsEnabled = false;
            this.pool_chbx.IsEnabled = false;
            this.style_cbx.IsEnabled = false;
            this.equip_cbx.IsEnabled = false;
            this.internet_cbx.IsEnabled = false;
            cleaning_cbx.IsEnabled = false;
            maintain_cbx.IsEnabled = false;
            Load_Ilus.IsEnabled = false;                                    
            bed = this.bed_tbx.Text;
            if (this.pool_chbx.IsChecked == true)
                pool = "Co";
            else
                pool = "Khong";
            if (this.bathtub_chbx.IsChecked == true)
                bath = "Co";
            else
                bath = "Khong";
            style = this.style_cbx.SelectedIndex;
            equip = this.equip_cbx.SelectedIndex;
            internet = this.internet_cbx.SelectedIndex;
            cleaning = this.cleaning_cbx.SelectedIndex;
            maintain = this.maintain_cbx.SelectedIndex;
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
            SqlCommand sqlcmd = new SqlCommand();
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
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "UPDATE PHONG SET SOGIUONG=" + bed + ", BONTAM='" + bath + "', HOBOI='" + pool + "', STYLE='" + this.style_cbx.SelectionBoxItem.ToString() + "', EQUIP='" + EquipTemp + "', INTERNET='" + InternetTemp + "', CLEANING='" + this.cleaning_cbx.SelectionBoxItem.ToString() + "', MAINTAIN='" + this.maintain_cbx.SelectionBoxItem.ToString() + "', ILLUS=@image WHERE TENPHONG='" + TenPhong + "'";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();
        }

        private void Save_MouseEnter(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));
        }

        private void Save_MouseLeave(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));
        }

        private void Cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
            this.bed_tbx.IsEnabled = false;
            this.bathtub_chbx.IsEnabled = false;
            this.pool_chbx.IsEnabled = false;
            this.style_cbx.IsEnabled = false;
            this.equip_cbx.IsEnabled = false;
            this.internet_cbx.IsEnabled = false;
            cleaning_cbx.IsEnabled = false;
            maintain_cbx.IsEnabled = false;
            Load_Ilus.IsEnabled = false;
            this.bed_tbx.Text = bed;
            if (pool == "Co")
                this.pool_chbx.IsChecked = true;
            else
                this.pool_chbx.IsChecked = false;
            if (bath == "Co")
                this.bathtub_chbx.IsChecked = true;
            else
                this.bathtub_chbx.IsChecked = false;
            this.style_cbx.SelectedIndex = style;
            this.equip_cbx.SelectedIndex = equip;
            this.internet_cbx.SelectedIndex = internet;
            this.cleaning_cbx.SelectedIndex = cleaning;
            this.maintain_cbx.SelectedIndex = maintain;

        }

        private void Cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF790B0B"));
        }
        private void Cancel_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF0B0B"));
        }


        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sttroompage a = new sttroompage(type_lbl.Content.ToString(), TenPhong);
            a.ShowDialog();

        } 

        private void add_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddService AS= new AddService(matp,this);
            AS.ShowDialog();
        }
        private void add_buttt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddProblem ap = new AddProblem(matp,this);
            ap.ShowDialog();
        }

        private void add_buttt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));

        }

        private void add_buttt_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));

        }

        private void Save_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));

        }

        private void Save_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));

        }

        private void Change_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));

        }

        private void Change_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void Cancel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF790B0B"));

        }

        private void Cancel_MouseLeave_1(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF0B0B"));

        }

        private void Border_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            CLoseTXT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Border_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
            CLoseTXT.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

        }

        private void add_butt_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));

        }

        private void add_butt_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));



        }
        Image early = new Image();
        private void Load_Ilus_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Ilus.ImageSource = early.Source;
            Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
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
