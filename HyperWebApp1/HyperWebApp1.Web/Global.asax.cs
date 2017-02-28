// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MvcApplication.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The MvcApplication.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HyperWebApp1.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System;
    using System.Web.Optimization;
    using System.Web.Routing;
    using HyperWebApp1.Web.Implementation;

    /// <summary>
    ///     Mvc Application
    /// </summary>
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// Application_s the start.
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
            if (AuthDataManager.IsFederatedAuthResponse(Request))
            {
                AuthDataManager.StoreAuthData(Request, Response);
            }
        }


        protected void Application_EndRequest(Object sender, EventArgs e)
        {
            if (AuthDataManager.IsFederatedAuthRedirect(Response))
            {
                AuthDataManager.StoreAuthRedirectData(Response);
            }
        }
    }
}
