using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Interfaces
{
    public interface IDataRepositoryWriter
    {
        void AddItem(GarageItem item);
        void AddImage(GarageImage image);
        void DeleteImage(GarageImage image);
        void SetImageAsThumbnail(GarageImage image);
        void DeleteItem(GarageItem item);
    }
}