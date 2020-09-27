using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task CreateNewInvoice(Invoice invoice);
        Task UpdateInvoice(Invoice invoice);
        Task DeleteInvoice(int id);
        Invoice GetInvoiceById(int id);
        Invoice GetInvoiceByOrder(int orderId);
        IList<Invoice> GetInvoicesByClient(int? clientId = null, string clientName = null, double? clientNip = null);
        IList<Invoice> GetInvoices();


    }
}
