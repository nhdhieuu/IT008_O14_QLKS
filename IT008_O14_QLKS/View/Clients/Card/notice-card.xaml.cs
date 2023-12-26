using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.AccessControl;
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

namespace IT008_O14_QLKS.View.Clients.Card
{
    /// <summary>
    /// Interaction logic for notice_card.xaml
    /// </summary>
    public partial class notice_card : UserControl
    {
        int truee=0;
        string mant;
        DateTime myDateTime = DateTime.Now;
        DB_connection connect = new DB_connection();
        public notice_card(string mant)
        {
            this.mant = mant;
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
            load();
        }
        private bool isRotated = true;
        
        private void load()
        {
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT * from notice where MANOTICE='{mant}' and '{trueday}'>=NGAYBD and '{trueday}'<=NGAYKT";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();




            while (reader.Read())
            {
                truee = 1;
                myBorder_Copy.Text = reader.GetString(1);
                txt.Text = reader.GetString(2);


            }
            
        }
        public int trave()
        {
            return truee;
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {

            

                if (isRotated)
                {

                   
                    xoa.Visibility = Visibility.Visible;


                    bd.CornerRadius = new CornerRadius(10, 10, 0, 0);




                }
                else
                {
                    xoa.Visibility = Visibility.Collapsed;
                    bd.CornerRadius = new CornerRadius(10, 10, 10, 10);



                }



                isRotated = !isRotated;
            }
        }
    }

