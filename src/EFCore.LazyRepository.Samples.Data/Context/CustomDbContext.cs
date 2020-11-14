using EFCore.LazyRepository.Samples.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore.LazyRepository.Samples.Data.Context
{
    public class CustomDbContext : DbContext
    {
        public CustomDbContext(DbContextOptions<CustomDbContext> optionsBuilderOptions)
            : base(optionsBuilderOptions) { }

        public DbSet<FooBar> FooBars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
