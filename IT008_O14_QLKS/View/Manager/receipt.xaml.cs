﻿using System;
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
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for receipt.xaml
    /// </summary>
    public partial class receipt : UserControl
    {
        public receipt()
        {
            InitializeComponent();
            ReceiptCard[] listCard = new ReceiptCard[4];

            listCard[0] = new ReceiptCard("1", "12/12/2012", "12:12", "100000");
            listCard[1] = new ReceiptCard("2", "12/12/2012", "12:12", "100000");
            listCard[2] = new ReceiptCard("3", "12/12/2012", "12:12", "100000");
            listCard[3] = new ReceiptCard("4", "12/12/2012", "12:12", "100000");

             
          
            Cc11.Content = listCard[0].Content;
            cc12.Content = listCard[1].Content;
            cc13.Content = listCard[2].Content;
            cc14.Content = listCard[3].Content;
            cc15.Content = listCard[3].Content;
            cc16.Content = listCard[3].Content;
            cc17.Content = listCard[3].Content;
            cc18.Content = listCard[3].Content;
            cc19.Content = listCard[3].Content;
            
        }
    }
}
