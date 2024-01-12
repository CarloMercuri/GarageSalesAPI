using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GarageSales.Business
{
    public interface ISalesFilesHandler
    {
        string GetUploadsDirectory();
        string GetEncryptedFileName(string originName);
    }
}