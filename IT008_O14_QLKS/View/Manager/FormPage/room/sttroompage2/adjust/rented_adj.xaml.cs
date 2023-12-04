using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
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
    /// Interaction logic for rented_adj.xaml
    /// </summary>
    public partial class rented_adj : UserControl
    {
        public rented_adj()
        {
            InitializeComponent();
        }
        string old;
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (char i in phone.Text)
            {
                if ((int)i - 48 >= 0 && (int)i - 48 <= 9)
                {

                }
                else
                {
                    phone.Text = old;
                }
            }
            old = phone.Text;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((cbb.SelectedItem as ComboBoxItem).Content.ToString() == "day")
            {
                cbb.Foreground = new SolidColorBrush(Colors.DarkGreen);
               
            }

        }
    }
}
