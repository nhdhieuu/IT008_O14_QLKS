using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.FormPage.room;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for RoomProblem.xaml
    /// </summary>
    public partial class RoomProblem : UserControl
    {
        DB_connection connect = new DB_connection();
        public int SL;
        public string DV;
        public Decimal Price;
        AddProblem AS;
        public string MAPR;
        public RoomProblem(int sL, string dV, Decimal price, AddProblem AS)
        {
            InitializeComponent();
            SL = sL;
            DV = dV;
            Price = Math.Truncate(price);
            this.SoLuong.Text = SL.ToString();
            this.Ten.Content = DV;
            this.Ten.ToolTip = Ten.Content;
            this.Gia.Text = Price.ToString() + " VND";
            this.AS = AS;
            this.SoLuong.Visibility = Visibility.Hidden;
            this.Post.Visibility = Visibility.Hidden;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandText = $"SELECT MAPR FROM PROBLEM WHERE PRNAME='{dV}'";
            sqlcmd.Connection = connect.sqlCon;
            MAPR = sqlcmd.ExecuteScalar().ToString();
        }

        private void Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (x.Content.ToString() == "+")
            {
                AS.added.Add(this);
                AS.AddedService.Children.Add(this);
                AS.AvaiService.Children.Remove(this);
                this.SoLuong.Visibility = Visibility.Visible;
                this.Post.Visibility = Visibility.Visible;
               
                x.Content = "-";

            }
            else
            {
                AS.added.Remove(this);
                AS.AddedService.Children.Remove(this);
                this.SoLuong.Visibility = Visibility.Hidden;
                this.Post.Visibility = Visibility.Hidden;
               
                x.Content = "+";
                AS.AvaiService.Children.Add(this);
            }
        }


        
    }
}
