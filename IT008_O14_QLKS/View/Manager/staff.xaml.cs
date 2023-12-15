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

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for staff.xaml
    /// </summary>
    public partial class staff : UserControl
    {
        List<StaffCard> stafflist;
        public staff()
        {
            InitializeComponent();
            stafflist = new List<StaffCard>();

            stafflist.Add(new StaffCard("Bui Trong Hoang Huy", "Le Tan", "NV001"));
            stafflist.Add(new StaffCard("Do Nguyen Hoang Huy", "Le Tan", "NV002"));
            stafflist.Add(new StaffCard("Pham Khai Hung", "Le Tan", "NV003"));
            stafflist.Add(new StaffCard("Phan Tran Tien Hung", "Phuc Vu", "NV004"));
            stafflist.Add(new StaffCard("Bui Thai Hoang", "Phuc Vu", "NV005"));
            stafflist.Add(new StaffCard("Ngo Duy Hung", "Phuc Vu", "NV006"));
            stafflist.Add(new StaffCard("Doan Quang Huy", "Phuc Vu", "NV007"));
            stafflist.Add(new StaffCard("To Hoang Huy", "Ve Sinh", "NV008"));
            stafflist.Add(new StaffCard("Nguyen Thi Lan", "Ve Sinh", "NV009"));
            stafflist.Add(new StaffCard("Le Thi Hoa", "Ve Sinh", "NV010"));
            stafflist.Add(new StaffCard("Pham Hoang Duy", "CSKH", "NV011"));
            stafflist.Add(new StaffCard("Nguyen Thi Hoa", "CSKh", "NV012"));

            ST01.Content = stafflist[0].Content;
            ST02.Content = stafflist[1].Content;
            ST03.Content = stafflist[2].Content;
            ST04.Content = stafflist[3].Content;
            ST05.Content = stafflist[4].Content;
            ST06.Content = stafflist[5].Content;
            ST07.Content = stafflist[6].Content;
            ST08.Content = stafflist[7].Content;
            ST09.Content = stafflist[8].Content;
            ST10.Content = stafflist[9].Content;
            ST11.Content = stafflist[10].Content;
            ST12.Content = stafflist[11].Content;


       
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            datelb.Content = DateTime.Now.ToString("MMM, dd, yyyy");
        }
    }
}
