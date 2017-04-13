using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProjectWork.Web
{
    public class Bootstrapper
    {
        public static void Run()
        {
            //Configure Autofac
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            //Configure Automapper
            //AutoMapperConfiguration.Configure();
        }
    }
}