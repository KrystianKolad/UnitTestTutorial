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