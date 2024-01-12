using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Controllers.RequestModels
{
    public class NewItemRequestModel
    {
        public string ItemName { get; set; }
        public int Amount { get; set; }

    }
}