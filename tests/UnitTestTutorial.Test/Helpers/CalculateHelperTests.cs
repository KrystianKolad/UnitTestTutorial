using System;
using NUnit.Framework;
using UnitTestTutorial.Helpers;
using UnitTestTutorial.Helpers.Interfaces;

namespace UnitTestTutorial.Test.Helpers
{
    [TestFixture]
    public class CalculateHelperTests
    {
        private ICalculateHelper _sut;

        [SetUp]
        public void SetUp()
        {
            _sut = new CalculateHelper();
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(2,2,4)]
        [TestCase(10,10,20)]
        public void Add_With_Valid_Data_Should_Return_Valid_Sum(double x, double y, double expectedResult)
        {
            double actualResult = _sut.Add(x,y);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        [TestCase(3,2,1)]
        [TestCase(4,2,2)]
        [TestCase(20,10,10)]
        public void Subtract_With_Valid_Data_Should_Return_Valid_Result(double x, double y, double expectedResult)
        {
            double actualResult = _sut.Subtract(x,y);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void Divide_With_Invalid_Divider_Should_Throw()
        {
            //arrange
            int x =1;
            int y=0;

            //act && assert
            Assert.Throws<ArgumentException>(()=>_sut.Divide(x,y));
        }

        [Test]
        [TestCase(3,3,1)]
        [TestCase(4,2,2)]
        [TestCase(20,10,2)]
        public void Divide_With_Valid_Data_Should_Return_Valid_Result(double x, double y, double expectedResult)
        {
            double actualResult = _sut.Divide(x,y);

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        [TestCase(3,2,6)]
        [TestCase(4,2,8)]
        [TestCase(20,10,200)]
        public void Multiply_With_Valid_Data_Should_Return_Valid_Result(double x, double y, double expectedResult)
        {
            double actualResult = _sut.Multiply(x,y);

            Assert.AreEqual(expectedResult,actualResult);
        }
    }
}