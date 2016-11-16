using Calamari.Models;
using Calamari.Repository.Context;
using Calamari.Repository.Contracts;
using GenericRepository.EF;
using System.Linq;

namespace Calamari.Repository
{
    public class ProductRepository : Repository<CalamariContext, Product>, IProductRepository
    {
        public Product GetSingle(int Id)
        {
            var query = GetAll().FirstOrDefault(x => x.Id == Id);
            return query;
        }
    }
}