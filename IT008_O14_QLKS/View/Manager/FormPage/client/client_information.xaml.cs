﻿using IT008_O14_QLKS.View.Manager.Card.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

namespace IT008_O14_QLKS.View.Manager.FormPage.client
{
    /// <summary>
    /// Interaction logic for client_information.xaml
    /// </summary>
    public partial class client_information : UserControl
    {
        string strCon= Properties.Settings.Default.strcon;
     
        SqlConnection sqlCon = null;
        public string ID { get; set; }
        DateTime now = DateTime.Now;
       
        public client_information(string ID)
        {
        
            InitializeComponent();
            
            client_class_card cls_card = new client_class_card(ID);
            cls_Card.Content = cls_card;
            this.ID = ID;

            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();

            }
            load();
            
        }
        private void load()
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"select * from KHACHHANG where MAKH='{ID}'";
            sqlcmd.Connection = sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read()) // Kiểm tra xem có dữ liệu hay không
                {
                    id.Text = reader.GetString(0);
                    ten.Text = reader.GetString(1);
                    usrname.Text = reader.GetString(2);
                  
                    cccd.Text = reader.GetString(4);
                    phone.Text = reader.GetString(5);
                    DateTime birthdayValue = reader.GetDateTime(6);
                    string formattedBirthday = birthdayValue.ToString("dd/MM/yyyy");
                    birthday.Text = formattedBirthday;

                    if (reader.GetString(7) == "Nam")
                    {
                        gender.Text = "Male";
                    }
                    else
                    {
                        gender.Text = "Female";
                    }
                }
            }

          reader.Close();
           
            string a = now.ToString();

            string[] str = a.Split('/');
            string trueday = str[1] + "-" + str[0] + "-" + str[2];

            string query = $"SELECT COUNT(*) FROM THUEPHONG WHERE MAKH = '{ID}' AND '{trueday}'< NGAYKT AND KQUATHUE='Thanh Cong'";

            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
               nor.Text = ((int)command.ExecuteScalar()).ToString();
                
            }
             query = $"SELECT COUNT(*) FROM THUEPHONG WHERE MAKH = '{ID}' AND KQUATHUE='Thanh Cong'";

            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
                tor.Text = ((int)command.ExecuteScalar()).ToString();

            }
            query = $"SELECT SUM(TONGTIEN) FROM HOADON WHERE MAKH = '{ID}'";

            using (SqlCommand command = new SqlCommand(query, sqlCon))
            {
               
                    int moneyFromDatabase = (int)command.ExecuteScalar();



                if (moneyFromDatabase > 0)
                    monney.Text = moneyFromDatabase.ToString("#,###") + " VND";
                else
                    monney.Text = "0 VND";





            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DependencyObject parent = VisualTreeHelper.GetParent(this);
             while (!(parent is Window) && parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            if (parent is client_view  window)
            {
                window.doi_view();
            }
            
        }

        private void Border_MouseDown_1(object sender, MouseButtonEventArgs e)
        {

            DependencyObject parent = VisualTreeHelper.GetParent(this);
            while (!(parent is Window) && parent != null)
            {
                parent = VisualTreeHelper.GetParent(parent);
            }

            if (parent is client_view window)
            {
                window.doi_view2();
            }
        }
    }
}
