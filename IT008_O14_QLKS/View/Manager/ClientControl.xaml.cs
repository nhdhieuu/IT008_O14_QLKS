using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.Card.roomCardbackground;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
 using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace IT008_O14_QLKS.View.Manager
{

    public partial class ClientControl : UserControl
    {
        SqlCommand sqlcmd = new SqlCommand();

      
        int pointcls = 0;
        string class_txt;
        string strCon = Properties.Settings.Default.strcon;
        SqlConnection sqlCon = null;
        string search;

        private DispatcherTimer t;
        public ClientControl()
        {
            InitializeComponent();

            sqlcmd.CommandType = CommandType.Text;
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();

            }
           
            load();

            t = new DispatcherTimer();
            
            t.Interval = TimeSpan.FromSeconds(1);
            t.Start();
            t.Tick += HenGio;


        }
        private void HenGio(object sender, EventArgs e)
        {
            load();
        }

        string tensx;
        private void load()
        {
           
            stk.Children.Clear();
           

            sqlcmd.CommandText = "select * from KHACHHANG";
            sqlcmd.CommandText+= search;
            if (type_s2==1)
            {
                sqlcmd.CommandText += " ORDER BY " + tensx + " " + sxtheo;
            }    
                
            sqlcmd.Connection = sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                themdoituong(reader.GetString(1), reader.GetString(2), reader.GetString(0), reader.GetString(9));

            }
            reader.Close();

        }
        int type_s = 0;
        private void Border_MouseDown_2(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            if (type_s == 0)
            {
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                type_s = 1;
                type.IsEnabled = true;
                cbb_clls.IsEnabled = true;
                ck_type.Visibility = System.Windows.Visibility.Visible;
               filter.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB07D1D"));
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFB730"));
                cbb_clls.SelectedIndex = 0;
                cbb_clls.Foreground = new SolidColorBrush((Colors.Gray));
                pointcls = 1;
                load();

            }
            else
            {

                type_s = 0;
                int note1 = 0;
                type.IsEnabled = false;
                cbb_clls.IsEnabled = false;
                ck_type.Visibility = System.Windows.Visibility.Hidden;
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                filter.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4B3306"));
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4B3306"));
                cbb_clls.Text = "";


            }
        }
        private void themdoituong(string name, string usrname, string id, string cls )
        {
            if(type_s==1)
            {
                int point = 0;

                if (cls == "Silver")
                {
                    point = 1;
                }
                if (cls == "Gold")
                {
                    point = 2;
                }
                if (cls == "Platinum")
                {
                    point = 3;
                }
                if (cls == "Diamond")
                {
                    point = 4;
                }
                if(point>=pointcls)
                {

                    ContentControl a = new ContentControl
                    {
                        Height = 120,
                        Width = 465
                    };
                    ClientCard b = new ClientCard(name, usrname, id, cls);


                    a.Content = b;
                    stk.Children.Add(a);

                }

            }
            else
            {
                ContentControl a = new ContentControl
                {
                    Height = 120,
                    Width = 465
                };
                ClientCard b = new ClientCard(name, usrname, id, cls);


                a.Content = b;
                stk.Children.Add(a);

            }




        }
        int note1 = 0;
        private void cbb_clls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            note1++;
            if (cbb_clls.Text != "" || note1 == 1)
            {
                if ((cbb_clls.SelectedItem as ComboBoxItem).Content.ToString() == "Silver")
                {

                    cbb_clls.Foreground = new SolidColorBrush((Colors.Gray));
                    pointcls = 1;

                }
                if ((cbb_clls.SelectedItem as ComboBoxItem).Content.ToString() == "Gold")
                {
                    cbb_clls.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFEEB74C"));
                    pointcls = 2;
                }
                if ((cbb_clls.SelectedItem as ComboBoxItem).Content.ToString() == "Platinum")
                {
                    cbb_clls.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF287EB8"));
                    pointcls = 3;
                }
                if ((cbb_clls.SelectedItem as ComboBoxItem).Content.ToString() == "Diamond")
                {
                    cbb_clls.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF370DA8"));
                    pointcls = 4;
                }
            }
            load();
        
           
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
         
            load();
        }
        int type_s2 = 0;
        private void bd_type1_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (type_s2 == 0)
            {
              
                asc.BorderBrush = new SolidColorBrush(Colors.Red);
                asc_txt.Foreground = new SolidColorBrush(Colors.Red);
                desc.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                desc_txt.Foreground = new SolidColorBrush(Colors.LightBlue);
                type1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                type_s2 = 1;
                type1.IsEnabled = true;
                cbb_clls1.IsEnabled = true;
                ck_type1.Visibility = System.Windows.Visibility.Visible;
                ord_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF05C86D"));
                cbb_clls1.SelectedIndex = 0;
                sxtheo = "asc";


            }
            else
            {
                asc.IsEnabled = false;
                desc.IsEnabled = false;
                asc.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF811B1B"));
                asc_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF811B1B"));
                desc.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF111176"));
                desc_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF111176"));
                type_s2 = 0;

                type1.IsEnabled = false;
                cbb_clls1.IsEnabled = false;
                ck_type1.Visibility = System.Windows.Visibility.Hidden;
                type1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                ord_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF242F26"));
                cbb_clls1.Text = "";
                asc.Background = new SolidColorBrush(Colors.Transparent);

                desc.Background = new SolidColorBrush(Colors.Transparent);
                note = 0;
                load();


            }
        }
        string sxtheo;
        private void asc_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            asc.Background= new SolidColorBrush(Colors.Red);
            asc_txt.Foreground = new SolidColorBrush(Colors.White);

            desc.Background = new SolidColorBrush(Colors.Transparent);
            desc_txt.Foreground = new SolidColorBrush(Colors.LightBlue);
            sxtheo = "asc";
            load();
        }

        private void desc_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            desc.Background = new SolidColorBrush(Colors.LightBlue);
            desc_txt.Foreground = new SolidColorBrush(Colors.White);
            asc.Background = new SolidColorBrush(Colors.Transparent);
            asc_txt.Foreground = new SolidColorBrush(Colors.Red);
            sxtheo = "desc";
            load();
        }
        int note = 0;
        private void cbb_clls1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            note++;
            if(note == 1)
            {
                asc.IsEnabled = true;
                desc.IsEnabled = true;
            }
            if (cbb_clls1.Text != ""||note==1)
            {
                if ((cbb_clls1.SelectedItem as ComboBoxItem).Content.ToString() == "A-Z")
                {

                    tensx = " SUBSTRING(TENKH, LEN(TENKH) - CHARINDEX(' ', REVERSE(TENKH)) + 2, LEN(TENKH)) ";
             

                }
                if ((cbb_clls1.SelectedItem as ComboBoxItem).Content.ToString() == "ID")
                {

                    tensx = " MAKH ";

                }
                if ((cbb_clls1.SelectedItem as ComboBoxItem).Content.ToString() == "Class")
                {

                    tensx = " ClassID ";

                }

                asc.Background = new SolidColorBrush(Colors.Red);
                asc_txt.Foreground = new SolidColorBrush(Colors.White);

                desc.Background = new SolidColorBrush(Colors.Transparent);
                desc_txt.Foreground = new SolidColorBrush(Colors.LightBlue);
                sxtheo = "asc";
                load();
            }
        
        }

        private void Image_MouseDown_1(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (search_txt.Text == "")
            {
                search = "";
            }
            else
            {
                t.Stop();
                stk.Children.Clear();

                sqlcmd.CommandText = $"select * from KHACHHANG where MAKH LIKE '{search_txt.Text}%' or  TENKH  LIKE '{search_txt.Text}%'";
                search = $" where MAKH  LIKE '{search_txt.Text}%' or  TENKH  LIKE '{search_txt.Text}%' ";
                sqlcmd.Connection = sqlCon;
                SqlDataReader reader = sqlcmd.ExecuteReader();
                while (reader.Read())
                {
                    themdoituong(reader.GetString(1), reader.GetString(2), reader.GetString(0), reader.GetString(9));

                }
                reader.Close();
            }

              
        }

        private void search_txt_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(search_txt.Text == "")
            {
                t.Start();
            }
            else
            {
               
            }
        }
    }
}