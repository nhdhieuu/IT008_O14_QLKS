using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage.service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for service.xaml
    /// </summary>
    public partial class service : UserControl
    {
        DB_connection db = new DB_connection();
        private int isAV=0;
        private int isFree=0 ;
        public service()
        {
            InitializeComponent();
            string ss = "select * from DICHVU order by MADV";
            SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string name = dataTable.Rows[i]["TENDV"].ToString();
                string id = dataTable.Rows[i]["MADV"].ToString();
                string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                card_dichvu cd = new card_dichvu(id, name, price);
                cd.cardDialogClosed += Cd_cardDialogClosed;
                ds_dichvu.Children.Add(cd);
            }

            DataTable dataTable1 = new DataTable();
            ss = "select * from PROBLEM order by MAPR";
            da = new SqlDataAdapter(ss, db.sqlCon);
            da.Fill(dataTable1);
            for (int i = 0; i < dataTable1.Rows.Count; i++)
            {
                string name = dataTable1.Rows[i]["PRNAME"].ToString();
                string id = dataTable1.Rows[i]["MAPR"].ToString();
                string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                ProbBlemCard pc = new ProbBlemCard(id, name, price);
                pc.problemDialogClosed += Pc_problemDialogClosed;
                ds_problem.Children.Add(pc);
            }


        }
        // sau khi problem Infor đóng
        private void Pc_problemDialogClosed(object sender, EventArgs e)
        {
            try
            {
                ds_problem.Children.Clear();
                DataTable dataTable1 = new DataTable();
                string ss = "select * from PROBLEM order by MAPR";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                da.Fill(dataTable1);
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    string name = dataTable1.Rows[i]["PRNAME"].ToString();
                    string id = dataTable1.Rows[i]["MAPR"].ToString();
                    string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                    ProbBlemCard pc = new ProbBlemCard(id, name, price);
                    pc.problemDialogClosed += Pc_problemDialogClosed;
                    ds_problem.Children.Add(pc);
                }
            }
            catch { }
        }
        // sau khi service Infor đóng
        private void Cd_cardDialogClosed(object sender, EventArgs e)
        {
            try
            {
                ds_dichvu.Children.Clear();
                string ss = "select * from DICHVU order by MADV";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i]["TENDV"].ToString();
                    string id = dataTable.Rows[i]["MADV"].ToString();
                    string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                    card_dichvu cd = new card_dichvu(id, name, price);
                    cd.cardDialogClosed += Cd_cardDialogClosed;
                    ds_dichvu.Children.Add(cd);
                }
            }
            catch { }
        }
        // nút thêm service
        private void but_add_service_MouseDown(object sender, MouseButtonEventArgs e)
        {
            serviceAdd sa = new serviceAdd();
            sa.Closed += Sa_Closed;
            sa.ShowDialog();
        }
        // nút thêm problem
        private void but_add_problem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            problemAdd pa = new problemAdd();
            pa.Closed += Pa_Closed;
            pa.ShowDialog();
        }
        //sau khi thêm service đóng
        private void Sa_Closed(object sender, EventArgs e)
        {
            try
            {
                ds_dichvu.Children.Clear();
                string ss = "select * from DICHVU order by MADV";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i]["TENDV"].ToString();
                    string id = dataTable.Rows[i]["MADV"].ToString();
                    string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                    card_dichvu cd = new card_dichvu(id, name, price);
                    cd.cardDialogClosed += Cd_cardDialogClosed;
                    ds_dichvu.Children.Add(cd);
                }
            }
            catch { }
        }
        // sau khi thêm problem đóng
        private void Pa_Closed(object sender, EventArgs e)
        {
            try
            {
                ds_problem.Children.Clear();
                DataTable dataTable1 = new DataTable();
                string ss = "select * from PROBLEM order by MAPR";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                da.Fill(dataTable1);
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    string name = dataTable1.Rows[i]["PRNAME"].ToString();
                    string id = dataTable1.Rows[i]["MAPR"].ToString();
                    string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                    ProbBlemCard pc = new ProbBlemCard(id, name, price);
                    pc.problemDialogClosed += Pc_problemDialogClosed;
                    ds_problem.Children.Add(pc);
                }
            }
            catch { }
        }
        // tìm dịch vụ
        private void search_card_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(search_card.Text))
                {
                    try
                    {
                        ds_dichvu.Children.Clear();
                        string ss;
                        if (aval_filter.IsChecked == true)
                        {
                            if (isAV==1)
                                ss = $"select * from DICHVU where (MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%') and SOLUONG>0 order by MADV";
                            else if (isAV==-1)
                                ss = $"select * from DICHVU where (MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%') and SOLUONG=0 order by MADV";
                            else ss = $"select * from DICHVU where MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%' order by MADV";
                        }
                        else
                            ss = $"select * from DICHVU where MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%' order by MADV";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string name = dataTable.Rows[i]["TENDV"].ToString();
                            string id = dataTable.Rows[i]["MADV"].ToString();
                            string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                            card_dichvu cd = new card_dichvu(id, name, price);
                            cd.cardDialogClosed += Cd_cardDialogClosed;
                            ds_dichvu.Children.Add(cd);
                        }
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        ds_dichvu.Children.Clear();
                        string ss;
                        if (aval_filter.IsChecked == true)
                        {
                            if (isAV==1)
                                ss = $"select * from DICHVU where (MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%') and  SOLUONG>0 order by MADV";
                            else if(isAV==-1)
                                ss = $"select * from DICHVU where (MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%') and SOLUONG=0 order by MADV";
                            else ss = $"select * from DICHVU where MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%' order by MADV";
                        }
                        else
                            ss = $"select * from DICHVU where MADV='{search_card.Text}' or TENDV LIKE '%{search_card.Text}%' order by MADV";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string name = dataTable.Rows[i]["TENDV"].ToString();
                            string id = dataTable.Rows[i]["MADV"].ToString();
                            string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                            card_dichvu cd = new card_dichvu(id, name, price);
                            cd.cardDialogClosed += Cd_cardDialogClosed;
                            ds_dichvu.Children.Add(cd);
                        }
                    }
                    catch { }
                }
            }
        }
        // tìm problem
        private void search_problem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!string.IsNullOrEmpty(search_problem.Text))
                {
                    try
                    {
                        ds_problem.Children.Clear();
                        DataTable dataTable1 = new DataTable();
                        string ss;
                        if(fee_filter.IsChecked==true)
                        {
                            if(isFree==1)
                                 ss= $"select * from PROBLEM where (MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%')and PRICE>0 order by MAPR";
                            else if(isFree==-1)
                                ss = $"select * from PROBLEM where (MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%') and PRICE=0 order by MAPR";
                            else ss = $"select * from PROBLEM where MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%' order by MAPR";
                        }   
                        else
                            ss = $"select * from PROBLEM where MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%' order by MAPR";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        da.Fill(dataTable1);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            string name = dataTable1.Rows[i]["PRNAME"].ToString();
                            string id = dataTable1.Rows[i]["MAPR"].ToString();
                            string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                            ProbBlemCard pc = new ProbBlemCard(id, name, price);
                            pc.problemDialogClosed += Pc_problemDialogClosed;
                            ds_problem.Children.Add(pc);
                        }
                    }
                    catch { }
                }
                else
                {
                    try
                    {
                        ds_problem.Children.Clear();
                        DataTable dataTable1 = new DataTable();
                        string ss;
                        if (fee_filter.IsChecked == true)
                        {
                            if (isFree==1)
                                ss = $"select * from PROBLEM where (MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%')and PRICE>0 order by MAPR";
                            else if(isFree==-1)
                                ss = $"select * from PROBLEM where (MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%') and PRICE=0 order by MAPR";
                            else ss = $"select * from PROBLEM where MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%' order by MAPR";
                        }
                        else
                            ss = $"select * from PROBLEM where MAPR='{search_problem.Text}' or PRNAME like '%{search_problem.Text}%' order by MAPR";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        da.Fill(dataTable1);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            string name = dataTable1.Rows[i]["PRNAME"].ToString();
                            string id = dataTable1.Rows[i]["MAPR"].ToString();
                            string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                            ProbBlemCard pc = new ProbBlemCard(id, name, price);
                            pc.problemDialogClosed += Pc_problemDialogClosed;
                            ds_problem.Children.Add(pc);
                        }
                    }
                    catch { }
                }
            }
        }
        // lọc available service
        private void aval_filter_Checked(object sender, RoutedEventArgs e)
        {
            try
            {

                string ss;
                
                if (isAV==0)
                {
                    return;
                }
                else if(isAV==1)
                {
                    ss = "select * from DICHVU where SOLUONG>0 order by MADV";
                }
                else ss = "select * from DICHVU where SOLUONG=0 order by MADV";
                ds_dichvu.Children.Clear();
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i]["TENDV"].ToString();
                    string id = dataTable.Rows[i]["MADV"].ToString();
                    string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                    card_dichvu cd = new card_dichvu(id, name, price);
                    cd.cardDialogClosed += Cd_cardDialogClosed;
                    ds_dichvu.Children.Add(cd);
                }
            }
            catch { }
        }
        // bỏ lọc available service
        private void aval_filter_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                aval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                unaval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                isAV = 0;
                ds_dichvu.Children.Clear();
                string ss = "select * from DICHVU order by MADV";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string name = dataTable.Rows[i]["TENDV"].ToString();
                    string id = dataTable.Rows[i]["MADV"].ToString();
                    string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                    card_dichvu cd = new card_dichvu(id, name, price);
                    cd.cardDialogClosed += Cd_cardDialogClosed;
                    ds_dichvu.Children.Add(cd);
                }
            }
            catch { }
        }
        // chọn available service
        private void aval__MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (aval_filter.IsChecked == false) { return; }
            if (isAV!=1)
            {
                isAV = 1;
                aval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                unaval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                if (aval_filter.IsChecked == true)
                {
                    try
                    {
                        ds_dichvu.Children.Clear();
                        string ss = "select * from DICHVU where SOLUONG>0 order by MADV";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string name = dataTable.Rows[i]["TENDV"].ToString();
                            string id = dataTable.Rows[i]["MADV"].ToString();
                            string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                            card_dichvu cd = new card_dichvu(id, name, price);
                            cd.cardDialogClosed += Cd_cardDialogClosed;
                            ds_dichvu.Children.Add(cd);
                        }
                    }
                    catch { }
                }
            }
        }
        // chọn unavailable servcie
        private void unaval__MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(aval_filter.IsChecked==false) { return; }
            if (isAV!=-1)
            {
                isAV = -1;
                unaval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                aval_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                if (aval_filter.IsChecked == true)
                {
                    try
                    {
                        ds_dichvu.Children.Clear();
                        string ss = "select * from DICHVU where SOLUONG=0 order by MADV";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        DataTable dataTable = new DataTable();
                        da.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string name = dataTable.Rows[i]["TENDV"].ToString();
                            string id = dataTable.Rows[i]["MADV"].ToString();
                            string price = dataTable.Rows[i]["DONGIA"].ToString();
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
                            card_dichvu cd = new card_dichvu(id, name, price);
                            cd.cardDialogClosed += Cd_cardDialogClosed;
                            ds_dichvu.Children.Add(cd);
                        }
                    }
                    catch { }
                }
            }
        }
        // lọc phí problem
        private void fee_filter_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                
                DataTable dataTable1 = new DataTable();
                string ss;
                
                if (isFree==0)
                {
                    return;
                }
                else if (isFree==1)
                    ss = "select * from PROBLEM where PRICE=0 order by MAPR";

                else ss = "select * from PROBLEM where PRICE>0 order by MAPR";
                ds_problem.Children.Clear();
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                da.Fill(dataTable1);
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    string name = dataTable1.Rows[i]["PRNAME"].ToString();
                    string id = dataTable1.Rows[i]["MAPR"].ToString();
                    string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                    ProbBlemCard pc = new ProbBlemCard(id, name, price);
                    pc.problemDialogClosed += Pc_problemDialogClosed;
                    ds_problem.Children.Add(pc);
                }
            }
            catch { }
        }
        // bỏ lọc phó problem
        private void fee_filter_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                free_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                fee_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                isFree = 0;
                ds_problem.Children.Clear();
                DataTable dataTable1 = new DataTable();
                string ss = "select * from PROBLEM order by MAPR";
                SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                da.Fill(dataTable1);
                for (int i = 0; i < dataTable1.Rows.Count; i++)
                {
                    string name = dataTable1.Rows[i]["PRNAME"].ToString();
                    string id = dataTable1.Rows[i]["MAPR"].ToString();
                    string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                    ProbBlemCard pc = new ProbBlemCard(id, name, price);
                    pc.problemDialogClosed += Pc_problemDialogClosed;
                    ds_problem.Children.Add(pc);
                }
            }
            catch { }
        }
        // chọn problem miễn phí
        private void free__MouseDown(object sender, MouseButtonEventArgs e)
        {
           if(fee_filter.IsChecked==false) { return; }
            if (isFree!=1)
            {
                isFree = 1;
                free_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                fee_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                if (fee_filter.IsChecked == true)
                {
                    try
                    {
                        ds_problem.Children.Clear();
                        DataTable dataTable1 = new DataTable();
                        string ss = "select * from PROBLEM where PRICE=0 order by MAPR";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        da.Fill(dataTable1);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            string name = dataTable1.Rows[i]["PRNAME"].ToString();
                            string id = dataTable1.Rows[i]["MAPR"].ToString();
                            string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                            ProbBlemCard pc = new ProbBlemCard(id, name, price);
                            pc.problemDialogClosed += Pc_problemDialogClosed;
                            ds_problem.Children.Add(pc);
                        }
                    }
                    catch { }
                }
            }
        }
        // chọn problem có phí
        private void fee__MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (fee_filter.IsChecked == false) { return; }
            if (isFree!=-1)
            {
                isFree = -1;
                fee_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                free_.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));
                if (fee_filter.IsChecked == true)
                {
                    try
                    {
                        ds_problem.Children.Clear();
                        DataTable dataTable1 = new DataTable();
                        string ss = "select * from PROBLEM where PRICE>0 order by MAPR";
                        SqlDataAdapter da = new SqlDataAdapter(ss, db.sqlCon);
                        da.Fill(dataTable1);
                        for (int i = 0; i < dataTable1.Rows.Count; i++)
                        {
                            string name = dataTable1.Rows[i]["PRNAME"].ToString();
                            string id = dataTable1.Rows[i]["MAPR"].ToString();
                            string price = dataTable1.Rows[i]["PRICE"].ToString();
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
                            ProbBlemCard pc = new ProbBlemCard(id, name, price);
                            pc.problemDialogClosed += Pc_problemDialogClosed;
                            ds_problem.Children.Add(pc);
                        }
                    }
                    catch { }
                }
            }
        }

        private void search_problem_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
