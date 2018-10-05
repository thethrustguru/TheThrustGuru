using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Drawing;
using TheThrustGuru.DataModels;
using System.Threading.Tasks;

namespace TheThrustGuru.Utils
{
    public class Ticket
    {
        PrintDocument pdoc = null;
        string underLine = "------------------------------------------";

        public List<StockDataModel> stocks { get; set; }
        public string receiptNo { get; set; }
        public DateTime receiptDate { get; set; }
        public decimal amountPayable { get; set; }
        public decimal totalPrice { get; set; }
        public decimal discount { get; set; }
        public decimal serviceCharge { get; set; }
        public decimal totalQuantity { get; set; }      
        public List<RecipesDataModel> recipes { get; set; }       

        
        public async Task print()
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;

            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;

            pdoc.DefaultPageSettings.PaperSize.Width = 520;

            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintPage);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }

        }

        public async Task printRecipe()
        {
            PrintDialog pd = new PrintDialog();
            pdoc = new PrintDocument();
            PrinterSettings ps = new PrinterSettings();
            Font font = new Font("Courier New", 15);


            PaperSize psize = new PaperSize("Custom", 100, 200);
            //ps.DefaultPageSettings.PaperSize = psize;

            pd.Document = pdoc;
            pd.Document.DefaultPageSettings.PaperSize = psize;
            //pdoc.DefaultPageSettings.PaperSize.Height =320;
            pdoc.DefaultPageSettings.PaperSize.Height = 820;

            pdoc.DefaultPageSettings.PaperSize.Width = 520;

            pdoc.PrintPage += new PrintPageEventHandler(pdoc_PrintRecipe);

            DialogResult result = pd.ShowDialog();
            if (result == DialogResult.OK)
            {
                PrintPreviewDialog pp = new PrintPreviewDialog();
                pp.Document = pdoc;
                result = pp.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pdoc.Print();
                }
            }

        }

        void pdoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 50;
            int startY = 55;
            int Offset = 40;
            graphics.DrawString("Welcome to The Thrust Guru", new Font("Courier New", 14),
                                new SolidBrush(Color.Black), startX, startY + Offset);
            Offset += 20;
            graphics.DrawString("Receipt No:" + receiptNo,
                     new Font("Courier New", 14),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Receipt Date :" + receiptDate,
                     new Font("Courier New", 12),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;            
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 40;            
            foreach(var data in stocks)
            {                
                graphics.DrawString(data.name + "\t" + FormatPrice.format(data.unitPrice), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 20;
            }            

            Offset += 20;                               
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Total Quantity\t" + totalQuantity, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Total Price\t" + FormatPrice.format(totalPrice), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Discounts\t" + FormatPrice.format(discount), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Service Charge\t" + FormatPrice.format(serviceCharge), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Amount Payable\t" + FormatPrice.format(amountPayable), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 40;           
            graphics.DrawString("---Thank you for shoping with us---", new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);
        }

        void pdoc_PrintRecipe(object sender, PrintPageEventArgs e)
        {
            Graphics graphics = e.Graphics;
            Font font = new Font("Courier New", 10);
            float fontHeight = font.GetHeight();
            int startX = 50;
            int startY = 55;
            int Offset = 40;
            graphics.DrawString("Welcome to The Thrust Guru", new Font("Courier New", 14),
                                new SolidBrush(Color.Black), startX, startY + Offset);           

            Offset += 20;
            graphics.DrawString("Receipt Date :" + receiptDate,
                     new Font("Courier New", 12),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 40; int qty = 0;
            foreach (var data in recipes)
            {
                graphics.DrawString(data.name + "\t" + FormatPrice.format(data.price), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);
                Offset += 20;
                qty++;
            }

            Offset += 20;
            graphics.DrawString(underLine, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Total Quantity\t" + qty, new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 20;
            graphics.DrawString("Total Price\t" + FormatPrice.format(totalPrice), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);
           
            Offset += 20;
            graphics.DrawString("Amount Payable\t" + FormatPrice.format(amountPayable), new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);

            Offset += 40;
            graphics.DrawString("---Thank you for shoping with us---", new Font("Courier New", 10),
                     new SolidBrush(Color.Black), startX, startY + Offset);
        }
    }
}

