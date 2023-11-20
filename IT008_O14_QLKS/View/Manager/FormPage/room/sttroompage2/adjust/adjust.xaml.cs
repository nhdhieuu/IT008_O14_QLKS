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

namespace IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust
{
    /// <summary>
    /// Interaction logic for adjust.xaml
    /// </summary>
    public partial class adjust : UserControl
    {
        public adjust()
        {
            InitializeComponent();

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          
               if((cbb.SelectedItem as ComboBoxItem).Content.ToString()=="empty")
            {
                cbb.Foreground = new SolidColorBrush(Colors.DarkGreen);
                empty_adj a = new empty_adj();
                adj_cc.Content = a.Content;
            }

            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "unavailable")
            {
                cbb.Foreground = new SolidColorBrush(Colors.DarkRed);
                unavailable_adj a = new unavailable_adj();
                adj_cc.Content = a.Content;
            }

        }
       
      }

    }

