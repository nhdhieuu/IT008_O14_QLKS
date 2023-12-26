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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for AddRoom2.xaml
    /// </summary>
    public partial class AddRoom2 : UserControl
    {
        public string RoomName;
        DB_connection connect = new DB_connection();
        public AddRoom2(string RoomName)
        {
            InitializeComponent();
            this.RoomName = RoomName;
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"SELECT * FROM PHONG WHERE TENPHONG='{RoomName}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while(reader.Read())
            {
                roomcard2 rc = new roomcard2(RoomName,reader.GetString(2),reader.GetInt32(11),"Client");
                this.roomcard.Content = rc.Content;
            }

        }
    }
}
