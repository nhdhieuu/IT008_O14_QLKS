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

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for addRoom1.xaml
    /// </summary>
    public partial class addRoom1 : UserControl
    {
        addRoom ar;
        public addRoom1()
        {
            InitializeComponent();
        }
        public addRoom1( addRoom a)
        {
            this.ar = a;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ar.chuyenview();
        }
    }
}