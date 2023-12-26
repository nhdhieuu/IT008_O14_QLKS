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
using IT008_O14_QLKS.Models;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for ReceiptCard.xaml
    /// </summary>
    public partial class ReceiptCard : UserControl
    {
        public string _receiptId;
        public DateTime _date;
        public string _datestring;
        public string _time;
        public string _totalMoney;
        public List<DichVu> _DichVu = new List<DichVu>();
        public Room _room = new Room();
        public List<Problem> _Problem = new List<Problem>();

        public ReceiptCard()
        {
            InitializeComponent();
        }

        public ReceiptCard(string receiptId, object date, string time, string totalMoney)
        {
            InitializeComponent();
            this._receiptId = receiptId;
            this._date = (DateTime)date;
            this._datestring = _date.ToString("dd/MM/yyyy");
            this._time = time;
            this._totalMoney = totalMoney;
            Display();
        }

        private void Display()
        {
            this.ReceiptIdBox.Content = "#" + _receiptId;
            this.DateBox.Content = _datestring;
            this.TimeBox.Content = _time;
            this.TotalMoneyBox.Text = int.Parse(_totalMoney).ToString("N0") + " VND";
        }

        private void getReceiptDichVu()
        {
            DB_connection db = new DB_connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText =

                "select distinct chitietdv.madv,chitietdv.soluong" +
                " from hoadon" +
                " inner join cthd" +
                "    on hoadon.sohd = cthd.sohd" +
                " left join chitietdv" +
                "    on chitietdv.mathuephong = cthd.maphong" +
            
                $" where hoadon.sohd = '{_receiptId}'";
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader[0] != null && sqlDataReader[1] != null )
                {
                    _DichVu.Add(new DichVu(sqlDataReader[0].ToString(), sqlDataReader[1].ToString()));
                                    
                }
            }
            sqlDataReader.Close();
        }
        private void getReceiptProblem()
        {
            DB_connection db = new DB_connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText =

                "select distinct chitietpr.mapr,chitietpr.soluong" +
                " from hoadon" +
                " inner join cthd" +
                "    on hoadon.sohd = cthd.sohd" +
                " left join chitietpr" +
                "    on chitietpr.mathuephong = cthd.maphong" +
            
                $" where hoadon.sohd = '{_receiptId}'";
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                if (sqlDataReader[0] != null && sqlDataReader[1] != null )
                {
                    _DichVu.Add(new DichVu(sqlDataReader[0].ToString(), sqlDataReader[1].ToString()));
                                    
                }
            }
            sqlDataReader.Close();
        }
        private void getReceiptRoomName()
        {
            DB_connection db = new DB_connection();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText =

                "select distinct maphong" +
                " from hoadon" +
                " inner join cthd" +
                "    on hoadon.sohd = cthd.sohd" +
            
                $" where hoadon.sohd = '{_receiptId}'";
            sqlCommand.ExecuteNonQuery();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                
                    _room = new Room(sqlDataReader[0].ToString());
                    
            }
            sqlDataReader.Close();
        }
        private void getReceiptInfo()
        {
            getReceiptRoomName();
            getReceiptDichVu();
            getReceiptProblem();
            
            
        }

        private void ReceiptCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            getReceiptInfo();
            PrintReceipt printReceipt = new PrintReceipt(this);
            printReceipt.Print();
        }
    }
}