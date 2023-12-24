using IT008_O14_QLKS.Connection_db;
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

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for ServiceCard.xaml
    /// </summary>
    public partial class ServiceCard : UserControl
    {
        DB_connection connect = new DB_connection();
        
        public string name;
        public string date;
        public string price;
        public ServiceCard(string name, DateTime date, Decimal price)
        {
           
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT TENDV FROM DICHVU where MADV='{name}'";
            sqlcmd.Connection = connect.sqlCon;
            this.name =sqlcmd.ExecuteScalar().ToString();
           this.date= date.ToString("dd/MM/yyyy");
            this.price = price.ToString() + " VND"; ;
            InitializeComponent();
            Inputt();
        }
        public void Inputt()
        {
            this.nametbx.Text =this. name;
            this.datetbx.Text = this.date;
            this.pricetbx.Text = this.price;
        }    
    }
}
