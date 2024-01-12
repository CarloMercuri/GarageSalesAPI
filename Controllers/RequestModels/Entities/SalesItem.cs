using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models
{
    public class SalesItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Amount { get; set; }

        public List<SalesImage> Images { get; set; }
        public List<SalesItemComment> Comments { get; set; }
        public List<SalesItemLink> Links { get; set; }

        public SalesItem()
        {

        }

        public SalesItem(int id, string name, int amount)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.Amount = amount;
        }

        public SalesItem(int id, string name, int amount, List<SalesImage> images)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.Amount = amount;
            this.Images = images;
        }

        public SalesItem(int id, string name, int amount, List<SalesImage> images, List<SalesItemLink> links)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.Amount = amount;
            this.Images = images;
            this.Links = links;
        }

        public SalesItem(int id, string name, int amount, List<SalesImage> images, List<SalesItemLink> links, List<SalesItemComment> comments)
        {
            this.ItemId = id;
            this.ItemName = name;
            this.Amount = amount;
            this.Images = images;
            this.Links = links;
            this.Comments = comments;
        }
    }
}