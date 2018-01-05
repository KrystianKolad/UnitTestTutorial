using UnitTestTutorial.Model;

namespace UnitTestTutorial.Helpers.Interfaces
{
    public interface IDiscountHelper
    {
         decimal GetDiscount(User user, decimal price);
    }
}