using Calamari.Models;
using System.Collections.Generic;

namespace Calamari.Service.Contracts
{
    public interface IEntityService<T> : IService
    where T : BaseEntity
    {
        void Create(T entity);

        void Delete(T entity);

        IEnumerable<T> GetAll();

        void Update(T entity);
    }
}