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
    public class BDataReader : IBusinessReader
    {
        private IDataRepositoryReader _dataQueries;
        private IBusinessUpConverter _upConverter;

        public BDataReader(IDataRepositoryReader reader, IBusinessUpConverter converter)
        {
            _dataQueries = reader;
            _upConverter = converter;
        }

        public List<SalesItem> GetAllItems()
        {
            return _upConverter.ConvertItems(_dataQueries.GetAllItems());
        }
    }
}