using GarageSales.Business;
using GarageSales.Data.EntityFramework;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Data.Logic
{
    public class EFDataWriter : IDataRepositoryWriter
    {
        IDataRepositoryDownConverter _converter;
        private GarageSalesContext _context;

        public EFDataWriter(IDataRepositoryDownConverter converter)
        {
            _converter = converter;
            _context = new GarageSalesContext();
        }
        public void AddImage(GarageImage image)
        {
            Image img = _converter.ConvertImage(image);
            List<Image> images = _context.Images.ToList();
            if(images.Count == 0)
            {
                // set as thumbnail if it's the first image
                img.image_type = 2;
            }
            _context.Images.Add(img);
            _context.SaveChanges();
        }

        public void SetImageAsThumbnail(GarageImage image)
        {
            List<Image> images = _context.Images.ToList();

            foreach(Image img in images)
            {
                if(img.image_id == image.ImageId)
                {
                    img.image_type = 2;
                }
                else
                {
                    img.image_type = 1;
                }
            }

            _context.SaveChanges();
        }

        public void DeleteItem(GarageItem item)
        {
            try
            {
                Item i = _converter.ConvertItem(item);
                _context.Items.Attach(i);
                _context.Items.Remove(i);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void DeleteImage(GarageImage image)
        {
            try
            {
                Image img = _converter.ConvertImage(image);

                _context.Images.Attach(img);
                _context.Images.Remove(img);
                _context.SaveChanges();

                FilesHelper files = new FilesHelper();
                files.DeleteImage(image.ImageName);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public void AddItem(GarageItem item)
        {
            Item repoItem = _converter.ConvertItem(item);
            _context.Items.Add(repoItem);
            _context.SaveChanges();
        }
    }
}