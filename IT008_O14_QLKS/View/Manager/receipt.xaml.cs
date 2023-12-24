using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Manager.Card;
using IT008_O14_QLKS.View.Manager.FormPage;
using IT008_O14_QLKS.View.Manager.FormPage.receipt;

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
        private bool isFilter = false;

        private string orderby = "asc";

        private string filter;


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

        // private void Datepicker_OnMouseDown(object sender, MouseButtonEventArgs e)
        // {
        //     DatePicker datePicker = new DatePicker();
        //     datePicker.Width = 200;
        //     datePicker.Height = 200;
        //     datePicker.IsDropDownOpen = true;
        //     datePicker.SelectedDateChanged += DatePicker_SelectionChanged;
        // }
        //
        // private void DatePicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        // {
        //     // Lấy ngày được chọn
        //     var datePicker = sender as DatePicker;
        //     var date = datePicker.SelectedDate;
        //
        //     // Xử lý ngày được chọn
        //     // ...
        //     DatePickerLabel.Content = date.Value.ToString();
        // }

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
                this.sortby = "sohd";
               this.orderby = "asc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
            else if (SortByComboBox.SelectedIndex == 0 && !isAsc)
            {
                this.sortby = "sohd";
                this.orderby = "desc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
            else if (SortByComboBox.SelectedIndex == 1 && isAsc)
            {
                this.sortby = "ngaylap";
                this.orderby = "asc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
            else if (SortByComboBox.SelectedIndex == 1 && !isAsc)
            {
                this.sortby = "ngaylap";
                this.orderby = "desc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
            else if (SortByComboBox.SelectedIndex == 2 && isAsc)
            {
                this.sortby = "tongtien";
                this.orderby = "asc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
            else if (SortByComboBox.SelectedIndex == 2 && !isAsc)
            {
                this.sortby = "tongtien";
                this.orderby = "desc";
                DisplaySort(this.sortby, this.orderby,filter);
            }
        }


        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Receipt_Add_Form a = new Receipt_Add_Form();
            a.ShowDialog();
        }

        public void SortByCheckBox_Click(object sender, MouseButtonEventArgs e)
        {
            if (!isSortBy)
            {
                AscBorder.Background = new SolidColorBrush(Colors.Red);
                AscTextBlock.Foreground = new SolidColorBrush(Colors.White);

                DescBorder.Background = new SolidColorBrush(Colors.Transparent);
                DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
                CheckBoxImage.Visibility = Visibility.Visible;
                SortByComboBox.SelectedIndex = 0;
                SortByComboBox.IsEnabled = true;
                AscBorder.IsEnabled = true;
                DescBorder.IsEnabled = true;
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
                AscBorder.IsEnabled = false;
                DescBorder.IsEnabled = false;
                SortByComboBox.IsEnabled = false;
                isSortBy = false;
            }
        }

        private void DisplaySort(string sortby, string noidung, string filter)
        {
            ReceiptCardPanel.Children.Clear();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = _db.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText =
                $"select sohd,NgayLap,CAST(ngaylap AS time),tongtien from hoadon {filter} order by {sortby} {noidung}";
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
            AscBorder.Background = new SolidColorBrush(Colors.Red);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.White);

            DescBorder.Background = new SolidColorBrush(Colors.Transparent);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.LightBlue);
            SortByComboBox.IsEnabled = true;
            isAsc = true;
            orderby = "asc";
            DisplaySort(sortby, orderby,filter);
        }

        private void DescBorder_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            DescBorder.Background = new SolidColorBrush(Colors.LightBlue);
            DescTextBlock.Foreground = new SolidColorBrush(Colors.White);
            AscBorder.Background = new SolidColorBrush(Colors.Transparent);
            AscTextBlock.Foreground = new SolidColorBrush(Colors.Red);
            SortByComboBox.IsEnabled = true;
            isAsc = false;
            orderby = "desc";
            DisplaySort(sortby, orderby,filter);
        }


        private void FilterSlider_OnValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            filter = $"where tongtien <= {FilterSlider.Value}";
            FilterMoneyTextBox.Text = FilterSlider.Value.ToString() + " VND";
            DisplaySort(sortby, orderby,filter);
        }

        private void FilterCheckBox_Click(object sender, MouseButtonEventArgs e)
        {
            if (isFilter == false)
            {
                FilterCheckBoxImage.Visibility = Visibility.Visible;
                FilterSlider.IsEnabled = true;
                allRadioButton.IsEnabled = true;
                CustomRadioButton.IsEnabled = true;
                CustomRadioButton.IsChecked = true;
                isFilter = true;
            }
            else
            {
                FilterCheckBoxImage.Visibility = Visibility.Hidden;
                FilterSlider.IsEnabled = false;
                allRadioButton.IsEnabled = false;
                CustomRadioButton.IsEnabled = false;
                isFilter = false;
                filter = "";
            }
        }

        private void AllRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            FilterSlider.Value = FilterSlider.Maximum;
            FilterMoneyTextBox.Text = FilterSlider.Value.ToString() + " VND";
            FilterSlider.IsEnabled = false;
        }

        private void CustomRadioButton_OnClick(object sender, RoutedEventArgs e)
        {
            FilterSlider.IsEnabled = true;
        }
    }
}