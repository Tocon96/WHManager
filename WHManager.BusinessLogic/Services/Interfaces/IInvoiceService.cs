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
        IList<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        IList<Invoice> GetInvoices();
        IList<Invoice> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate);
        IList<Invoice> SearchInvoices(List<string>criteria);
    }
}
