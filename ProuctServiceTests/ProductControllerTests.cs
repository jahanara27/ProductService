using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProductService;
using ProductService.Controllers;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace ProuctServiceTests
{
    [TestClass]
    public class ProductControllerTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            var _expectedProducts = new[] {
                new Product(1, "Apple", "iPhone X", 2000),
                new Product(2, "Samsung", "Note 9", 1400),
                new Product(3, "Google", "Pixel 3", 1309),
                new Product(4, "OnePlus", "6T", 788),
            };
        }
        [TestMethod]
        public async Task GetAllProductTest()
        {
            Mock<ILogger<ProductsController>> mockLogger = new Mock<ILogger<ProductsController>>();
            ProductsController productsController = new ProductsController(mockLogger.Object);
            var _actualProducts = (await productsController.GetProducts()) as ObjectResult;

            Assert.AreEqual(200, _actualProducts?.StatusCode);
        }

        [DataRow(1)]
        [TestMethod]
        public async Task GetProductByIdTest(int id)
        {
            Product _expctedProduct = new Product(1, "Apple", "iPhone X", 2000);

            Mock<ILogger<ProductsController>> mockLogger = new Mock<ILogger<ProductsController>>();
            ProductsController productsController = new ProductsController(mockLogger.Object);
            var okresult = (await productsController.GetProductById(id)) as OkObjectResult;
            var _actualProduct = okresult?.Value as Product;
            Assert.AreEqual(_expctedProduct.Model, _actualProduct.Model);
        }
    }
}