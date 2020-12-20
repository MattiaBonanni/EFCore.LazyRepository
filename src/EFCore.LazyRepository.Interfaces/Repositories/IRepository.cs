using EFCore.LazyRepository.Interfaces.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace EFCore.LazyRepository.Interfaces.Repositories
{
    /// <summary>
    /// The main base repository 
    /// </summary>
    public interface IRepository
    {
        /// <summary>
        /// Get one (in the future I hope 'or more') entity of type <see cref="IRepositoryEntity"/>
        /// </summary>
        /// <typeparam name="T">Class of type <see cref="IRepositoryEntity"/></typeparam>
        /// <param name="func">At this moment is not used</param>
        /// <returns>returns an <see cref="IQueryable{T}"/> from which retrieve entities</returns>
        IQueryable<T> Get<T>(Expression<Func<T, bool>> func = default)
            where T : class, IRepositoryEntity;

        /// <summary>
        /// Add a new entity of type <see cref="IRepositoryEntity"/>
        /// </summary>
        /// <typeparam name="T">Class of type <see cref="IRepositoryEntity"/></typeparam>
        /// <param name="entity">The instance <see cref="IRepositoryEntity"/> to add</param>
        /// <returns></returns>
        void Add<T>(T entity)
            where T : class, IRepositoryEntity;

        /// <summary>
        /// Update an existing entity of type <see cref="IRepositoryEntity"/>
        /// </summary>
        /// <typeparam name="T">Class of type <see cref="IRepositoryEntity"/></typeparam>
        /// <param name="entity">The instance <see cref="IRepositoryEntity"/> to update</param>
        /// <returns></returns>
        void Update<T>(T entity)
            where T : class, IRepositoryEntity;

        /// <summary>
        /// Remove an existing entity of type <see cref="IRepositoryEntity"/>
        /// </summary>
        /// <typeparam name="T">Class of type <see cref="IRepositoryEntity"/></typeparam>
        /// <param name="entity">The instance <see cref="IRepositoryEntity"/> to delete</param>
        /// <returns></returns>
        void Remove<T>(T entity)
            where T : class, IRepositoryEntity;
    }
}
