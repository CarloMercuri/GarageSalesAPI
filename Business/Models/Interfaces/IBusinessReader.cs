using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models.Interfaces
{
    public interface IBusinessReader
    {
        List<SalesItem> GetAllItems();
    }
}