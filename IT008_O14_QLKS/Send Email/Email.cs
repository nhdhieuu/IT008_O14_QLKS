using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security;
using IT008_O14_QLKS.Connection_db;
using System.Data.SqlClient;
using System.Data;
using IT008_O14_QLKS.Util;
using System.Windows.Documents;

namespace IT008_O14_QLKS.Send_Email
{
    internal class Email
    {
        string username="";
        string toemail;
        DB_connection connect = new DB_connection();
        public Email(string username)
        {
            this.username = username;
            Truyvan();
            
        }
        private void Truyvan()
        {
            
        }
               public void Change_pass()
        {
            SqlCommand sqlcmd = new SqlCommand();

            sqlcmd.CommandType = CommandType.Text;

            sqlcmd.CommandText = $"select * from KHACHHANG where USERNAME='{username}'";
            sqlcmd.Connection = connect.sqlCon;
            SqlDataReader reader = sqlcmd.ExecuteReader();
            using (reader)
            {
                if (reader.Read()) // Kiểm tra xem có dữ liệu hay không
                {
                    toemail = reader.GetString(11);
                }
            }
           

            reader.Close();
         try
            {
                MailAddress to = new MailAddress(toemail);
                MailAddress from = new MailAddress("ginkohotel@gmail.com");

                MailMessage email = new MailMessage(from, to);
                email.Subject = "Changing GINKGO account password";
                string mkmoi = random_str();
                email.Body = $"You have changed your account password!\nYour account:{username}\nYour new passwword:{mkmoi}";

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587; // Sử dụng cổng 587 cho TLS
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("ginkohotel@gmail.com", "buvp zhce avyp rphz");

                smtp.EnableSsl = true; // Bật SSL


                try
                {
                    smtp.Send(email);
                    string hasspass3 = HashPassword.HashToHexString(HashPassword.CalculateSHA256(mkmoi));
                    sqlcmd.CommandText = "UPDATE " + "KHACHHANG" + " SET PASS='" + hasspass3 + "' WHERE USERNAME='" + username + "'";
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("we had sent an email with new password to email:");

                }
                catch (SmtpException ex)
                {
                    MessageBox.Show(ex.Message);
                }

               
            }
            catch
            {
                MessageBox.Show("invalid username");


            }


        }
        private string random_str()
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            // Đối tượng Random để tạo số ngẫu nhiên
            Random random = new Random();

            // Tạo chuỗi ngẫu nhiên bằng cách chọn các ký tự từ chuỗi characters
            string randomString = new string(Enumerable.Repeat(characters, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());

            return randomString;
        }
        public string Travegamil()
        {
            return username;
        }
    }
       
    }

