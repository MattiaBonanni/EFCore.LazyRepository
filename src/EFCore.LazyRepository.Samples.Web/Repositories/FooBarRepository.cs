using System;

namespace EFCore.LazyRepository.Repositories
{
    public partial class FooBarRepository
    {
        public void FromRepository()
        {
            Console.WriteLine("Hello from repository");
        }
    }
}
