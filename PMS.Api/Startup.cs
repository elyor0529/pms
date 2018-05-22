using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using log4net.Config;
using PMS.Api.Models;

[assembly: OwinStartup(typeof(PMS.Api.Startup))]
[assembly: XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace PMS.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ApplicationDbContext.Initializer();

            ConfigureAuth(app);
        }
    }
}
