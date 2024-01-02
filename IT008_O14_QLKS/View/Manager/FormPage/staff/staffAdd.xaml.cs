using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.FormPage.service;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace IT008_O14_QLKS.View.Manager.FormPage.staff
{
    /// <summary>
    /// Interaction logic for staffAdd.xaml
    /// </summary>
    public partial class staffAdd : Window
    {
        DB_connection dB_Connection = new DB_connection();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
        public staffAdd()
        {
            InitializeComponent();
            try
            {
                String str = $"select top(1) MANV from NHANVIEN  order by MANV DESC";
                adapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
                adapter.Fill(dataTable);
                string idLon = dataTable.Rows[0]["MANV"].ToString();
                idLon = idLon.Substring(2);
                int soht = int.Parse(idLon);
                soht++;
                string sommoi = "NV" + soht.ToString();
                staffID.Text = sommoi;
            }
            catch { }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

 
        private void add_border_MouseEnter(object sender, MouseEventArgs e)
        {
            add_border.Background=new SolidColorBrush((Color)ColorConverter.ConvertFromString("#000000"));
        }

        private void add_border_MouseLeave(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));
        }

        private void add_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (string.IsNullOrEmpty(staffID.Text) || string.IsNullOrEmpty(staffName.Text) || string.IsNullOrEmpty(staffPhone.Text)||string.IsNullOrEmpty(staffCCCD.Text)
                ||string.IsNullOrEmpty(staffPostion.Text)||string.IsNullOrEmpty(staffGender.Text)||string.IsNullOrEmpty(staffBirthday.Text)) 
            {
                MessageBox.Show("Please complete all information", "Notice");
            }
            else
            {
                try
                {
                    // add to database
                    string sql = "INSERT INTO NHANVIEN VALUES " +
                        $"('{staffID.Text}','{staffName.Text}','{staffCCCD}','{staffPhone.Text}','{staffBirthday.Text}','{staffGender.Text}','{staffPostion.Text}')";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = dB_Connection.sqlCon;
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("New staff has been added", "Notice");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Can not add new staff.", "Notice");
                }
            }
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
    }
}
