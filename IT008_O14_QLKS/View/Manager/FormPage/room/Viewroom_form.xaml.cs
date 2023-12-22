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

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for Viewroom_form.xaml
    /// </summary>
    public partial class Viewroom_form : Window
    {
        DB_connection connect = new DB_connection();
        public Viewroom_form(string IDroom)
        {
            InitializeComponent();
            string MaPhong = "M" + IDroom;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM PHONG WHERE TENPHONG='"+IDroom+"'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            roomcard2 rc=new roomcard2();
            while (reader.Read())
            {
                rc = new roomcard2(reader.GetString(1), reader.GetString(2), reader.GetInt32(11),"RoomInfor");
                int sogiuong = reader.GetInt16(3);
                this.bed_tbx.Text = sogiuong.ToString();
               
                if (reader.GetString(5) == "Co")
                    this.bathtub_chbx.IsChecked=true;
                if (reader.GetString(8) == "Co")
                    this.pool_chbx.IsChecked = true;
                this.style_cbx.SelectedIndex=0;
                if (reader.GetString(7) == "Cao")
                {
                    this.internet_cbx.SelectedIndex = 0;
                }
                if (reader.GetString(7) == "Trung Binh")
                {
                    this.internet_cbx.SelectedIndex =1;
                }
                if (reader.GetString(7) == "Thap")
                {
                    this.internet_cbx.SelectedIndex = 2;
                }
                this.type_lbl.Content = reader.GetString(4);
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
                if (this.type_lbl.Content.ToString() == "Unavailabl")
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
            }
            reader.Close();
            
                sqlcmd.CommandText = "SELECT TENKH FROM THUEPHONG T INNER JOIN KHACHHANG K ON T.MAKH=K.MAKH WHERE MAPHONG='" + MaPhong + "'";
                this.TenKH_lbl.Content = sqlcmd.ExecuteScalar();
            if((string)type_lbl.Content=="Rented"||(string) type_lbl.Content == "Booking")
            {
                sqlcmd.CommandText = "SELECT NGAYBD FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "'";
                object value = sqlcmd.ExecuteScalar();
                DateTime date = (DateTime)value;
                this.tungay_lbl.Content = date.ToString("dd/MM/yyyy");
                sqlcmd.CommandText = "SELECT NGAYKT FROM THUEPHONG WHERE MAPHONG='" + MaPhong + "'";
                object value2 = sqlcmd.ExecuteScalar();
                DateTime date2 = (DateTime)value2;
                this.denngay_lbl.Content = date2.ToString("dd/MM/yyyy");
            }    
            

            this.RoomCardCtrl.Content = rc.Content;
            ServiceCard [] SC=new ServiceCard[10];
            ServiceCard[] SCa = new ServiceCard[10];
            ProbBlemCard[] PC= new ProbBlemCard[10];
            SC[0] = new ServiceCard("Maria Ozawa", "19/11/2023", "2M");
            SC[1] = new ServiceCard("Takizawa ", "18/11/2023", "1M");
            SC[2] = new ServiceCard("Jun Aizawa", "17/11/2023", "600k");
            SC[3] = new ServiceCard("Megu Fujiura", "20/11/2023", "1.5M");
            SC[4] = new ServiceCard("Sakurai", "19/11/2023", "550k");
            SC[5] = new ServiceCard("Utsunomiya", "20/11/2023", "650k");
            SC[6] = new ServiceCard("Momotani", "20/11/2023", "500k");
            SC[7] = new ServiceCard("Saori Hara", "19/11/2023", "400k");
            SC[8] = new ServiceCard("Leah Dizon", "18/11/2023", "900k");
            SC[9] = new ServiceCard("Noyomi", "19/11/2023", "200k");


            SCa[0] = new ServiceCard("Maria Ozawa", "19/11/2023", "2M");
            SCa[1] = new ServiceCard("Takizawa ", "18/11/2023", "1M");
            SCa[2] = new ServiceCard("Jun Aizawa", "17/11/2023", "600k");
            SCa[3] = new ServiceCard("Megu Fujiura", "20/11/2023", "1.5M");
            SCa[4] = new ServiceCard("Sakurai", "19/11/2023", "550k");
            SCa[5] = new ServiceCard("Utsunomiya", "20/11/2023", "650k");
            SCa[6] = new ServiceCard("Momotani", "20/11/2023", "500k");
            SCa[7] = new ServiceCard("Saori Hara", "19/11/2023", "400k");
            SCa[8] = new ServiceCard("Leah Dizon", "18/11/2023", "900k");
            SCa[9] = new ServiceCard("Noyomi", "19/11/2023", "200k");

            PC[0] = new ProbBlemCard("Maria Ozawa", "19/11/2023", "2M");
            PC[1] = new ProbBlemCard("Takizawa ", "18/11/2023", "1M");
            PC[2] = new ProbBlemCard("Jun Aizawa", "17/11/2023", "600k");
            PC[3] = new ProbBlemCard("Megu Fujiura", "20/11/2023", "1.5M");
            PC[4] = new ProbBlemCard("Sakurai", "19/11/2023", "550k");
            PC[5] = new ProbBlemCard("Utsunomiya", "20/11/2023", "650k");
            PC[6] = new ProbBlemCard("Momotani", "20/11/2023", "500k");
            PC[7] = new ProbBlemCard("Saori Hara", "19/11/2023", "400k");
            PC[8] = new ProbBlemCard("Leah Dizon", "18/11/2023", "900k");
            PC[9] = new ProbBlemCard("Noyomi", "19/11/2023", "200k");

            CC1.Content = SC[0].Content;
            CC2.Content = SC[1].Content;
            CC3.Content = SC[2].Content;
            CC4.Content = SC[3].Content;
            CC5.Content = SC[4].Content;
            CC6.Content = SC[5].Content;
            CC7.Content = SC[6].Content;
            CC8.Content = SC[7].Content;
            CC9.Content = SC[8].Content;
            CC10.Content = SC[9].Content;
            
            CCa1.Content = SCa[0].Content;
            CCa2.Content = SCa[1].Content;
            CCa3.Content = SCa[2].Content;
            CCa4.Content = SCa[3].Content;
            CCa5.Content = SCa[4].Content;
            CCa6.Content = SCa[5].Content;
            CCa7.Content = SCa[6].Content;
            CCa8.Content = SCa[7].Content;
            CCa9.Content = SCa[8].Content;
            CCa10.Content = SCa[9].Content;

            CCb1.Content = PC[0].Content;
            CCb2.Content = PC[1].Content;
            CCb3.Content= PC[2].Content;
            CCb4.Content = PC[3].Content;
            CCb5.Content = PC[4].Content;
            CCb6.Content = PC[5].Content;
            CCb7.Content = PC[6].Content;
            CCb8.Content   = PC[7].Content;
            CCb9.Content = PC[8].Content;
            CCb10.Content = PC[9].Content;  



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
            add_butt.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));
        }

        private void add_butt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));
        }

        private void add_buttt_MouseDown(object sender, MouseButtonEventArgs e)
        {

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
        }

        private void Cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF790B0B"));
        }
        private void Cancel_MouseLeave_1(object sender, MouseEventArgs e)
        {
            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF0B0B"));
        }
    }
}
