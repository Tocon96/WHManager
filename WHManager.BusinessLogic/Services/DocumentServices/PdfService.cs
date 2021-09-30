using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;
using System.IO;
using WHManager.BusinessLogic.Services.Interfaces;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.DocumentServices
{
    public class PdfService : IPdfService
    {
        IInvoiceService invoiceService = new InvoiceService();

        public void GeneratePdf(string fileName, int invoiceId)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                Invoice invoice = invoiceService.GetInvoiceById(invoiceId);

                IList<string> invoiceData = ProcessInvoice(invoice);

                /*
                Font bigFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 14, Font.BOLD);
                Font smallFont = FontFactory.GetFont(BaseFont.HELVETICA, BaseFont.CP1257, 12, Font.NORMAL);

                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                Paragraph invoiceHeader = new Paragraph("Faktura " + invoiceData[0]);
                invoiceHeader.Font.Size = 24;
                invoiceHeader.Font.SetStyle("bold");
                invoiceHeader.Alignment = 1;
                pdfDoc.Add(invoiceHeader);
                pdfDoc.Add(Chunk.NEWLINE);
                pdfDoc.Add(Chunk.NEWLINE);

                PdfPTable clientDataTable = CreateClientDataTable(invoiceData, bigFont, smallFont);
                pdfDoc.Add(clientDataTable);
                */
                //pdfDoc.Close();
                stream.Close();
            }
        }

        public Invoice GetInvoice(int invoiceId)
        {
            Invoice invoice = invoiceService.GetInvoiceById(invoiceId);
            return invoice;
        }

        public IList<string> ProcessInvoice(Invoice invoice)
        {
            IList<string> invoiceData = new List<string>();
            invoiceData.Add(invoice.Id.ToString());
            invoiceData.Add(invoice.Client.Name.ToString());
            invoiceData.Add(invoice.Client.Nip.ToString());
            invoiceData.Add(invoice.Client.PhoneNumber.ToString());

            invoiceData.Add(invoice.Order.DateOrdered.ToShortDateString()); 
            invoiceData.Add(invoice.DateIssued.ToShortDateString());
            
            return invoiceData;
        }
        /*
        private void ApplyCellAttributes(PdfPTable table, PdfPCell cell, string type)
        {
            cell.Border = 0;
            if (type == "client")
            {
                cell.HorizontalAlignment = 0;
            }
            
            if(type == "date")
            {
                cell.HorizontalAlignment = 2;
            }

            table.AddCell(cell);
        }

        private PdfPTable CreateClientDataTable(IList<string> invoiceData, Font bigFont, Font smallFont)
        {
            PdfPTable table = new PdfPTable(2);

            float[] array = new float[2];
            array[0] = 300;
            array[1] = 300;

            table.SetWidthPercentage(array, PageSize.A4);

            PdfPCell clientData = new PdfPCell(new Phrase("Klient: ", bigFont));
            PdfPCell clientName = new PdfPCell(new Phrase("Nazwa: " + invoiceData[1], smallFont));
            PdfPCell clientNip = new PdfPCell(new Phrase("NIP: " + invoiceData[2], smallFont));
            PdfPCell clientPhone = new PdfPCell(new Phrase("Nr telefonu: " + invoiceData[3], smallFont));

            PdfPCell dateIssuedData = new PdfPCell(new Phrase("Data złożenia zamówienia: ", bigFont));
            PdfPCell dateIssued = new PdfPCell(new Phrase(invoiceData[4], smallFont));
            PdfPCell dateOrderedData = new PdfPCell(new Phrase("Data realizacji zamówienia: ", bigFont));
            PdfPCell dateOrdered = new PdfPCell(new Phrase(invoiceData[5], smallFont));

            ApplyCellAttributes(table, clientData, "client");
            ApplyCellAttributes(table, dateIssuedData, "date");
            ApplyCellAttributes(table, clientName, "client");
            ApplyCellAttributes(table, dateIssued, "date");
            ApplyCellAttributes(table, clientNip, "client");
            ApplyCellAttributes(table, dateOrderedData, "date");
            ApplyCellAttributes(table, clientPhone, "client");
            ApplyCellAttributes(table, dateOrdered, "date");

            return table;
        }{
        */
    }
}