using System;
using System.Collections.Generic;
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

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for ReceiptCard.xaml
    /// </summary>
    public partial class ReceiptCard : UserControl
    {
        private string _receiptId;
        private string _date;
        private string _time;
        private string _totalMoney;
        
        public ReceiptCard()
        {
            InitializeComponent();
        }
        public ReceiptCard(string receiptId, string date, string time, string totalMoney)
        {
            InitializeComponent();
            this._receiptId = receiptId;
            this._date = date;
            this._time = time;
            this._totalMoney = totalMoney;
            Display();
        }

        private void Display()
        {
            this.ReceiptIdBox.Content = "#"+_receiptId;
            this.DateBox.Content = _date;
            this.TimeBox.Content      = _time;
            this.TotalMoneyBox.Content = _totalMoney;
        }
    }
}
