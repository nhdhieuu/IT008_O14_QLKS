using IT008_O14_QLKS.Connection_db;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Shapes;
using System.Drawing;
using ColorConverter = System.Windows.Media.ColorConverter;
using Color = System.Windows.Media.Color;
using IT008_O14_QLKS.View.Clients.FormPage;
using Image = System.Windows.Controls.Image;
using Microsoft.Win32;

namespace IT008_O14_QLKS.View.Clients
{
    public partial class ClientsHome : UserControl
    {
        DB_connection connect = new DB_connection();
        SqlCommand sqlcmd = new SqlCommand();
        public string ten;
        public string tendn;
        public string sdt;
        public string cmnd;
        public string tuoi;
        public string gtinh;
        BitmapImage avttt;
         Image early = new Image();
        public ClientsHome()
        {
            InitializeComponent();
        }
        public ClientsHome(string username)
        {
            InitializeComponent();
            
            sqlcmd.CommandType = CommandType.Text;
            sqlcmd.Connection = connect.sqlCon;
            sqlcmd.CommandText = "SELECT * FROM KHACHHANG WHERE USERNAME='" + username + "'";
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
                this.cccd.Text = reader.GetString(4);
                cmnd = cccd.Text;
                this.hang.Content = reader.GetString(9);
            }
            reader.Close();
            //load ảnh
            sqlcmd.CommandText = "SELECT AVATAR FROM KHACHHANG WHERE USERNAME='" + username + "'";
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
            sqlcmd.CommandText = "SELECT NGAYSINH FROM KHACHHANG WHERE USERNAME='" + username + "'";
            DateTime saleDate = (DateTime)sqlcmd.ExecuteScalar();
            int saleYear = saleDate.Year;
            this.age.Text = (2023 - saleYear).ToString();
            tuoi = age.Text;
            background();


        }

        private void Save_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
            this.name.IsEnabled = false;
            this.phone.IsEnabled = false;
            this.cccd.IsEnabled = false;
            this.age.IsEnabled = false;
            this.gender.IsEnabled = false;
            this.UpdateAVT.IsEnabled = false;
            ten=this.name.Text ;
            sdt = this.phone.Text;
            cmnd = this.cccd.Text;
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

            sqlcmd.CommandText = "UPDATE KHACHHANG SET TENKH='"+this.name.Text+"' , SDT='"+this.phone.Text+"' , GIOITINH='"+this.gender.Text+"' ,CCCD='"+this.cccd.Text+"', AVATAR=@image WHERE USERNAME='"+tendn+"'";
            sqlcmd.ExecuteNonQuery();
        }

        private void Save_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF08631D"));

        }

        private void Save_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Save.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF17D141"));

        }

        private void Change_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Visible;
            this.Cancel.Visibility = Visibility.Visible;
            this.Change.Visibility = Visibility.Hidden;
            this.name.IsEnabled = true;
            this.phone.IsEnabled = true;
            this.cccd.IsEnabled = true;
            this.age.IsEnabled = true;
            this.gender.IsEnabled = true;
            this.UpdateAVT.IsEnabled = true;
        }

        private void Change_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF8C6C0A"));

        }

        private void Change_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Change.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#C6980A"));

        }

        private void Cancel_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Save.Visibility = Visibility.Hidden;
            this.Cancel.Visibility = Visibility.Hidden;
            this.Change.Visibility = Visibility.Visible;
            this.name.Text= ten;
            this.phone.Text = sdt;
            this.cccd.Text = cmnd;
            this.gender.Text = gtinh;
            this.age.Text = tuoi;
            if (ChangeAvt == 1)
            {
                this.avt.ImageSource = avttt;
                this.avtt.ImageSource = avttt;
            }
            this.name.IsEnabled = false;
            this.phone.IsEnabled = false;
            this.cccd.IsEnabled = false;
            this.age.IsEnabled = false;
            this.gender.IsEnabled = false;
            this.UpdateAVT.IsEnabled = false;
          
           
        }

        private void Cancel_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF790B0B"));

        }

        private void Cancel_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {

            Cancel.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDF0B0B"));

        }
        private void background()
        {
            string truepath = "";
            string currentFolderPath = AppDomain.CurrentDomain.BaseDirectory.ToString();

            string[] parts = currentFolderPath.Split('\\');
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] != "Debug" && parts[i] != "bin")
                    truepath += parts[i] + "/";
            }





            string imagePath = System.IO.Path.Combine(truepath, "Resources", hang.Content + ".jpg");

            // Tạo một đối tượng BitmapImage
            BitmapImage bitmap = new BitmapImage();

            // Thiết lập đường dẫn nguồn cho BitmapImage
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath, UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            // Tạo một ImageBrush và thiết lập hình ảnh làm nền
            ImageBrush imageBrush = new ImageBrush(bitmap);

            // Thiết lập nền của phần tử (vd: Grid, Border, etc.)
            imageBrush.Stretch = Stretch.Fill;
            Classs.Background = imageBrush;

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

        private void ChangePassword_MouseEnter(object sender, MouseEventArgs e)
        {
            this.ChangePassword.Background= new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF283AB8"));
        }

        private void ChangePassword_MouseLeave(object sender, MouseEventArgs e)
        {
            this.ChangePassword.Background=new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF4F63EB"));
        }

        private void ChangePassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangePass cp=new ChangePass(tendn);
            cp.ShowDialog();
        }
    }
}