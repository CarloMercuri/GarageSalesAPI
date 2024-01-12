using GarageSales.Data.EntityFramework;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace GarageSales.Data.Logic
{
    public class EFDataReader : IDataRepositoryReader
    {
        private IDataRepositoryUpConverter _converter;
        private GarageSalesContext _context;

        public EFDataReader(IDataRepositoryUpConverter converter)
        {
            _converter = converter;
            _context = new GarageSalesContext();
        } 

        /// <summary>
        /// Gets a specific Image from database.
        /// </summary>
        /// <param name="img_id"></param>
        /// <returns></returns>
        public GarageImage GetImage(int img_id)
        {
            Image img = _context.Images.FirstOrDefault(x => x.image_id == img_id);
            return _converter.ConvertImage(img);
        }

        /// <summary>
        /// Gets a list of all Items from database, included extras
        /// </summary>
        /// <returns></returns>
        public List<GarageItem> GetAllItems()
        {
            List<Item> items = _context.Items.Include(i => i.Images).Include(l => l.ItemLinks).Include(c => c.ItemAdminComments).ToList();

            return _converter.ConvertItems(items);
        }


    }
}