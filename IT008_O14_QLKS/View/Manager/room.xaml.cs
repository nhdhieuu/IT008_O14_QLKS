using IT008_O14_QLKS.View.Manager.Card;
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

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for room.xaml
    /// </summary>
    public partial class room : UserControl
    {
        public room()
        {
            InitializeComponent();
            roomcard[] listCard = new roomcard[6];
            // -- Load các giá trị cho 6 ô từ data base
            listCard[0]= new roomcard("P101", "VIP", "Booked", "day", 2, 2);
            listCard[1] = new roomcard("P102", "VIP", "Unavailable", "day", 2, 2);
            listCard[2] = new roomcard("P103", "Normal", "Trần Văn A", "hour", 2, 2);
            listCard[3] = new roomcard("P104", "VIP", "Empty", "day", 2, 2);
            listCard[4] = new roomcard("P105", "Normal", "Empty", "day", 2, 2);
            listCard[5] = new roomcard("P106", "Normal", "Unavailable", "day", 2, 2);
          

            //

             
          
            cc11.Content = listCard[0].Content;
            cc21.Content = listCard[1].Content;
            cc12.Content = listCard[2].Content;
            cc22.Content = listCard[3].Content;
            cc13.Content = listCard[4].Content;
            cc23.Content = listCard[5].Content;
           


        }
        int cleaned = 1;
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
          if(cleaned == 1) {
                Clean.Background = new SolidColorBrush(Colors.Green);
                cleaned = 2;
            }
            else if (cleaned == 2)
            {
                Clean.Background = new SolidColorBrush(Colors.Red);
                cleaned = 3;
            }
           else if (cleaned == 3)
            {
                Clean.Background = new SolidColorBrush(Colors.Gray);
                cleaned = 1;
            }




        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            if (cleaned == 1)
            {
                Clean.Background = new SolidColorBrush(Colors.DarkGray);
               
            }
            else if (cleaned == 2)
            {
                Clean.Background = new SolidColorBrush(Colors.DarkGreen);
               
            }
            else if (cleaned == 3)
            {
                Clean.Background = new SolidColorBrush(Colors.DarkRed);
              
            }



        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            if (cleaned == 1)
            {
                Clean.Background = new SolidColorBrush(Colors.Gray);
               
            }
            else if (cleaned == 2)
            {
                Clean.Background = new SolidColorBrush(Colors.Green);
               
            }
            else if (cleaned == 3)
            {
                Clean.Background = new SolidColorBrush(Colors.Red);
               
            }


        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void Border_MouseEnter_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0E9755"));
        }

        private void Border_MouseLeave_1(object sender, MouseEventArgs e)
        {
            add.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF66BB6A"));
        }

        private void Border_MouseEnter_2(object sender, MouseEventArgs e)
        {
            calender.Background= new SolidColorBrush(Colors.Black);
        }

        private void calender_MouseLeave(object sender, MouseEventArgs e)
        {
            calender.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF605C5C"));

        }
    }
    
}