using GarageSales.Business;
using GarageSales.Business.Logic;
using GarageSales.Business.Models.Interfaces;
using GarageSales.Data.Interfaces;
using GarageSales.Data.Logic;
using GarageSales.Processing.Models.Interfaces;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace GarageSales
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<IBusinessReader, BDataReader>();
            container.RegisterType<IBusinessWriter, BDataWriter>();
            container.RegisterType<IDataRepositoryReader, EFDataReader>();
            container.RegisterType<IDataRepositoryWriter, EFDataWriter>();
            container.RegisterType<IBusinessDownConverter, BDataDownConverter>();
            container.RegisterType<IBusinessUpConverter, BDataUpConverter>();
            container.RegisterType<IDataRepositoryDownConverter, DownDataLayerConverter>();
            container.RegisterType<IDataRepositoryUpConverter, UpDataLayerConverter>();
            container.RegisterType<ISalesFilesHandler, FilesHelper>();
            

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}