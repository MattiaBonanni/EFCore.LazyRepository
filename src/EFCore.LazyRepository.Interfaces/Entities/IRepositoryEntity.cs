using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.LazyRepository.Interfaces.Entities
{
    /// <summary>
    /// The base interface used to register the repositories
    /// </summary>
    public interface IRepositoryEntity
    {
        /// <summary>
        /// The name of the repository which will be used to retrieve it from the dictionary
        /// </summary>
        [NotMapped]
        public string RepositoryName { get; }
    }
}
