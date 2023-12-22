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
using IT008_O14_QLKS.View.Manager.FormPage.receipt;

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for Room_card_client.xaml
    /// </summary>
    public partial class Room_card_client : UserControl
    {
       
        string ID;
        DateTime myDateTime = DateTime.Now;
        int paid = 0;
        decimal tongtien = 0;
        private string thuoctinh;
        int sservice = 0;
        public decimal tongtienphong;
    
        Conectiondatabase connect =new Conectiondatabase();
        public Room_card_client(string ID)
        {
            this.ID = ID;
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
            card.Content = new roomcard2();
        
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



        }
        public Room_card_client(string ID,string type)
        {
            this.ID = ID;
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
            card.Content = new roomcard2();

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
            tinhtienphong();



        }
        TimeSpan giothue;
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
                    TimeSpan timeDifference = reader.GetDateTime(4)-myDateTime ;
                    giothue = reader.GetDateTime(4) - reader.GetDateTime(3);
                    if (timeDifference.Days<0)
                    {
                        if(paid==0)
                        { 
                            typetxt.Text = "NOT PAID";
                            typetxt.Foreground = new SolidColorBrush(Colors.Red);
                            bd_time.BorderBrush = new SolidColorBrush(Colors.Red);
                            nbtxtleft.Visibility = Visibility.Collapsed;
                            view.Text = "PAY";
                            CANCEL.Visibility = Visibility.Collapsed;
                            add.Visibility = Visibility.Collapsed;

                        }
                        else
                        {

                            typetxt.Text = "PAID";
                            typetxt.Foreground = new SolidColorBrush(Colors.Green);
                            bd_time.BorderBrush = new SolidColorBrush(Colors.Green);
                            nbtxtleft.Visibility = Visibility.Collapsed;
                            view.Text = "VIEW";
                            CANCEL.Visibility=Visibility.Collapsed;
                            add.Visibility = Visibility.Collapsed;
                            thuoctinh = "paid";

                        }
                        
                    }
                    else
                    {
                        if (timeDifference.Days > 0)
                        {
                            typetxt.Text = "days left";

                            nbtxtleft.Text = timeDifference.Days.ToString();
                        }
                        if (timeDifference.Days == 0)
                        {
                            if (timeDifference.Hours <0)

                            {
                                if (paid == 0)
                                {
                                    typetxt.Text = "NOT PAID";
                                    typetxt.Foreground = new SolidColorBrush(Colors.Red);
                                    bd_time.BorderBrush = new SolidColorBrush(Colors.Red);
                                    nbtxtleft.Visibility = Visibility.Collapsed;
                                    view.Text = "PAY";
                                    CANCEL.Visibility = Visibility.Collapsed;
                                    add.Visibility = Visibility.Collapsed;
                                }
                                else
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
                            else
                            {
                                nbtxtleft.Text = timeDifference.Hours.ToString();
                            }
                            
                        }

                    }

                  

                    ftxt.Text = reader.GetString(2).Substring(1);
                    fromdate.Text =  reader.GetDateTime(3).ToString("dd/MM/yyyy HH:mm:ss");
                    todate.Text = reader.GetDateTime(4).ToString("dd/MM/yyyy HH:mm:ss");
                }
            }
            reader.Close();
            
           
        }
        private decimal tinhtienphong()
        {
            decimal tienphong = 0;
           
            tongtienphong += tongtien;
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM PHONG WHERE TENPHONG = '{ftxt.Text}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
         
            while (reader.Read())
            {
               
                if (giothue.Days >= 0)
                    tienphong += (decimal)reader.GetSqlMoney(10) * giothue.Days;
                else {
                    if (giothue.Hours >= 0)
                        tienphong += (decimal)reader.GetSqlMoney(9) * giothue.Days;
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
            if( typetxt.Text!="PAID" && typetxt.Text != "NOT PAID")
            {
                giahan a = new giahan(ID); 
                a.ShowDialog();
                load();
            }    

        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void CANCEL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            cancel a = new cancel(ID);
            a.ShowDialog();
            load();
        }
       public int chk = 0;
       
        
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
                    window.tinhtien(tongtienphong);
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
                    window.trutien(tongtienphong);
                }
            }
        }
    }
}
