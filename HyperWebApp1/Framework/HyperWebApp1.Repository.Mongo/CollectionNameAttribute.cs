// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CollectionNameAttribute.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The Collection Name Attribute.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HyperWebApp1.Repository.Mongo
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Attribute used to annotate Enities with to override mongo collection name. By default, when this attribute
    /// is not specified, the classname will be used.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    [ExcludeFromCodeCoverage]
    public class CollectionNameAttribute : Attribute
    {
        /// <summary>
        ///  Initializes a new instance of the <see cref="CollectionNameAttribute" /> class.
        /// Initializes a new instance of the CollectionName class attribute with the desired name.
        /// </summary>
        /// <param name="value">Name of the collection.</param>
        /// <exception cref="System.ArgumentException">Empty collection Name not allowed;value</exception>
        public CollectionNameAttribute(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Empty collection Name not allowed", "value");
            }
            this.Name = value;
        }

        /// <summary>
        /// Gets the name of the collection.
        /// </summary>
        /// <value>
        /// The name of the collection.
        /// </value>
        public virtual string Name { get; private set; }
    }
}
