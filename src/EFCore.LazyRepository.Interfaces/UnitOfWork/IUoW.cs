using EFCore.LazyRepository.Interfaces.Repositories;
using EFCore.LazyRepository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.LazyRepository.Interfaces.UnitOfWork
{
    /// <summary>
    /// The Unit of Works which contains all the registered repositories for entity of type <see cref="IRepositoryEntity"/>
    /// </summary>
    public interface IUoW
    {
        /// <summary>
        /// The dictionary which contains the repositories
        /// </summary>
        IDictionary<string, IRepository> Repositories { get; }

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        /// <returns>
        ///     A task that represents the asynchronous save operation. The task result contains the
        ///     number of state entries written to the database.
        /// </returns>
        /// <exception cref="DbUpdateException">
        ///     An error is encountered while saving to the database.
        /// </exception>
        /// <exception cref="DbUpdateConcurrencyException">
        ///     A concurrency violation is encountered while saving to the database.
        ///     A concurrency violation occurs when an unexpected number of rows are affected during save.
        ///     This is usually because the data in the database has been modified since it was loaded into memory.
        /// </exception>
        Task Commit();
    }
}
