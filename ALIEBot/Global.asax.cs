using ALIEbot.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ALIEbot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DataBuilder.BuildCharacters();
            GlobalConfiguration.Configure(WebApiConfig.Register);

        }
    }
}
