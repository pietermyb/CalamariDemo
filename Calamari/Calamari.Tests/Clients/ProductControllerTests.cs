using Calamari.ClientPortal.Controllers;
using Calamari.Models;
using Calamari.Service.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Calamari.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        private Mock<IProductService> _ProductServiceMock;
        private ProductController objController;
        private List<Product> listProduct;

        [TestInitialize]
        public void Initialize()
        {
            _ProductServiceMock = new Mock<IProductService>();
            objController = new ProductController(_ProductServiceMock.Object);
            listProduct = new List<Product>() {
            new Product
            {
                Id = 1, RefId = new System.Guid("d3cac20f-a57f-48cb-a47a-356aff5b23ae"),
                Name = "Battered Rings", Description = "1Kg Calamari Rings in Batter.",
                Price = 120
            },
            new Product
            {
                Id = 1, RefId = new System.Guid("3c9f12fa-3079-4b39-a1f7-a3bf0193223e"),
                Name = "Griller Rings", Description = "1Kg Calamari Rings.",
                Price = 80
            },
            new Product
            {
                Id = 1, RefId = new System.Guid("262d6309-9f29-45d9-8716-0e2f24929a55"),
                Name = "Steaks", Description = "1Kg Calamari steaks.",
                Price = 120
            }
          };
        }

        [TestMethod]
        [TestCategory("Controller - Product")]
        public void Product_Get_All()
        {
            //Arrange
            _ProductServiceMock.Setup(x => x.GetAll()).Returns(listProduct);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<Product>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("Battered Rings", result[0].Name);
            Assert.AreEqual("Griller Rings", result[1].Name);
            Assert.AreEqual("Steaks", result[2].Name);
        }
    }
}