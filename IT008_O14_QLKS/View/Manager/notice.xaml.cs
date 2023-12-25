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
using System.Diagnostics;
using IT008_O14_QLKS.View.Clients.FormPage;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;
using IT008_O14_QLKS.View.Clients.Card.Card_room;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for notice.xaml
    /// </summary>
    public partial class notice : UserControl
    {
        DateTime myDateTime = DateTime.Now;
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
       public void load()
        {
            stk.Children.Clear();

            SqlCommand sqlcmd = new SqlCommand();
         
            sqlcmd.CommandText = $"SELECT * FROM notice";
            sqlcmd.Connection = connect.sqlCon;


            using (SqlDataReader reader1 = sqlcmd.ExecuteReader())
            {

                while (reader1.Read())
                {
                    add(reader1.GetString(0), reader1.GetString(1), reader1.GetString(2), reader1.GetDateTime(3).ToString(), reader1.GetDateTime(4).ToString());

                }
                
            }
          
        }
        private void add(string mant, string header, string noidung, string ngaybd, string ngaykt)
        {
          

            ContentControl a = new ContentControl
            {

                Width = 380,
                Height =450
            };
            Border c = new Border
            {
                Height = 20
            };
            NoticeCard_2 b = new NoticeCard_2(mant,header,noidung,ngaybd,ngaykt,this);
           a.Content = b;
          
           
           
                stk.Children.Add(a);
                stk.Children.Add(c);
           
        }    
        private void Delete_OnClick(object sender, RoutedEventArgs e)
        {
            TextBlock clickedItem = FindClickedItem(sender);
           
            addstk.Children.Remove(clickedItem);



        }
        private static TextBlock FindClickedItem(object sender)
        {
            var mi = sender as MenuItem;
            if (mi == null)
            {
                return null;
            }

            var cm = mi.CommandParameter as ContextMenu;
            if (cm == null)
            {
                return null;
            }

            return cm.PlacementTarget as TextBlock;
        }

    
    private void send_but_Click(object sender, RoutedEventArgs e)
        {
            
            if(dpk1.Value==null||dpk2.Value==null||header_box.Text==""||noidung_box.Text=="")
            {
                MessageBox.Show("Please fill all information");
            }
            else
            {
                if(dpk2.Value<dpk1.Value)
                {
                    MessageBox.Show("Invalid time");
                }
                else
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
                    reader.Close();


                    using (SqlConnection connection = new SqlConnection(connect.strCon))
                    {
                        // Mở kết nối
                        connection.Open();

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO notice (MANOTICE, header, noidung, ngaybd, ngaykt) VALUES (@MANOTICE, @header, @noidung, @ngaybd, @ngaykt)", connection))
                        {

                            string[] str = dpk1.Value.ToString().Split('/');
                            string ngaybd = str[1] + "-" + str[0] + "-" + str[2];
                            string[] str2 = dpk2.Value.ToString().Split('/');
                            string ngaykt = str2[1] + "-" + str2[0] + "-" + str2[2];

                            cmd.Parameters.AddWithValue("@MANOTICE", noticetieptheo);
                            cmd.Parameters.AddWithValue("@header", header_box.Text);
                            cmd.Parameters.AddWithValue("@noidung", noidung_box.Text);
                            cmd.Parameters.AddWithValue("@ngaybd", ngaybd);
                            cmd.Parameters.AddWithValue("@ngaykt", ngaykt);

                            // Thực thi câu lệnh INSERT
                            cmd.ExecuteNonQuery();
                        }



                    }






                }
                foreach (UIElement element in addstk.Children)
                {
                    if (element is TextBlock)
                    {
                        TextBlock textBlock = (TextBlock)element;
                        themCTNT(textBlock.Text, noticetieptheo);
                    }
                }
                MessageBox.Show("Add notice sucessfully!");
            }
            load();
        
        }
        private void themCTNT(string txt, string mant)
        {
            string maKH = "khong";
            string classs = "khong";
            string rtype = "khong";
            int floor = 0;
            string[] chuoi = txt.Split(' ');
            try
            {

                if (chuoi[5] == "class")
                {
                    classs = chuoi[4];
                  
                }
            }
            catch(Exception ex)
            {

            }
         
            try
            {

                if (chuoi[6] == "room")
                {
                    rtype = chuoi[4];
                   
                }
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (chuoi[3] == "floor")
                {
                    floor = Int32.Parse(chuoi[4]);
                   
                }
            }
            catch (Exception ex)
            {

            }

            try
            {
                if (chuoi[2] == "id:")
                {
                    maKH = chuoi[3];
                   
                }
            }
            catch(Exception ex)
            {

            }
           
           

            if (txt == "all client")
            { maKH = "all";
              
            }
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                // Mở kết nối
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("INSERT INTO CTNT (MANOTICE, TANG, LOAIPHONG, ClassID, MAKH) VALUES (@MANOTICE, @tang, @loaiphong, @class, @MaKH)", connection))
                {

                    

                    cmd.Parameters.AddWithValue("@MANOTICE", noticetieptheo);
                    cmd.Parameters.AddWithValue("@tang", floor);
                    cmd.Parameters.AddWithValue("@loaiphong",rtype);
                    cmd.Parameters.AddWithValue("@class",classs); // Giả sử bạn muốn sử dụng thời gian hiện tại
                    cmd.Parameters.AddWithValue("@MAKH", maKH); // Giả sử bạn muốn sử dụng thời gian hiện tại cộng thêm 7 ngày

                    // Thực thi câu lệnh INSERT
                    cmd.ExecuteNonQuery();
                }

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
            string enter = a.txt;
            TextBlock txt = new TextBlock
            {
                ContextMenu = (ContextMenu)Resources["contextMenu"],
                Text =enter,
                FontSize = 15
            };
       

            addstk.Children.Add(txt);
          
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
    

