using EFCore.LazyRepository.Interfaces.Entities;

namespace EFCore.LazyRepository.Samples.Data.Entities
{
    public class FooBar : IRepositoryEntity
    {
        public int Id { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }

        public string RepositoryName { get; } = nameof(FooBar);
    }
}
