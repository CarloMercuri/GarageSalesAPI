using GarageSales.Data.Logic;
using GarageSales.Data.Models;
using GarageSales.Processing.Models;
using GarageSales.Processing.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System.Threading;
using System.Web;
using System.Web.Http;
using GarageSales.Controllers.RequestModels;
using System.Web.Http.Cors;
using GarageSales.Controllers.RequestModels.Containers;
using GarageSales.Business;

namespace GarageSales.Controllers
{
    [Route("[controller]")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GarageController : ApiController
    {
        IBusinessReader _reader;
        IBusinessWriter _writer;
        ISalesFilesHandler _files;

        public GarageController(IBusinessReader reader, IBusinessWriter writer, ISalesFilesHandler files)
        {
            _reader = reader;
            _writer = writer;
            _files = files;
        }

        [Route("GetItems")]
        [HttpGet]
        public IHttpActionResult GetAllItems()
        {
            try
            {
                List<SalesItem> items = _reader.GetAllItems();
                ItemsResponseContainer resp = new ItemsResponseContainer();
                resp.Amount = items.Count;
                resp.Items = items;
                return Ok(resp);

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("AddItem")]
        [HttpPost]
        public IHttpActionResult AddItem([FromBody] SalesItem item)
        {
            try
            {
                _writer.AddItem(item);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("DeleteImage")]
        [HttpPost]
        public IHttpActionResult AddItem([FromBody] SalesImage image)
        {
            try
            {
                _writer.DeleteImage(image);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("DeleteItem")]
        [HttpPost]
        public IHttpActionResult DeleteItem([FromBody] SalesItem item)
        {
            try
            {
                _writer.DeleteItem(item);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [Route("SetImageAsThumbnail")]
        [HttpPost]
        public IHttpActionResult SetImageAsThumbnail([FromBody] SalesImage image)
        {
            try
            {
                _writer.SetImageAsThumbnail(image);

                return Ok();

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }




        [HttpPost]
        [Route("UploadFile")]
        //[TokenAuthentication]
        public async Task<HttpResponseMessage> ReceiveFile()
        {
            try
            {
                HttpResponseMessage response = new HttpResponseMessage();
                int itemId = -1;

                var headers = Request.Headers;
                if (headers.Contains("Item-ID"))
                {
                    itemId = Convert.ToInt32(headers.GetValues("Item-ID").First());
                }
                else
                {
                    response.StatusCode = HttpStatusCode.NotAcceptable;
                    response.ReasonPhrase = "Invalid request! Missing Item-ID Header";
                    return response;
                }

                if (!Request.Content.IsMimeMultipartContent())
                {
                    response.StatusCode = HttpStatusCode.NotAcceptable;
                    response.ReasonPhrase = "Invalid request!";
                    return response;
                }

                


                // The file is uploaded here. The name is handled by MyMultipartFormDataStreamProvider.cs and FileHandler.cs

                CustomMultiForm streamProvider = new CustomMultiForm(_files.GetUploadsDirectory());


                var task = await Request.Content.ReadAsMultipartAsync(streamProvider);

                var file = streamProvider.FileData.First();

                if (file == null)
                {
                    response.StatusCode = HttpStatusCode.InternalServerError;
                    response.ReasonPhrase = "Error uploading the file";
                    return response;
                }


                var _fileInfo = new FileInfo(file.LocalFileName);

                // This handles processing the saved file into the database
                string enumString = EnumControl.GetImageTypeEnumName<ItemImageType>(ItemImageType.ITEMIMAGE);
                SalesImage img = new SalesImage(_fileInfo.Name, enumString, 0, itemId);
                _writer.AddImage(img, itemId);

                response.StatusCode = HttpStatusCode.OK;
                response.ReasonPhrase = $"File {_fileInfo.Name} uploaded successfully";
                return response;
            }
            catch (Exception ex)
            {
                HttpResponseMessage response = new HttpResponseMessage();
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.ReasonPhrase = $"Internal server error. Probably a bad image format.";
                return response;
            }
          

        }

    }
}