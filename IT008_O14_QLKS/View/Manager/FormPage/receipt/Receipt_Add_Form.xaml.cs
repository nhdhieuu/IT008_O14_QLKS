using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Threading;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Clients.Card.Card_room;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager.FormPage.receipt
{
    /// <summary>
    /// Interaction logic for Receipt_Add_Form.xaml
    /// </summary>
    public partial class Receipt_Add_Form : Window
    {
        DispatcherTimer t;
        DB_connection connect = new DB_connection();
        string ID;
        string MAKH;
        DateTime myDateTime = DateTime.Now;
        public Receipt_Add_Form()
        {
            InitializeComponent();
          

            t = new DispatcherTimer();

            t.Interval = TimeSpan.FromSeconds(1);
            t.Start();
            t.Tick += HenGio;


        }
        private void HenGio(object sender, EventArgs e)
        {
            DATE.Text = DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss");
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

            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF96958A"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tongthanhtoan = 0;
            for(int i=0;i<tparr.Count;i++)
            {
                tparr.RemoveAt(i);
            }    
            tien.Text = "";
            if (search_txt.Text == "")
            {
                tentxt.Visibility = Visibility.Collapsed;
                x.Visibility = Visibility.Collapsed;
                stk.Visibility = Visibility.Collapsed;


            }
            else
            {
                tentxt.Text = "";
                stk.Visibility = Visibility.Visible;
                stk.Children.Clear();
                MAKH=search_txt.Text;
                
                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = $"select MAKH,TENKH from KHACHHANG where MAKH='{search_txt.Text}' OR TENKH='{search_txt.Text}' ";

                sqlcmd.Connection = connect.sqlCon;
                SqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {

                    ID = reader.GetString(0);
                    tentxt.Text = reader.GetString(1);
                    tentxt.Visibility = Visibility.Visible;
                    x.Visibility = Visibility.Visible;


                }
                reader.Close();
            }
            if (tentxt.Visibility == Visibility.Visible &&tentxt.Text!="")
            {
                save_but.IsEnabled = true;
                x_but.IsEnabled = true;
                load();
            }
            else
            {
                tentxt.Visibility = Visibility.Collapsed;
                x.Visibility = Visibility.Collapsed;
                stk.Children.Clear();
                save_but.IsEnabled = false;
                x_but.IsEnabled = false;


            }    
        }
        public void pay( string ten)
        {
            search_txt.Text = ten;
            tongthanhtoan = 0;
            for (int i = 0; i < tparr.Count; i++)
            {
                tparr.RemoveAt(i);
            }
            tien.Text = "";
            if (search_txt.Text == "")
            {
                tentxt.Visibility = Visibility.Collapsed;
                x.Visibility = Visibility.Collapsed;
                stk.Visibility = Visibility.Collapsed;


            }
            else
            {
                tentxt.Text = "";
                stk.Visibility = Visibility.Visible;
                stk.Children.Clear();
                MAKH = search_txt.Text;

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandText = $"select MAKH,TENKH from KHACHHANG where MAKH='{search_txt.Text}' OR TENKH='{search_txt.Text}' ";

                sqlcmd.Connection = connect.sqlCon;
                SqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {

                    ID = reader.GetString(0);
                    tentxt.Text = reader.GetString(1);
                    tentxt.Visibility = Visibility.Visible;
                    x.Visibility = Visibility.Visible;


                }
                reader.Close();
            }
            if (tentxt.Visibility == Visibility.Visible && tentxt.Text != "")
            {
                save_but.IsEnabled = true;
                x_but.IsEnabled = true;
                load();
            }
            else
            {
                tentxt.Visibility = Visibility.Collapsed;
                x.Visibility = Visibility.Collapsed;
                stk.Children.Clear();
                save_but.IsEnabled = false;
                x_but.IsEnabled = false;


            }
        }
        public void load()
        {
            tongthanhtoan = 0;
            for (int i = 0; i < tparr.Count; i++)
            {
                tparr.RemoveAt(i);
            }
            tien.Text = "";
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];

            stk.Children.Clear();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' AND '{trueday}' > NGAYBD AND '{trueday}' <NGAYKT AND KQUATHUE='Thanh Cong'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {


                add(reader.GetString(0));


            }
            reader.Close();
            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' and '{trueday}' > NGAYKT AND KQUATHUE='Thanh Cong'";
            using (SqlDataReader reader1 = sqlcmd.ExecuteReader())
            {

                while (reader1.Read())
                {


                    add(reader1.GetString(0));


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
            Room_card_client b = new Room_card_client(ID, "hoadon");
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



        private void x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            tentxt.Visibility = Visibility.Collapsed;
            x.Visibility = Visibility.Collapsed;
            stk.Children.Clear();
            save_but.IsEnabled = false;
            x_but.IsEnabled = false;
            tongthanhtoan = 0;
            tien.Text = "";
            for (int i = 0; i < tparr.Count; i++)
            {
                tparr.RemoveAt(i);
            }


        }
        decimal tongthanhtoan = 0;
        List<string> tparr =new List<string>();
        public void tinhtien(decimal tongtienphong,string tp)
        {
            int truee = 1;
            for(int i=0;i<tparr.Count;i++)
            {
                if (tp == tparr[i])
                    truee = 0;
            }  
            if(truee == 1)
            {
                tparr.Add(tp);
            }    
           
            tongthanhtoan += tongtienphong;
            sua();
        }
        public void trutien(decimal tongtienphong,string tp)
        {
          
            int truee = 1;
            for (int i = 0; i < tparr.Count; i++)
            {
                if (tp == tparr[i])
                    tparr.RemoveAt(i);     
            }
          

            tongthanhtoan -= tongtienphong;
            sua();
        }
        private void sua()
        {

            int moneyAsInt = Convert.ToInt32(tongthanhtoan);

            if (moneyAsInt > 0)
                tien.Text = moneyAsInt.ToString("#,###") + " VND";
            else
            {
                tien.Text = "0 VND";

            }
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        string hdcaonhat;
        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
           
        }
        string hdtieptheo;
        private void save_but_MouseDown(object sender, MouseButtonEventArgs e)
        {
      
            if (tongthanhtoan==0)
            {
                MessageBox.Show("Please pick a room");
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand();

                sqlcmd.CommandType = CommandType.Text;

                sqlcmd.CommandText = $"SELECT TOP 1 SOHD FROM HOADON ORDER BY SOHD DESC";
                sqlcmd.Connection = connect.sqlCon;
                SqlDataReader reader = sqlcmd.ExecuteReader();

                while (reader.Read())
                {

                    hdcaonhat = reader.GetString(0);
                   hdtieptheo =GenerateNextString(hdcaonhat);
                  

                }
                reader.Close();
                luuhoadon();
            
                load();
                for (int i = 0; i < tparr.Count; i++)
                {
                    tparr.RemoveAt(i);
                }

            }
            
        }
        private void luuhoadon()
        {

           

                SqlCommand sqlcmd = new SqlCommand();

                 sqlcmd.CommandType = CommandType.Text;

               sqlcmd.CommandText = $"insert into HOADON(SOHD,NGAYLAP,TONGTIEN,MAKH) values ('{hdtieptheo}','{myDateTime.ToString("MM-dd-yyyy HH:mm:ss")}',{Convert.ToInt32(tongthanhtoan)},'{MAKH.ToUpper()}');";
               sqlcmd.Connection = connect.sqlCon;

                 sqlcmd.ExecuteNonQuery();
               taocthd();



            }
        private void taocthd()
        {
           for(int i=0;i<tparr.Count;i++)
            {
                SqlCommand sqlcmd = new SqlCommand();

                sqlcmd.CommandType = CommandType.Text;

            

                sqlcmd.CommandText = $"insert into CTHD(SOHD,MAPHONG) values ('{hdtieptheo}','{tparr[i]}');";
                sqlcmd.Connection = connect.sqlCon;
                sqlcmd.Connection = connect.sqlCon;

                sqlcmd.ExecuteNonQuery();
            }    
        }
            static string GenerateNextString(string inputStr)
        {
            // Kiểm tra xem chuỗi có đúng định dạng không
            if (!inputStr.StartsWith("HD"))
            {
                throw new ArgumentException("Invalid input format");
            }

            // Lấy phần số trong chuỗi
            string numberStr = inputStr.Substring(2);

            // Chuyển số thành một số nguyên
            int number = int.Parse(numberStr);

            // Tăng giá trị số lên 1
            int nextNumber = number + 1;

            // Tạo chuỗi tiếp theo
            string nextStr = "HD" + nextNumber.ToString("D3");

            return nextStr;
        }
    }
    

}
