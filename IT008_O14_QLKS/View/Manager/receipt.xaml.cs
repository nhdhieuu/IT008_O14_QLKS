using System;
using System.Collections.Generic;
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
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for receipt.xaml
    /// </summary>
    public partial class receipt : UserControl
    {
        DB_connection _db = new DB_connection();
        
        
        public receipt()
        {
            InitializeComponent();
            this.Loaded += receipt_Loaded;

            
            
        }

        private void receipt_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCommand= new SqlCommand();
            sqlCommand.Connection = _db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                
                ReceiptCard receiptCard =new ReceiptCard(sqlDataReader[0].ToString(),sqlDataReader[1],sqlDataReader[2].ToString(),sqlDataReader[3].ToString());
                ContentControl contentControl = new ContentControl();
                if(ReceiptCardPanel.Children.Count >= 1) {
                    // Child thứ 2, set margin 
                    contentControl.Margin = new Thickness(0, 10, 0, 0);  
                }
                
                contentControl.Content = receiptCard.Content;
                ReceiptCardPanel.Children.Add(contentControl);
            }
            sqlDataReader.Close();
        }

        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn cần tìm kiếm");
            }
            else
            {
                ReceiptCardPanel.Children.Clear();;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _db.sqlCon;
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon where sohd = '" + SearchBox.Text + "'";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ReceiptCard receiptCard = new ReceiptCard(sqlDataReader[0].ToString(), sqlDataReader[1], sqlDataReader[2].ToString(), sqlDataReader[3].ToString());
                        ContentControl contentControl = new ContentControl();
                        if (ReceiptCardPanel.Children.Count >= 1)
                        {
                            // Child thứ 2, set margin 
                            contentControl.Margin = new Thickness(0, 10, 0, 0);
                        }

                        contentControl.Content = receiptCard.Content;
                        ReceiptCardPanel.Children.Add(contentControl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn");
                }
                sqlDataReader.Close();
            }
        }
    }
}
