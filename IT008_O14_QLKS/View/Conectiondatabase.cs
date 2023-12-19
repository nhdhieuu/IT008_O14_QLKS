using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT008_O14_QLKS.View
{
    internal class Conectiondatabase
    {

        public string strCon = Properties.Settings.Default.strcon;
        public SqlConnection sqlCon = null;
       public Conectiondatabase()
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
     
     
    }
   
    
}
