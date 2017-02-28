// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SingleRow.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The SingleRow.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Entities
{
    using System.Runtime.Serialization;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    using HyperWebApp1.Repository.Mongo;

    /// <summary>
    /// The singleRow.
    /// </summary>
    public class SingleRow : MongoEntity
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name string.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city string.
        /// </value>
        public string City { get; set; }
    }
}