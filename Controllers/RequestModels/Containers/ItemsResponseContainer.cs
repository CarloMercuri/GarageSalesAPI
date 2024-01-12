using GarageSales.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Controllers.RequestModels.Containers
{
    public class ItemsResponseContainer
    {
        public int Amount { get; set; }
        public List<SalesItem> Items { get; set; } = new List<SalesItem>();
    }
}