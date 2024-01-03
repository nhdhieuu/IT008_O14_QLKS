using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Clients.Card.Card_room;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust;
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2;
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
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for addRoom1.xaml
    /// </summary>
    public partial class addRoom1 : UserControl
    {
        public addRoom ar;
        DB_connection connect = new DB_connection();
        List<RoomCardThue> listRoom = new List<RoomCardThue>();
        int page = 1;
        public string MAKH;
        public addRoom1()
        {
            InitializeComponent();
        }
        public addRoom1( addRoom a, string MAKH)
        {
            InitializeComponent();
            Page_index_lbl.Text = "1";
            this.ar = a;

           this.MAKH= MAKH;
        }
        public void Load()
        {
            listRoom.Clear();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = "SELECT * FROM PHONG WHERE TRANGTHAI='Available'";
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while(reader.Read())
            {
                RoomCardThue a = new RoomCardThue(reader.GetString(1), reader.GetString(2), reader.GetInt32(11), reader.GetDecimal(9), reader.GetDecimal(10), this);
                listRoom.Add(a);
            }
            reader.Close();
            for(int i=0;i<listRoom.Count;i++)
            {
                sqlcmd.CommandText = "SELECT * FROM THUEPHONG WHERE MAPHONG='M"+listRoom[i].IDRoom+"'";
                SqlDataReader reader2 = sqlcmd.ExecuteReader();
                while (reader2.Read())
                {
                    if (reader2.GetString(5)=="Thanh Cong" || reader2.GetString(5) == "Dang Thue")
                    {
                        if ((to.Value>reader2.GetDateTime(3) && to.Value<= reader2.GetDateTime(4))||(from.Value >= reader2.GetDateTime(3) && from.Value < reader2.GetDateTime(4))||(from.Value<= reader2.GetDateTime(3)&& to.Value>= reader2.GetDateTime(4)))
                        {
                            listRoom.Remove(listRoom[i]);
                        }    
                    }    
                }
                reader2.Close();
            }
            Display();
        }
        public void Display()
        {
            List<RoomCardThue> temp=new List<RoomCardThue>();
            if (std == 0 && sup1 == 0 && dlx1 == 0 && sui == 0)
                temp.AddRange(listRoom);
            if (sup1 == 1 && std == 0 && dlx1 == 0 && sui == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior")
                    {
                        temp.Add(i);
                    }
                }
            if (std == 1 && sup1 == 0 && dlx1 == 0 && sui == 0)
            {
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Standard")
                    {
                        temp.Add(i);
                    }
                }
            }
            if (dlx1 == 1 && sup1 == 0 && std == 0 && sui == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Deluxe")
                    {
                        temp.Add(i);
                    }
                }
            if (sui == 1 && sup1 == 0 && dlx1 == 0 && std == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Suite")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && std == 1 && dlx1 == 0 && sui == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Standard")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && dlx1 == 1 && std == 0 && sui == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Deluxe")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && sui == 1 && dlx1 == 0 && std == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Suite")
                    {
                        temp.Add(i);
                    }
                }
            if (std == 1 && dlx1 == 1 && sui == 0 && sup1 == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Standard" || i.loai.Text == "Deluxe")
                    {
                        temp.Add(i);
                    }
                }
            if (std == 1 && sui == 1 && dlx1 == 0 && sup1 == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Suite" || i.loai.Text == "Standard")
                    {
                        temp.Add(i);
                    }
                }
            if (dlx1 == 1 && sui == 1 && sup1 == 0 && std == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Deluxe" || i.loai.Text == "Suite")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && std == 1 && dlx1 == 1 && sui == 0 )
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Standard" || i.loai.Text == "Deluxe")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && std == 1 && sui == 1 && dlx1 == 0 )
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Standard" || i.loai.Text == "Suite")
                    {
                        temp.Add(i);
                    }
                }
            if (sui == 1 && std == 1 && dlx1 == 1 && sup1 == 0)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Suite" || i.loai.Text == "Standard" || i.loai.Text == "Deluxe")
                    {
                        temp.Add(i);
                    }
                }
            if (sup1 == 1 && std == 1 && dlx1 == 1 && sui == 1)
                foreach (RoomCardThue i in listRoom)
                {
                    if (i.loai.Text == "Superior" || i.loai.Text == "Standard" || i.loai.Text == "Deluxe" || i.loai.Text == "Suite")
                    {
                        temp.Add(i);
                    }
                }
            if(FilterSlider.Value>0)
            {
                List<RoomCardThue> temp2 = new List<RoomCardThue>();
                foreach (RoomCardThue i in temp)
                {
                    if ((i.PriceTong)> Convert.ToDecimal(FilterSlider.Value))
                    {
                        //MessageBox.Show("right");
                        temp2.Add(i);
                    }
                }
                temp.Clear();
                temp.AddRange(temp2);
            }    
            if(sort!="")
            {
                if (sort == "ASC")
                    temp.Sort((p1, p2) => p1.PriceTong.CompareTo(p2.PriceTong));
                if(sort=="DESC")
                    temp.Sort((p1, p2) => p2.PriceTong.CompareTo(p1.PriceTong));
            }    
            int start = page * 6 - 6;
            try
            {
                CC1.Content = temp[start].Content;
            }
            catch
            {
                CC1.Content = null;
            }
            try
            {
                CC2.Content = temp[start + 1].Content;
            }
            catch
            {
                CC2.Content = null;
            }
            try
            {
                CC3.Content = temp[start + 2].Content;
            }
            catch
            {
                CC3.Content = null;
            }
            try
            {
                CC4.Content = temp[start + 3].Content;
            }
            catch
            {
                CC4.Content = null;
            }
            try
            {
                CC5.Content = temp[start + 4].Content;
            }
            catch
            {
                CC5.Content = null;
            }
            try 
            {
                CC6.Content = temp[start + 5].Content;
            }
             catch
            {
                CC6.Content = null;
            } 
           
               
        }
        
        private void Back_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(page>1)
                page--;
            Page_index_lbl.Text = page.ToString();
            Display();
        }

        private void Next_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int temp = listRoom.Count % 6;
            int PageCount;
            if (temp == 0)
                PageCount = listRoom.Count / 6;
            else
                PageCount = listRoom.Count / 6 + 1;
            if(page<PageCount)
                page++;
            Page_index_lbl.Text = page.ToString();
            Display();

        }

        private void from_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (from.Value < DateTime.Now)
            {
                
                MessageBox.Show("The selected day must be in the future!");
                from.Value=null;
                return;
            }
            else
            {
                if (to.Value != null && to.Value > from.Value)
                    Load();
            }    

        }

        private void to_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (to.Value < DateTime.Now)
            {
                MessageBox.Show("The selected day must be in the future!");
                to.Value= null;
                return;
            }
            else
            {
                if (to.Value <= from.Value)
                {
                    MessageBox.Show("The end date must be greater than the start date!");
                    return;
                }
                else
                    if (from.Value != null )
                        Load();

            }
        }
        int type_s = 0;
        private void bd_type_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (type_s == 0)
            {
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                type_s = 1;
                type.IsEnabled = true;
                sup.IsEnabled = true;
                standard.IsEnabled = true;
                VIP.IsEnabled = true;
                Dlx.IsEnabled = true;
                ck_type.Visibility = Visibility.Visible;
                bd_type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFC513"));
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));

            }
            else
            {

                type_s = 0;

                type.IsEnabled = false;
                sup.IsEnabled = false;
                standard.IsEnabled = false;
                VIP.IsEnabled = false;
                Dlx.IsEnabled = false;
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                VIP.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                ck_type.Visibility = Visibility.Hidden;
                bd_type.BorderBrush = new SolidColorBrush(Colors.White);
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#AFFFC000"));
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F797979"));
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                

            }
        }
        int std = 0;
        private void standard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (std == 0)
            {
                standard.Background = new SolidColorBrush(Colors.WhiteSmoke);
                std = 1;
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));
               
            }
            else
            {
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                std = 0;
            }
            Display();
        }
        int sup1 = 0;
        private void sup_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sup1 == 0)
            {
                sup.Background = new SolidColorBrush(Colors.WhiteSmoke);
                sup1 = 1;

                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));
                
            }
            else
            {
                sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

                sup1 = 0;
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
            Display();
        }
        int dlx1 = 0;
        private void Dlx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dlx1 == 0)
            {
                Dlx.Background = new SolidColorBrush(Colors.WhiteSmoke);
                dlx1 = 1;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));
                 

            }
            else
            {
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

                dlx1 = 0;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            
            }
            Display();
        }
        int sui = 0;
        private void VIP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sui == 0)
            {
                VIP.Background = new SolidColorBrush(Colors.WhiteSmoke);
                sui = 1;
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));
            }
            else
            {
                VIP.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                sui = 0;

                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
            Display();
        }
        int status_s = 0;
        private void bd_status_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (status_s == 0)
            {
                FilterSlider.IsEnabled = true;
                ck_status.Visibility = Visibility.Visible;
                status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF048AFF"));
                bd_status.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                status_s = 1;
            }
            else
            {

                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                status_s = 0;
                ck_status.Visibility = Visibility.Hidden;
                status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2014E91"));
                bd_status.BorderBrush = new SolidColorBrush(Colors.White);
                FilterSlider.IsEnabled = false;
            }
        }
        int stage_s = 0;
       
        private void bd_stage_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (stage_s == 0)
            {
                stage_s = 1;
                ck_stage.Visibility = Visibility.Visible;
                stage.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                stg_t.Foreground = new SolidColorBrush(Colors.White);
                bd_stage.BorderBrush = new SolidColorBrush(Colors.Green);
                AscBorder.IsEnabled = true;
                DescBorder.IsEnabled = true;
            }
            else
            {
                stage_s = 0;
                ck_stage.Visibility = Visibility.Hidden;
                stage.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                stg_t.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7FFFFFFF"));
                bd_stage.BorderBrush = new SolidColorBrush(Colors.White);
                AscBorder.IsEnabled = false;
                DescBorder.IsEnabled = false;
                AscBorder.Background = new SolidColorBrush(Colors.Transparent);
                AscTextBlock.Foreground = new SolidColorBrush(Colors.Red);
                DescBorder.Background = new SolidColorBrush(Colors.Transparent);
                DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
                sort = "";
                Display();
            }
        }

       

        private void FilterSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            FilterMoneyTextBox.Text = FilterSlider.Value.ToString() + " VND";
            Display();
        }
        string sort = "";
        private void AscBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AscBorder.Background = new SolidColorBrush(Colors.Red);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.White);

            DescBorder.Background = new SolidColorBrush(Colors.Transparent);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
            sort = "ASC";
            Display();
        }

        private void DescBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DescBorder.Background = new SolidColorBrush(Colors.LightBlue);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.White);
            AscBorder.Background = new SolidColorBrush(Colors.Transparent);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            sort = "DESC";
            Display();
        }
    }
}
