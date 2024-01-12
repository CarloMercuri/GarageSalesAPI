using GarageSales.Data.EntityFramework;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Interfaces
{
    public interface IDataRepositoryUpConverter
    {
        GarageImage ConvertImage(Image input);
        List<GarageImage> ConvertImages(IEnumerable<Image> input);
        GarageItemLink ConvertLink(ItemLink input);
        List<GarageItemLink> ConvertsLinks(IEnumerable<ItemLink> input);
        GarageItemComment ConvertComment(ItemAdminComment input);
        List<GarageItemComment> ConvertComments(IEnumerable<ItemAdminComment> input);
        GarageItem ConvertItem(Item input);
        List<GarageItem> ConvertItems(IEnumerable<Item> input);
    }
}