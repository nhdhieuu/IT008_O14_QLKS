using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using IT008_O14_QLKS.View.Manager.Card;

namespace IT008_O14_QLKS.Models
{
    public class PrintReceipt
    { 
        private PrintDocument PrintDocument;
        private Graphics graphics;
        private ReceiptCard _receiptCard;
        
        private int InitialHeight = 360;
        private float x = 0;
        private float y = 0;

        public PrintReceipt(ReceiptCard receiptCard)
        {
            this._receiptCard = receiptCard;
        }
        
        public void Print()
        {
            var doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(FormatPage);
            doc.Print();
        }
        void DrawAtStart(string text, float Offset)
        {
            int startX = 10;
            int startY = 5;
            Font minifont = new Font("Arial", 12);

            graphics.DrawString(text, minifont,
                     new SolidBrush(Color.Black), x + 5, y + Offset);
        }
        void InsertItem(string key, string value, float Offset)
        {
            Font minifont = new Font("Arial", 12);
            int startX = 10;
            int startY = 5;

            graphics.DrawString(key, minifont,
                         new SolidBrush(Color.Black), x + 5, y + Offset);

            graphics.DrawString(value, minifont,
                     new SolidBrush(Color.Black), x + 130, y + Offset);
        }
        void InsertHeaderStyleItem(string key, string value, float Offset)
        {
            int startX = 10;
            int startY = 5;
            Font itemfont = new Font("Arial", 13, FontStyle.Bold);

            graphics.DrawString(key, itemfont,
                         new SolidBrush(Color.Black), x + 5, y + Offset);

            graphics.DrawString(value, itemfont,
                     new SolidBrush(Color.Black), x + 130, y + Offset);
        }
        void DrawLine(string text, Font font, float Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), x + xOffset, y + Offset);
        }
        void DrawSimpleString(string text, Font font, float Offset, int xOffset)
        {
            int startX = 10;
            int startY = 5;
            graphics.DrawString(text, font,
                     new SolidBrush(Color.Black), x + xOffset, y + Offset);
        }

        private void FormatPage(object sender, PrintPageEventArgs e)
        {
            graphics = e.Graphics;
            Font minifont = new Font("Arial", 12);
            Font itemfont = new Font("Arial", 13);
            Font smallfont = new Font("Arial", 8);
            Font mediumfont = new Font("Arial", 17);
            Font largefont = new Font("Arial", 18);
            RectangleF pageRectangle = e.PageSettings.PrintableArea;
            SizeF pageSize = pageRectangle.Size;

            float layoutWidth = pageSize.Width;
            float layoutHeight = 0f;
            float centerX = (pageSize.Width) / 2;
            float centerY = (pageSize.Height) / 2;
            x = centerX;
            y = centerY;
            float Offset = 0;
            int smallinc = 15, mediuminc = 20, largeinc = 25;

            //Image image = Resources.logo;
            //e.Graphics.DrawImage(image, startX + 50, startY + Offset, 100, 30);

            // graphics.DrawString("Welcome to Ginko Hotel", smallfont,
            //       new SolidBrush(Color.Black), x + 22, y + Offset);

            Offset = Offset + largeinc + 10;

            String underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            DrawAtStart($"Invoice Number: {_receiptCard._receiptId}", Offset);




            Offset = Offset + mediuminc;
            DrawAtStart("Phone: 0123456789", Offset);


            Offset = Offset + mediuminc;
            DrawAtStart($"Date: {_receiptCard._date}", Offset);

            Offset = Offset + smallinc;
            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;

            InsertHeaderStyleItem("Name. ", "Price. ", Offset);

            Offset = Offset + largeinc;

            foreach (var detailroom  in _receiptCard._room.room)
            {
                InsertItem(detailroom,"" , Offset);
                Offset = Offset + mediuminc;
            }

            foreach (var dichVu in _receiptCard._DichVu)
            {
                if (dichVu._ttdichvu[0] != "" && dichVu._ttdichvu[1] != "")
                {
                    InsertItem(dichVu._ttdichvu[0] + " x " + dichVu._ttdichvu[1], "", Offset);
                    Offset = Offset + mediuminc;
                }
                
                    

            }
            foreach (var problem in _receiptCard._Problem)
            {
                if (problem._ttproblem[0] != "" && problem._ttproblem[1] != "")
                {
                    
                    InsertItem(problem._ttproblem[0] + " x " + problem._ttproblem[1], "", Offset);
                    Offset = Offset + mediuminc;
                }

            }
            Offset = Offset + smallinc;
            // InsertItem("P101", "", Offset);
            // Offset = Offset + smallinc;
            //
            // Offset = Offset + smallinc;

            underLine = "-------------------------";
            DrawLine(underLine, largefont, Offset, 30);

            Offset = Offset + largeinc;
            Offset = Offset + smallinc;
            InsertItem(" Net. Total: ", $"{_receiptCard._totalMoney}", Offset);


            // Offset = Offset + largeinc;
            // String address = shop.Address;
            // DrawSimpleString("Address: " + address, minifont, Offset, 15);

            // Offset = Offset + smallinc;
            // String number = "Tel: " + shop.Phone1 + " - OR - " + shop.Phone2;
            // DrawSimpleString(number, minifont, Offset, 35);

            Offset = Offset + 7;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);

            Offset = Offset + mediuminc;
            String greetings = "Thanks for visiting us.";
            DrawSimpleString(greetings, mediumfont, Offset, 28);

            Offset = Offset + mediuminc;
            underLine = "-------------------------------------";
            DrawLine(underLine, largefont, Offset, 0);
        }

    }
}