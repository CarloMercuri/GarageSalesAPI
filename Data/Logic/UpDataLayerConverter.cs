using GarageSales.Data.EntityFramework;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Logic
{
    public class UpDataLayerConverter : IDataRepositoryUpConverter
    {
        /// <summary>
        /// Converts an EntityFramework 'Image' instance to a Processing Layer 'GarageImage' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GarageImage ConvertImage(Image input)
        {
            GarageImage gimage = new GarageImage(input.image_id, ConvertToImageType(input.ImageType.type_name), input.image_name, input.item_id);
            return gimage;
        }

        /// <summary>
        /// Converts an EntityFramework 'List<Image>' instance to a Processing Layer 'List<GarageImage>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<GarageImage> ConvertImages(IEnumerable<Image> input)
        {
            List<GarageImage> output = new List<GarageImage>();

            foreach(Image img in input)
            {
                output.Add(ConvertImage(img));
            }

            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'ItemLink' instance to a Processing Layer 'GarageItemLink' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GarageItemLink ConvertLink(ItemLink input)
        {
            GarageItemLink output = new GarageItemLink(ConvertToLinkType(input.LinkType.type_name), input.link_url);
            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'List<ItemLink>' instance to a Processing Layer 'List<GarageItemLink>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<GarageItemLink> ConvertsLinks(IEnumerable<ItemLink> input)
        {
            List<GarageItemLink> output = new List<GarageItemLink>();

            foreach (ItemLink link in input)
            {
                output.Add(ConvertLink(link));
            }

            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'ItemAdminComment' instance to a Processing Layer 'GarageItemComment' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GarageItemComment ConvertComment(ItemAdminComment input)
        {
            GarageItemComment output = new GarageItemComment(input.comment_text, input.comment_id);
            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'List<ItemAdminComment>' instance to a Processing Layer 'List<GarageItemComment>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<GarageItemComment> ConvertComments(IEnumerable<ItemAdminComment> input)
        {
            List<GarageItemComment> output = new List<GarageItemComment>();

            foreach (ItemAdminComment comment in input)
            {
                output.Add(ConvertComment(comment));
            }

            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'Item' instance to a Processing Layer 'GarageItem' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GarageItem ConvertItem(Item input)
        {
            GarageItem output = new GarageItem(input.item_id, input.item_name, input.item_amount);

            if(input.Images != null)
            {
                output.Images = ConvertImages(input.Images);
            }

            if(input.ItemLinks != null)
            {
                output.Links = ConvertsLinks(input.ItemLinks);
            }

            if(input.ItemAdminComments != null)
            {
                output.Comments = ConvertComments(input.ItemAdminComments);
            }

            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'List<Item>' instance to a Processing Layer 'List<GarageItem>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<GarageItem> ConvertItems(IEnumerable<Item> input)
        {
            List<GarageItem> output = new List<GarageItem>();

            foreach (Item item in input)
            {
                output.Add(ConvertItem(item));
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
            if(Enum.TryParse(typeString, true, out ItemImageType result))
            {
                return result;
            }
            else
            {
                return ItemImageType.UNKNOWN;
            }
        }

        public T Convert<T>(object input)
        {
            if(input is T)
            {

            }
            return default(T);
        }
    }
}