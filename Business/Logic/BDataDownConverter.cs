using GarageSales.Business.Models.Interfaces;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business.Logic
{
    public class BDataDownConverter : IBusinessDownConverter
    {
        public GarageItemComment ConvertComment(SalesItemComment input)
        {
            return new GarageItemComment(input.CommentText, input.CommentId);            
        }

        public List<GarageItemComment> ConvertComments(IEnumerable<SalesItemComment> input)
        {
            List<GarageItemComment> output = new List<GarageItemComment>();

            foreach(SalesItemComment c in input)
            {
                output.Add(ConvertComment(c));
            }

            return output;
        }

        public GarageImage ConvertImage(SalesImage input)
        {
            return new GarageImage(input.ImageId, ConvertToImageType(input.ImageType), input.ImageName, input.ItemId);
        }

        public List<GarageImage> ConvertImages(IEnumerable<SalesImage> input)
        {
            List<GarageImage> output = new List<GarageImage>();

            foreach (SalesImage i in input)
            {
                output.Add(ConvertImage(i));
            }

            return output;
        }

        public GarageItem ConvertItem(SalesItem input)
        {
            return new GarageItem(input.ItemId, input.ItemName, input.Amount, ConvertImages(input.Images), ConvertsLinks(input.Links), ConvertComments(input.Comments));
        }

        public List<GarageItem> ConvertItems(IEnumerable<SalesItem> input)
        {
            List<GarageItem> output = new List<GarageItem>();

            foreach (SalesItem i in input)
            {
                output.Add(ConvertItem(i));
            }

            return output;
        }

        public GarageItemLink ConvertLink(SalesItemLink input)
        {
            return new GarageItemLink(ConvertToLinkType(input.LinkType), input.LinkText);
        }

        public List<GarageItemLink> ConvertsLinks(IEnumerable<SalesItemLink> input)
        {
            List<GarageItemLink> output = new List<GarageItemLink>();

            foreach (SalesItemLink i in input)
            {
                output.Add(ConvertLink(i));
            }

            return output;
        }

        /// <summary>
        /// Converts a string rapresenting the ItemLinkType enumerator (usually coming from database), to an ItemLinkType enumerator.
        /// Returns ItemLinkType.UNKNOWN if it cannot be parsed.
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        private ItemLinkType ConvertToLinkType(string typeString)
        {
            if (Enum.TryParse(typeString, true, out ItemLinkType result))
            {
                return result;
            }
            else
            {
                return ItemLinkType.UNKNOWN;
            }
        }

        /// <summary>
        /// Converts a string rapresenting the ItemImageType enumerator (usually coming from database), to an ItemImageType enumerator.
        /// Returns ItemImageType.UNKNOWN if it cannot be parsed.
        /// </summary>
        /// <param name="typeString"></param>
        /// <returns></returns>
        private ItemImageType ConvertToImageType(string typeString)
        {
            if (Enum.TryParse(typeString, true, out ItemImageType result))
            {
                return result;
            }
            else
            {
                return ItemImageType.UNKNOWN;
            }
        }
    }
}