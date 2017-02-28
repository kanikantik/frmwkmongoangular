using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HyperWebApp1.API.Startup))]

namespace HyperWebApp1.API
{
    public partial class Startup
    {
        /// <summary>
        /// The configuration method.
        /// </summary>
        /// <param name="app">The app parameter.</param>
        public void Configuration(IAppBuilder app)
        {  //no code as EPAM SSO is selected

        }
    }
}
