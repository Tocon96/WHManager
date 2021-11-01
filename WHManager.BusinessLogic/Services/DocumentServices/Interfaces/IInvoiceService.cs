using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IInvoiceService
    {
        int CreateNewInvoice(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        Invoice GetInvoiceById(int id);
        Invoice GetInvoiceByOrder(int orderId);
        IList<Invoice> GetInvoices();
        IList<Invoice> SearchInvoices(List<string>criteria);
        void GeneratePdf(string filename, Order order);
    }
}