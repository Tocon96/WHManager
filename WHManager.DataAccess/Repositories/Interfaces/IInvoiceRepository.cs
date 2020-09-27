using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.DataAccess.Models;

namespace WHManager.DataAccess.Repositories.Interfaces
{
    public interface IInvoiceRepository
    {
        Task<Invoice> CreateNewInvoiceAsync(int id, DateTime dateIssued, int clientId, int orderId);
        Task UpdateInvoiceAsync(int id, DateTime dateIssued, int clientId, int orderId);
        Task DeleteInvoiceAsync(int id);
        Invoice GetInvoice(int id);
        IEnumerable<Invoice> GetAllInvoices();
        IEnumerable<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        Invoice GetInvoiceByOrder(int orderId);
    }
}
