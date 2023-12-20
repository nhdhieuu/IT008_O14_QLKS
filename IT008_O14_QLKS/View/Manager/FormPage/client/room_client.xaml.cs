using IT008_O14_QLKS.View.Clients.Card.Card_room;
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
using System.Xml.Linq;

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for room_client.xaml
    /// </summary>
    public partial class room_client : UserControl
    {
        public room_client()
        {
            InitializeComponent();
            load();
        }
        public void load()
        {
            stk.Children.Clear();

            ContentControl a = new ContentControl
            {
               
                Width = 693
            };
            Room_card_client b = new Room_card_client();

            a.Content = b;
            stk.Children.Add(a);

        }
    }
}
