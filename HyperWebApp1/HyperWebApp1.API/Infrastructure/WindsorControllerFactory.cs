// --------------------------------------------------------------------------------------------------------------------
// <copyright company="EPAM SYSTEMS" file="WindsorControllerFactory.cs">
//   Copyright 2016
// </copyright>
// <summary>
//   WindsorControllerFactory
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Web.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Castle.MicroKernel;
    using Castle.Windsor;
    using Castle.Windsor.Installer;
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel kernel;

        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public override void ReleaseController(IController controller)
        {
            kernel.ReleaseComponent(controller);
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            if (controllerType == null)
            {
                throw new HttpException(404, string.Format("The controller for path '{0}' could not be found.", requestContext.HttpContext.Request.Path));
            }
            return (IController)kernel.Resolve(controllerType);
        }

    }
}