using System;
using UnitTestTutorial.Enums;
using UnitTestTutorial.Helpers.Interfaces;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.Helpers
{
    public class DiscountHelper : IDiscountHelper
    {
        public decimal GetDiscount(User user, decimal price)
        {
            if(price<0)
            {
                throw new ArgumentException($"Price cannot be less than zero");
            }
            switch(user.UserType)
            {
                case (int)UserTypeEnum.RegularUser:
                return price;
                case (int)UserTypeEnum.GoldenUser:
                return price*0.8m;
                case (int)UserTypeEnum.PlatinumUser:
                return price*0.6m;
                default: throw new ArgumentException($"UserType is invalid");
            }
        }
    }
}