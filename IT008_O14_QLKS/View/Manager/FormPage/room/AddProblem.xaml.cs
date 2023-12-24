using IT008_O14_QLKS.Connection_db;
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
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for AddProblem.xaml
    /// </summary>
    public partial class AddProblem : Window
    {
        DB_connection connect = new DB_connection();
        public List<RoomProblem> added = new List<RoomProblem>();
        public string matp;
        Viewroom_form vr;
        public AddProblem(string matp, Viewroom_form vr)
        {
            InitializeComponent();
            this.vr = vr;
            this.matp = matp;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM PROBLEM";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                RoomProblem RS = new RoomProblem(1, reader.GetString(1), reader.GetDecimal(2), this);

                ContentControl CC = new ContentControl();
                CC.Height = 42;
                CC.Width = 375;
                CC.Content = RS.Content;
                AvaiService.Children.Add(CC);
            }
            reader.Close();
        }

        private void accept_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Parameters.Add("@Date", SqlDbType.DateTime);
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.Parameters.Add("@Money", SqlDbType.Money);
            for (int i = 0; i < added.Count; i++)
            {

                sqlcmd.Parameters["@Date"].Value = DateTime.Now;
                sqlcmd.Parameters["@Money"].Value = added[i].Price;
                sqlcmd.CommandText = $"INSERT INTO CHITIETPR (MATHUEPHONG, MAPR, SOLUONG, THANHTIEN, NGAYPR) VALUES ('{matp}','{added[i].MAPR}',{added[i].SL},@Money,@Date)";
                sqlcmd.ExecuteNonQuery();
            }
            this.Close();
            vr.LoadProb();
        }

        private void accept_butt_MouseEnter(object sender, MouseEventArgs e)
        {
            accept_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));
        }

        private void accept_butt_MouseLeave(object sender, MouseEventArgs e)
        {
            accept_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void cancel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void cancel_MouseEnter(object sender, MouseEventArgs e)
        {
            this.cancel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF830F0F"));

        }

        private void cancel_MouseLeave(object sender, MouseEventArgs e)
        {

            this.cancel.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFED1B1B"));

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
