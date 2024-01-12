using GarageSales.Data.EntityFramework;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business.Models.Interfaces
{
    public interface IBusinessDownConverter
    {
        GarageImage ConvertImage(SalesImage input);
        List<GarageImage> ConvertImages(IEnumerable<SalesImage> input);
        GarageItemLink ConvertLink(SalesItemLink input);
        List<GarageItemLink> ConvertsLinks(IEnumerable<SalesItemLink> input);
        GarageItemComment ConvertComment(SalesItemComment input);
        List<GarageItemComment> ConvertComments(IEnumerable<SalesItemComment> input);
        GarageItem ConvertItem(SalesItem input);
        List<GarageItem> ConvertItems(IEnumerable<SalesItem> input);
    }
}