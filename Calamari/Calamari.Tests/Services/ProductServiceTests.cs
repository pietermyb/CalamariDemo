using Calamari.Models;
using Calamari.Repository.Contracts;
using Calamari.Service;
using Calamari.Service.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;

namespace Calamari.Tests.Services
{
    /// <summary>
    /// Summary description for Calamari
    /// </summary>
    [TestClass]
    public class ProductServiceTests
    {
        private ProductService _productService;
        private Mock<IProductRepository> _productRepo;
        private Mock<IUnitOfWork> _unitOfWork;
        private Mock<Product> _getByIdResult;
        private Mock<IQueryable<Product>> _getAllResult;

        [TestInitialize]
        public void Initialize()
        {
            _productRepo = new Mock<IProductRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _getByIdResult = new Mock<Product>();
            _getAllResult = new Mock<IQueryable<Product>>();
        }

        [TestMethod]
        [TestCategory("Service - Product")]
        public void ProductService_GetByID_Success()
        {
            // Arrange
            _productRepo.Setup(x => x.Find(It.IsAny<long>()))
                .Returns(_getByIdResult.Object)
                .Verifiable();

            _productService = new ProductService(_unitOfWork.Object, _productRepo.Object);

            // Act
            var result = _productService.GetById(123);

            // Assert
            Assert.IsNotNull(result);
            _productRepo.Verify();
        }

        [TestMethod]
        [TestCategory("Service - Product")]
        public void ProductService_GetAll_Success()
        {
            // Arrange
            _productRepo.Setup(x => x.GetAll())
                .Returns(_getAllResult.Object)
                .Verifiable();

            _productService = new ProductService(_unitOfWork.Object, _productRepo.Object);

            // Act
            var result = _productService.GetAll();

            // Assert
            Assert.IsNotNull(result);
            _productRepo.Verify();
        }
    }
}