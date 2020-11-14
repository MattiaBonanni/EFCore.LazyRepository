using EFCore.LazyRepository.Interfaces.Entities;
using EFCore.LazyRepository.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EFCore.LazyRepository.Repositories
{
    /// <inheritdoc cref="IRepository"/>
    public class BaseRepository : IRepository
    {
        private DbContext _context { get; set; }

        public BaseRepository(DbContext context)
        {
            _context = context;
        }

        /// <inheritdoc />
        public virtual IQueryable<T> Get<T>(Func<T, bool> func = default)
            where T : class, IRepositoryEntity
        {
            var dbSet = CurrentDbSet<T>().AsQueryable();

            //if (func != default)
            //    return dbSet.Where<T>(func);

            return dbSet.AsQueryable();
        }

        /// <inheritdoc />
        public virtual void Add<T>(T item)
            where T : class, IRepositoryEntity
        {
            var dbSet = CurrentDbSet<T>();

            dbSet.Add(item);
            _context.Entry(item).State = EntityState.Added;
        }

        /// <inheritdoc />
        public void Remove<T>(T item)
            where T : class, IRepositoryEntity
        {
            var dbSet = CurrentDbSet<T>();

            var dbEntityEntry = _context.Entry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(item);
            }

            dbSet.Remove(item);
            _context.Entry(item).State = EntityState.Deleted;
        }

        /// <inheritdoc />
        public virtual void Update<T>(T item)
            where T : class, IRepositoryEntity
        {
            var dbSet = CurrentDbSet<T>();

            var dbEntityEntry = _context.Entry(item);
            if (dbEntityEntry.State == EntityState.Detached)
            {
                dbSet.Attach(item);
            }

            _context.Entry(item).State = EntityState.Modified;
        }

        #region Utilties

        private DbSet<T> CurrentDbSet<T>()
                where T : class, IRepositoryEntity
            => _context.Set<T>();


        #endregion
    }
}
