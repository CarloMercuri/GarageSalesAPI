using GarageSales.Data.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Models
{
    public class GarageImage
    {
        public int ImageId { get; set; }
        public ItemImageType ImageType { get; set; }
        public string ImageName { get; set; }
        public int ItemId { get; set; }

        public GarageImage()
        {

        }


        public GarageImage(int id, ItemImageType type, string name, int itemId)
        {
            this.ImageId = id;
            this.ImageType = type;
            this.ImageName = name;
            this.ItemId = itemId;
        }
    }
}