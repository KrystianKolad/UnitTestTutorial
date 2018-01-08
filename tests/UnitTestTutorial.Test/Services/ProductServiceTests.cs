using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using UnitTestTutorial.Helpers.Interfaces;
using UnitTestTutorial.Model;
using UnitTestTutorial.ReadRepository.Interfaces;
using UnitTestTutorial.Services;
using UnitTestTutorial.Services.Interfaces;
using UnitTestTutorial.WriteRepository.Interfaces;

namespace UnitTestTutorial.Test.Services
{
    [TestFixture]
    public class ProductServiceTests
    {
        private IProductService _sut;

        private Mock<IWriteRepository<Product>> _productWriteRepositoryMock;

        private Mock<IReadRepository<Product>> _productReadRepositoryMock;

        private Mock<IDiscountHelper> _discountHelperMock;

        [SetUp]
        public void SetUp()
        {
            _discountHelperMock = new Mock<IDiscountHelper>();
            _productWriteRepositoryMock = new Mock<IWriteRepository<Product>>();
            _productReadRepositoryMock = new Mock<IReadRepository<Product>>();

            _sut = new ProductService(_discountHelperMock.Object,_productWriteRepositoryMock.Object,_productReadRepositoryMock.Object);
        }

        [Test]
        public void AddProduct_Should_Call_Add_From_Repository()
        {
            Product product = new Product();

            _sut.AddProduct(product);

            _productWriteRepositoryMock.Verify(x=>x.Add(It.IsAny<Product>()));
        }

        [Test]
        public void GetSortedProducts_Should_GetProducts_Sorted_By_Price()
        {
            IList<Product> products = new List<Product>(){
                new Product(){Price = 5},
                new Product(){Price = 3},
                new Product(){ Price = 8}
            };

            _productReadRepositoryMock.Setup(x=>x.GetAll()).Returns(products);

            var result = _sut.GetSortedProducts();

            Assert.IsNotEmpty(result);
            Assert.AreEqual(3,result[0].Price);
            Assert.AreEqual(5,result[1].Price);
            Assert.AreEqual(8,result[2].Price);
        }
        
        [Test]
        public void GetProductsPrice_Should_Return_Valid_Price()
        {
            IList<Product> products = new List<Product>(){
                new Product(){Price = 5},
                new Product(){Price = 3},
                new Product(){ Price = 8}
            };

            User user = new User();

            decimal expectedResult = 16;

            _discountHelperMock.Setup(x=>x.GetDiscount(It.IsAny<User>(),16)).Returns(16);

            decimal actualResult = _sut.GetProductsPrice(user,products);

            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}