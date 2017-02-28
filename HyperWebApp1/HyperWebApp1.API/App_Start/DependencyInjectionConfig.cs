// --------------------------------------------------------------------------------------------------------------------
// <copyright company="EPAM SYSTEMS" file="DependencyInjectionConfig.cs">
//   Copyright 2016
// </copyright>
// <summary>
//   DependencyInjectionConfig
// </summary>
// 
// --------------------------------------------------------------------------------------------------------------------
using WebActivatorEx;
[assembly: PreApplicationStartMethod(typeof(HyperWebApp1.API.DependencyInjectionConfig), "Start")]
[assembly: ApplicationShutdownMethodAttribute(typeof(HyperWebApp1.API.DependencyInjectionConfig), "Stop")]
namespace HyperWebApp1.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Castle.Windsor.Installer;    
    using HyperWebApp1.Repository;
    using HyperWebApp1.Services;
    using Controllers;
    using HyperWebApp1.Web.Infrastructure;  
	using global::HyperWebApp1.Repository.Mongo;    
	using global::HyperWebApp1.Common.Logging;
    using global::HyperWebApp1.Common.LoggingImplementation;

	/// <summary>
    /// DependencyInjectionConfig
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Registration.IWindsorInstaller" />
    public class DependencyInjectionConfig : IWindsorInstaller
    {
		/// <summary>
        /// The container
        /// </summary>
        private static IWindsorContainer container;

		/// <summary>
        /// Starts this instance.
        /// </summary>
        public static void Start()
        {
            container = new WindsorContainer().Install(FromAssembly.This());
            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

		/// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer" />.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                               .BasedOn<IController>()
                               .LifestyleTransient());    
			container.Register(Component.For<ILogHelper>().ImplementedBy<Log4NetLogger>());  
			RegisterRepositories(container);
			RegisterServices(container);
		}

		/// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="container">The container.</param>
		public void RegisterRepositories(IWindsorContainer container)
		{
			 container.Register(Component.For<ISingleRowRepository>().ImplementedBy<SingleRowRepository>());
		}

		/// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="container">The container.</param>
        public void RegisterServices(IWindsorContainer container)
        {
			 container.Register(Component.For<ISingleRowService>().ImplementedBy<SingleRowService>());
        }

		/// <summary>
        /// Stops this instance.
        /// </summary>
        protected void Stop()
        {
            container.Dispose();
        }
    }
}
