using IT008_O14_QLKS.Connection_db;
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
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        DB_connection connect = new DB_connection();
        List<RoomService> added = new List<RoomService>();
        public AddService()
        {
            InitializeComponent();
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = "SELECT * FROM DICHVU";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                RoomService RS = new RoomService(reader.GetInt16(3), reader.GetString(1), reader.GetDecimal(2),this);
              
                ContentControl CC = new ContentControl();
                CC.Height = 42;
                CC.Width = 375;
                CC.Content = RS.Content;
                AvaiService.Children.Add( CC );
            }
        }
        public void Them()
        {
            this.Close();
        }
        private void accept_butt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void accept_butt_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void accept_butt_MouseLeave(object sender, MouseEventArgs e)
        {

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
