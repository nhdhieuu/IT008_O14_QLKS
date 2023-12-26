using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for NoticeCard_2.xaml



    public partial class NoticeCard_2 : UserControl
    {
        DB_connection connect = new DB_connection();
        notice nt;
        string mant;
        string header;
        string noidung;
        string ngaybd;
        string ngaykt;
        public NoticeCard_2(string mant, string header, string noidung, string ngaybd, string ngaykt, notice nt)
        {
            InitializeComponent();
            this.mant = mant;
            this.nt = nt;
            this.header = header;
            this.noidung = noidung;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
            load();
        }
        private void load()
        {
            hdtxt.Content = header;
            ndtxt.Text = noidung;
            start.Content = ngaybd;
            end.Content = ngaykt;
            scr.ScrollToVerticalOffset(scr.ScrollableHeight);
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandText = $"SELECT * FROM CTNT where MANOTICE='{mant}'";
            sqlcmd.Connection = connect.sqlCon;


            using (SqlDataReader reader1 = sqlcmd.ExecuteReader())
            {

                while (reader1.Read())
                {

                    if (reader1.GetString(5).ToUpper() != "KHONG")
                    {
                        if (reader1.GetString(5) == "all")
                        {
                            totxt.Text += "all client\n";
                        }
                        else
                        {
                            totxt.Text += "client has id: " + reader1.GetString(5) + "\n";
                        }

                    }


                    if (reader1.GetInt32(1) != 0)
                    {

                        totxt.Text += "all client in floor " + reader1.GetInt32(1).ToString() + "\n";



                    }
                    if (reader1.GetString(2).ToUpper() != "KHONG")
                    {

                        totxt.Text += "all client have " + reader1.GetString(2) + " room " + "\n";



                    }
                    if (reader1.GetString(3).ToUpper() != "KHONG")
                    {

                        totxt.Text += "all client have " + reader1.GetString(3) + " class" + "\n";



                    }





                }

            }
       
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            string deleteCommand = $"DELETE FROM CTNT WHERE MANOTICE='{mant}'";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand để thực hiện lệnh DELETE
                using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                {

                    // Thực hiện lệnh DELETE
                    command.ExecuteNonQuery();


                }

            }
          deleteCommand = $"DELETE FROM notice WHERE MANOTICE='{mant}'";

            // Kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand để thực hiện lệnh DELETE
                using (SqlCommand command = new SqlCommand(deleteCommand, connection))
                {

                    // Thực hiện lệnh DELETE
                    command.ExecuteNonQuery();


                }

            }
            nt.load();
        }
    }
}

