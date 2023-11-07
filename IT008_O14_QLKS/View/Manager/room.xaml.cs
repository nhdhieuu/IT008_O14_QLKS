using IT008_O14_QLKS.View.Manager.Card;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
            listCard[0]= new roomcard("P103", "Normal", "Booked", "day", 2, 2);
            listCard[1] = new roomcard("P102", "VIP", "Unavailable", "day", 2, 2);
            listCard[2] = new roomcard("P103", "Normal", "Trần Văn A", "hour", 2, 2);
            listCard[3] = new roomcard("P104", "VIP", "Empty", "day", 2, 2);
            listCard[4] = new roomcard("P105", "Normal", "Empty", "day", 2, 2);
            listCard[5] = new roomcard("P106", "Normal", "Nguyễn Thị B", "day", 2, 2);
          

            //

             
          
            cc11.Content = listCard[0].Content;
            cc21.Content = listCard[1].Content;
            cc12.Content = listCard[2].Content;
            cc22.Content = listCard[3].Content;
            cc13.Content = listCard[4].Content;
            cc23.Content = listCard[5].Content;
           


        }
    
        int cleaned = 1;
       

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
            
        }

        private void calender_MouseLeave(object sender, MouseEventArgs e)
        {
            

        }
        int type_s = 0;
        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            if(type_s == 0)
            {
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                type_s = 1;
                type.IsEnabled = true;
                sup.IsEnabled = true;
                standard.IsEnabled = true;
                VIP.IsEnabled = true;
                Dlx.IsEnabled = true;
                ck_type.Visibility = Visibility.Visible;
                bd_type.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                type_txt.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFC513"));


            }
            else
            {
                type.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                type_s = 0;
                
                type.IsEnabled = false;
                sup.IsEnabled = false;
                standard.IsEnabled = false;
                VIP.IsEnabled = false;
                Dlx.IsEnabled = false;
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                VIP.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                ck_type.Visibility = Visibility.Hidden;
                bd_type.BorderBrush = new SolidColorBrush(Colors.White);
                type_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFB78E10"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));

            }
        }
        int std = 0;
        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            if (std == 0)
            {
                standard.Background = new SolidColorBrush(Colors.WhiteSmoke);
                std = 1;
               
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));


            }
            else
            {
                standard.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
                standardt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
                std = 0;
            }
        }
        int sup1 = 0;
        private void Border_MouseDown_4(object sender, MouseButtonEventArgs e)
        {

            if (sup1 == 0)
            {
                sup.Background = new SolidColorBrush(Colors.WhiteSmoke);
                sup1 = 1;

                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));

            }
            else
            {
               sup.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

               sup1 = 0;
                supt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
        }
        int dlx1 = 0;
        private void Dlx_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (dlx1 == 0)
            {
                Dlx.Background = new SolidColorBrush(Colors.WhiteSmoke);
                dlx1 = 1;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));


            }
            else
            {
                Dlx.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));

                dlx1 = 0;
                Dlxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
        
        }
        int vip = 0;

        private void VIP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (vip == 0)
            {
                VIP.Background = new SolidColorBrush(Colors.WhiteSmoke);
              vip = 1;
                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD6A611"));


            }
            else
            {
               VIP.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#B2FFFFFF"));
vip = 0;

                VIPt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF797979"));
            }
        }

        int status_s = 0;
        private void bd_type_Copy1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(status_s==0)
            {
                ck_status.Visibility = Visibility.Visible;
                status_txt.Foreground = new SolidColorBrush(Colors.LightBlue);
                bd_status.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF22DC63"));
                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4E4B4B"));
                status_s = 1;
                rent_bd.IsEnabled = true;
            }
            else
            {
                stauts.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                status_s = 0;
                ck_status.Visibility = Visibility.Hidden;
                status_txt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF014E91"));
                bd_status.BorderBrush = new SolidColorBrush(Colors.White);
                rent_bd.IsEnabled = false;
            }
        }
        int rent = 0;
        private void rent_bd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(rent==0)
            {
                
                rent_bd.Background = new SolidColorBrush(Colors.Black);
                rent_t.Foreground = new SolidColorBrush(Colors.White);
                rent = 1;
            }
            else {
                rent_bd.Background = new SolidColorBrush(Colors.White);
                rent_t.Foreground = new SolidColorBrush(Colors.Black);
                rent = 0;
            }
        }
        int stage_s = 0;
    
        private void bd_stage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(stage_s==0)
            {
               
            }    
        }
    }
    
}