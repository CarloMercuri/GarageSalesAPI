using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GarageSales.Business
{
    public class FilesHelper : ISalesFilesHandler
    {
        public string GetEncryptedFileName(string originName)
        {
            return "";
        }

        public void DeleteImage(string fileName)
        {
            try
            {
                File.Delete(Path.Combine(GetUploadsDirectory(), fileName));
            }
            catch (Exception ex)
            {

            }
        }

        public string GetUploadsDirectory()
        {
            //return @"C:\GarageSalesStorage\Uploads";
            return @"C:\dev\SalesCentral\sales-central\src\assets\itemImages";
        }
    }
}