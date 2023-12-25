using IT008_O14_QLKS.View.Manager.FormPage.service;
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
        public string id;
        public string price;
        public event EventHandler problemDialogClosed;
        public ProbBlemCard(string id, string name, string price)
        {
            this.name = name;
            this.id = id;
            this.price = price;
            InitializeComponent();
            Inputt();
        }
        public void Inputt()
        {
            this.nametbx.Text = this.name;
            this.idtbx.Text = this.id;
            this.pricetbx.Text = this.price;
        }
        private void detail_but_MouseDown(object sender, MouseButtonEventArgs e)
        {
            problemInfor pi = new problemInfor(this.id);
            pi.Closed += Pi_Closed;
            pi.ShowDialog();
        }

        private void Pi_Closed(object sender, EventArgs e)
        {
            problemDialogClosed?.Invoke(this, EventArgs.Empty);
        }
    }
}

