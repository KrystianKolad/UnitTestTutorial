using System;
using NUnit.Framework;
using UnitTestTutorial.Helpers;
using UnitTestTutorial.Helpers.Interfaces;
using UnitTestTutorial.Model;

namespace UnitTestTutorial.Test.Helpers
{
    [TestFixture]
    public class DiscountHelperTests
    {
        private IDiscountHelper _sut; 

        [SetUp]
        public void SetUp()
        {
            _sut = new DiscountHelper();
        }

        [Test]
        [TestCase(100,0,100)]
        [TestCase(100,1,80)]
        [TestCase(100,2,60)]
        public void GetDiscount_With_Valid_Client_Type_Should_Return_Valid_Price(decimal price, int type, decimal expectedResult)
        {
            //arrange
            User user = new User()
            {
                UserType = type 
            };

            //act
            decimal actualResult = _sut.GetDiscount(user,price);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void GetDiscount_With_InValid_Client_Type_Should_Throw()
        {
            User user = new User()
            {
                UserType = 99 
            };

            decimal price = 123;

            Assert.Throws<ArgumentException>(() => _sut.GetDiscount(user,price));
        }

        [Test]
        public void GetDiscount_With_InValid_Price_Should_Throw()
        {
            User user = new User()
            {
                UserType = 0
            };

            decimal price = -1;

            Assert.Throws<ArgumentException>(()=>_sut.GetDiscount(user,price));
        }
    }
}