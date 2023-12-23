using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
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

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for service.xaml
    /// </summary>
    public partial class service : UserControl
    {
        DB_connection db=new DB_connection();

        public service()
        {
            InitializeComponent();

            string ss = "select * from DICHVU";
            
            SqlDataAdapter da= new SqlDataAdapter(ss,db.sqlCon);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            for(int i = 0;i<dataTable.Rows.Count;i++)
            {
                string name= dataTable.Rows[i]["TENDV"].ToString();
                string id= dataTable.Rows[i]["MADV"].ToString();
                string price = dataTable.Rows[i]["DONGIA"].ToString();
                card_dichvu cd=new card_dichvu(id,name,price);
                ds_dichvu.Children.Add(cd);
            }    
            
            DataTable  dataTable1 = new DataTable();
            ss = "select * from PROBLEM";
            da = new SqlDataAdapter (ss,db.sqlCon);
            da.Fill(dataTable1);
            for(int i = 0; i<dataTable1.Rows.Count;i++)
            {
                string name = dataTable.Rows[i]["PRNAME"].ToString();
                string id = dataTable.Rows[i]["MAPR"].ToString();
                string price = dataTable.Rows[i]["PRICE"].ToString();
                ProbBlemCard pc=new ProbBlemCard(id,name,price);
                ds_problem.Children.Add(pc);
            }    

          /*  SC[0] = new card_dichvu("DV01","Coca-cola","30000");
            SC[1] = new card_dichvu("DV02", "Pepsi", "30000");
            SC[2] = new card_dichvu("DV03", "Fanta", "30000");
            SC[3] = new card_dichvu("DV04", "7Up", "30000");
            SC[4] = new card_dichvu("DV05", "Nuoc suoi", "20000");
            SC[5] = new card_dichvu("DV06", "Bia Huda", "");
            SC[6] = new card_dichvu("DV07", "Bia Ha Noi", "30000");
            SC[7] = new card_dichvu("DV08", "Bia sai Gon", "30000");
            SC[8] = new card_dichvu("DV09", "Ruou vang do Merlot", "3000000");
            SC[9] = new card_dichvu("DV10", "Ruou vang trang Chardonnay", "3000000");
            SC[10] = new card_dichvu("DV11", "Ruou vang hong Rosé", "2500000");
            SC[11] = new card_dichvu("DV12", "Banh mi bate", "30000");
            SC[12] = new card_dichvu("DV13", "Buger", "50000");
            SC[13] = new card_dichvu("DV14", "Spaghetti", "200000");
            SC[14] = new card_dichvu("DV15", "Tom hum", "1500000");
            SC[15] = new card_dichvu("DV16", "Sushi", "300000");
            SC[16] = new card_dichvu("DV17", "Salad hoa qua", "150000");
            SC[17] = new card_dichvu("DV18", "Beef steak", "1000000");
            SC[18] = new card_dichvu("DV19", "Chocolate Fondant", "300000");
            SC[19] = new card_dichvu("DV20", "Pudding", "100000");
            SC[20] = new card_dichvu("DV21", "Pho bo", "100000");
            SC[21] = new card_dichvu("DV22", "Don phong", "500000");
            SC[22] = new card_dichvu("DV23", "Spa", "4000000");*/

          /*  CC1.Content = SC[0].Content;
            CC2.Content = SC[1].Content;
            CC3.Content = SC[2].Content;
            CC4.Content = SC[3].Content;
            CC5.Content = SC[4].Content;
            CC6.Content = SC[5].Content;
            CC7.Content = SC[6].Content;
            CC8.Content = SC[7].Content;
            CC9.Content = SC[8].Content;
            CC10.Content = SC[10].Content;
            CC11.Content = SC[11].Content;
            CC12.Content = SC[12].Content;
            CC13.Content = SC[13].Content;
            CC14.Content = SC[14].Content;
            CC15.Content = SC[15].Content;
            CC16.Content = SC[16].Content;
            CC17.Content = SC[17].Content;
            CC18.Content = SC[18].Content;
            CC19.Content = SC[19].Content;
            CC20.Content = SC[20].Content;
            CC21.Content = SC[21].Content;
            CC22.Content = SC[22].Content;*/

            /*PC[0] = new ProbBlemCard("PR01", "repair", "200k");
            PC[1] = new ProbBlemCard("PR02", "repair", "200k");
            PC[2] = new ProbBlemCard("PR03", "repair", "200k");
            PC[3] = new ProbBlemCard("PR04", "repair", "200k");
            PC[4] = new ProbBlemCard("PR05", "repair", "200k");
            PC[5] = new ProbBlemCard("PR06", "repair", "200k");
            PC[6] = new ProbBlemCard("PR07", "repair", "200k");
            PC[7] = new ProbBlemCard("PR08", "repair", "200k");
            PC[8] = new ProbBlemCard("PR09", "repair", "200k");
            PC[9] = new ProbBlemCard("PR10", "repair", "200k");

            PC1.Content = PC[0].Content;
            PC2.Content = PC[1].Content;
            PC3.Content = PC[2].Content;
            PC4.Content = PC[3].Content;
            PC5.Content = PC[4].Content;
            PC6.Content = PC[5].Content;
            PC7.Content = PC[6].Content;
            PC8.Content = PC[7].Content;
            PC9.Content = PC[8].Content;
            PC10.Content = PC[9].Content;*/
        }

        private void but_add_service_MouseDown(object sender, MouseButtonEventArgs e)
        {
            serviceAdd sa = new serviceAdd();
            sa.ShowDialog();
        }

        private void but_add_problem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            problemAdd pa = new problemAdd();
            pa.ShowDialog();
        }
    }
}
