using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.View.Manager.FormPage.room;
using IT008_O14_QLKS.View.Manager.Card.roomCardbackground;
using IT008_O14_QLKS.View.Manager.FormPage.room;
namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for roomcard.xaml
    /// </summary>
    public partial class roomcard : UserControl
    {
        public string IDroom { get; set; }
        public string typeroom { get; set; }
        public string status { get; set; }  
        
       
      public int time { get; set; }
        public string typetime { get; set; }
        public int numer_guest { get; set; }
        


        public roomcard(string IDroom, string typeroom, string status, string typetime, int number,  int time)
        {
            this.IDroom = IDroom;
            this.typeroom = typeroom;
            this.status = status;
            this.typetime = typetime;
            this.numer_guest = number;
            this.time = time;
            InitializeComponent();
            input();
        }

        private void Image_KeyDown(object sender, KeyEventArgs e)
        {

       
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void viewbd_MouseEnter(object sender, MouseEventArgs e)
        {
            viewbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF091E75"));
        }

        private void viewbd_MouseLeave(object sender, MouseEventArgs e)
        {
            viewbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0C2BAB"));
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            statusbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF725805"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {

            statusbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC6980A"));
        }
        public void input (  )
        {
            idroomtxt.Text = this.IDroom;
            loai.Text = this.typeroom;
            statustxt.Text = this.status;
            number_guesttxt.Text = this.numer_guest.ToString();
            if (this.typeroom=="Standard")
            {
                loai.Foreground = new SolidColorBrush(Colors.White);
            }
            if (this.status == "Booking")
            {
                mainbd.Background = new SolidColorBrush(Colors.Blue) ;
                statustxt.Foreground = new SolidColorBrush(Colors.White);
                idroomtxt.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (this.status == "Empty")
            {
                mainbd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
               idroomtxt.Foreground = new SolidColorBrush(Colors.White);
                statustxt.Foreground = new SolidColorBrush(Colors.White);
            }
            else if (this.status == "Unavailabl")
            {
                mainbd.Background = new SolidColorBrush(Colors.DarkRed);
                statustxt.Foreground = new SolidColorBrush(Colors.White);
                idroomtxt.Foreground = new SolidColorBrush(Colors.White);

            }    
                else {

               
                        if (this.typetime == "day")
                        {
                            if (this.time > 1)
                                numbertxt.Text = time.ToString() + " days";
                            else
                                numbertxt.Text = time.ToString() + " day";
                        }
                        if (this.typetime == "hour")
                        {
                            if (this.time > 1)
                                numbertxt.Text = time.ToString() + " hours";
                            else
                                numbertxt.Text = time.ToString() + " hour";
                        }
                      
                    }
            //chon nen

            if (this.typeroom == "Superior" || this.typeroom == "Deluxe" || this.typeroom == "Suite")
            {
                if (this.status == "Empty"||this.status == "Booking")
                {
                    Vip_empty vip = new Vip_empty();
                    background.Content = vip;
                }
                else
                {
                    VIP vip = new VIP();
                    background.Content = vip;
                }    
            }



            if (this.typeroom == "Standard")
            {
                if (this.status == "Empty" || this.status == "Booking")
                {
                    Normal_empty vip = new Normal_empty();
                    background.Content = vip;
                }
                else
                {
                    Normal vip = new Normal();
                    background.Content = vip;
                }
            }



        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Viewroom_form vr = new Viewroom_form(IDroom);
            vr.ShowDialog();
        }

        private void statusbd_MouseDown(object sender, MouseButtonEventArgs e)
        {
            sttroompage a = new sttroompage(this.status);
            a.ShowDialog();
        }
    }
    }

