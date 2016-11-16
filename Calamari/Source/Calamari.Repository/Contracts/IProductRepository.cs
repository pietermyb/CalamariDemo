using Calamari.Models;
using GenericRepository;

namespace Calamari.Repository.Contracts
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetSingle(int Id);
    }
}