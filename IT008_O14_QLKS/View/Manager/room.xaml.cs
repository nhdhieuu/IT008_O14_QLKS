using IT008_O14_QLKS.View.Manager.Card;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
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
using IT008_O14_QLKS.View.Manager.FormPage.room;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Media.Media3D;
using IT008_O14_QLKS.Connection_db;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for room.xaml
    /// </summary>
    public partial class room : UserControl
    {

        DB_connection connect = new DB_connection();
        int RecordCount;
        public room()
        {
            InitializeComponent();
            Load();
        }
        public void Load()
        {
            int PageIndex = int.Parse(Page_index_lbl.Text);
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = "SELECT *FROM (SELECT *, ROW_NUMBER() OVER (ORDER BY (SELECT NULL)) AS row_num FROM PHONG "+ TypeFilter()+ StatusFilter()+ FloorFilter() + SearchFilter()+ " ) AS tbl WHERE row_num BETWEEN " + (PageIndex*6-5)+ " AND "+ PageIndex*6;

            sqlcmd.Connection = connect.sqlCon;
            
            SqlDataReader reader = sqlcmd.ExecuteReader();
            roomcard[] listCard = new roomcard[6];
            int i = 0;
            while (reader.Read())
            {
                listCard[i]= new roomcard(reader.GetString(1), reader.GetString(2), reader.GetString(4), "day", reader.GetInt32(11), 2);
                i++;
            }
            reader.Close();
            sqlcmd.CommandText = "select COUNT(*) FROM PHONG "+ TypeFilter()+ StatusFilter()+ FloorFilter();
            RecordCount = (int)sqlcmd.ExecuteScalar();

            //
            if (listCard[0] != null)
                cc11.Content = listCard[0].Content;
            else
                cc11.Content = null;
            if (listCard[1] != null)
                cc21.Content = listCard[1].Content;
            else
                cc21.Content = null;
            if (listCard[2] != null)
                cc12.Content = listCard[2].Content; 
            else
                cc12.Content = null;
            if (listCard[3] != null)
                cc22.Content = listCard[3].Content;  
            else
                cc22.Content = null;
            if (listCard[4] != null)
                cc13.Content = listCard[4].Content;
            else
                cc13.Content = null;
            if (listCard[5] != null)
                cc23.Content = listCard[5].Content;
            else
                cc23.Content = null;
        }
        public string SearchFilter()
        {
            string FilterSearch = "";
            if (this.Search_tbx.Text != "")
            {
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.Text;
                sqlcmd.CommandText = "SELECT COUNT (*) FROM PHONG WHERE TENPHONG='" + this.Search_tbx.Text + "'";
                sqlcmd.Connection = connect.sqlCon;
                int count = (int)sqlcmd.ExecuteScalar();
                if (count == 1)
                {
                    FilterSearch = "WHERE TENPHONG='" + this.Search_tbx.Text + "'";
                }
            }
            return FilterSearch;

        }
        public string TypeFilter()
        {
            string FilterType = "";
            if (sup1 == 1)
                FilterType = "WHERE LOAIPHONG='Superior'";
            if (std == 1)
                FilterType = "WHERE LOAIPHONG='Standard'";
            if (dlx1 == 1)
                FilterType = "WHERE LOAIPHONG='Deluxe'";
            if (sui == 1)
                FilterType = "WHERE LOAIPHONG='Suite'";
            if (sup1 == 1 && std == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Superior')";
            if (sup1 == 1 && dlx1 == 1)
                FilterType = "WHERE LOAIPHONG IN ('Deluxe','Superior')";
            if (sup1 == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Suite','Superior')";
            if (std == 1 && dlx1 == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Deluxe')";
            if (std == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Suite')";
            if (dlx1 == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Suite','Deluxe')";
            if (sup1 == 1 && std == 1 && dlx1 == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Superior','Deluxe')";
            if (sup1 == 1 && std == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Superior','Suite')";
            if (sup1 == 1 && dlx1 == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Deluxe','Superior','Suite')";
            if (sui == 1 && std == 1 && dlx1 == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Suite','Deluxe')";
            if (sup1 == 1 && std == 1 && dlx1 == 1 && sui == 1)
                FilterType = "WHERE LOAIPHONG IN ('Standard','Superior','Deluxe','Suite')";
            return FilterType;
        }
        public string StatusFilter()
        {
            string FilterStatus = "";
            string AND = "AND";
            if (sup1 == 0 && std == 0 && dlx1 == 0 && sui == 0)
                AND = "WHERE";
            if (rent == 1)
                FilterStatus = $" {AND} TRANGTHAI='Rented'";
            if (booked == 1)
                FilterStatus = $" {AND} TRANGTHAI='Booking'";
            if (empty == 1)
                FilterStatus = $" {AND} TRANGTHAI='Empty'";
            if (unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI='Unavailabl'";
            if (rent == 1 && booked == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Rented')";
            if (rent == 1 && empty == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Empty','Rented')";
            if (rent == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Unavailabl','Rented')";
            if (booked == 1 && empty == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Empty')";
            if (booked == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Unavailabl')";
            if (empty == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Unavailabl','Empty')";
            if (rent == 1 && booked == 1 && empty == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Rented','Empty')";
            if (rent == 1 && booked == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Rented','Unavailabl')";
            if (rent == 1 && empty == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Empty','Rented','Unavailabl')";
            if (sui == 1 && booked == 1 && empty == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Unavailabl','Empty')";
            if (rent == 1 && booked == 1 && empty == 1 && unavai == 1)
                FilterStatus = $" {AND} TRANGTHAI IN ('Booking','Rented','Empty','Unavailabl')";
            return FilterStatus;
        }
        public string FloorFilter()
        {
            string FilterFloor="";
            string AND = "AND";
            if (sup1 == 0 && std == 0 && dlx1 == 0 && sui == 0 && rent == 0 && booked == 0 && empty == 0 && unavai == 0)
                AND = "WHERE";
            if (stage_s == 1)
                FilterFloor = $" {AND} TENPHONG LIKE '_" + stage_num + "__'";

            return FilterFloor;
        }
        int cleaned = 1;
       
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            AddRoomForm ar=new AddRoomForm();
            ar.ShowDialog();
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E9755"));
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF66BB6A"));
        }

        private void Border_MouseEnter_2(object sender, MouseEventArgs e)
        {
            
        }

        private void calender_MouseLeave(object sender, MouseEventArgs e)
        {
            

        }
        int type_s = 0;
        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if(type_s == 0)
            {
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                type_s = 1;
                type.IsEnabled = true;
                sup.IsEnabled = true;
                standard.IsEnabled = true;
                VIP.IsEnabled = true;
                Dlx.IsEnabled = true;
                ck_type.Visibility = Visibility.Visible;
                bd_type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                type_txt.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFC513"));
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
             supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));

            }
            else
            {
                
                type_s = 0;
              
                type.IsEnabled = false;
                sup.IsEnabled = false;
                standard.IsEnabled = false;
                VIP.IsEnabled = false;
                Dlx.IsEnabled = false;
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                VIP.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                ck_type.Visibility = Visibility.Hidden;
                bd_type.BorderBrush = new SolidColorBrush(Colors.White);
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AFFFC000"));
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                type.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                sui = 0;
                dlx1 = 0;
                std = 0;
                sup1 = 0;
                Load();

            }
        }
        int std = 0;
        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            if (std == 0)
            {
                standard.Background = new SolidColorBrush(Colors.WhiteSmoke);
                std = 1;
               
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));



            }
            else
            {
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                std = 0;
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }
        int sup1 = 0;
        private void Border_MouseDown_4(object sender, MouseButtonEventArgs e)
        {

            if (sup1 == 0)
            {
                sup.Background = new SolidColorBrush(Colors.WhiteSmoke);
                sup1 = 1;

                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));

            }
            else
            {
               sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

               sup1 = 0;
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }
        int dlx1 = 0;
        private void Dlx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dlx1 == 0)
            {
                Dlx.Background = new SolidColorBrush(Colors.WhiteSmoke);
                dlx1 = 1;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));


            }
            else
            {
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

                dlx1 = 0;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();

        }
        int sui = 0;

        private void VIP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sui == 0)
            {
                VIP.Background = new SolidColorBrush(Colors.WhiteSmoke);
              sui = 1;
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));


            }
            else
            {
               VIP.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                sui = 0;

                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }

        int status_s = 0;
        private void bd_type_Copy1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(status_s==0)
            {
                ck_status.Visibility = Visibility.Visible;
                status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF048AFF"));
                bd_status.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                status_s = 1;
                rent_bd.IsEnabled = true;
                booked_bd.IsEnabled = true;
                empty_bd.IsEnabled = true; 
                unavai_bd.IsEnabled = true;
                rent_t.Foreground = new SolidColorBrush(Colors.Black);
                booked_t.Foreground = new SolidColorBrush(Colors.Blue);
                empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                unavai_t.Foreground = new SolidColorBrush(Colors.DarkRed);
            }
            else
            {

                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                status_s = 0;
                ck_status.Visibility = Visibility.Hidden;
                status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2014E91"));
                bd_status.BorderBrush = new SolidColorBrush(Colors.White);
                rent_bd.IsEnabled = false;
                booked_bd.IsEnabled = false;
                rent_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                rent_t.Foreground = new SolidColorBrush(Colors.Black);
                rent = 0;
                booked_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                booked_t.Foreground = new SolidColorBrush(Colors.Blue);
                booked = 0;
                unavai_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                unavai_t.Foreground = new SolidColorBrush(Colors.DarkRed);
                unavai = 0;

                empty_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                empty = 0;
                empty_bd.IsEnabled =false;
                unavai_bd.IsEnabled = false;
                rent_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F000000"));
                booked_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C0000FF"));
                empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00652E"));
                unavai_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8B0000"));
                Load();
            }
        }
        int rent = 0;
        private void rent_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(rent==0)
            {
                
                rent_bd.Background = new SolidColorBrush(Colors.Black);
                rent_t.Foreground = new SolidColorBrush(Colors.White);
                rent = 1;
            }
            else {
                rent_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF")); 
                rent_t.Foreground = new SolidColorBrush(Colors.Black);
                rent = 0;
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }

        
        int booked =0;
        private void booked_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (booked == 0)
            {

                booked_bd.Background = new SolidColorBrush(Colors.Blue);
               booked_t.Foreground = new SolidColorBrush(Colors.White);
                booked= 1;
            }
            else
            {
                booked_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                booked_t.Foreground = new SolidColorBrush(Colors.Blue);
                booked = 0;
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }
        int empty = 0;
        private void empty_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (empty == 0)
            {

                empty_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                empty_t.Foreground = new SolidColorBrush(Colors.White);
               empty= 1;
            }
            else
            {
               empty_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
               empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                empty = 0;
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();
        }
        int unavai=0;
        private void unavai_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (unavai== 0)
            {

               unavai_bd.Background = new SolidColorBrush(Colors.DarkRed);
               unavai_t.Foreground = new SolidColorBrush(Colors.White);
               unavai = 1;
            }
            else
            {
               unavai_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
               unavai_t.Foreground = new SolidColorBrush(Colors.DarkRed);
                unavai = 0;
            }
            this.Page_index_lbl.Text = "1";
            this.Search_tbx.Text = string.Empty;
            Load();

        }
        int stage_s = 0;
        int stage_num = 1;
        private void bd_stage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (stage_s == 0)
            {
                stage_s = 1;
                ck_stage.Visibility = Visibility.Visible;
                stage.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                stg_t.Foreground = new SolidColorBrush(Colors.White);
                up.Background = new SolidColorBrush(Colors.LightGray);
                down.Background = new SolidColorBrush(Colors.LightGray);
                bd_stage.BorderBrush = new SolidColorBrush(Colors.Green);
                num_s.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF7BB04"));
                up.IsEnabled = true;
                down.IsEnabled = true;
               
            }
            else
            {
                stage_s = 0;
                ck_stage.Visibility = Visibility.Hidden;
                stage.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                stg_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFFFFFF"));
                up.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFFFFFF"));
                down.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFFFFFF"));
                bd_stage.BorderBrush = new SolidColorBrush(Colors.White);
                num_s.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FF7BB04"));
                up.IsEnabled = false;
                down.IsEnabled = false;
            }
            this.Search_tbx.Text = string.Empty;
            Load();
        }

        private void up_MouseDown(object sender, MouseButtonEventArgs e)
        {
            stage_num += 1;
            if(stage_num <=9)
            {
                num_s.Content = "0" + stage_num.ToString();
            }
            else
            {
                num_s.Content =  stage_num.ToString();
            }
            this.Search_tbx.Text = string.Empty;
            Load();
        }

        private void down_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (stage_num > 0) 
            {
                
                stage_num -= 1;
                if (stage_num<= 9)
                {
                    if (stage_num == 0)
                        num_s.Content = "G";
                    else
                        num_s.Content = "0" + stage_num.ToString();
                }
                else
                {
                    num_s.Content = stage_num.ToString();
                }
            }
            this.Search_tbx.Text = string.Empty;
            Load();

        }

        private void Next_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int PageCount;
            int index = int.Parse(this.Page_index_lbl.Text);
            int temp = RecordCount % 6;
            if (temp == 0)
                PageCount = RecordCount / 6;
            else
                PageCount = RecordCount / 6+1;
            if (index < PageCount)
            {
                index++;
                this.Page_index_lbl.Text = index.ToString();
                this.Search_tbx.Text = string.Empty;
                Load();
            }
           
        }

        private void Back_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int index = int.Parse(this.Page_index_lbl.Text);
            if (index > 1)
            {
                index--;
                this.Page_index_lbl.Text = index.ToString();
                this.Search_tbx.Text = string.Empty;
                Load();
            }
           
        }

        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            type_s = 0;

            type.IsEnabled = false;
            sup.IsEnabled = false;
            standard.IsEnabled = false;
            VIP.IsEnabled = false;
            Dlx.IsEnabled = false;
            standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            VIP.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            ck_type.Visibility = Visibility.Hidden;
            bd_type.BorderBrush = new SolidColorBrush(Colors.White);
            type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AFFFC000"));
            Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
            supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
            VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
            standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
            type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
            sui = 0;
            dlx1 = 0;
            std = 0;
            sup1 = 0;
            stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
            status_s = 0;
            ck_status.Visibility = Visibility.Hidden;
            status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2014E91"));
            bd_status.BorderBrush = new SolidColorBrush(Colors.White);
            rent_bd.IsEnabled = false;
            booked_bd.IsEnabled = false;
            rent_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            rent_t.Foreground = new SolidColorBrush(Colors.Black);
            rent = 0;
            booked_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            booked_t.Foreground = new SolidColorBrush(Colors.Blue);
            booked = 0;
            unavai_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            unavai_t.Foreground = new SolidColorBrush(Colors.DarkRed);
            unavai = 0;

            empty_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
            empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
            empty = 0;
            empty_bd.IsEnabled = false;
            unavai_bd.IsEnabled = false;
            rent_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F000000"));
            booked_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7C0000FF"));
            empty_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F00652E"));
            unavai_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F8B0000"));
            Load();
            this.Search_tbx.Text = string.Empty;
        }
    }
    
}