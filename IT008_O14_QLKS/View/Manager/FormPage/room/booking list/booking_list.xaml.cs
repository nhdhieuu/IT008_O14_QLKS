using IT008_O14_QLKS.View.Clients.Card.Card_room;
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

namespace IT008_O14_QLKS.View.Manager.FormPage.room.booking_list
{
    /// <summary>
    /// Interaction logic for booking_list.xaml
    /// </summary>
    public partial class booking_list : Window
    {
        string ID;
        public int so = 0;
        DateTime myDateTime = DateTime.Now;
        DB_connection connect=new DB_connection();
        public booking_list(string id)
        {
           
            InitializeComponent();
            this.ID = id;
            this.ID = "M" + ID;
            load();
        

        }
        private void load()
        {
            stk.Children.Clear();
            SqlCommand sqlcmd = new SqlCommand();
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE  MAPHONG = '{ID}' and '{trueday}' <NGAYKT AND KQUATHUE='Dang Thue'";

            sqlcmd.Connection = connect.sqlCon;


            using (SqlDataReader reader1 = sqlcmd.ExecuteReader())
            {

                while (reader1.Read())
                {


                    add(reader1.GetString(0));
                    so++;


                }
            }

        }
        public void add(string ID)
        {
            ContentControl a = new ContentControl
            {

                Width = 693
            };
            Border c = new Border
            {
                Height = 20
            };
            Room_card_client b = new Room_card_client(ID,"book2");
            b.book();
            b.book2();
            if (b.loai() == "paid")
            {

            }
            else
            {
                a.Content = b;
                stk.Children.Add(a);
                stk.Children.Add(c);
            }

        }
    
        public void reset()
        {
            
            load();
        }    
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {


            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {

            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }
    }
}
