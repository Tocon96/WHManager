using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        int CreateNewInvoice(DateTime dateIssued, int clientId, int orderId);
        void UpdateInvoice(int id, DateTime dateIssued, int clientId, int orderId);
        void DeleteInvoice(int id);
        Invoice GetInvoice(int id);
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        IEnumerable<Invoice> GetInvoicesByDate(DateTime? earlierDate, DateTime? laterDate);
        Invoice GetInvoiceByOrder(int orderId);
        IEnumerable<Invoice> SearchInvoices(List<string> criteria);
    }
}
