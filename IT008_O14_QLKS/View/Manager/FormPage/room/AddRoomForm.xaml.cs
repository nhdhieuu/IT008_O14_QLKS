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
    /// Interaction logic for AddRoomForm.xaml
    /// </summary>
    public partial class AddRoomForm : Window
    {
        public AddRoomForm()
        {
            InitializeComponent();
        }

        private void Close_Butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Close_Butt_MouseEnter(object sender, MouseEventArgs e)
        {
            Close_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
            CloseTXT.Foreground = new SolidColorBrush(Colors.White);
        }

        private void Close_Butt_MouseLeave(object sender, MouseEventArgs e)
        {
            Close_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFF1F0E7"));
            CloseTXT.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void Accept_Butt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //**********************
            this.Close();
        }

        private void Accept_Butt_MouseEnter(object sender, MouseEventArgs e)
        {
           Accept_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF685111"));
        }

        private void Accept_Butt_MouseLeave(object sender, MouseEventArgs e)
        {
            Accept_Butt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC6980A"));
        }

        private void add_buttt_MouseEnter(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF057832"));
        }

        private void add_buttt_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void add_buttt_MouseLeave(object sender, MouseEventArgs e)
        {
            add_buttt.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF27CF69"));
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
