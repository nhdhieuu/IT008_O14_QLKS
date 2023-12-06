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
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2;
using IT008_O14_QLKS.View.Manager.FormPage.room.sttroompage2.adjust;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for sttroompage.xaml
    /// </summary>
    public partial class sttroompage : Window

    {
        string cstt { get; set; }
        
        public sttroompage(string cstt)
        {

            InitializeComponent();
           
                        this.cstt=cstt;
             Load();
            roomcard2 a = new roomcard2();
            room.Content = a.Content;
            
        }
        private void Load()
        {
            if(cstt=="Unavailable")
            {
                cstt_txt.Text = "unavailable";
                cstt_bd.Background = new SolidColorBrush(Colors.DarkRed);
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
              unavailble a = new unavailble();
                stt2.Content = a.Content;
                //adj_bd.Height = 0;
            }
           else if (cstt == "Empty")
            {
                cstt_txt.Text = "empty";
                cstt_bd.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF00652E"));
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
               adjust a = new adjust(this.cstt);
                stt2.Content = a.Content;
               // adj_bd.Height = 0;
            }
            else  if (cstt == "Booked")
            {
                cstt_txt.Text = "booked";
                cstt_bd.Background = new SolidColorBrush(Colors.Blue);
                cstt_txt.Foreground = new SolidColorBrush(Colors.White);
                booked a = new booked();
                stt2.Content = a.Content;
                //adj_bd.Height = 0;
            }
            else
            {
                adjust a = new adjust(this.cstt);
                stt2.Content = a.Content;

            }


        }
        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void delbtn_border_MouseEnter(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            delbtn_text.Foreground = new SolidColorBrush(Colors.White);
        }

        private void delbtn_border_MouseLeave(object sender, MouseEventArgs e)
        {
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFE9E8E2"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void sttgrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
