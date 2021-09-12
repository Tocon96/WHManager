using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public interface IPdfService
    {
        public void GeneratePdf(string fileName, int invoiceId);
        public Invoice GetInvoice(int invoiceId);
        public IList<string> ProcessInvoice(Invoice invoice);
    }
}
