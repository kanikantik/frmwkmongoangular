// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Service.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Service.Pattern
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading;
    using System.Threading.Tasks;
    using HyperWebApp1.Repository.Pattern.Infrastructure;
    using HyperWebApp1.Repository.Pattern.Repositories;

    /// <summary>
    /// The service.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public abstract class Service<TEntity> : IService<TEntity> where TEntity : class, IObjectState
    {
        #region Private Fields

        /// <summary>
        /// The repository.
        /// </summary> 
        private readonly IRepository<TEntity> repository;

        #endregion Private Fields

        #region Constructor    
        /// <summary>
        /// Initializes a new instance of the <see cref="Service{TEntity}" /> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public Service(IRepository<TEntity> repository)
        {
            this.repository = repository;
        }


        #endregion Constructor

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Insert(TEntity entity)
        {
            this.repository.Insert(entity);
        }

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            this.repository.InsertRange(entities);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Update(TEntity entity)
        {
            this.repository.Update(entity);
        }

        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void UpdateRange(IEnumerable<TEntity> entities)
        {
            this.repository.UpdateRange(entities);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entities">The entities.</param>
        public virtual void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.repository.DeleteRange(entities);
        }

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="id">The id parameter.</param>
        public virtual void Delete(object id)
        {
            this.repository.Delete(id);
        }

        /// <summary>
        /// The delete method.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Delete(TEntity entity)
        {
            this.repository.Delete(entity);
        }

        /// <summary>
        /// The queryable.
        /// </summary>
        /// <returns>
        /// The <see cref="IQueryable" />.
        /// </returns>
        public IQueryable<TEntity> Queryable()
        {
            return this.repository.Queryable();
        }
    }
}