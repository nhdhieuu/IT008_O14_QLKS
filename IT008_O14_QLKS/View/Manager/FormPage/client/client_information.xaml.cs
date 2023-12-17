using IT008_O14_QLKS.View.Manager.Card.Client;
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

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for client_information.xaml
    /// </summary>
    public partial class client_information : UserControl
    {
        public client_information()
        {
            InitializeComponent();
            client_class_card cls_card =new client_class_card();
            cls_Card.Content = cls_card;
        }
    }
}
