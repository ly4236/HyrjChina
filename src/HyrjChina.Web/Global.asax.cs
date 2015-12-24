using Enyim.Caching;
using HyrjChina.Web.Cache;
using HyrjChina.Web.Entities;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace HyrjChina.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private readonly static string RedisConnection = ConfigurationManager.AppSettings["RedisConnection"];
        private readonly ILog _logger = LogManager.GetLogger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Task.Factory.StartNew(() =>
            //{
            //    Database.SetInitializer(new CreateDatabaseIfNotExists<DefaultDbContext>());
            //    Database.SetInitializer(new InitData());
            //    var count = new DefaultDbContext().Customer.Count();

            //    if (RedisContext.RedisDatabase == null)
            //    {
            //        RedisContext.RedisDatabase = ConnectionMultiplexer.Connect(RedisConnection).GetDatabase();
            //    }
            //});
        }

        private void CurrentDomainOnFirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            _logger.Error(e.Exception);
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            var lastError = Server.GetLastError().GetBaseException();
            {
                _logger.Error(lastError);
            }
        }
    }
}
