using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Models
{
    public class GarageItemLink
    {
        public int ItemId { get; set; }
        public ItemLinkType LinkType { get; set; }
        public string Link { get; set; }

        public GarageItemLink(ItemLinkType linkType, string link)
        {
            this.LinkType = linkType;
            this.Link = link;
        }
    }
}