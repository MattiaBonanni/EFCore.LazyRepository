using EFCore.LazyRepository.Interfaces.Entities;
using EFCore.LazyRepository.Interfaces.Repositories;
using EFCore.LazyRepository.Interfaces.UnitOfWork;
using EFCore.LazyRepository.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCore.LazyRepository.UnitOfWork
{
    /// <inheritdoc cref="IUoW" />
    public class UoW : IUoW
    {
        private DbContext _context { get; set; }

        /// <inheritdoc />
        public IDictionary<string, IRepository> Repositories { get; set; } = new Dictionary<string, IRepository>();

        public UoW(DbContext context, IEnumerable<IRepositoryEntity> repositoryEntities)
        {
            _context = context;

            foreach (var repositoryEntity in repositoryEntities)
                Repositories.Add(repositoryEntity.RepositoryName, new BaseRepository(_context));
        }

        /// <inheritdoc />
        public Task Commit()
        {
            return _context.SaveChangesAsync();
        }
    }
}
