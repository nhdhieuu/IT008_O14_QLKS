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
    /// Interaction logic for ProbBlemCard.xaml
    /// </summary>
    public partial class ProbBlemCard : UserControl
    {
        public string name;
        public string date;
        public string price;
        public ProbBlemCard(string name, string date, string price)
        {
            this.name = name;
            this.date = date;
            this.price = price;
            InitializeComponent();
            Inputt();
        }
        public void Inputt()
        {
            this.nametbx.Text = this.name;
            this.datetbx.Text = this.date;
            this.pricetbx.Text = this.price;
        }
    }
}
