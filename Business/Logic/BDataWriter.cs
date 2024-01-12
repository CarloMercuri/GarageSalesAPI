using GarageSales.Business.Models.Interfaces;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using GarageSales.Processing.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business.Logic
{
    public class BDataWriter : IBusinessWriter
    {
        private IDataRepositoryWriter _dataWriter;
        private IBusinessDownConverter _downConverter;

        public BDataWriter(IDataRepositoryWriter writer, IBusinessDownConverter converter)
        {
            _dataWriter = writer;
            _downConverter = converter;
        }

        public void DeleteImage(SalesImage image)
        {
            _dataWriter.DeleteImage(_downConverter.ConvertImage(image));
        }

        public void DeleteItem(SalesItem item)
        {
            _dataWriter.DeleteItem(_downConverter.ConvertItem(item));
        }

        public void SetImageAsThumbnail(SalesImage image)
        {
            _dataWriter.SetImageAsThumbnail(_downConverter.ConvertImage(image));
        }

        public void AddComment(SalesItemComment comment, int itemId)
        {
            throw new NotImplementedException();
        }

        public void AddImage(SalesImage image, int itemId)
        {
            _dataWriter.AddImage(_downConverter.ConvertImage(image));
        }

        public void AddItem(SalesItem item)
        {
            _dataWriter.AddItem(_downConverter.ConvertItem(item));
        }

        public void AddLink(SalesItemLink link, int itemId)
        {
            throw new NotImplementedException();
        }

        public void AddUploadedImage(string imageName, int itemId)
        {
            throw new NotImplementedException();
        }

        public void EditComment(SalesItemComment comment, int itemId)
        {
            throw new NotImplementedException();
        }

        public void EditImage(SalesImage image, int itemId)
        {
            throw new NotImplementedException();
        }

        public void EditItem(SalesItem item)
        {
            throw new NotImplementedException();
        }

        public void EditLink(SalesItemLink link, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}