using Calamari.Models;
using GenericRepository;

namespace Calamari.Repository.Contracts
{
    internal interface IProductRepository : IRepository<Product>
    {
        Product GetSingle(int Id);
    }
}