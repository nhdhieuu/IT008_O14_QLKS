using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace IT008_O14_QLKS.View.Manager.FormPage.staff
{
    /// <summary>
    /// Interaction logic for staffInfor.xaml
    /// </summary>
    public partial class staffInfor : Window
    {
        DB_connection dB_Connection=new DB_connection();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
        public staffInfor(string id)
        {
            InitializeComponent();
            try
            {
                string sql = $"select * from NHANVIEN where MANV='{id}'";
                adapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                adapter.Fill(dataTable);
                staffID.Text = dataTable.Rows[0]["MANV"].ToString();
                staffName.Text = dataTable.Rows[0]["TENNV"].ToString();
                staffCCCD.Text = dataTable.Rows[0]["CCCD"].ToString();
                staffGender.Text = dataTable.Rows[0]["GIOITINH"].ToString();
                string bd = dataTable.Rows[0]["NGAYSINH"].ToString();
                string dayy = bd.Split(' ')[0];
                staffBirthday.Text = dayy;
                staffPostion.Text = dataTable.Rows[0]["BOPHAN"].ToString();
                staffPhone.Text = dataTable.Rows[0]["SDT"].ToString();
            }
            catch { }
            
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void close_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void close_b_MouseEnter(object sender, MouseEventArgs e)
        {
            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
        }

        private void close_b_MouseLeave(object sender, MouseEventArgs e)
        {
            close_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9E5D9"));

            close_lb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            adjust_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            adjust_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));

        }

        private void adjust_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!adjust_lb.Content.Equals("save"))
            {
                notice_lb.Visibility = Visibility.Hidden;
                staffName.IsEnabled = true;
                staffBirthday.IsEnabled = true;
                staffCCCD.IsEnabled = true;
                staffPhone.IsEnabled = true;
                staffGender.IsEnabled = true;
                staffPostion.IsEnabled = true;
                adjust_lb.Content = "save";
            }
            else
            {
                if (string.IsNullOrEmpty(staffName.Text) || string.IsNullOrEmpty(staffPhone.Text) || string.IsNullOrEmpty(staffGender.Text) ||
                   string.IsNullOrEmpty(staffPostion.Text) || string.IsNullOrWhiteSpace(staffBirthday.Text) || string.IsNullOrEmpty(staffCCCD.Text))
                {
                    notice_lb.Visibility = Visibility.Visible;
                    return;
                }

                // 
                try
                {
                    string sql = $"UPDATE NHANVIEN set TENNV='{staffName.Text}',CCCD='{staffCCCD.Text}',GIOITINH='{staffGender.Text}'," +
                        $"SDT='{staffPhone.Text}',BOPHAN='{staffPostion.Text}',NGAYSINH='{staffBirthday.Text}'  WHERE MANV='{staffID.Text}'";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = dB_Connection.sqlCon;
                    sqlCommand.ExecuteNonQuery();
                    MessageBox.Show("Staff has jusst been adjusted.", "Notice");
                }
                catch {
                    MessageBox.Show("Can not adjust this staff.", "Notice");
                }
                notice_lb.Visibility = Visibility.Hidden;
                staffName.IsEnabled = false;
                staffBirthday.IsEnabled = false;
                staffCCCD.IsEnabled = false;
                staffPhone.IsEnabled = false;
                staffGender.IsEnabled = false;
                staffPostion.IsEnabled = false;
                adjust_lb.Content = "adjust";
            }
        }
    }
}
