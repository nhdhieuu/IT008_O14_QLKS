using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Clients.Card.Card_room
{
    /// <summary>
    /// Interaction logic for Room_card_client.xaml
    /// </summary>
    public partial class Room_card_client : UserControl
    {
        public Room_card_client()
        {
            InitializeComponent();
            xoa.Visibility = Visibility.Collapsed;
            card.Content = new roomcard2();
        
            bd.CornerRadius = new CornerRadius(10, 10, 10, 10);
 
        }
        private bool isRotated = true;
        private void OnBorderMouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void myBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation rotateAnimation = new DoubleAnimation();

            if (isRotated)
            {
                rotateAnimation.To = 180;
                xoa.Visibility = Visibility.Visible;

                bd.CornerRadius = new CornerRadius(10, 10, 0, 0);
            }
            else
            {
                  rotateAnimation.To = 0;
                xoa.Visibility = Visibility.Collapsed;
                bd.CornerRadius = new CornerRadius(10, 10, 10, 10);
            


            }

            rotateAnimation.Duration = TimeSpan.FromSeconds(0.3);

            myBorder.RenderTransformOrigin = new Point(0.5, 0.5);
            RotateTransform rotateTransform = new RotateTransform();
            myBorder.RenderTransform = rotateTransform;

            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

            isRotated = !isRotated;
        }
    }
}
