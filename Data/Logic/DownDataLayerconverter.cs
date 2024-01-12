using GarageSales.Data.EntityFramework;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Logic
{
    public class DownDataLayerConverter : IDataRepositoryDownConverter
    {
        /// <summary>
        /// Converts an Processing 'GarageImage' instance to an EntityFramework Layer 'Image' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Image ConvertImage(GarageImage input)
        {
            Image output = new Image();
            int imageTypeInt = (int)input.ImageType;
            output.image_id = input.ImageId;
            output.image_name = input.ImageName;
            output.item_id = input.ItemId;
            output.image_type = imageTypeInt;
            output.ImageType = new ImageType()
            {
                type_id = imageTypeInt,
                type_name = Enum.GetName(typeof(ItemImageType), imageTypeInt)
            };

            return output;
        }

        /// <summary>
        /// Converts a Processing 'List<GarageImage>' instance to an EntityFramework Layer 'List<Image>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Image> ConvertImages(IEnumerable<GarageImage> input)
        {
            List<Image> output = new List<Image>();

            foreach (GarageImage img in input)
            {
                output.Add(ConvertImage(img));
            }

            return output;
        }

           /// <summary>
        /// Converts an Processing 'GarageItemLink' instance to a EntityFramework Layer 'ItemLink' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ItemLink ConvertLink(GarageItemLink input)
        {
            int itemTypeInt = (int)input.LinkType;
            ItemLink output = new ItemLink();
            output.link_url = input.Link;
            output.link_type = itemTypeInt;
            output.item_id = input.ItemId;
            //output.Item = item;
            output.LinkType = new LinkType()
            {
                type_id = (int)input.LinkType,
                type_name = Enum.GetName(typeof(ItemLinkType), itemTypeInt)

            };

            return output;
        }

        /// <summary>
        /// Converts an Processing 'List<GarageItemLink>' instance to a EntityFramework Layer 'List<ItemLink>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ItemLink> ConvertsLinks(IEnumerable<GarageItemLink> input)
        {
            List<ItemLink> output = new List<ItemLink>();

            foreach (GarageItemLink link in input)
            {
                output.Add(ConvertLink(link));
            }

            return output;
        }

        /// <summary>
        /// Converts a Processing 'GarageItemComment' instance to an EntityFramework Layer 'ItemAdminComment' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public ItemAdminComment ConvertComment(GarageItemComment input)
        {
            ItemAdminComment output = new ItemAdminComment()
            {
                comment_id = input.CommentId,
                comment_text = input.Text,
                //Item = item
            };
            return output;
        }

        /// <summary>
        /// Converts a Processing 'List<GarageItemComment>' instance to an EntityFramework Layer 'List<ItemAdminComment>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<ItemAdminComment> ConvertComments(IEnumerable<GarageItemComment> input)
        {
            List<ItemAdminComment> output = new List<ItemAdminComment>();

            foreach (GarageItemComment comment in input)
            {
                output.Add(ConvertComment(comment));
            }

            return output;
        }

        /// <summary>
        /// Converts a Processing 'GarageItem' instance to an EntityFramework Layer 'Item' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Item ConvertItem(GarageItem input)
        {
            Item output = new Item();
            output.item_name = input.ItemName;
            output.item_amount = input.ItemAmount;
            output.item_id = input.Id;

            if (input.Images != null)
            {
                output.Images = ConvertImages(input.Images);
            }

            if (input.Links != null)
            {
                output.ItemLinks = ConvertsLinks(input.Links);
            }

            if (input.Comments != null)
            {
                output.ItemAdminComments = ConvertComments(input.Comments);
            }

            return output;
        }

        /// <summary>
        /// Converts an EntityFramework 'List<Item>' instance to a Processing Layer 'List<GarageItem>' instance.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public List<Item> ConvertItems(IEnumerable<GarageItem> input)
        {
            List<Item> output = new List<Item>();

            foreach (GarageItem item in input)
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