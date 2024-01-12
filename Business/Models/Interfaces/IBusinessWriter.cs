using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Processing.Models.Interfaces
{
    public interface IBusinessWriter
    {
        void AddItem(SalesItem item);
        void AddImage(SalesImage image, int itemId);
        void AddComment(SalesItemComment comment, int itemId);
        void AddLink(SalesItemLink link, int itemId);

        void DeleteImage(SalesImage image);
        void DeleteItem(SalesItem item);
        void SetImageAsThumbnail(SalesImage image);

        void EditItem(SalesItem item);
        void EditImage(SalesImage image, int itemId);
        void EditComment(SalesItemComment comment, int itemId);
        void EditLink(SalesItemLink link, int itemId);
        void AddUploadedImage(string imageName, int itemId);
    }
}