﻿using System;
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
using IT008_O14_QLKS.View.Manager.FormPage.room;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for roomcard2.xaml
    /// </summary>
    public partial class roomcard2 : UserControl
    {
        public string TenPhong;
        public string Parents;
        public roomcard2()
        {
            InitializeComponent();
            
        }
      
        public roomcard2(string TenPhong, string Type, int SoNguoi, string Parents)
        {
            InitializeComponent();
            if (Type == "Standard")
            {
                StandardBG a = new StandardBG();
                background.Content = a.Content;
            }
            if (Type == "Superior")
            {
                SuperiorBG a = new SuperiorBG();
                background.Content = a.Content;
            }
            if (Type == "Deluxe")
            {
                DeluxeBG a = new DeluxeBG();
                background.Content = a.Content;
            }
            if (Type == "Suite")
            {
                SuiteBG a = new SuiteBG();
                background.Content = a.Content;
            }

            this.TenPhongTblx.Text = TenPhong;
            this.TenPhong = TenPhong;
            if(Type=="Standard")
                this.TypeTblx.Text = "STD";
            if (Type == "Superior")
                this.TypeTblx.Text = "SUP";
            if (Type == "Deluxe")
                this.TypeTblx.Text = "DLX";
            if (Type == "Suite")
                this.TypeTblx.Text = "SUT";
            this.SoNguoiTblx.Text = SoNguoi.ToString();
            this.Parents = Parents;
        }

       
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Parents != "RoomInfor" && Parents!="Client")
            {
                Viewroom_form vr = new Viewroom_form(TenPhong);
                vr.ShowDialog();
            }
        }
    }
}
