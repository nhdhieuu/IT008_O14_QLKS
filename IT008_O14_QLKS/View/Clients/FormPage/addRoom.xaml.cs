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
    /// Interaction logic for addRoom.xaml
    /// </summary>
    public partial class addRoom : Window
    {
        public addRoom1 a;
        public string MAKH;
        public addRoom(string ID)
        {
            InitializeComponent();
            this.MAKH = ID;
            a = new addRoom1(this,MAKH);
            main_content.Content = a;
            

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

            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#F1F0E7"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

        }

        private void search_txt_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        public void chuyenview(string Roomname,Decimal PriceTong, string MAKH,addRoom1 ar)
        {
            img1.Visibility = Visibility.Collapsed;
            img2.Visibility = Visibility.Visible;
            search.Visibility = Visibility.Collapsed;
            search2.Visibility = Visibility.Collapsed;
            filter.Visibility=Visibility.Collapsed;
            Tieude.Text = "room information";
            AddRoom2 ar2 = new AddRoom2(Roomname, PriceTong, MAKH,ar);
            main_content.Content = ar2;
        }

        private void img2_MouseDown(object sender, MouseButtonEventArgs e)
        {

            img1.Visibility = Visibility.Visible;
            img2.Visibility = Visibility.Collapsed;
            search.Visibility = Visibility.Visible;
            search2.Visibility = Visibility.Visible;
            filter.Visibility = Visibility.Visible;
            Tieude.Text = "reserve";
           
            main_content.Content = a;
        }
    }
    
}
