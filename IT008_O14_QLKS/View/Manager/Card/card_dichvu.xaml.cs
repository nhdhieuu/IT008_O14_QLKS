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

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for card_dichvu.xaml
    /// </summary>
    public partial class card_dichvu : UserControl
    {
        public string name;
        public string ID;
        public string price;
        public card_dichvu(string id, string name, string price)
        {
            this.name = name;
            this.ID = id;
            this.price = price;
            InitializeComponent();
            this.nametbx.Text = this.name;
            this.idtbx.Text = this.ID;
            this.pricetbx.Text = this.price;
        }
    }
}
