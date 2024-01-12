using GarageSales.Business.Models.Interfaces;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business.Logic
{
    public class BDataUpConverter : IBusinessUpConverter
    {
        public SalesItemComment ConvertComment(GarageItemComment input)
        {
            return new SalesItemComment(input.Text, input.CommentId);
        }

        public List<SalesItemComment> ConvertComments(IEnumerable<GarageItemComment> input)
        {
            List<SalesItemComment> output = new List<SalesItemComment>();

            foreach (GarageItemComment c in input)
            {
                output.Add(ConvertComment(c));
            }

            return output;
        }

        public SalesImage ConvertImage(GarageImage input)
        {
            //Enum.GetName(typeof(ItemImageType), imageTypeInt)
            return new SalesImage(input.ImageName,
                                  Enum.GetName(typeof(ItemImageType), (int)input.ImageType),
                                  input.ImageId,
                                  input.ItemId);
        }

        public List<SalesImage> ConvertImages(IEnumerable<GarageImage> input)
        {
            List<SalesImage> output = new List<SalesImage>();

            foreach(GarageImage image in input)
            {
                output.Add(ConvertImage(image));
            }

            return output;
        }

        public SalesItem ConvertItem(GarageItem input)
        {
            return new SalesItem(input.Id,
                                 input.ItemName,
                                 input.ItemAmount,
                                 ConvertImages(input.Images),
                                 ConvertsLinks(input.Links),
                                 ConvertComments(input.Comments));
        }

        public List<SalesItem> ConvertItems(IEnumerable<GarageItem> input)
        {
            List<SalesItem> output = new List<SalesItem>();

            foreach (GarageItem l in input)
            {
                output.Add(ConvertItem(l));
            }

            return output;
        }

        public SalesItemLink ConvertLink(GarageItemLink input)
        {
            return new SalesItemLink(Enum.GetName(typeof(ItemLinkType), (int)input.LinkType),
                                     input.Link);
        }

        public List<SalesItemLink> ConvertsLinks(IEnumerable<GarageItemLink> input)
        {
            List<SalesItemLink> output = new List<SalesItemLink>();

            foreach (GarageItemLink l in input)
            {
                output.Add(ConvertLink(l));
            }

            return output;
        }
    }
}