using Calamari.Business.Contracts;
using Calamari.Service;

namespace Calamari.Business
{
    public class ProductManger : IProductManager
    {
        public ProductManger()
        {
        }

        #region Class Fields

        private ProductService _productService;

        #endregion Class Fields
    }
}