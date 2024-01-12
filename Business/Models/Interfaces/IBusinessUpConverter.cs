using GarageSales.Data.EntityFramework;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business.Models.Interfaces
{
    public interface IBusinessUpConverter
    {
        SalesImage ConvertImage(GarageImage input);
        List<SalesImage> ConvertImages(IEnumerable<GarageImage> input);
        SalesItemLink ConvertLink(GarageItemLink input);
        List<SalesItemLink> ConvertsLinks(IEnumerable<GarageItemLink> input);
        SalesItemComment ConvertComment(GarageItemComment input);
        List<SalesItemComment> ConvertComments(IEnumerable<GarageItemComment> input);
        SalesItem ConvertItem(GarageItem input);
        List<SalesItem> ConvertItems(IEnumerable<GarageItem> input);
    }
}