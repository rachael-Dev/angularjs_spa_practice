using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace FIGFiance.BookStore.Test.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class Bootstrapper
    {
        public static void Run()
        {
            // Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            ////Configure AutoMapper
            //AutoMapperConfiguration.Configure();
        }
    }
}