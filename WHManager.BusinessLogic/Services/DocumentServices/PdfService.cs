using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WHManager.BusinessLogic.Services.DocumentServices.Interfaces;

namespace WHManager.BusinessLogic.Services.DocumentServices
{
    public class PdfService : IPdfService
    {
        public FileStreamResult GeneratePdf()
        {
            throw new NotImplementedException();
        }
    }
}
