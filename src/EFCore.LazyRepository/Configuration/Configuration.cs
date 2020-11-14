using EFCore.LazyRepository.Interfaces.Entities;
using EFCore.LazyRepository.Interfaces.UnitOfWork;
using EFCore.LazyRepository.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace EFCore.LazyRepository.Configuration
{
    public static class Configuration
    {
        /// <summary>
        /// Register <see cref="IUoW"/> with the repositories for all entity of type <see cref="IRepositoryEntity"/>
        /// </summary>
        /// <param name="services">An instacne of <see cref="IServiceCollection"/></param>
        /// <param name="func">A delegate used to retrieve the specified assemblies from which scan for valid entities</param>
        /// <returns></returns>
        public static IServiceCollection RegisterRepositories(this IServiceCollection services, Func<Assembly, bool> func)
        {
            var assemblies = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .Where(func).ToList();
            assemblies.Add(Assembly.GetEntryAssembly());

            services.Scan(scan => scan
                .FromAssemblies(assemblies)
                .AddClasses(classes => classes.AssignableTo<IRepositoryEntity>())
                .AsImplementedInterfaces()
                .WithScopedLifetime());

            services.AddScoped<IUoW, UoW>();

            return services;
        }
    }
}
