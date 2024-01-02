using IT008_O14_QLKS.Connection_db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for problemInfor.xaml
    /// </summary>
    public partial class problemInfor : Window
    {
        DB_connection dB_Connection= new DB_connection();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
        public problemInfor(string id)
        {
            InitializeComponent();
            String str = $"select * from PROBLEM where MAPR='{id}'";
            adapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
            adapter.Fill(dataTable);
            problemID.Text = dataTable.Rows[0]["MAPR"].ToString();
            problemName.Text = dataTable.Rows[0]["PRNAME"].ToString();
            string price = dataTable.Rows[0]["PRICE"].ToString();
            bool pp = double.TryParse(price, out double real_price);
            if (pp)
            {
                if (real_price == 0)
                {
                    price = "free";
                }
                else
                {
                    price = real_price.ToString();
                }

            }
            problemPrice.Text = price;
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
        private void adjust_border_MouseEnter(object sender, MouseEventArgs e)
        {
            adjust_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void adjust_border_MouseLeave(object sender, MouseEventArgs e)
        {
            adjust_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void adjust_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (adjust_lb.Content.ToString() == "save")
            {
                if (string.IsNullOrEmpty(problemID.Text)  || string.IsNullOrEmpty(problemName.Text) || string.IsNullOrEmpty(problemPrice.Text))
                {
                    MessageBox.Show("Please complete all the information", "Notice");
                }
                else
                {
                    /* add database code here */
                    try
                    {
                        string sql = $"UPDATE PROBLEM SET PRNAME='{problemName.Text}',PRICE='{problemPrice.Text}'," +
                           $"where MAPR='{problemID.Text}' ";
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = sql;
                        sqlCommand.Connection = dB_Connection.sqlCon;
                        sqlCommand.ExecuteNonQuery();


                        MessageBox.Show("Saved", "Notice");
                    }
                    catch
                    {
                        MessageBox.Show("Lỗi xảy ra.", "Error");
                    }
                    problemID.IsEnabled = false;
                    problemName.IsEnabled = false;
                    problemPrice.IsEnabled = false;
                    adjust_lb.Content = "adjust";
                }
            }
            else if (adjust_lb.Content.ToString() == "adjust")
            {
              
                problemName.IsEnabled = true;
                problemPrice.IsEnabled = true;
                adjust_lb.Content = "save";
            }
        }

        private void del_border_MouseEnter(object sender, MouseEventArgs e)
        {
            del_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void del_border_MouseLeave(object sender, MouseEventArgs e)
        {
            del_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#BF0B0B"));
        }

        private void del_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult boxResult= MessageBox.Show("Do you want to delete this problem?", "Notice",MessageBoxButton.YesNo);
            if(boxResult == MessageBoxResult.Yes)
            {
                // code delete problem from database

                try
                {
                    string sql = $"DELETE FROM PROBLEM WHERE MAPR='{problemID.Text}' ";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = dB_Connection.sqlCon;
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Problem has been deleted.", "Notice");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Can not delete this problem.", "Error");
                }

                
            }
            
        }
    }
}

