// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Repository.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The Repository.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace HyperWebApp1.Repository.Mongo
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using Pattern.Infrastructure;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MongoDB.Driver.Linq;
    using Pattern.Repositories;
    using mongoQuery = MongoDB.Driver.Builders;
    /// <summary>
    /// The Repository class.
    /// </summary>
    /// <typeparam name="T">The T typeparam</typeparam>
    [ExcludeFromCodeCoverage]
    public abstract class Repository<T> : IRepository<T>, IQueryable<T> where T : class, IMongoEntity, IObjectState
    {

        /// <summary>
        /// MongoCollection field.
        /// </summary>
        private IMongoCollection<T> collection;

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// Uses the Default App/Web.Config connection strings to fetch the connectionString and Database name.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        /// <remarks>
        /// Default constructor defaults to "DefaultConnection" key for connectionstring.
        /// </remarks>
        public Repository()
            : this("DefaultConnection")
        {

        }

        /// <summary>
        /// Initializes a new instance of the Repository class.
        /// </summary>
        /// <param name="connectionString">Connectionstring to use for connecting to MongoDB.</param>
        public Repository(string connectionString)
        {
            var url = new MongoUrl(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            var client = new MongoClient(url);
            var database = client.GetDatabase(url.DatabaseName);
            this.collection = database.GetCollection<T>(GetCollectionName<T>());
        }

        private static string GetCollectionName<T>()
        {
            string collectionName;
            if (typeof(T).BaseType.Equals(typeof(object)))
            {
                collectionName = GetCollectioNameFromInterface<T>();
            }
            else
            {
                collectionName = GetCollectionNameFromType(typeof(T));
            }

            if (string.IsNullOrEmpty(collectionName))
            {
                throw new ArgumentException("Collection name cannot be empty for this entity");
            }
            return collectionName;
        }

        /// <summary>
        /// Determines the collectionname from the specified type.
        /// </summary>
        /// <param name="entityType">The type of the entity to get the collectionname from.</param>
        /// <returns>
        /// Returns the collectionname from the specified type.
        /// </returns>
        private static string GetCollectionNameFromType(Type entityType)
        {
            string collectionName;

            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = Attribute.GetCustomAttribute(entityType, typeof(CollectionNameAttribute));
            if (att != null)
            {
                // It does! Return the value specified by the CollectionName attribute
                collectionName = ((CollectionNameAttribute)att).Name;
            }
            else
            {
                if (typeof(MongoEntity).IsAssignableFrom(entityType))
                {
                    // No attribute found, get the basetype
                    while (!entityType.BaseType.Equals(typeof(MongoEntity)))
                    {
                        entityType = entityType.BaseType;
                    }
                }
                collectionName = entityType.Name;
            }

            return collectionName;
        }

        private static string GetCollectioNameFromInterface<T>()
        {
            string collectioName;

            // Check to see if the object (inherited from Entity) has a CollectionName attribute
            var att = Attribute.GetCustomAttribute(typeof(T), typeof(CollectionNameAttribute));
            if (att != null)
            {
                // It does! Return the value specified by the CollectionName attribute
                collectioName = ((CollectionNameAttribute)att).Name;
            }
            else
            {
                collectioName = typeof(T).Name;
            }

            return collectioName;
        }

        /// <summary>
        /// Gets the expression tree that is associated with the instance of <see cref="T:System.Linq.IQueryable" />.
        /// </summary>
        /// <value>
        /// The Expression value
        /// </value>
        public Expression Expression
        {
            get { return this.collection.AsQueryable<T>().Expression; }
        }

        /// <summary>
        /// Gets the type of the element(s) that are returned when the expression tree associated with this instance of <see cref="T:System.Linq.IQueryable" /> is executed.
        /// </summary>
        /// /// <value>
        /// The type value
        /// </value>
        public Type ElementType
        {
            get
            {
                return this.collection.AsQueryable<T>().ElementType;
            }
        }

        /// <summary>
        /// Gets the query provider that is associated with this data source.
        /// </summary>
        /// /// <value>
        /// The Query Provider value
        /// </value>
        public IQueryProvider Provider
        {
            get
            {
                return this.collection.AsQueryable<T>().Provider;
            }
        }

        /// <summary>
        /// Upserts an entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// The updated entity.
        /// </returns>
        public virtual T Update(T entity)
        {
            collection.ReplaceOneAsync(Builders<T>.Filter.Eq(s => s.Id, entity.Id), entity);
            return entity;
        }

        /// <summary>
        /// Deletes an entity from the repository by its id.
        /// </summary>
        /// <param name="id">The entity's id.</param>
        public virtual void Delete(string id)
        {
            this.collection.DeleteOne(Builders<T>.Filter.Eq(s => s.Id, id));
        }

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        public virtual void Delete(T entity)
        {
            this.Delete(entity.Id);
        }

        /// <summary>
        /// Deletes the entities matching the predicate.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        public virtual void Delete(Expression<Func<T, bool>> predicate)
        {
            foreach (var entity in this.collection.AsQueryable().Where(predicate))
            {
                this.Delete(entity);
            }
        }

        /// <summary>
        /// Checks if the entity exists for given predicate.
        /// </summary>
        /// <param name="predicate">The expression.</param>
        /// <returns>
        /// True when an entity matching the predicate exists, false otherwise.
        /// </returns>
        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            return this.collection.AsQueryable().Any(predicate);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Insert(T entity)
        {
            this.collection.InsertOne(entity);
        }

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void InsertRange(IEnumerable<T> entities)
        {
            this.collection.InsertManyAsync(entities);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">The id object.</param>
        public void Delete(object id)
        {
            this.collection.DeleteOne(Builders<T>.Filter.Eq(s => s.Id, id));
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return this.collection.AsQueryable<T>().GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.collection.AsQueryable<T>().GetEnumerator();
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entity">The entities.</param>
        public void UpdateRange(IEnumerable<T> entity)
        {
            foreach (T en in entity)
            {
                this.Update(en);
            }
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public void DeleteRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                this.Delete(entity.Id);
            }
        }

        void IRepository<T>.Update(T entity)
        {
            collection.ReplaceOneAsync(Builders<T>.Filter.Eq(s => s.Id, entity.Id), entity);
        }

        IQueryable<T> IRepository<T>.Queryable()
        {
            return this.collection.AsQueryable<T>();
        }
    }
}