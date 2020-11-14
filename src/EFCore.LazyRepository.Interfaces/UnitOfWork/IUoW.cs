using EFCore.LazyRepository.Interfaces.Repositories;
using EFCore.LazyRepository.Interfaces.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore.LazyRepository.Interfaces.UnitOfWork
{
    /// <summary>
    /// The Unit of Works which contains all the registered repositories for entity of type <see cref="IRepositoryEntity"/>
    /// </summary>
    public interface IUoW
    {
        /// <summary>
        /// The dictionaty which contains the repositories
        /// </summary>
        IDictionary<string, IRepository> Repositories { get; }

        /// <inheritdoc cref="DbContext.SaveChanges" />
        Task Commit();
    }
}
