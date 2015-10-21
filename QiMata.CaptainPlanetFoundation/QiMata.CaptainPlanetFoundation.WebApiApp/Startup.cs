using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(QiMata.CaptainPlanetFoundation.WebApiApp.Startup))]

namespace QiMata.CaptainPlanetFoundation.WebApiApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
