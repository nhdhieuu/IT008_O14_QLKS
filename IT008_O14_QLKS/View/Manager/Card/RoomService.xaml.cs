using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.FormPage.room;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Interaction logic for RoomService.xaml
    /// </summary>
    public partial class RoomService : UserControl
    {
        public int SL;
        public string DV;
        public Decimal Price;
        AddService AS;
        DB_connection connect = new DB_connection();
        public string MADV;
        public RoomService(int sL, string dV, Decimal price, AddService AS)
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
            this.ASC.Visibility = Visibility.Hidden;
            this.DESC.Visibility = Visibility.Hidden;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT MADV FROM DICHVU WHERE TENDV='{dV}'";
            sqlcmd.Connection = connect.sqlCon;
            MADV = sqlcmd.ExecuteScalar().ToString();
        }
            

        private void Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (x.Content.ToString()=="+")
            {
                AS.AddedService.Children.Add(this);
                AS.added.Add(this);
                AS.AvaiService.Children.Remove(this);
                this.SoLuong.Visibility = Visibility.Visible;
                this.Post.Visibility = Visibility.Visible;
                this.ASC.Visibility = Visibility.Visible;
                this.DESC.Visibility = Visibility.Visible;
                x.Content = "-";
               
            }
            else
            {
                AS.added.Remove(this);
                AS.AddedService.Children.Remove(this);
                this.SoLuong.Visibility = Visibility.Hidden;
                this.Post.Visibility = Visibility.Hidden;
                this.ASC.Visibility = Visibility.Hidden;
                this.DESC.Visibility = Visibility.Hidden;
                x.Content = "+";
                AS.AvaiService.Children.Add(this);
            }    
        }


        private void ASC_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            this.SoLuong.Text = (SL + 1).ToString();
            SL++;
           
        }

        private void DESC_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (SL > 1)
                this.SoLuong.Text = (SL - 1).ToString();
            SL--;
           
        }
    }
}
