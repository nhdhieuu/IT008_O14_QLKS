using IT008_O14_QLKS.View.Manager.FormPage.staff;
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
    /// Interaction logic for StaffCard.xaml
    /// </summary>

    /// 

    public partial class StaffCard : UserControl
    {
        /// Các thành phần của thẻ nhân viên
        string TenNV { get; set; }
        string Vitri { get; set; }  
        string MaNV { get;set; }

        public StaffCard(string manv, string name,string vitri)
        {
            this.TenNV = name;
            this.Vitri = vitri;
            this.MaNV = manv;
            InitializeComponent();
            manv_tbl.Text = manv;
            name_tbl.Text = name;
            postion_tbl.Text = vitri;
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            staffInfor SI = new staffInfor(MaNV);
            SI.ShowDialog();
            
        }
       
        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            bd_view.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F9F9393"));
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {

            bd_view.Background = null;
        }

      
    }
}
