using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using IT008_O14_QLKS.View.Clients.Card.Card_room;
using System.Windows;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Clients.FormPage;

namespace IT008_O14_QLKS.View.Clients
{
    public partial class ClientsRoom : UserControl
    {
        string hallo;
        private DateTime myDateTime = DateTime.Now;
        string username;
        string ID;
        DB_connection connect = new DB_connection();
        public ClientsRoom(string username)
        {
            InitializeComponent();
            this.username = username;
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT *  from KHACHHANG Where username='{username}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {
                this.ID = reader.GetString(0);


            }
            reader.Close();
            loadhuy();
            loadbook();
            load();
           
        

        }
        public void loadhuy()
        {
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];


            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' and ((KQUATHUE='That Bai')or('{trueday}'>NGAYKT and KQUATHUE!='Thanh Cong'))";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {

                //tb.Visibility = Visibility.Hidden;
                add(reader.GetString(0), "huy");


            }
            reader.Close();

        }
        public void loadbook()
        {
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];

           
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' and '{trueday}' <= NGAYKT AND KQUATHUE='Dang Thue'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {

                //tb.Visibility = Visibility.Hidden;
                add(reader.GetString(0),"book");


            }
            reader.Close();

        }
      
        public void load()
        {
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];

            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' and  KQUATHUE='Thanh Cong'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {

                //tb.Visibility = Visibility.Hidden;
                add(reader.GetString(0),"khong");


            }reader.Close();

        }
        public void add(string ID, string str)
        {
            ContentControl a = new ContentControl
            {

                Width = 693
            };
            Border c = new Border
            {
                Height = 20
            };
            Room_card_client b = new Room_card_client(ID,"client");
            if (str == "book")
                b.book();
            if(str == "huy")
                b.huy();
            a.Content = b;
            stk.Children.Add(a);
            stk.Children.Add(c);
        }


        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            reset();
        }
        public void reset()
        {
            stk.Children.Clear();
            loadhuy();
            loadbook();
            load();
   
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            addRoom a = new addRoom();
            a.ShowDialog();
        }
    }

}