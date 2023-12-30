using IT008_O14_QLKS.Connection_db;
using IT008_O14_QLKS.View.Clients.FormPage;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
using IT008_O14_QLKS.View.Manager.Card;
using LiveCharts;

namespace IT008_O14_QLKS.View.Manager
{
    /// <summary>
    /// Interaction logic for home.xaml
    /// </summary>
    public partial class home : UserControl
    {
      
        DB_connection connect = new DB_connection();
        SqlCommand sqlcmd = new SqlCommand();
        public string ten;
        public string tendn;
        public string sdt;
        public string cmnd;
        public string tuoi;
        public string gtinh;
        public string ID;
        BitmapImage avttt;
        Image early = new Image();
        public home(string userName)
        {
            InitializeComponent();

            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = "SELECT * FROM QUANLI WHERE USERNAME='" + userName + "'";
            SqlDataReader reader = sqlcmd.ExecuteReader();
            while (reader.Read())
            {
                this.name.Text = reader.GetString(1);
                ten = this.name.Text;
                this.username.Text = reader.GetString(2);
                tendn = this.username.Text;
                this.UN2.Content = reader.GetString(2);
                this.phone.Text = reader.GetString(5);
                sdt = phone.Text;
                this.gender.Text = reader.GetString(7);
                gtinh = gender.Text;
                id.Text = reader.GetString(0);
                ID = id.Text;


            }
            reader.Close();
            //load ảnh
            sqlcmd.CommandText = "SELECT AVATAR FROM QUANLI WHERE USERNAME='" + userName + "'";
            try
            {
                byte[] imageData = (byte[])sqlcmd.ExecuteScalar();
                MemoryStream memStream = new MemoryStream(imageData);

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memStream;
                bitmap.EndInit();
                avttt = bitmap;
                avt.ImageSource = bitmap;
                avtt.ImageSource = bitmap;
            }
            catch { }

            //lấy tuổi
            sqlcmd.CommandText = "SELECT NGAYSINH FROM QUANLI WHERE USERNAME='" + userName + "'";
            DateTime saleDate = (DateTime)sqlcmd.ExecuteScalar();
            int saleYear = saleDate.Year;
            this.age.Text = (2023 - saleYear).ToString();
            tuoi = age.Text;
        }


        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void View_more_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void View_more_MouseEnter(object sender, MouseEventArgs e)
        {

        }

        private void View_more_MouseLeave(object sender, MouseEventArgs e)
        {


        }

        private void Change_pass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Change_pass.Visibility = Visibility.Hidden;
            Save.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Visible;
            this.name.IsEnabled = true;
            this.phone.IsEnabled = true;
            this.age.IsEnabled = true;
            this.gender.IsEnabled = true;
            this.UpdateAVT.IsEnabled = true;
            id.IsEnabled= true;
        }

        private void Change_pass_MouseEnter(object sender, MouseEventArgs e)
        {
            Change_pass.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));
        }

        private void Change_pass_MouseLeave(object sender, MouseEventArgs e)
        {
            Change_pass.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void Change_pass2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangePass cp = new ChangePass(tendn,"Manager");
            cp.ShowDialog();
        }
        private void Change_pass2_MouseEnter(object sender, MouseEventArgs e)
        {
            Change_pass2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF063792"));
        }

        private void Change_pass2_MouseLeave(object sender, MouseEventArgs e)
        {
            Change_pass2.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF0A4CC6"));
        }

        private void Save_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Save.Visibility = Visibility.Hidden;
            Change_pass.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;

            this.name.IsEnabled = false;
            this.phone.IsEnabled = false;
            this.id.IsEnabled = false;
            this.age.IsEnabled = false;
            this.gender.IsEnabled = false;
            this.UpdateAVT.IsEnabled = false;
            ten = this.name.Text;
            sdt = this.phone.Text;
            ID = this.id.Text;
            gtinh = this.gender.Text;
            tuoi = this.age.Text;
            //luu avt
            BitmapSource bitmap = avt.ImageSource as BitmapSource;
            byte[] imageData;
            using (MemoryStream memory = new MemoryStream())
            {
                BitmapEncoder enc = new BmpBitmapEncoder(); // hoặc JpegEncoder
                enc.Frames.Add(BitmapFrame.Create(bitmap));
                enc.Save(memory);

                imageData = memory.ToArray();
            }
            sqlcmd.Parameters.Add("@image", SqlDbType.VarBinary).Value = imageData;

            sqlcmd.CommandText = "UPDATE QUANLI SET TENQUANLI='" + this.name.Text + "' , SDT='" + this.phone.Text + "' , GIOITINH='" + this.gender.Text + "' ,MAQL='" + this.id.Text + "', AVATAR=@image WHERE USERNAME='" + tendn + "'";
            sqlcmd.ExecuteNonQuery();
        }

        private void Save_MouseEnter(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));
        }

        private void Save_MouseLeave(object sender, MouseEventArgs e)
        {
            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));
        }

        private void Change_pass_Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            Stop.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFAC0D0D"));
        }

        private void Change_pass_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            Stop.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFC90303"));
        }

        private void Stop_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Save.Visibility = Visibility.Hidden;
            Change_pass.Visibility = Visibility.Visible;
            Stop.Visibility = Visibility.Hidden;

            this.name.Text = ten;
            this.phone.Text = sdt;
            this.id.Text = ID;
            this.gender.Text = gtinh;
            this.age.Text = tuoi;
            if (ChangeAvt == 1)
            {
                this.avt.ImageSource = avttt;
                this.avtt.ImageSource = avttt;
            }
            this.name.IsEnabled = false;
            this.phone.IsEnabled = false;
            this.id.IsEnabled = false;
            this.age.IsEnabled = false;
            this.gender.IsEnabled = false;
            this.UpdateAVT.IsEnabled = false;
        }
        int ChangeAvt = 0;
        private void UpdateAVT_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeAvt = 1;
            avt.ImageSource = early.Source;
            Microsoft.Win32.OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select Image to set avatar";
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.bmp;*.jpg;*.png|JPG Files|*.jpg|PNG Files|*.png|JPEG Files|*.jpeg";
            ofd.ShowDialog();
            avt.ImageSource = early.Source;

            if (ofd.FileName != "")
            {
                string tb_uri;
                tb_uri = ofd.FileName;
                Uri image_Path = new Uri(tb_uri);
                avt.ImageSource = new BitmapImage(image_Path);
                avt.Stretch = System.Windows.Media.Stretch.UniformToFill;
                early.Source = avt.ImageSource;

            }
            else
            {
            }
        }

        private void BtnStatistical_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {   
                if(DatePicker_StartDate.SelectedDate.Value == null || DatePicker_EndDate.SelectedDate.Value == null)
                {
                    throw new Exception("Vui lòng chọn ngày để thống kê phân tích");
                }
                DateTime start = DatePicker_StartDate.SelectedDate.Value;
                DateTime end = DatePicker_EndDate.SelectedDate.Value;
                string startstring = start.ToString("MM/dd/yyyy");
                string endstring = end.ToString("MM/dd/yyyy");
                Console.WriteLine(startstring);
                Console.WriteLine(endstring);
                LoadChart(startstring,endstring);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Vui lòng chọn ngày để thống kê phân tích");
                
            }
            
        }

        public void LoadChart(string starttime, string endtime)
        {
            List<string> maphong = new List<string>();
            ChartValues<int> tongtien = new ChartValues<int>();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = connect.sqlCon;
            sqlCommand.CommandType = System.Data.CommandType.Text;
            sqlCommand.CommandText = $"select sohd,tongtien " +
                                     $" from hoadon" +
                                     $" where ngaylap >= '{starttime}'" +
                                     $" and ngaylap <= '{endtime}'";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                maphong.Add(sqlDataReader[0].ToString());
                tongtien.Add(int.Parse(sqlDataReader[1].ToString()));
            }
            AxisY_Right.MaxValue = 0;

            for(int i=0;i<tongtien.Count;i++) 
            {
                if (tongtien[i]>AxisY_Right.MaxValue)
                {
                    AxisY_Right.MaxValue = tongtien[i];
                }
            }
           
            
            QuantityValues_ColumnSeries.Values = tongtien;
            AxisX_Bottom.Labels = maphong;
            sqlDataReader.Close();
        }
        
    }
}
