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

namespace IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust
{
    /// <summary>
    /// Interaction logic for adjust.xaml
    /// </summary>
    public partial class adjust : UserControl
    {
        string ostt { get; set; }
        string ID;
        public adjust( string ostt,string ID)
        {
          
            this.ostt = ostt;
            InitializeComponent();
            original a = new original();
            adj_cc.Content = a.Content;
            if (ostt =="Empty")
            {
                empty.Visibility = Visibility.Collapsed;
            }
            else
            {
                rented.Visibility = Visibility.Collapsed ;
            }
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
               if((cbb.SelectedItem as ComboBoxItem).Content.ToString()=="empty")
            {
               
            }

            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "unavailable")
            {
                cbb.Foreground = new SolidColorBrush(Colors.DarkRed);
               
                
            }
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "rented")
            {
                cbb.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC9A01E"));
               rented_adj a = new rented_adj();
                adj_cc.Content = a.Content;
            }

        }
       
      }

    }

