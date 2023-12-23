using IT008_O14_QLKS.View.Clients.Card.Card_room;
using IT008_O14_QLKS.View.Manager.Card;
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
using System.Xml.Linq;
using System.Windows.Threading;
using IT008_O14_QLKS.Connection_db;

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for room_client.xaml
    /// </summary>
  
    public partial class room_client : UserControl
    {
        private DateTime myDateTime = DateTime.Now;
        string ID;
        DB_connection connect =new DB_connection();
        public room_client( string ID)
        {
            InitializeComponent();
            this.ID= ID;
            load();

            
            
        }
      
        public void load()
        {
            string a = myDateTime.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];
            
            stk.Children.Clear();
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"SELECT * FROM THUEPHONG WHERE MAKH = '{ID}' and '{trueday}' > NGAYKT AND KQUATHUE='Thanh Cong'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();

            while (reader.Read())
            {

                    tb.Visibility = Visibility.Hidden;
                    add(reader.GetString(0));
                    
                
            }
          
        }
        public void add(string ID)
        {
            ContentControl a = new ContentControl
            {

                Width = 693
            };
            Border c = new Border
            {
                Height = 20
            };
            Room_card_client b = new Room_card_client(ID);

            a.Content = b;
            stk.Children.Add(a);
            stk.Children.Add(c);
        }
    }
}
