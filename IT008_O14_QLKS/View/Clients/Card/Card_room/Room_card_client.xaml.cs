using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage.client;
using System.Data.SqlTypes;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.FormPage.receipt;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;
using IT008_O14_QLKS.View.Manager;
using IT008_O14_QLKS.View.Manager.FormPage.room.booking_list;
using IT008_O14_QLKS.View.Clients.FormPage;
using IT008_O14_QLKS.View.Manager.FormPage.room;
using System.Xaml.Schema;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;
using MessageBox = System.Windows.Forms.MessageBox;

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for Room_card_client.xaml
    /// </summary>
    public partial class Room_card_client : UserControl
    {
        TimeSpan giotinhtien;
        DateTime ngaybd;
        string ID;
        DateTime myDateTime = DateTime.Now;
        int paid = 0;
        decimal tongtien = 0;
        private string thuoctinh;
        int sservice = 0;
        public decimal tongtienphong;
        string khachhang;

        string type;
        Connectiondatabase connect =new Connectiondatabase();

        public Room_card_client(string ID)
        {
            this.ID = ID;
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
       
        
            bd.CornerRadius = new CornerRadius(10, 10, 10, 10);
          

            load();
            loadservice();
            loadpr();
            if (sservice > 1)
                soservice.Text = sservice.ToString() + " SERVICES";
            else
                soservice.Text = sservice.ToString() + " SERVICE";
            if(problem>1)
            {
                soservice.Text+= " + " + problem.ToString() + " PROBLEMS";
            }  
            else
                soservice.Text += " + " + problem.ToString() + " PROBLEM";

            int moneyAsInt = Convert.ToInt32(tongtien);

            if(moneyAsInt > 0)
            money_txt.Text = moneyAsInt.ToString("#,###") + " VND";
            else
            {
                money_txt.Text = "0 VND";

            }
            tinhtienphong();
            tinhgio();

      

        }
        public Room_card_client(string ID,string type)
        {
            this.ID = ID;
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
          

            bd.CornerRadius = new CornerRadius(10, 10, 10, 10);


            load();
            loadservice();
            loadpr();
            
            if (sservice>1)
            soservice.Text = sservice.ToString() + " SERVICES";
            else 
                soservice.Text = sservice.ToString() + " SERVICE";
            if (problem > 1)
            {
                soservice.Text += " + " + problem.ToString() + " PROBLEMS";
            }
            else
                soservice.Text += " + " + problem.ToString() + " PROBLEM";

            int moneyAsInt = Convert.ToInt32(tongtien);

            if (moneyAsInt > 0)
                money_txt.Text = moneyAsInt.ToString("#,###") + " VND";
            else
            {
                money_txt.Text = "0 VND";

            }
            if(type=="hoadon")
            {
                CK.Visibility = Visibility.Visible;
                rbutton.Visibility=Visibility.Collapsed;   
            }
            if(type=="client")
            {
                if (typetxt.Text!="PAID"&& typetxt.Text != "NOT PAID" && ftxt.Text!="cancel"&&ftxt.Text != "reserving...")
                {

                }    
                    else {
                            rbutton.Visibility = Visibility.Collapsed;
                        }
            }    

            tinhtienphong();
            tinhgio();


        }
        TimeSpan giothue;
        public void reset()
        {
            tienphong = 0;
            tongtienphong = 0;
            tongtien = 0;
            load();
            loadservice();
            loadpr();
            if (sservice > 1)
                soservice.Text = sservice.ToString() + " SERVICES";
            else
                soservice.Text = sservice.ToString() + " SERVICE";
            if (problem > 1)
            {
                soservice.Text += " + " + problem.ToString() + " PROBLEMS";
            }
            else
                soservice.Text += " + " + problem.ToString() + " PROBLEM";

            int moneyAsInt = Convert.ToInt32(tongtien);

            if (moneyAsInt > 0)
                money_txt.Text = moneyAsInt.ToString("#,###") + " VND";
            else
            {
                money_txt.Text = "0 VND";

            }
            tinhtienphong();
         
        }
        private void load()
        {

            string query = $"SELECT COUNT(*) FROM CTHD WHERE MAPHONG = '{ID}'";

            // Mở kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                connection.Open();

                // Tạo đối tượng SqlCommand với chuỗi truy vấn và kết nối
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thực hiện truy vấn và nhận kết quả COUNT
                    int count = (int)command.ExecuteScalar();
                    paid = count;

                }
            }
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MATHUEPHONG='{ID}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            using (reader)
            {
                if (reader.Read()) // Kiểm tra xem có dữ liệu hay không
                {
                    khachhang = reader.GetString(1);
                    ngaybd = reader.GetDateTime(3);
                    if (ngaybd > DateTime.Now)
                    {
                        add.Visibility = Visibility.Collapsed;
                    }
                    TimeSpan timeDifference = reader.GetDateTime(4) - myDateTime;

                  


                    giothue = reader.GetDateTime(4) - reader.GetDateTime(3);
                    TimeSpan giodung = timeDifference;
                    giotinhtien= reader.GetDateTime(4) - reader.GetDateTime(3);
                    if (giothue<timeDifference)
                    {
                        giodung = giothue;
                    }    
                    if (giodung.Days < 0)
                    {
                        if (paid == 0)
                        {
                            if (type != "book" && type != "huy")
                            {
                                typetxt.Text = "NOT PAID";
                                typetxt.Foreground = new SolidColorBrush(Colors.Red);
                                bd_time.BorderBrush = new SolidColorBrush(Colors.Red);
                                nbtxtleft.Visibility = Visibility.Collapsed;
                                view.Text = "PAY";
                                rbutton.Visibility = Visibility.Collapsed;
                                CANCEL.Visibility = Visibility.Collapsed;
                                add.Visibility = Visibility.Collapsed;
                            }


                        }
                        else
                        {
                            if (type != "book" && type != "huy")
                            {
                                typetxt.Text = "PAID";
                                typetxt.Foreground = new SolidColorBrush(Colors.Green);
                                bd_time.BorderBrush = new SolidColorBrush(Colors.Green);
                                nbtxtleft.Visibility = Visibility.Collapsed;
                                view.Text = "VIEW";
                                CANCEL.Visibility = Visibility.Collapsed;
                                add.Visibility = Visibility.Collapsed;
                                thuoctinh = "paid";
                            }
                        }

                    }
                    else
                    {
                        if (giodung.Days > 0)
                        {


                            typetxt.Text = "days left";
                            nbtxtleft.Text = giodung.Days.ToString();
                      




                        }
                        if (giodung.Days <= 0)
                        {
                            if (giodung.Hours <= 0)

                            {
                                if (paid == 0)
                                {

                                    if (type != "book" && type != "huy")
                                    {
                                        typetxt.Text = "NOT PAID";
                                        typetxt.Foreground = new SolidColorBrush(Colors.Red);
                                        bd_time.BorderBrush = new SolidColorBrush(Colors.Red);
                                        nbtxtleft.Visibility = Visibility.Collapsed;
                                        view.Text = "PAY";
                                        rbutton.Visibility = Visibility.Collapsed;
                                        CANCEL.Visibility = Visibility.Collapsed;
                                        add.Visibility = Visibility.Collapsed;
                                    }
                                }
                                else
                                {


                                    if (type != "book" && type != "huy")
                                    {

                                        typetxt.Text = "PAID";
                                        typetxt.Foreground = new SolidColorBrush(Colors.Green);
                                        bd_time.BorderBrush = new SolidColorBrush(Colors.Green);
                                        nbtxtleft.Visibility = Visibility.Collapsed;
                                        view.Text = "VIEW";
                                        CANCEL.Visibility = Visibility.Collapsed;
                                        add.Visibility = Visibility.Collapsed;
                                        thuoctinh = "paid";
                                    }
                                }

                            }
                            else
                            {

                                nbtxtleft.Text = giodung.Hours.ToString();
                              

                               

                            }

                        }

                    }



                    ftxt.Text = reader.GetString(2).Substring(1).ToUpper();
                    fromdate.Text = reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss");
                    todate.Text = reader.GetDateTime(4).ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            reader.Close();
            if (type == "huy")
                huy();
            if (type == "book")
                book();
            //load rom

            sqlcmd.CommandText = $"select * from PHONG where TENPHONG ='{ftxt.Text}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader2 = sqlcmd.ExecuteReader();

            using (reader2)
            {
                if (reader2.Read()) // Kiểm tra xem có dữ liệu hay không
                {
                    roomcard2 rc = new roomcard2(reader2.GetString(1), reader2.GetString(2), reader2.GetInt32(11), "khong");
                    card.Content=rc;    
                }
            }
        }
        decimal tienphong = 0;
        private decimal tinhtienphong()
        {

           
            tongtienphong += tongtien;
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM PHONG WHERE TENPHONG = '{ftxt.Text}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
         
            while (reader.Read())
            {
                tienphong = 0;
               
                if (giotinhtien.Days > 0)
                {

                    tienphong += giotinhtien.Days * (decimal)reader.GetSqlMoney(10);


                }    
                   
                else {
                    if (giotinhtien.Hours > 0)
                        tienphong += (decimal)reader.GetSqlMoney(9) * giotinhtien.Hours;
                   else
                    {
                        tienphong += (decimal)reader.GetSqlMoney(9);
                    }
                }
                


            }
            reader.Close();
  tong.Text = Convert.ToInt32(tienphong).ToString("#,###") + "(room) + " + Convert.ToInt32(tongtien).ToString("#,###") + "(service) = ";
            tongtienphong += tienphong;
         
            int moneyAsInt = Convert.ToInt32(tongtienphong);

            if (moneyAsInt > 0)
                tong.Text += moneyAsInt.ToString("#,###") + " VND";
            else
            {
                tong.Text += "0 VND";

            }
            return tongtienphong;
        }
        public string loai()
        {
            return thuoctinh;

        }
        private bool isRotated = true;
        private void OnBorderMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void myBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation rotateAnimation = new DoubleAnimation();

            if (isRotated)
            {
              
                rotateAnimation.To = 180;
                xoa.Visibility = Visibility.Visible;

              
                bd.CornerRadius = new CornerRadius(10, 10, 0, 0);
              
               
               

            }
            else
            {
                  rotateAnimation.To = 0;
                xoa.Visibility = Visibility.Collapsed;
                bd.CornerRadius = new CornerRadius(10, 10, 10, 10);
            


            }

            rotateAnimation.Duration = TimeSpan.FromSeconds(0.3);

            myBorder.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            RotateTransform rotateTransform = new RotateTransform();
            myBorder.RenderTransform = rotateTransform;

            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

            isRotated = !isRotated;
        
        }
        private void loadservice()
        {
            sservice = 0;
            service1.Children.Clear();
          SqlCommand sqlcmd = new SqlCommand();
         
            
            SqlCommand sqlcmd2 = new SqlCommand();
           sqlcmd2.CommandText = $"select * from CHITIETDV where MATHUEPHONG ='{ID}'";



            sqlcmd2.Connection = connect.sqlCon;
            SqlDataReader reader2 = sqlcmd2.ExecuteReader();
            while (reader2.Read())
            {
                them2(reader2.GetString(1),reader2.GetInt32(2).ToString(),reader2.GetDateTime(4));
                sservice += 1;
               
              
            }
            reader2.Close();




        }
        int problem = 0;
        private void loadpr()
        {
            problem = 0;

            SqlCommand sqlcmd = new SqlCommand();


            SqlCommand sqlcmd2 = new SqlCommand();
            sqlcmd2.CommandText = $"select * from CHITIETPR where MATHUEPHONG ='{ID}'";



            sqlcmd2.Connection = connect.sqlCon;
            SqlDataReader reader2 = sqlcmd2.ExecuteReader();
            while (reader2.Read())
            {
                problem += 1;
                addpr( reader2.GetString(1), reader2.GetDateTime(4));

            }
            reader2.Close();




        }
        private void addpr(string madv, DateTime time)
        {
            ContentControl a = new ContentControl
            {
                Height = 51,
                Width = 580
            };
            problemcard b = new problemcard( madv, time);
            tongtien += b.tinhtien();
            a.Content = b.Content;


            service1.Children.Add(a);
        }
        private void them2(string madv, string soluong,DateTime time)
    {
    
            ContentControl a = new ContentControl
            {
                Height = 51,
                Width = 580
            };
            service_card b = new service_card( 0, madv,soluong,time);
            tongtien += b.tinhtien()*  int.Parse(soluong);
            a.Content = b.Content;


            service1.Children.Add(a);

      


    }

        private void them(string madv, string soluong)
        {
            
           


        

         


        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(type=="book2")
            {
                using (SqlConnection connection = new SqlConnection(connect.strCon))
                {
                    connection.Open();







                    string sqlQuery = $"UPDATE THUEPHONG SET KQUATHUE = 'Thanh Cong' WHERE MATHUEPHONG ='{ID}'";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Accept Successfully!");
                    DependencyObject parent = VisualTreeHelper.GetParent(this);
                    while (!(parent is Window))
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                    }

                    if (parent is booking_list window)
                    {
                     
                    }
                }
              
            }    
            if (type != "book" && type != "huy" &&type !="book2")
            {
                if (typetxt.Text != "PAID" && typetxt.Text != "NOT PAID")
                {
                    giahan a = new giahan(ID,ngaybd);
                    a.ShowDialog();
                    load();
                }
                if (view.Text == "PAY")
                {
               


                }
            }
            this.reset();
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CANCEL_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
            if (type == "book2")
            {
                using (SqlConnection connection = new SqlConnection(connect.strCon))
                {
                    connection.Open();







                   string sqlQuery = $"UPDATE THUEPHONG SET KQUATHUE = 'That Bai' WHERE MATHUEPHONG ='{ID}'";

                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cancel Successfully!");
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                while (!(parent is Window))
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is booking_list window)
                {
                    window.reset();
                }
            }
            else
            {
                if (type == "book")
                {
                    cancel a = new cancel(ID, "book",ngaybd);
                    a.ShowDialog();
                    load();

                    DependencyObject parent = VisualTreeHelper.GetParent(this);
                    while (!(parent is UserControl))
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                    }

                    if (parent is ClientsRoom window)
                    {
                        window.reset();
                    }

                }
                else
                {
                    cancel a = new cancel(ID,ngaybd);
                    a.ShowDialog();
                    load();
                    DependencyObject parent = VisualTreeHelper.GetParent(this);
                    while (!(parent is UserControl))
                    {
                        parent = VisualTreeHelper.GetParent(parent);
                    }

                    if (parent is room_client window)
                    {
                        window.reset();
                    }

                }
            }
           

           
        }
       public int chk = 0;

        public object Messagebox { get; private set; }

        private void CK_MouseDown(object sender, MouseButtonEventArgs e)
        {
           
          if(chk==0)
            {
                ck_type.Visibility = Visibility.Visible;
                chk = 1;
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                while (!(parent is Window) && parent != null)
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is Receipt_Add_Form window)
                {
                    window.tinhtien(tongtienphong,ID);
                }


            }
            else
            {
                ck_type.Visibility = Visibility.Hidden;
                chk = 0;
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                while (!(parent is Window) && parent != null)
                {
                    parent = VisualTreeHelper.GetParent(parent);
                }

                if (parent is Receipt_Add_Form window)
                {
                    window.trutien(tongtienphong,ID);
                }
            }
        }

        private void view_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        public void book()
        {
            type = "book";
            main.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3E70F0"));
            main.CornerRadius = new CornerRadius(10);
            rbutton.Visibility = Visibility.Collapsed;
            sv_grid.Visibility = Visibility.Collapsed;
            bd.Visibility = Visibility.Collapsed;
            add.Visibility = Visibility.Collapsed;
            bdtien1.Visibility=Visibility.Collapsed;
            tong.Visibility=Visibility.Collapsed;
            Bdcuoi.Visibility=Visibility.Collapsed;
            int moneyAsInt = Convert.ToInt32(tienphong);

            if (moneyAsInt > 0)
                ftxt_Copy.Text = "ROOM PRICE = "+ moneyAsInt.ToString("#,###") + " VND";
            else
            {
                ftxt_Copy.Text = "ROOM PRICE = " + "0 VND";

            }
            ftxt.Text = "reserving...";
            ftxt.Foreground = new SolidColorBrush(Colors.White);
            fromdate_Copy.Foreground = new SolidColorBrush(Colors.White);
            fromdate_Copy1.Foreground = new SolidColorBrush(Colors.White);
            typetxt.Foreground = new SolidColorBrush(Colors.White);
            bd_time.BorderBrush= new SolidColorBrush(Colors.White);
            ftxt_Copy.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD24B"));
            fromdate.Foreground = new SolidColorBrush(Colors.White);
            todate.Foreground = new SolidColorBrush(Colors.White);
            nbtxtleft.Foreground = new SolidColorBrush(Colors.White);
            if (giothue.Days > 0)
            {
                if (giothue.Days > 1)
                    typetxt.Text = "days";
                else
                {
                    typetxt.Text = "day";
                }
                nbtxtleft.Text = giothue.Days.ToString();
                
            }
            else
            {
                if (giothue.Hours > 1)
                    typetxt.Text = "hours";
                else
                {
                    typetxt.Text = "hour";
                }
                nbtxtleft.Text = giothue.Hours.ToString();
                
            }

        }
        public void book2()
        {
            type = "book2";
          if(ftxt.Text!="cancel")
                rbutton.Visibility = Visibility.Visible;
            
            view.Text = "ACCEPT";
           
            ftxt.Text = $"reserving by {khachhang}";
          

        }
        public void huy()
        {
            x.Visibility = Visibility.Visible;
            type = "huy";
            rbutton.Visibility = Visibility.Collapsed;
            main.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BF0B0B"));
            main.CornerRadius = new CornerRadius(10);
           Bdcuoi.Visibility = Visibility.Collapsed;
            sv_grid.Visibility = Visibility.Collapsed;
            bd.Visibility = Visibility.Collapsed;
            add.Visibility = Visibility.Collapsed;
            bdtien1.Visibility = Visibility.Collapsed;
            tong.Visibility = Visibility.Collapsed;
            Bdcuoi.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BF0B0B"));
            int moneyAsInt = Convert.ToInt32(tienphong);

            if (moneyAsInt > 0)
                ftxt_Copy.Text = "ROOM PRICE = " + moneyAsInt.ToString("#,###") + " VND";
            else
            {
                ftxt_Copy.Text = "ROOM PRICE = " + "0 VND";

            }
            ftxt.Text = "cancel";
            ftxt.Foreground = new SolidColorBrush(Colors.White);
            fromdate_Copy.Foreground = new SolidColorBrush(Colors.White);
            fromdate_Copy1.Foreground = new SolidColorBrush(Colors.White);
            typetxt.Foreground = new SolidColorBrush(Colors.White);
            bd_time.BorderBrush = new SolidColorBrush(Colors.White);
            ftxt_Copy.Foreground = new SolidColorBrush(Colors.White);
            fromdate.Foreground = new SolidColorBrush(Colors.White);
            todate.Foreground = new SolidColorBrush(Colors.White);
            nbtxtleft.Foreground = new SolidColorBrush(Colors.White);
            totaltxt.Text = "CANCELLATION REASON";
            totaltxt.Foreground = new SolidColorBrush(Colors.White);
            CANCEL.Visibility = Visibility.Collapsed;
            view.Text = "NEW";
            nbtxtleft.Visibility = Visibility.Visible;
            if(giothue.Days>0)
            {
                if(giothue.Days>1)
                typetxt.Text = "days";
                else
                {
                    typetxt.Text = "day";
                }
                nbtxtleft.Text = giothue.Days.ToString();
              
            }
            else
            {
                if (giothue.Hours > 1)
                    typetxt.Text = "hours";
                else
                {
                    typetxt.Text = "hour";
                }
                nbtxtleft.Text = giothue.Hours.ToString();
              
            }
           
            

        }

        private void x_MouseDown(object sender, MouseButtonEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                connection.Open();



                string a = myDateTime.ToString();

                string[] str = a.Split('/');
                string trueday = str[1] + "-" + str[0] + "-" + str[2];


               
                string sqlQuery = $"delete from THUEPHONG WHERE MATHUEPHONG='{ID}'";
              try
                {
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {

                        command.ExecuteNonQuery();
                    }
                }
                catch
                {

                }
             

            }
            DependencyObject parent = VisualTreeHelper.GetParent(this);
            while (!(parent is UserControl) )
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            if (parent is ClientsRoom window)
            {
                window.reset();
            }
        }

        private void add_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            add_SV_PR a = new add_SV_PR(ref ID,this);
            a.ShowDialog();
        }
        private void tinhgio()
        {

        }
    }
}
