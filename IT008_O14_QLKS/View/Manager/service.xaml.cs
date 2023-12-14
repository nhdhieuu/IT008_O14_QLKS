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
    /// Interaction logic for service.xaml
    /// </summary>
    public partial class service : UserControl
    {
        public service()
        {
            InitializeComponent();
            ServiceCard[] SC = new ServiceCard[10];

            ProbBlemCard[] PC =new ProbBlemCard[10];
            SC[0] = new ServiceCard("Maria Ozawa", "19/11/2023", "2M");
            SC[1] = new ServiceCard("Takizawa ", "18/11/2023", "1M");
            SC[2] = new ServiceCard("Jun Aizawa", "17/11/2023", "600k");
            SC[3] = new ServiceCard("Megu Fujiura", "20/11/2023", "1.5M");
            SC[4] = new ServiceCard("Sakurai", "19/11/2023", "550k");
            SC[5] = new ServiceCard("Utsunomiya", "20/11/2023", "650k");
            SC[6] = new ServiceCard("Momotani", "20/11/2023", "500k");
            SC[7] = new ServiceCard("Saori Hara", "19/11/2023", "400k");
            SC[8] = new ServiceCard("Leah Dizon", "18/11/2023", "900k");
            SC[9] = new ServiceCard("Noyomi", "19/11/2023", "200k");

            CC1.Content = SC[0].Content;
            CC2.Content = SC[1].Content;
            CC3.Content = SC[2].Content;
            CC4.Content = SC[3].Content;
            CC5.Content = SC[4].Content;
            CC6.Content = SC[5].Content;
            CC7.Content = SC[6].Content;
            CC8.Content = SC[7].Content;
            CC9.Content = SC[8].Content;
            CC10.Content = SC[9].Content;

            PC[0] = new ProbBlemCard("PR01", "repair", "200k");
            PC[1] = new ProbBlemCard("PR02", "repair", "200k");
            PC[2] = new ProbBlemCard("PR03", "repair", "200k");
            PC[3] = new ProbBlemCard("PR04", "repair", "200k");
            PC[4] = new ProbBlemCard("PR05", "repair", "200k");
            PC[5] = new ProbBlemCard("PR06", "repair", "200k");
            PC[6] = new ProbBlemCard("PR07", "repair", "200k");
            PC[7] = new ProbBlemCard("PR08", "repair", "200k");
            PC[8] = new ProbBlemCard("PR09", "repair", "200k");
            PC[9] = new ProbBlemCard("PR10", "repair", "200k");

            PC1.Content = PC[0].Content;
            PC2.Content = PC[1].Content;
            PC3.Content = PC[2].Content;
            PC4.Content = PC[3].Content;
            PC5.Content = PC[4].Content;
            PC6.Content = PC[5].Content;
            PC7.Content = PC[6].Content;
            PC8.Content = PC[7].Content;
            PC9.Content = PC[8].Content;
            PC10.Content = PC[9].Content;
        }
    }
}
