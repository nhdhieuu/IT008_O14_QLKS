using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.Connection_db;
using Xceed.Wpf.Toolkit;

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for giahan.xaml
    /// </summary>
    public partial class giahan : Window
    {
        string ID;
        DB_connection connect = new DB_connection();
        public giahan(string iD)
        {
            InitializeComponent();
            ID = iD;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {



            this.Close();



        }
        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            // animation đóng form
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEFEEE5"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF740909"));

        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }


        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
             if(dtpk.Value ==null)
            {

                txt.Text = "please pick a datetime";
                txt.Foreground = new SolidColorBrush(Colors.Red);
                txt.FontSize = 55;
            }
            else
            {

                string a = dtpk.Value.ToString();

                string[] str = a.Split('/');
                string trueday = str[1] + "-" + str[0] + "-" + str[2];
                if (dtpk.Value < DateTime.Now)
                {
                    txt.Text = "please pick a future time";
                    txt.Foreground = new SolidColorBrush(Colors.Red);
                    txt.FontSize = 55;
                }
                else
                {
                    using (SqlConnection connection = new SqlConnection(connect.strCon))
                    {
                        connection.Open();


                        // Chuyển đổi thành chuỗi theo định dạng tháng ngày năm giờ phút giây

                        string sqlQuery = $"UPDATE THUEPHONG SET NGAYKT = '{trueday}' WHERE MATHUEPHONG ='{ID}'";

                        using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                        {

                            command.ExecuteNonQuery();
                        }
                    }

                    this.Close();
                }


            }
        }
           
    }

}
