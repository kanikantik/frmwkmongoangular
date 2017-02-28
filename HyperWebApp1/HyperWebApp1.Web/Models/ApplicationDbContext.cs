// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationDbContext.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The ApplicationDbContext.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Web.Models
{

    /// <summary>
    ///     Application Db Context
    /// </summary>
    public class ApplicationDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
        /// </summary>
        public ApplicationDbContext()
        {
        }
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>Action Result</returns>
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}