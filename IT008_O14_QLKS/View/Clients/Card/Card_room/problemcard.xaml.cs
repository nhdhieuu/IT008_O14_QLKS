using System;
using System.Collections.Generic;
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

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for problemcard.xaml
    /// </summary>
    public partial class problemcard : UserControl
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
       
        public problemcard(string ID, DateTime time)
        {
            InitializeComponent();
            this.ID = ID;
           
            this.time = time;

            load();

        }

        private void load()
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = $"select * from PROBLEM where MAPR='{ID}'";

            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                decimal moneyFromDatabase = (decimal)reader.GetSqlMoney(2);

                this.tt = moneyFromDatabase;
                ttt = tt;
                int moneyAsInt = Convert.ToInt32(moneyFromDatabase);

                if(moneyAsInt > 0)
                tien.Text = moneyAsInt.ToString("#,###") + " VND";
                else
                {
                    tien.Text = "0 VND";
                }

                name.Text = reader.GetString(1);

            }
            reader.Close();
            ngay.Text = time.ToString("dd/MM/yyyy");

            




        }
        int click = 0;
        public decimal tinhtien()
        {
            return ttt;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {


        }
    }
}

