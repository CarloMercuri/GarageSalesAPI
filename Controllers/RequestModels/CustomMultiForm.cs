using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;

namespace GarageSales.Controllers.RequestModels
{
    public class CustomMultiForm : MultipartFormDataStreamProvider
    {
        string basePath;

        public CustomMultiForm(string path)
            : base(path)
        {
            basePath = path;
        }

        public override string GetLocalFileName(System.Net.Http.Headers.HttpContentHeaders headers)
        {
            string fileName;
            string newName = GetValidFileName(headers.ContentDisposition.FileName);


            return newName;
        }

        /// <summary>
        /// Returns a valid name. Only accepts the file name
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private string GetValidFileName(string name)
        {
            // Clean it up if needed
            string fixedName = name.Replace("\"", string.Empty);

            string fullPath = Path.Combine(basePath, fixedName);
     
            string fileExtension = Path.GetExtension(fullPath);

            string newName = Guid.NewGuid().ToString() + fileExtension;

         

            return newName;
        }
    }
}