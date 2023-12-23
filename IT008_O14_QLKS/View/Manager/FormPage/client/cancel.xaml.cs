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
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for cancel.xaml
    /// </summary>
   
    public partial class cancel : Window
    {
        private DateTime myDateTime = DateTime.Now;
        string ID;
        Conectiondatabase connect = new Conectiondatabase();
        string type;
        public cancel(string ID)
        {
            InitializeComponent();
            this.ID = ID;
        }
        public cancel(string ID,string type)
        {
            InitializeComponent();
            this.ID = ID;
            this.type = type;
            
        }

        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connect.strCon))
            {
                connection.Open();



                string a = myDateTime.ToString();

                string[] str = a.Split('/');
                string trueday = str[1] + "-" + str[0] + "-" + str[2];

               
                string sqlQuery = $"UPDATE THUEPHONG SET NGAYKT = '{trueday}' WHERE MATHUEPHONG ='{ID}'";
                if(type=="book")
                {
                    sqlQuery = $"UPDATE THUEPHONG SET KQUATHUE = 'That Bai' WHERE MATHUEPHONG ='{ID}'";
                }    

                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {

                    command.ExecuteNonQuery();
                }
                this.Close();
            }
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
    }
}
