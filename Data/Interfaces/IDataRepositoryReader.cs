using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Interfaces
{
    public interface IDataRepositoryReader
    {
        List<GarageItem> GetAllItems();
    }
}