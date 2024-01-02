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
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2;
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.Connection_db;
using System.Data.SqlClient;
using System.Data;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for sttroompage.xaml
    /// </summary>
    public partial class sttroompage : Window

    {
        string cstt { get; set; }
        string ID;
        DB_connection connect = new DB_connection();
        public sttroompage(string cstt,string ID)
        {
            this.ID = ID;

            InitializeComponent();
           
                        this.cstt=cstt;
             Load();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;


            sqlcmd.CommandText = $"select * from PHONG where TENPHONG ='{ID}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader2 = sqlcmd.ExecuteReader();

            using (reader2)
            {
                if (reader2.Read()) // Kiểm tra xem có dữ liệu hay không
                {
                    roomcard2 rc = new roomcard2(reader2.GetString(1), reader2.GetString(2), reader2.GetInt32(11), "RoomInfor");
                    room.Content = rc;
                }
            }
        }
     
            
        
        private void Load()
        {
            if(cstt=="Unavailable")
            {
                cstt_txt.Text = "unavailable";
                cstt_bd.Background = new SolidColorBrush(Colors.DarkRed);
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
              unavailable_adj a=new unavailable_adj(ID,this);
                stt2.Content = a.Content;
                //adj_bd.Height = 0;
            }
           else if (cstt == "Empty")
            {
                cstt_txt.Text = "empty";
                cstt_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
               empty_adj a = new empty_adj(ID, this);
                stt2.Content = a.Content;
               // adj_bd.Height = 0;
            }
            else  if (cstt == "Booking")
            {
                cstt_txt.Text = "booking";
                cstt_bd.Background = new SolidColorBrush(Colors.Blue);
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
                empty_adj a = new empty_adj(ID,this);
                stt2.Content = a.Content;
                //adj_bd.Height = 0;
            }
            else
            {
                empty_adj a = new empty_adj(ID,this);
                stt2.Content = a.Content;

            }


        }
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE9E8E2"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void sttgrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
