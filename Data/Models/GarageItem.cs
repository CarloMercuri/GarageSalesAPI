using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Models
{
    public class GarageItem
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public int ItemAmount { get; set; }
        public List<GarageImage> Images { get; set; } = new List<GarageImage>();
        public List<GarageItemLink> Links { get; set; } = new List<GarageItemLink>();
        public List<GarageItemComment> Comments { get; set; } = new List<GarageItemComment>();

        public GarageItem()
        {

        }

        public GarageItem(int id, string name, int amount)
        {
            this.Id = id;
            this.ItemName = name;
            this.ItemAmount = amount;
        }

        public GarageItem(int id, string name, int amount, List<GarageImage> images)
        {
            this.Id = id;
            this.ItemName = name;
            this.ItemAmount = amount;
            this.Images = images;
        }

        public GarageItem(int id, string name, int amount, List<GarageImage> images, List<GarageItemLink> links)
        {
            this.Id = id;
            this.ItemName = name;
            this.ItemAmount = amount;
            this.Images = images;
            this.Links = links;

        }

        public GarageItem(int id, string name, int amount, List<GarageImage> images, List<GarageItemLink> links, List<GarageItemComment> comments)
        {
            this.Id = id;
            this.ItemName = name;
            this.ItemAmount = amount;
            this.Images = images;
            this.Links = links;
            this.Comments = comments;

        }

        public void AddImage(GarageImage image)
        {
            this.Images.Add(image);
        }

        public void AddImages(List<GarageImage> images)
        {
            this.Images.AddRange(images);
        }

        public void AddImages(params GarageImage[] images)
        {
            this.Images.AddRange(images);
        }

        public void AddLink(GarageItemLink link)
        {
            this.Links.Add(link);
        }

        public void AddLinks(List<GarageItemLink> links)
        {
            this.Links.AddRange(links);
        }

        public void AddLinks(params GarageItemLink[] links)
        {
            this.Links.AddRange(links);

        }

        public void AddComment(GarageItemComment comment)
        {
            this.Comments.Add(comment);
        }

        public void AddComments(List<GarageItemComment> comments)
        {
            this.Comments.AddRange(comments);
        }

        public void AddComments(params GarageItemComment[] comments)
        {
            this.Comments.AddRange(comments);

        }
    }
}