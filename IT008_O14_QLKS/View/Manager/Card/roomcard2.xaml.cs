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
using IT008_O14_QLKS.View.Manager.Card.roomCardbackground;
namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for roomcard2.xaml
    /// </summary>
    public partial class roomcard2 : UserControl
    {
        public roomcard2()
        {
            InitializeComponent();
            Vip_empty  a = new Vip_empty();
            background.Content = a.Content;

        }
    }
}
