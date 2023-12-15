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
    /// Interaction logic for notice.xaml
    /// </summary>
    public partial class notice : UserControl
    {
        public List<NoticeCard> noticeCards;
        public notice()
        {
            InitializeComponent();
             
            noticeCards = new List<NoticeCard>();
            

        }

        private void send_but_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(notice_context.Text))
            {
                NoticeCard noticeCard= new NoticeCard(notice_context.Text);
                noticeCards.Add(noticeCard);
                Notice_list.Children.Add(noticeCard);
            }
                if (noticeCards.Count > 0)
            {
                for(int i = 0; i < noticeCards.Count; i++)
                {

                    Notice_list.Children[i]= noticeCards[i];
                }
            }
        }
    }
}
