using IT008_O14_QLKS.View.Clients.FormPage;
using IT008_O14_QLKS.View.Manager.Card.roomCardbackground;
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

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for RoomCardThue.xaml
    /// </summary>
    public partial class RoomCardThue : UserControl
    {
        public string IDRoom;
        public string Type;
        public int Guest;
        public Decimal PriceGio;
        public Decimal PriceNgay;
        public Decimal PriceTong;
        public addRoom1 ar;
        public RoomCardThue(string IDRoom, string Type, int Guest, Decimal PriceGio, Decimal PriceNgay, addRoom1 ar)
        {
            InitializeComponent();
            this.IDRoom = IDRoom;
            this.Type = Type;
            this.Guest = Guest;
            this.PriceGio = PriceGio;
            this.PriceNgay = PriceNgay;
            this.idroomtxt.Text = IDRoom;
            this.loai.Text = Type;
            this.number_guesttxt.Text=Guest.ToString();
            this.ar=ar;
            
            TimeSpan diff = (DateTime)ar.to.Value - (DateTime)ar.from.Value;
            int distance = diff.Days;
            if(distance < 1)
            {
                PriceTong = (Math.Truncate(PriceGio) * diff.Hours);
                this.tonggia.Text = PriceTong.ToString()+" VND";
            }
            else
            {
                PriceTong = (Math.Truncate(PriceNgay) * diff.Days);
                this.tonggia.Text = PriceTong.ToString() + " VND";

            }
            //this.tonggia.Text = Math.Truncate(Price).ToString()+" VND";

            if (this.Type == "Standard")
            {
                StandardBG bg = new StandardBG();
                this.loai.Foreground= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9B9B9B"));
                background.Content = bg;
            }
            if (this.Type == "Superior")
            {
                SuperiorBG bg = new SuperiorBG();
                this.loai.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF9B9B9B"));
                background.Content = bg;
            }
            if (this.Type == "Deluxe")
            {
                DeluxeBG bg = new DeluxeBG();
                background.Content = bg;
            }
            if (this.Type == "Suite")
            {   
                SuiteBG bg = new SuiteBG();
                background.Content = bg;
            }

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ar.ar.chuyenview(IDRoom, PriceTong, ar.MAKH, ar);
        }
    }
}
