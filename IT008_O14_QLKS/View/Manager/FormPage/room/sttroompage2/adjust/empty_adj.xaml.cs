using IT008_O14_QLKS.View.Manager.FormPage.client;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using IT008_O14_QLKS.Connection_db;

namespace IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust
{
    /// <summary>
    /// Interaction logic for empty_adj.xaml
    /// </summary>
    public partial class empty_adj : UserControl
    {
        sttroompage stt;
        string ID;
        DB_connection connect = new DB_connection();
        DateTime now = DateTime.Now;
        public empty_adj(string iD, sttroompage stt)
        {
            
            InitializeComponent();
            this.stt = stt;
            ID = "M"+iD;
       
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
            this.stt.Close();
        }
        
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            string a = now.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"UPdate THUEPHONG  set KQUATHUE ='That Bai'  WHERE (MAPHONG = '{ID}'  and KQUATHUE='Dang Thue') or(MAPHONG = '{ID}' and  KQUATHUE='Thanh Cong' and '{trueday}'< NGAYBD)";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();
          

        

            sqlcmd.CommandText = $"UPdate THUEPHONG  set  NGAYKT='{trueday}'  WHERE MAPHONG = '{ID}'  and KQUATHUE='Thanh Cong' and '{trueday}'>=NGAYBD and '{trueday}'<=NGAYKT";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();

            sqlcmd.CommandText = $"UPdate PHONG  set  TRANGTHAI='Unavailabl'  WHERE MAPHONG = '{ID}'";
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.ExecuteNonQuery();

            MessageBox.Show("adjust sucessfully");
            this.stt.Close();

        }
    }
}
