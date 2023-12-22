using System;
using System.Collections.Generic;
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
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for receipt.xaml
    /// </summary>
    public partial class receipt : UserControl
    {
        DB_connection _db = new DB_connection();
        private bool isSortBy = false;
        private bool isAsc = true;
        private string sortby = "sohd";

        public receipt()
        {
            InitializeComponent();
            this.Loaded += receipt_Loaded;



        }

        private void receipt_Loaded(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                ReceiptCard receiptCard = new ReceiptCard(sqlDataReader[0].ToString(), sqlDataReader[1],
                    sqlDataReader[2].ToString(), sqlDataReader[3].ToString());
                ContentControl contentControl = new ContentControl();
                if (ReceiptCardPanel.Children.Count >= 1)
                {
                    // Child thứ 2, set margin 
                    contentControl.Margin = new Thickness(0, 10, 0, 0);
                }

                contentControl.Content = receiptCard.Content;
                ReceiptCardPanel.Children.Add(contentControl);
            }

            sqlDataReader.Close();
        }

        private void Search_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SearchBox.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số hóa đơn cần tìm kiếm");
            }
            else
            {
                ReceiptCardPanel.Children.Clear();
                ;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = _db.sqlCon;
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText =
                    "select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon where sohd = '" + SearchBox.Text +
                    "'";
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        ReceiptCard receiptCard = new ReceiptCard(sqlDataReader[0].ToString(), sqlDataReader[1],
                            sqlDataReader[2].ToString(), sqlDataReader[3].ToString());
                        ContentControl contentControl = new ContentControl();
                        if (ReceiptCardPanel.Children.Count >= 1)
                        {
                            // Child thứ 2, set margin 
                            contentControl.Margin = new Thickness(0, 10, 0, 0);
                        }

                        contentControl.Content = receiptCard.Content;
                        ReceiptCardPanel.Children.Add(contentControl);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn");

                }

                sqlDataReader.Close();
            }
        }

        private void Datepicker_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DatePicker datePicker = new DatePicker();
            datePicker.Width = 200;
            datePicker.Height = 200;
            datePicker.IsDropDownOpen = true;
            datePicker.SelectedDateChanged += DatePicker_SelectionChanged;
        }

        private void DatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Lấy ngày được chọn
            var datePicker = sender as DatePicker;
            var date = datePicker.SelectedDate;

            // Xử lý ngày được chọn
            // ...
            DatePickerLabel.Content = date.Value.ToString();
        }

        private void ReloadButton_Click(object sender, MouseButtonEventArgs e)
        {
            ReceiptCardPanel.Children.Clear();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = "select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                ReceiptCard receiptCard = new ReceiptCard(sqlDataReader[0].ToString(), sqlDataReader[1],
                    sqlDataReader[2].ToString(), sqlDataReader[3].ToString());
                ContentControl contentControl = new ContentControl();
                if (ReceiptCardPanel.Children.Count >= 1)
                {
                    // Child thứ 2, set margin 
                    contentControl.Margin = new Thickness(0, 10, 0, 0);
                }

                contentControl.Content = receiptCard.Content;
                ReceiptCardPanel.Children.Add(contentControl);
            }

            sqlDataReader.Close();
        }
        
        
        
        
        private void SortByComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SortByComboBox.SelectedIndex == 0 && isAsc)
            {
                string sortby = "sohd";
                string noidung = "asc";
                DisplaySort(sortby, noidung);
            }
            else if (SortByComboBox.SelectedIndex == 0 && !isAsc)
            {
                string sortby = "sohd";
                string noidung = "desc";
                DisplaySort(sortby, noidung);
            }
            else if (SortByComboBox.SelectedIndex == 1 && isAsc)
            {
                string sortby = "ngaylap";
                string noidung = "asc";
                DisplaySort(sortby, noidung);
            }
            else if (SortByComboBox.SelectedIndex == 1 && !isAsc)
            {
                string sortby = "ngaylap";
                string noidung = "desc";
                DisplaySort(sortby, noidung);
            }
            else if (SortByComboBox.SelectedIndex == 2 && isAsc)
            {
                string sortby = "tongtien";
                string noidung = "asc";
                DisplaySort(sortby, noidung);
            }
            else if (SortByComboBox.SelectedIndex == 2 && !isAsc)
            {
                string sortby = "tongtien";
                string noidung = "desc";
                DisplaySort(sortby, noidung);
            }
            
        }

        public void SortByCheckBox_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isSortBy)
            {
                AscBorder.Background= new SolidColorBrush(Colors.Red);
                AscTextBlock.Foreground = new SolidColorBrush(Colors.White);

                DescBorder.Background = new SolidColorBrush(Colors.Transparent);
                DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
                CheckBoxImage.Visibility = Visibility.Visible;
                SortByComboBox.SelectedIndex = 0;
                SortByComboBox.IsEnabled = true;
                isSortBy = true;
                isAsc = true;
            }
            else
            {
                AscBorder.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                AscTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
                DescBorder.BorderBrush = new SolidColorBrush(Colors.LightBlue);
                DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
                SortByBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#7F4E4B4B"));
                CheckBoxImage.Visibility = Visibility.Hidden;

                SortByComboBox.IsEnabled = false;
                isSortBy = false;
            }
            
        }

        private void DisplaySort(string sortby, string noidung)
        {
            ReceiptCardPanel.Children.Clear();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = $"select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon order by {sortby} {noidung}";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                ReceiptCard receiptCard = new ReceiptCard(sqlDataReader[0].ToString(), sqlDataReader[1],
                    sqlDataReader[2].ToString(), sqlDataReader[3].ToString());
                ContentControl contentControl = new ContentControl();
                if (ReceiptCardPanel.Children.Count >= 1)
                {
                    // Child thứ 2, set margin 
                    contentControl.Margin = new Thickness(0, 10, 0, 0);
                }

                contentControl.Content = receiptCard.Content;
                ReceiptCardPanel.Children.Add(contentControl);
            }

            sqlDataReader.Close();
        }

        private void AscBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            AscBorder.Background= new SolidColorBrush(Colors.Red);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.White);

            DescBorder.Background = new SolidColorBrush(Colors.Transparent);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
            SortByComboBox.IsEnabled = true;
            isAsc = true;
            DisplaySort(sortby, "asc");
        }

        private void DescBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DescBorder.Background = new SolidColorBrush(Colors.LightBlue);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.White);
            AscBorder.Background = new SolidColorBrush(Colors.Transparent);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            SortByComboBox.IsEnabled = true;
            isAsc = false;
            DisplaySort(sortby, "desc");
        }
    }
}
