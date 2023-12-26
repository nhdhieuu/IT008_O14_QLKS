using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage.staff;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
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

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for staff.xaml
    /// </summary>
    public partial class staff : UserControl
    {
        DB_connection dB_Connection = new DB_connection();
        SqlCommand sqlCommand = new SqlCommand();
        private bool isAsc = true;
        public staff()
        {
            InitializeComponent();
            DataTable dataTable = new DataTable();
            string str = "select * from NHANVIEN";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string manv = dataTable.Rows[i]["MANV"].ToString();
                string name = dataTable.Rows[i]["TENNV"].ToString();
                string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                if (vitri == "Le Tan")
                    vitri = "Receptionist";
                else if (vitri == "Phuc Vu")
                    vitri = "Service";
                else if (vitri == "Ve Sinh")
                    vitri = "Hygiene";
                else if (vitri == "CSKH")
                    vitri = "Custom care";
                StaffCard staffCard = new StaffCard(manv, name, vitri);
                ds_staff.Children.Add(staffCard);
            }
        }
        // thêm staff
        private void add_border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            staffAdd SA = new staffAdd();
            SA.ShowDialog();
            ds_staff.Children.Clear();
            DataTable dataTable = new DataTable();
            string str = "select * from NHANVIEN";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(str, dB_Connection.sqlCon);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string manv = dataTable.Rows[i]["MANV"].ToString();
                string name = dataTable.Rows[i]["TENNV"].ToString();
                string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                if (vitri == "Le Tan")
                    vitri = "Receptionist";
                else if (vitri == "Phuc Vu")
                    vitri = "Service";
                else if (vitri == "Ve Sinh")
                    vitri = "Hygiene";
                else if (vitri == "CSKH")
                    vitri = "Custom care";
                StaffCard staffCard = new StaffCard(manv, name, vitri);
                ds_staff.Children.Add(staffCard);
            }

        }
        //
        private void add_border_MouseEnter(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25be56"));
        }
        // 
        private void add_border_MouseLeave(object sender, MouseEventArgs e)
        {
            add_border.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
        }
        // chọn sắp xếp tăng
        private void asc_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!isAsc)
            {
                asc_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                desc_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D9D9D9"));
                isAsc = true;
                if(sort_checkbox.IsChecked==true)
                    sort_checkbox_Checked(sender, e);
            }
        }
        // chọn sắp xếp giảm
        private void desc_b_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isAsc)
            {
                desc_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#12CE69"));
                asc_b.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D9D9D9"));
                isAsc = false;
                if(sort_checkbox.IsChecked == true)
                    sort_checkbox_Checked(sender, e);
            }
        }
        // chọn vị trí
        private void postion_check_Checked(object sender, RoutedEventArgs e)
        {
            string sql = $"select * from NHANVIEN  ";
            string bophan = "";
            if (postion_combo.Text == "Receptionist")
                bophan = "Le Tan";
            else if (postion_combo.Text == "Service")
                bophan = "Phuc Vu";
            else if (postion_combo.Text == "Hygiene")
                bophan = "Ve Sinh";
            else if (postion_combo.Text == "Custom care")
                bophan = "CSKH";
            sql += $"where BOPHAN='{bophan}'";
            if (sort_checkbox.IsChecked == true)
            {
                if (sort_combo.SelectedItem != null)
                {
                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";
                    if (postion_combo.SelectedItem != null)
                    {
                        ds_staff.Children.Clear();
                        DataTable dataTable = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                        sqlDataAdapter.Fill(dataTable);
                        for (int i = 0; i < dataTable.Rows.Count; i++)
                        {
                            string manv = dataTable.Rows[i]["MANV"].ToString();
                            string name = dataTable.Rows[i]["TENNV"].ToString();
                            string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                            if (vitri == "Le Tan")
                                vitri = "Receptionist";
                            else if (vitri == "Phuc Vu")
                                vitri = "Service";
                            else if (vitri == "Ve Sinh")
                                vitri = "Hygiene";
                            else if (vitri == "CSKH")
                                vitri = "Custom care";
                            StaffCard staffCard = new StaffCard(manv, name, vitri);
                            ds_staff.Children.Add(staffCard);
                        }
                    }
                }
            }
            else
            {
                if (postion_combo.SelectedItem != null)
                {
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }

            }
        }
        // bỏ chọn vị trí
        private void postion_check_Unchecked(object sender, RoutedEventArgs e)
        {
            string sql = $"select * from NHANVIEN";
            if (sort_checkbox.IsChecked == true)
            {
                if (sort_combo.SelectedItem != null)
                {
                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";

                }
            }
            ds_staff.Children.Clear();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
            sqlDataAdapter.Fill(dataTable);
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string manv = dataTable.Rows[i]["MANV"].ToString();
                string name = dataTable.Rows[i]["TENNV"].ToString();
                string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                if (vitri == "Le Tan")
                    vitri = "Receptionist";
                else if (vitri == "Phuc Vu")
                    vitri = "Service";
                else if (vitri == "Ve Sinh")
                    vitri = "Hygiene";
                else if (vitri == "CSKH")
                    vitri = "Custom care";
                StaffCard staffCard = new StaffCard(manv, name, vitri);
                ds_staff.Children.Add(staffCard);
            }

        }
        // chọn sắp xếp
        private void sort_checkbox_Checked(object sender, RoutedEventArgs e)
        {
            if (postion_check.IsChecked == true)
            {
                string sql = $"select * from NHANVIEN  ";
                string bophan = "";
                if (postion_combo.Text == "Receptionist")
                    bophan = "Le Tan";
                else if (postion_combo.Text == "Service")
                    bophan = "Phuc Vu";
                else if (postion_combo.Text == "Hygiene")
                    bophan = "Ve Sinh";
                else if (postion_combo.Text == "Custom care")
                    bophan = "CSKH";
                sql += $"where BOPHAN='{bophan}'";
                if (sort_combo.SelectedItem != null)
                {

                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
            }
            else
            {
                if (sort_combo.SelectedItem != null)
                {
                    string sql = $"select * from NHANVIEN  ";

                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
            }
        }
        // bỏ chọn sắp xếp
        private void sort_checkbox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (postion_check.IsChecked == true)
            {
                string sql = $"select * from NHANVIEN  ";
                string bophan = "";
                if (postion_combo.Text == "Receptionist")
                    bophan = "Le Tan";
                else if (postion_combo.Text == "Service")
                    bophan = "Phuc Vu";
                else if (postion_combo.Text == "Hygiene")
                    bophan = "Ve Sinh";
                else if (postion_combo.Text == "Custom care")
                    bophan = "CSKH";
                sql += $"where BOPHAN='{bophan}'";

                ds_staff.Children.Clear();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                sqlDataAdapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string manv = dataTable.Rows[i]["MANV"].ToString();
                    string name = dataTable.Rows[i]["TENNV"].ToString();
                    string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                    if (vitri == "Le Tan")
                        vitri = "Receptionist";
                    else if (vitri == "Phuc Vu")
                        vitri = "Service";
                    else if (vitri == "Ve Sinh")
                        vitri = "Hygiene";
                    else if (vitri == "CSKH")
                        vitri = "Custom care";
                    StaffCard staffCard = new StaffCard(manv, name, vitri);
                    ds_staff.Children.Add(staffCard);
                }

            }
            else
            {

                string sql = $"select * from NHANVIEN  ";
                ds_staff.Children.Clear();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                sqlDataAdapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string manv = dataTable.Rows[i]["MANV"].ToString();
                    string name = dataTable.Rows[i]["TENNV"].ToString();
                    string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                    if (vitri == "Le Tan")
                        vitri = "Receptionist";
                    else if (vitri == "Phuc Vu")
                        vitri = "Service";
                    else if (vitri == "Ve Sinh")
                        vitri = "Hygiene";
                    else if (vitri == "CSKH")
                        vitri = "Custom care";
                    StaffCard staffCard = new StaffCard(manv, name, vitri);
                    ds_staff.Children.Add(staffCard);
                }
            }
        }
        // thay đổi lựa chọn vị trí
        private void postion_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (postion_check.IsChecked == true)
            {
                string sql = $"select * from NHANVIEN  ";
                string bophan = "";
                if (((ComboBoxItem)postion_combo.SelectedItem).Content.ToString() == "Receptionist")
                    bophan = "Le Tan";
                else if (((ComboBoxItem)postion_combo.SelectedItem).Content.ToString() == "Service")
                    bophan = "Phuc Vu";
                else if (((ComboBoxItem)postion_combo.SelectedItem).Content.ToString() == "Hygiene")
                    bophan = "Ve Sinh";
                else if (((ComboBoxItem)postion_combo.SelectedItem).Content.ToString() == "Custom care")
                    bophan = "CSKH";
                sql += $"where BOPHAN='{bophan}'";
                if (sort_checkbox.IsChecked == true)
                {
                    if (sort_combo.SelectedItem != null)
                    {
                        string sortby = "";
                        if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                            sortby = "BOPHAN";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                            sortby = "TENNV";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                            sortby = "MANV";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                            sortby = "NGAYSINH";
                        string asc_desc = "ASC";
                        if (!isAsc)
                            asc_desc = "DESC";
                        sql += $" order by {sortby} {asc_desc} ";

                    }
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
                else
                {
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
            }

        }
        // thay đổi lựa chọn sắp xếp
        private void sort_combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sort_checkbox.IsChecked == true)
            {
                string sql = $"select * from NHANVIEN  ";
                if (postion_check.IsChecked == true)
                {
                    if (postion_combo.SelectedItem != null)
                    {
                        string bophan = "";
                        if (postion_combo.Text == "Receptionist")
                            bophan = "Le Tan";
                        else if (postion_combo.Text == "Service")
                            bophan = "Phuc Vu";
                        else if (postion_combo.Text == "Hygiene")
                            bophan = "Ve Sinh";
                        else if (postion_combo.Text == "Custom care")
                            bophan = "CSKH";
                        sql += $"where BOPHAN='{bophan}'";
                    }
                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
                else
                {
                    string sortby = "";
                    if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                        sortby = "BOPHAN";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                        sortby = "TENNV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                        sortby = "MANV";
                    else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                        sortby = "NGAYSINH";
                    string asc_desc = "ASC";
                    if (!isAsc)
                        asc_desc = "DESC";
                    sql += $" order by {sortby} {asc_desc} ";
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
            }
        }
        // tìm kiếm 
        private void search_tb_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                string wd= search_tb.Text;
                if(wd==null||wd==""||wd==" " )
                {
                    sort_checkbox_Checked(sender, e);
                }
                else
                {
                    string sql = $"select * from NHANVIEN WHERE (MANV='{wd}' or TENNV like '%{wd}%') ";
                    if(postion_check.IsChecked == true)
                    {
                        if (postion_combo.SelectedItem != null)
                        {
                            string bophan = "";
                            if (postion_combo.Text == "Receptionist")
                                bophan = "Le Tan";
                            else if (postion_combo.Text == "Service")
                                bophan = "Phuc Vu";
                            else if (postion_combo.Text == "Hygiene")
                                bophan = "Ve Sinh";
                            else if (postion_combo.Text == "Custom care")
                                bophan = "CSKH";
                            sql += $" and BOPHAN='{bophan}'";
                        }
                    }
                    if(sort_checkbox.IsChecked == true)
                    {
                        string sortby = "";
                        if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Postion")
                            sortby = "BOPHAN";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Name")
                            sortby = "TENNV";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "ID")
                            sortby = "MANV";
                        else if (((ComboBoxItem)sort_combo.SelectedItem).Content.ToString() == "Birthday")
                            sortby = "NGAYSINH";
                        string asc_desc = "ASC";
                        if (!isAsc)
                            asc_desc = "DESC";
                        sql += $" order by {sortby} {asc_desc} ";
                    }
                    ds_staff.Children.Clear();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, dB_Connection.sqlCon);
                    sqlDataAdapter.Fill(dataTable);
                    for (int i = 0; i < dataTable.Rows.Count; i++)
                    {
                        string manv = dataTable.Rows[i]["MANV"].ToString();
                        string name = dataTable.Rows[i]["TENNV"].ToString();
                        string vitri = dataTable.Rows[i]["BOPHAN"].ToString();
                        if (vitri == "Le Tan")
                            vitri = "Receptionist";
                        else if (vitri == "Phuc Vu")
                            vitri = "Service";
                        else if (vitri == "Ve Sinh")
                            vitri = "Hygiene";
                        else if (vitri == "CSKH")
                            vitri = "Custom care";
                        StaffCard staffCard = new StaffCard(manv, name, vitri);
                        ds_staff.Children.Add(staffCard);
                    }
                }
            }
        }
    }
}
