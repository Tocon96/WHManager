﻿using LiveCharts;
using System;
using System.Collections.Generic;
using System.Text;
using WHManager.BusinessLogic.Models;

namespace WHManager.BusinessLogic.Services.ReportsServices.Interfaces
{
    public interface IContrahentReportsService
    {
        public int CreateReport(ContrahentReports report);
        public void DeleteReport(int reportId);
        public ContrahentReports GetReport(int id);
        public IList<ContrahentReports> GetClientReports();
        public IList<ContrahentReports> GetProviderReports();
        public IDictionary<string, double> ParseDeliveryList(List<Delivery> deliveries);
        public IDictionary<string, double> ParseOrderList(List<Order> orders);
        public IList<ContrahentReports> SearchReports(List<string> criteria);
    }
}
