using Calamari.Models;
using Calamari.Service.Contracts;
using GenericRepository;

namespace Calamari.Service
{
    public class ProductService : EntityService<Product>, IProductService
    {
        #region Constructor

        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion Constructor

        #region Methods

        public Product GetById(long Id)
        {
            return _repository.Find(Id);
        }

        #endregion Methods

        #region Class Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<Product> _repository;

        #endregion Class Fields
    }
}