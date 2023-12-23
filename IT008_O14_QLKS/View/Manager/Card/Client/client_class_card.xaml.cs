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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlTypes;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.FormPage.client;

namespace IT008_O14_QLKS.View.Manager.Card.Client
{
    /// <summary>
    /// Interaction logic for client_class_card.xaml
    /// </summary>
    public partial class client_class_card : UserControl
    {
        public string ID;
        DB_connection connect = new DB_connection();
        public client_class_card(string ID)
        {
            InitializeComponent();
            this.ID = ID;
            load();
            

        }
        public void Xoa()
        {
            len.Visibility=Visibility.Collapsed;
            xuong.Visibility=Visibility.Collapsed;
        }
        private void load()
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            
            sqlcmd.CommandText = $"select * from KHACHHANG where MAKH='{ID}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                txt.Text = reader.GetString(9);
                background(reader.GetString(9));
            }
            reader.Close();
        }
        private void background(string bg)
        {
            if(bg=="Diamond")
            {
                txt.Foreground = new SolidColorBrush(Colors.White);
                clss.Foreground = new SolidColorBrush(Colors.White);


            }  
            else
            {
                txt.Foreground = new SolidColorBrush(Colors.Black);
                clss.Foreground = new SolidColorBrush(Colors.Black);

            }
            string truepath = "";
            string currentFolderPath = AppDomain.CurrentDomain.BaseDirectory.ToString();

            string[] parts = currentFolderPath.Split('\\');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] != "Debug" && parts[i] != "bin")
                    truepath += parts[i] + "/";
            }
            string imagePath = System.IO.Path.Combine(truepath, "Resources", bg + ".jpg");

            // Tạo một đối tượng BitmapImage
            BitmapImage bitmap = new BitmapImage();

            // Thiết lập đường dẫn nguồn cho BitmapImage
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            // Tạo một ImageBrush và thiết lập hình ảnh làm nền
            ImageBrush imageBrush = new ImageBrush(bitmap);

            // Thiết lập nền của phần tử (vd: Grid, Border, etc.)
            imageBrush.Stretch = Stretch.Fill;
            back.Background = imageBrush;

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            string updateQuery = $"UPDATE KHACHHANG SET CLASS = " +
                                     $"CASE " +
                                     $"    WHEN CLASS = 'Diamond' THEN 'Platinum' " +
                                     $"    WHEN CLASS = 'Platinum' THEN 'Gold' " +
                                     $"    WHEN CLASS = 'Gold' THEN 'Silver' " +
                                     $"    ELSE CLASS " +
                                     $"END " +
                                     $"WHERE MAKH = '{ID}'";
            using (SqlCommand command = new SqlCommand(updateQuery, connect.sqlCon))
            {
                command.ExecuteNonQuery();
            }

            update();
            load();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            string updateQuery = $"UPDATE KHACHHANG SET CLASS = " +
                                     $"CASE " +
                                     $"    WHEN CLASS = 'Silver' THEN 'Gold' " +
                                     $"    WHEN CLASS = 'Gold' THEN 'Platinum' " +
                                     $"    WHEN CLASS = 'Platinum' THEN 'Diamond' " +
                                     $"    ELSE CLASS " +
                                     $"END " +
                                     $"WHERE MAKH = '{ID}'";
            using (SqlCommand command = new SqlCommand(updateQuery, connect.sqlCon))
            {
                command.ExecuteNonQuery();
            }

            update();
            load();
        }
        private void update()
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            string updateQuery = @"
            UPDATE KHACHHANG
            SET CLASSID =
                CASE
                    WHEN CLASS = 'Silver' THEN 1
                    WHEN CLASS = 'Gold' THEN 2
                    WHEN CLASS = 'Platinum' THEN 3
                    WHEN CLASS = 'Diamond' THEN 4
                    ELSE CLASSID
                END
            WHERE MAKH = @CustomerId";
            using (SqlCommand command = new SqlCommand(updateQuery, connect.sqlCon))
            {   
                command.Parameters.AddWithValue("@CustomerId", ID);
                command.ExecuteNonQuery();
            }
           
        }
    }
}
