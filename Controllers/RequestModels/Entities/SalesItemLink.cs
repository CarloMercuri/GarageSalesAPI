using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models
{
    public class SalesItemLink
    {
        public int LinkId { get; set; }
        public string LinkType { get; set; }
        public string LinkText { get; set; }

        public SalesItemLink()
        {

        }

        public SalesItemLink(string type, string text)
        {
            this.LinkType = type;
            this.LinkText = text;
        }

        public SalesItemLink(string type, string text, int id)
        {
            this.LinkType = type;
            this.LinkText = text;
            this.LinkId = id;
        }
    }
}