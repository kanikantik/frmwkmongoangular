// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MongoEntity.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The Mongo Entity.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Repository.Mongo
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.Serialization;
    using Pattern.Infrastructure;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;
    /// <summary>
    /// Abstract Entity for all the BusinessEntities.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class MongoEntity : IMongoEntity, IObjectState
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary record for an entity).
        /// </summary>
        /// <value>
        /// The id for this object (the primary record for an entity).
        /// </value>
        [DataMember]
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }

        /// <summary>
        /// Gets or sets the state of the object.
        /// </summary>
        /// <value>
        /// The state of the object.
        /// </value>
        [BsonIgnore]
        public ObjectState ObjectState { get; set; }
    }
}
