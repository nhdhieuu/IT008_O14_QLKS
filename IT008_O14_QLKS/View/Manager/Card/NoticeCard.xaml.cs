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

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for NoticeCard.xaml
    /// </summary>
    public partial class NoticeCard : UserControl
    {
        string _context;
        public NoticeCard(string noticeContext)
        {
            _context = noticeContext;
            InitializeComponent();
            noticecard_context.Text = noticeContext;
            
        }
    }
}
