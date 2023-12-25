using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.View.Manager.FormPage.notice;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for notice.xaml
    /// </summary>
    public partial class notice : UserControl
    {
        string noticecaonhat;
        string noticetieptheo = "N001";
        public List<NoticeCard> noticeCards;
        DB_connection connect = new DB_connection();
        public notice()
        {
            InitializeComponent();

            noticeCards = new List<NoticeCard>();

            load();
        }
        private void load()
        {

        }

        private void send_but_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT TOP 1 MANOTICE FROM NOTICE ORDER BY MANOTICE DESC";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {

                noticecaonhat = reader.GetString(0);
                noticetieptheo = GenerateNextString(noticecaonhat);


            }

            MessageBox.Show(dpk1.SelectedDate.ToString());
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                // Mở kết nối
                connection.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO notice (MANOTICE, header, noidung, ngaybd, ngaykt) VALUES (@MANOTICE, @header, @noidung, @ngaybd, @ngaykt)", connection))
                {

                    string[] str = dpk1.SelectedDate.ToString().Split('/');
                    string ngaybd = str[1] + "-" + str[0] + "-" + str[2];
                    string[] str2 = dpk1.SelectedDate.ToString().Split('/');
                    string ngaykt = str2[1] + "-" + str2[0] + "-" + str2[2];

                    cmd.Parameters.AddWithValue("@MANOTICE", noticetieptheo);
                    cmd.Parameters.AddWithValue("@header", header_box.Text);
                    cmd.Parameters.AddWithValue("@noidung", noidung_box.Text);
                    cmd.Parameters.AddWithValue("@ngaybd", ngaybd); // Giả sử bạn muốn sử dụng thời gian hiện tại
                    cmd.Parameters.AddWithValue("@ngaykt", ngaykt); // Giả sử bạn muốn sử dụng thời gian hiện tại cộng thêm 7 ngày

                    // Thực thi câu lệnh INSERT
                    cmd.ExecuteNonQuery();
                }
                // Tạo một đối tượng SqlCommand với câu lệnh INSERT

            }
        }
        static string GenerateNextString(string inputStr)
        {
            // Kiểm tra xem chuỗi có đúng định dạng không
            if (!inputStr.StartsWith("N"))
            {
                inputStr = "N000";
            }

            // Lấy phần số trong chuỗi
            string numberStr = inputStr.Substring(1);

            // Chuyển số thành một số nguyên
            int number = int.Parse(numberStr);

            // Tăng giá trị số lên 1
            int nextNumber = number + 1;

            // Tạo chuỗi tiếp theo
            string nextStr = "N" + nextNumber.ToString("D3");

            return nextStr;
        }
        private void ShowPopup_Click(object sender, RoutedEventArgs e)
        {
            addnotice a = new addnotice(addstk);
            a.ShowDialog();
        }
        private void ClosePopup_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void myPopup_MouseLeave(object sender, MouseEventArgs e)
        {
            // Đóng Popup khi bạn nhấn vào một vùng trống
           
        }
    }
}
    

