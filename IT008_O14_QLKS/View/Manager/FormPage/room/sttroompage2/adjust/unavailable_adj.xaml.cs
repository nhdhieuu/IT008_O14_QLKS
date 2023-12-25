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
using System.Runtime.Remoting.Contexts;
using IT008_O14_QLKS.Connection_db;

namespace IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust
{
    /// <summary>
    /// Interaction logic for unavailable_adj.xaml
    /// </summary>
    public partial class unavailable_adj : UserControl
    {
        string ID;
        sttroompage stt;
        public unavailable_adj(string iD,sttroompage stt)
        {
            InitializeComponent();
            ID = "M"+iD;
            this.stt = stt;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.stt.Close();
        }
        DB_connection connect =new DB_connection(); 
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.CommandText = $"UPdate PHONG  set  TRANGTHAI='Available'  WHERE MAPHONG = '{ID}'";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();

            MessageBox.Show("adjust sucessfully");
            this.stt.Close();
            
           
        }
    }
}
