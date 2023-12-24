using IT008_O14_QLKS.View.Manager.FormPage.room;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.RightsManagement;
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
    /// Interaction logic for RoomService.xaml
    /// </summary>
    public partial class RoomService : UserControl
    {
        int SL;
        string DV;
        Decimal Price;
        AddService AS;
        public RoomService(int sL, string dV, Decimal price, AddService AS)
        {
            InitializeComponent();
            SL = sL;
            DV = dV;
            Price  = Math.Truncate(price);
            this.SoLuong.Text = SL.ToString();
            this.Ten.Text = DV;
            this.Gia.Text = Price.ToString() + " VND";
            this.AS= AS;
        }

        private void Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AS.Them();
        }
    }
}
