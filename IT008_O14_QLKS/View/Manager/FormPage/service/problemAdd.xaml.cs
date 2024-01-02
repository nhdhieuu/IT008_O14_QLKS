using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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

namespace IT008_O14_QLKS.View.Manager.FormPage.service
{
    /// <summary>
    /// Interaction logic for problemAdd.xaml
    /// </summary>
    public partial class problemAdd : Window
    {
        DB_connection dB_Connection = new DB_connection();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
        public problemAdd()
        {
            InitializeComponent();
            try
            {
                String str = $"select top(1) MAPR from PROBLEM  order by MAPR DESC";
                adapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
                adapter.Fill(dataTable);
                string idLon = dataTable.Rows[0]["MAPR"].ToString();
                idLon = idLon.Substring(2);
                int soht = int.Parse(idLon);
                soht++;
                string sommoi = "PR" + soht.ToString();
                problemID.Text = sommoi;
            }
            catch { }
        }
        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void close_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void close_border_MouseEnter(object sender, MouseEventArgs e)
        {
            close_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));

            close_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
        }

        private void close_border_MouseLeave(object sender, MouseEventArgs e)
        {
            close_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E9E5D9"));

            close_text.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#740909"));
        }

        private void add_border_MouseEnter(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void add_border_MouseLeave(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void add_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(problemID.Text) ||  string.IsNullOrEmpty(problemName.Text) || string.IsNullOrEmpty(problemPrice.Text))
            {
                MessageBox.Show("Please complete all the information", "Notice");
            }
            else
            {
                // add problem to database here
                //
                MessageBox.Show("New problem has been added", "Notice");
                this.Close();
            }
        }
    }
}
