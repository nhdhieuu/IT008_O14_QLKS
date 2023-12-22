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


namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for client_view.xaml
    /// </summary>
    public partial class client_view : Window
    {
        string id;
        public client_view(string id)
        {
            this.id = id;
            InitializeComponent();
            client_information  mainview=new client_information(id);
            content.Content=mainview;
            
        }
      public void doi_view()
        {
            room_client mainview = new room_client(id);
            content.Content = mainview;
            bd1.Background = new SolidColorBrush(Colors.Transparent);
            bd2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDBD9CD"));
            bd3.Background = new SolidColorBrush(Colors.Transparent);
        }
         public void doi_view2()
        {
            receipt_client mainview = new receipt_client();
            content.Content = mainview;
            bd1.Background = new SolidColorBrush(Colors.Transparent);
            bd2.Background = new SolidColorBrush(Colors.Transparent);
            bd3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDBD9CD"));
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
            
            delbtn_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF96958A"));
            delbtn_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Border_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            client_information mainview = new client_information(id);
            content.Content = mainview;
            bd1.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDBD9CD"));
            bd2.Background= new SolidColorBrush(Colors.Transparent);
            bd3.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Border_MouseDown_3(object sender, MouseButtonEventArgs e)
        {
            room_client mainview = new room_client(id);
            content.Content = mainview;
            bd1.Background = new SolidColorBrush(Colors.Transparent);
            bd2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDBD9CD"));
            bd3.Background = new SolidColorBrush(Colors.Transparent);
        }

        private void Border_MouseDown_4(object sender, MouseButtonEventArgs e)
        {
            receipt_client mainview = new receipt_client();
            content.Content = mainview;
            bd1.Background = new SolidColorBrush(Colors.Transparent);
            bd2.Background = new SolidColorBrush(Colors.Transparent);
            bd3.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDBD9CD"));
        }
    }
}
