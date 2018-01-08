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
        
    }
}