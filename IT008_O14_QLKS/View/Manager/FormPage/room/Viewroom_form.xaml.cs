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
using System.Windows.Shapes;

namespace IT008_O14_QLKS.View.Manager.FormPage.room
{
    /// <summary>
    /// Interaction logic for Viewroom_form.xaml
    /// </summary>
    public partial class Viewroom_form : Window
    {
        public Viewroom_form(string IDroom)
        {
            InitializeComponent();
            ServiceCard [] SC=new ServiceCard[10];
            ServiceCard[] SCa = new ServiceCard[10];
            ProbBlemCard[] PC= new ProbBlemCard[10];
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


            SCa[0] = new ServiceCard("Maria Ozawa", "19/11/2023", "2M");
            SCa[1] = new ServiceCard("Takizawa ", "18/11/2023", "1M");
            SCa[2] = new ServiceCard("Jun Aizawa", "17/11/2023", "600k");
            SCa[3] = new ServiceCard("Megu Fujiura", "20/11/2023", "1.5M");
            SCa[4] = new ServiceCard("Sakurai", "19/11/2023", "550k");
            SCa[5] = new ServiceCard("Utsunomiya", "20/11/2023", "650k");
            SCa[6] = new ServiceCard("Momotani", "20/11/2023", "500k");
            SCa[7] = new ServiceCard("Saori Hara", "19/11/2023", "400k");
            SCa[8] = new ServiceCard("Leah Dizon", "18/11/2023", "900k");
            SCa[9] = new ServiceCard("Noyomi", "19/11/2023", "200k");

            PC[0] = new ProbBlemCard("Maria Ozawa", "19/11/2023", "2M");
            PC[1] = new ProbBlemCard("Takizawa ", "18/11/2023", "1M");
            PC[2] = new ProbBlemCard("Jun Aizawa", "17/11/2023", "600k");
            PC[3] = new ProbBlemCard("Megu Fujiura", "20/11/2023", "1.5M");
            PC[4] = new ProbBlemCard("Sakurai", "19/11/2023", "550k");
            PC[5] = new ProbBlemCard("Utsunomiya", "20/11/2023", "650k");
            PC[6] = new ProbBlemCard("Momotani", "20/11/2023", "500k");
            PC[7] = new ProbBlemCard("Saori Hara", "19/11/2023", "400k");
            PC[8] = new ProbBlemCard("Leah Dizon", "18/11/2023", "900k");
            PC[9] = new ProbBlemCard("Noyomi", "19/11/2023", "200k");

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
            
            CCa1.Content = SCa[0].Content;
            CCa2.Content = SCa[1].Content;
            CCa3.Content = SCa[2].Content;
            CCa4.Content = SCa[3].Content;
            CCa5.Content = SCa[4].Content;
            CCa6.Content = SCa[5].Content;
            CCa7.Content = SCa[6].Content;
            CCa8.Content = SCa[7].Content;
            CCa9.Content = SCa[8].Content;
            CCa10.Content = SCa[9].Content;

            CCb1.Content = PC[0].Content;
            CCb2.Content = PC[1].Content;
            CCb3.Content= PC[2].Content;
            CCb4.Content = PC[3].Content;
            CCb5.Content = PC[4].Content;
            CCb6.Content = PC[5].Content;
            CCb7.Content = PC[6].Content;
            CCb8.Content   = PC[7].Content;
            CCb9.Content = PC[8].Content;
            CCb10.Content = PC[9].Content;  



        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ViewRoomWD.Close();
        }

        private void Border_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            CLoseTXT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Border_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseBD.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
            CLoseTXT.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void ViewRoomWD_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void add_butt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_butt.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));
        }

        private void add_butt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));
        }

        private void add_buttt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void add_buttt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));

        }

        private void add_buttt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));

        }
    }
}
