﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleRowService.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   Autogenerated Web Services
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HyperWebApp1.Services
{
    using Entities;
    using Repository;
    using HyperWebApp1.Service.Pattern;
	
	/// <summary>
    /// The singlerow service.
    /// </summary>
    public class SingleRowService : Service<SingleRow>, ISingleRowService
    { 
		/// <summary>
        /// The repository asynchronous
        /// </summary>
		private readonly ISingleRowRepository repositoryAsync;
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleRowService"/> class.
        /// </summary>
        /// <param name="repository">
        /// The async repository.
        /// </param>

        public SingleRowService(ISingleRowRepository repository)
            : base(repository)
        {
		    this.repositoryAsync = repository;
        }
	}
}