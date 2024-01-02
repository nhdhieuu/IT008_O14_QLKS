﻿using IT008_O14_QLKS.Connection_db;
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
    /// Interaction logic for serviceInfor.xaml
    /// </summary>
    public partial class serviceInfor : Window
    {
        DB_connection dB_Connection = new DB_connection();
        SqlDataAdapter adapter;
        DataTable dataTable = new DataTable();
      
        public serviceInfor(string id)
        {
            InitializeComponent();
            String str = $"select * from DICHVU where MADV='{id}'";
            adapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
            adapter.Fill(dataTable);
            serviceID.Text = dataTable.Rows[0]["MADV"].ToString();
            serviceName.Text = dataTable.Rows[0]["TENDV"].ToString();
            string price = dataTable.Rows[0]["DONGIA"].ToString();
            serviceAmount.Text = dataTable.Rows[0]["SOLUONG"].ToString();
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
            servicePrice.Text = price;

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
                if (string.IsNullOrEmpty(serviceID.Text) || string.IsNullOrEmpty(serviceAmount.Text) || string.IsNullOrEmpty(serviceName.Text) || string.IsNullOrEmpty(servicePrice.Text))
                {
                    MessageBox.Show("Please complete all the information", "Notice");
                }
                else
                {
                    /* add database code here */

                    try
                    {




                        string sql = $"UPDATE DICHVU SET TENDV='{serviceName.Text}',DONGIA='{servicePrice.Text}',SOLUONG='{serviceAmount.Text}'" +
                        $"where MADV='{serviceID.Text}' ";
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.CommandText = sql;
                        sqlCommand.Connection = dB_Connection.sqlCon;
                        sqlCommand.ExecuteNonQuery();

                        MessageBox.Show("Saved", "Notice");
                        serviceID.IsEnabled = false;
                        serviceAmount.IsEnabled = false;
                        serviceName.IsEnabled = false;
                        servicePrice.IsEnabled = false;
                        adjust_lb.Content = "adjust";


                    }
                    catch
                    {
                        MessageBox.Show("Đã xảy ra lỗi.\nVui lòng kiểm tra lại thông tin.", "NOTICE");
                    }
                }
            }
            else if (adjust_lb.Content.ToString() == "adjust")
            {
                
                serviceAmount.IsEnabled = true;
                serviceName.IsEnabled = true;
                servicePrice.IsEnabled = true;
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
            MessageBoxResult boxResult = MessageBox.Show("Do you want to delete this service?", "Notice", MessageBoxButton.YesNo);
            if (boxResult == MessageBoxResult.Yes)
            {
                // code delete service from database

                try
                {
                    string sql = $"DELETE FROM DICHVU WHERE MADV='{serviceID.Text}' ";
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandText = sql;
                    sqlCommand.Connection = dB_Connection.sqlCon;
                    sqlCommand.ExecuteNonQuery();

                    MessageBox.Show("Service has been deleted.", "Notice");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Can not delete this service.", "Error");
                }
            }

        }
    }
}
