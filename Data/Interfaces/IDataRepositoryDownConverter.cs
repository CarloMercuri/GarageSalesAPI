using GarageSales.Data.EntityFramework;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Interfaces
{
    public interface IDataRepositoryDownConverter
    {
        Image ConvertImage(GarageImage input);
        List<Image> ConvertImages(IEnumerable<GarageImage> input);
        ItemLink ConvertLink(GarageItemLink input);
        List<ItemLink> ConvertsLinks(IEnumerable<GarageItemLink> input);
        ItemAdminComment ConvertComment(GarageItemComment input);
        List<ItemAdminComment> ConvertComments(IEnumerable<GarageItemComment> input);
        Item ConvertItem(GarageItem input);
        List<Item> ConvertItems(IEnumerable<GarageItem> input);
    }
}