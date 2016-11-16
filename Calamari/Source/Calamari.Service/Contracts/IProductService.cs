using Calamari.Models;

namespace Calamari.Service.Contracts
{
    /// <summary>
    /// Product Service Contract
    /// </summary>
    public interface IProductService : IEntityService<Product>
    {
        /// <summary>
        /// Get a Product By Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Product GetById(long Id);
    }
}
