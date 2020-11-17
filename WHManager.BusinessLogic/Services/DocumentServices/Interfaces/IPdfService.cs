using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace WHManager.BusinessLogic.Services.DocumentServices.Interfaces
{
    public interface IPdfService
    {
        FileStreamResult GeneratePdf();
    }
}
