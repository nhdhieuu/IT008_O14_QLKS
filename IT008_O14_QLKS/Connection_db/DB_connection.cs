using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IT008_O14_QLKS.Connection_db
{
    internal class DB_connection
    {
        public string strCon = Properties.Settings.Default.strcon;
        public SqlConnection sqlCon = null;
        public DB_connection()
        {
            try
            {
                if (sqlCon == null)
                {
                    sqlCon = new SqlConnection(strCon);
                }
                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();

                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Mất kết nối");
            }
            
        }
    }
}
