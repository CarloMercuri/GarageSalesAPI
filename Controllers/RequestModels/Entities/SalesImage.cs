using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models
{
    public class SalesImage
    {
        public int ImageId { get; set; }
        public int ItemId { get; set; }
        public string ImageName { get; set; }
        public string ImageType { get; set; }

        public SalesImage()
        {

        }

        public SalesImage(string name, string imageType)
        {
            this.ImageName = name;
            this.ImageType = imageType;
        }

        public SalesImage(string name, string imageType, int imageId)
        {
            this.ImageId = imageId;
            this.ImageName = name;
            this.ImageType = imageType;
        }

        public SalesImage(string name, string imageType, int imageId, int itemId)
        {
            this.ImageId = imageId;
            this.ItemId = itemId;
            this.ImageName = name;
            this.ImageType = imageType;
        }
    }
}