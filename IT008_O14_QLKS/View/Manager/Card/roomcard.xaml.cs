using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.View.Manager.FormPage.room;
using IT008_O14_QLKS.View.Manager.Card.roomCardbackground;

using System.Data.SqlClient;
using System.Data;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Clients.FormPage;
using IT008_O14_QLKS.View.Manager.FormPage.room.booking_list;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for roomcard.xaml
    /// </summary>
    public partial class roomcard : UserControl
    {
        public string IDroom { get; set; }
        public string typeroom { get; set; }
        public string status; 
        
       
      public int time { get; set; }
        public string typetime { get; set; }
        public int numer_guest { get; set; }
        int so = 0;


        public roomcard(string IDroom, string typeroom, string status, string typetime, int number,  int time)
        {
            this.IDroom = IDroom;
            this.typeroom = typeroom;
            this.status = status;
           
            this.numer_guest = number;
            InitializeComponent();
            
            input();
            loadso();
        }
        DateTime myDateTime = DateTime.Now;
        DB_connection connect = new DB_connection();
        private void loadso()
        {
             int soluong=0;
            SqlCommand sqlcmd = new SqlCommand();
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];
            sqlcmd.CommandType = CommandType.Text;
            string tenphong = "M" + IDroom;
            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE  MAPHONG = '{tenphong}' and '{trueday}' <NGAYKT AND KQUATHUE='Dang Thue'";
            sqlcmd.Connection = connect.sqlCon;


            using (SqlDataReader reader1 = sqlcmd.ExecuteReader())
            {

                while (reader1.Read())
                {


                    soluong++;
                   


                }
                reader1.Close();
            }
            sott.Text = soluong.ToString();
            
        }    
        private void Image_KeyDown(object sender, KeyEventArgs e)
        {

       
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void viewbd_MouseEnter(object sender, MouseEventArgs e)
        {
            viewbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0077E0"));
        }

        private void viewbd_MouseLeave(object sender, MouseEventArgs e)
        {
            viewbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00A9FF"));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            statusbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF725805"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {

            statusbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC6980A"));
        }
        public void GetDay()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            string tenphong = "M" + IDroom;
            sqlcmd.CommandText = $"SELECT NGAYBD FROM THUEPHONG WHERE  MAPHONG = '{tenphong}'";
            sqlcmd.Connection = connect.sqlCon;
            DateTime d = (DateTime)sqlcmd.ExecuteScalar();
            TimeSpan diff = DateTime.Now - d;
            int span = diff.Days;
            if (span >= 1)
            {
                this.typetime = "day";
                this.time = diff.Days;
            }
            else
            {
                this.typetime = "hour";
                this.time = diff.Hours;
            }
        }
        public void input (  )
        {
            idroomtxt.Text = this.IDroom;
            loai.Text = this.typeroom;
            statustxt.Text = this.status;
            number_guesttxt.Text = this.numer_guest.ToString();
            if (this.status == "Rented")
                GetDay();
            if (this.typeroom=="Standard")
            {
                loai.Foreground = new SolidColorBrush(Colors.White);
            }
            if (this.status == "Booking")
            {
                mainbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4D96FF")) ;
                statustxt.Foreground = new SolidColorBrush(Colors.White);
                idroomtxt.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (this.status == "Empty")
            {
                mainbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6BCB77"));
               idroomtxt.Foreground = new SolidColorBrush(Colors.White);
                statustxt.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (this.status == "Unavailabl")
            {
                mainbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DA5C53"));
                statustxt.Foreground = new SolidColorBrush(Colors.White);
                idroomtxt.Foreground = new SolidColorBrush(Colors.White);

            }    
                else {
                if(this.status=="Rented")
                {
                    if (this.typetime == "day")
                    {
                        if (this.time > 1)
                            numbertxt.Text = time.ToString() + " days";
                        else
                            numbertxt.Text = time.ToString() + " day";
                    }
                    if (this.typetime == "hour")
                    {
                        if (this.time > 1)
                            numbertxt.Text = time.ToString() + " hours";
                        else
                            numbertxt.Text = time.ToString() + " hour";
                    }
                }    

               
                       
                      
                    }
            //chon nen

            if (this.typeroom == "Standard" )
            {
                    StandardBG bg= new StandardBG();
                    background.Content = bg;
            }
            if (this.typeroom == "Superior")
            {
                SuperiorBG bg = new SuperiorBG();
                background.Content = bg;
            }
            if (this.typeroom == "Deluxe")
            {
                DeluxeBG bg = new DeluxeBG();
                background.Content = bg;
            }
            if (this.typeroom == "Suite")
            {
                SuiteBG bg = new SuiteBG();
                background.Content = bg;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (status == "Rented")
            {
                Viewroom_form vr = new Viewroom_form(IDroom, numbertxt.Text);
                vr.ShowDialog();
            }
            else
            {
                ViewRoom_BEU vr=new ViewRoom_BEU(IDroom);
                vr.ShowDialog();
            }    

        }

        private void statusbd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            booking_list a = new booking_list(IDroom);
            a.ShowDialog();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
    }

