using IT008_O14_QLKS.View.Clients.Card.Card_room;
using IT008_O14_QLKS.View.Manager.FormPage.room;
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

namespace IT008_O14_QLKS.View.Clients.FormPage
{
    /// <summary>
    /// Interaction logic for add_SV_PR.xaml
    /// </summary>
    public partial class add_SV_PR : Window
    {
        string matp;
        Room_card_client room;
        public add_SV_PR( ref string matp, Room_card_client rc)
        {
            InitializeComponent();
            this.matp = matp;
            this.room = rc;
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            room.reset();

                        this.Close();

        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
          
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
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

            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD4D4D4"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
      
            AddService a = new AddService(matp,this);
            this.Visibility = Visibility.Collapsed;
            a.ShowDialog();
            
        }

        private void Border_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            AddProblem a=new AddProblem(matp,this);
            this.Visibility = Visibility.Collapsed;
            a.ShowDialog();
        }
    }
}
