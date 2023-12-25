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
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.FormPage.notice
{
    /// <summary>
    /// Interaction logic for addnotice.xaml
    /// </summary>
    public partial class addnotice : Window
    {
        StackPanel noticePanel;
        public addnotice(StackPanel a  ) 
        {
            noticePanel = a;
            InitializeComponent();
            cbb.SelectedIndex = 0;
            cbb2.Visibility = Visibility.Collapsed;
            cus.Visibility = Visibility.Collapsed;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
          
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {


            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {

            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D9D9D9"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbb.SelectedIndex == 0)
            {
                cbb2.Visibility = Visibility.Collapsed;
                cus.Visibility = Visibility.Collapsed;
                cus2.Visibility = Visibility.Collapsed;
            }
            if (cbb.SelectedIndex == 1)
            {
                cbb2.Visibility = Visibility.Collapsed;
                cus2.Visibility = Visibility.Collapsed;
                cus.Visibility = Visibility.Visible;
                

            }
            if (cbb.SelectedIndex == 4)
            {
                cbb2.Visibility = Visibility.Collapsed;
                cus.Visibility = Visibility.Collapsed;
                cus2.Visibility = Visibility.Visible;


            }
            if (cbb.SelectedIndex == 2)
            {
                cus2.Visibility = Visibility.Collapsed;
                cbb2.Visibility = Visibility.Visible;
                cus.Visibility = Visibility.Collapsed;
                cbb2.Items.Clear();
                ComboBoxItem a = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Silver"
                };
                cbb2.Items.Add(a);
                ComboBoxItem a2 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Gold"
                }; cbb2.Items.Add(a2);
                ComboBoxItem a3 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Platinum"
                }; cbb2.Items.Add(a3);
                ComboBoxItem a4 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Diamond"
                }; cbb2.Items.Add(a4);
                cbb2.SelectedIndex = 0;


            }
            if (cbb.SelectedIndex == 3)
            {
                cus2.Visibility = Visibility.Collapsed;
                cbb2.Visibility = Visibility.Visible;
                cus.Visibility = Visibility.Collapsed;
                cbb2.Items.Clear();
                ComboBoxItem a = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Standard"
                };
                cbb2.Items.Add(a);
                ComboBoxItem a2 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Superior"
                }; cbb2.Items.Add(a2);
                ComboBoxItem a3 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Deluxe"
                }; cbb2.Items.Add(a3);
                ComboBoxItem a4 = new ComboBoxItem
                {
                    FontSize = 20,
                    Content = "Suite"
                }; cbb2.Items.Add(a4);
                cbb2.SelectedIndex = 0;


            }
            
        }

        private void cus2_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
        string old;
        private void cus_TextChanged(object sender, TextChangedEventArgs e)
        {

            foreach (char i in cus.Text)
            {
                if ((int)i - 48 >= 0 && (int)i - 48 <= 9)
                {

                }
                else
                {
                    cus.Text = old;
                }
            }
            old = cus.Text;
        }
        string a;

        public string tra_ve()
        {
           
            if(cbb.SelectedIndex == 0)
            {
                a = "all client";

            }
            if (cbb.SelectedIndex == 1)
            {
                a = "all client in floor " +cus.Text;

            }
          
            if (cbb.SelectedIndex == 2)
            {
                a = "all client  have " + cbb2.Text +" class";

            }
            if (cbb.SelectedIndex == 3)
            {
                a = "all client  have " + cbb2.Text + "  room";

            }
            if (cbb.SelectedIndex == 4)
            {
                a = "client has id: " + cus2.Text;

            }
            return a;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(cbb.SelectedIndex==1 && cus.Text=="")
            {
                MessageBox.Show("Fill all information!");
            }
            else
            {

                if (cbb.SelectedIndex == 4 && cus2.Text == "")
                {
                    MessageBox.Show("Fill all information!");
                }
                else
                {
                    TextBlock a = new TextBlock
                    {

                        Text = tra_ve(),
                        FontSize=15
                    };
                    noticePanel.Children.Add(a);
                }
            }
          
        }
    }
}
