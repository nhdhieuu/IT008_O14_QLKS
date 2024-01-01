using IT008_O14_QLKS.View.Manager.FormPage.client;
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
using System.IO;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Windows.Threading;

namespace IT008_O14_QLKS.View.Manager.Card
{
    /// <summary>
    /// Interaction logic for ClientCard.xaml
    /// </summary>
    public partial class ClientCard: UserControl
    {
        public string name { get; set; }
        public string usrname
        {
            get; set;
        }
        public string id { get; set; }  
        public string cls { get; set; }


        public ClientCard(string name, string usrname, string id, string cls)
        {
            InitializeComponent();
            // SQL quy dịnh các thuộc tính từ id
            this.name = name;
            this.usrname = usrname;
            this.id = id;   
            this.cls = cls;

            //
            tentxt.ToolTip = name;
            //quy dinh background
            background();
            //
            //quy dinh cac yeu to khac
            yeuto();
            //
        }
      
        private void bd_view_MouseEnter(object sender, MouseEventArgs e)
        {
            bd_view.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F9F9393"));
        }

        private void bd_view_MouseLeave(object sender, MouseEventArgs e)
        {
            bd_view.Background=null;
        }
        private void background()
        {
            string truepath = "";
            string currentFolderPath = AppDomain.CurrentDomain.BaseDirectory.ToString();
          
            string[] parts = currentFolderPath.Split('\\');
            for (int i = 0; i < parts.Length ; i++)
            {
                if(parts[i]!="Debug"&& parts[i]!="bin")
                truepath += parts[i] + "/";
            }


         


        }
        private void yeuto()
        {
            if(cls=="Gold")
            {

                idtxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFBEAD0C"));
            }
            if (cls == "Platinum")
            {

                idtxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0D7654"));

                cls = "Plat";
                
            }
            if (cls == "Diamond")
            {
               
                idtxt.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF460C84"));
               
                cls = "Dia";

            }
            tentxt.Text = name;
            usrtxt.Text = usrname;
            idtxt.Text = cls + "#" + id;

        }

        private void bd_view_MouseDown(object sender, MouseButtonEventArgs e)
        {
            client_view a = new client_view(id);
            a.ShowDialog();
        }
    }
}
