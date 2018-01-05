using UnitTestTutorial.Helpers.Interfaces;
using UnitTestTutorial.Model;
using UnitTestTutorial.ReadRepository.Interfaces;
using UnitTestTutorial.Services.Interfaces;
using UnitTestTutorial.WriteRepository.Interfaces;

namespace UnitTestTutorial.Services
{
    public class ProductService : IProductService
    {
        private IDiscountHelper _discountHelper;
        private IWriteRepository<Product> _productWriteRepository;
        private IReadRepository<Product> _productReadRepository;
        public ProductService(IDiscountHelper discountHelper, IWriteRepository<Product> productWriteRepository, IReadRepository<Product> productReadRepository)
        {
            _discountHelper = discountHelper ?? throw new System.ArgumentNullException(nameof(discountHelper));
            _productWriteRepository = productWriteRepository ?? throw new System.ArgumentNullException(nameof(productWriteRepository));
            _productReadRepository = productReadRepository ?? throw new System.ArgumentNullException(nameof(productReadRepository));
        }
    }
}