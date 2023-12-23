using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for service_card.xaml
    /// </summary>
    public partial class service_card : UserControl
    {
        Conectiondatabase connect = new Conectiondatabase();
        public string ID;
        string ten;
        string dongia;
        int tick;
        decimal tt;
        decimal ttt;
        DateTime time;
        string soluong;
        string type;
        public service_card( int tick, string ID, string soluong)
        {
            InitializeComponent();
            this.ID = ID;
          
            this.soluong = soluong;
         
            load();
            ngay.Visibility = Visibility.Collapsed;
            cot2.Visibility = Visibility.Collapsed;
        }
        public service_card(int tick, string ID,string soluong, DateTime time)
        {
            InitializeComponent();
            this.ID = ID;
            this.soluong = soluong;
            this.time = time;
           
            load();

        }

        private void load()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = $"select * from DICHVU where MADV='{ID}'";

            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                decimal moneyFromDatabase = (decimal)reader.GetSqlMoney(2);

                this.tt = moneyFromDatabase;
                ttt = tt;
                int moneyAsInt = Convert.ToInt32(moneyFromDatabase);


                tien.Text = moneyAsInt.ToString("#,###") + " VND";
      
                name.Text=reader.GetString(1);

            }
            reader.Close();
            ngay.Text = time.ToString("dd/MM/yyyy");
      
            x2.Text = "x"+soluong;




        }
        int click = 0;
        public decimal tinhtien( )
        {
            return ttt;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {

            
        }
    }
}
