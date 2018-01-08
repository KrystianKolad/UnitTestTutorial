using System.Collections.Generic;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.Services.Interfaces
{
    public interface IProductService
    {
         IList<Product> GetSortedProducts();

         decimal GetProductsPrice(User user,IList<Product> products);

         void AddProduct(Product product);
    }
}