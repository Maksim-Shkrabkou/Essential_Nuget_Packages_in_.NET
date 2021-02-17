using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace xUnitTutorial
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            //Arrange
            _sut = new Calculator();
        }

        // Sample
        [Fact]
        public void Add_TwoPositiveNumbers_ShouldReturnCorrectResult()
        {
            //Act
            _sut.Add(5);
            _sut.Add(8);
            
            //Assert
            Assert.Equal(13, _sut.Value);
        }
        
        // Sample
        [Fact]
        public void Add_OneNegativeAndOnePositiveNumbers_ShouldReturnCorrectResult()
        {
            //Act
            _sut.Add(-3);
            _sut.Add(3);
            
            //Assert
            Assert.Equal(0, _sut.Value);
        }
        
        
        // Sample using InlineData
        [Theory]
        [InlineData(13,5,8)]
        [InlineData(0,-3,3)]
        [InlineData(0,0,0)]
        public void Add_CollectionDifferentNumbers_ShouldReturnCorrectResult(
            decimal expected,
            decimal firstToAdd,
            decimal secondToTest)
        {
            //Act
            _sut.Add(firstToAdd);
            _sut.Add(secondToTest);
            
            //Assert
            Assert.Equal(expected, _sut.Value);
        }
        
        
        // How to make test skipped
        [Fact(Skip = "Attribute for skipping test -> example")]
        public void Add_TwoNegativeNumbers_ShouldReturnCorrectResult()
        {
            //Act
            _sut.Add(-3);
            _sut.Add(3);
            
            //Assert
            Assert.Equal(0, _sut.Value);
        }


        // Sample using MemberData from static method
        [Theory]
        [MemberData(nameof(TestData))]
        public void Add_CollectionDifferentNumbersUsingMemberData_ShouldReturnCorrectResult(
            decimal expected, params decimal[] valuesToAdd)
        {
            //Act
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }
            
            //Assert
            Assert.Equal(expected, _sut.Value);
        }
        
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] {15, new decimal[] {10, 5}};
            yield return new object[] {15, new decimal[] {10, 5}};
            yield return new object[] {-10, new decimal[] {-30, 20}};
        }
        
        // Sample using MemberData from static method with parameters of quantity test data
        // Test will run only 2 times!!! (but have test data to run 4 times)
        [Theory]
        [MemberData(nameof(GetData), parameters: 2)]
        public void Add_CollectionDifferentNumbersUsingMemberDataWithParameters_ShouldReturnCorrectResult(
            decimal expected, params decimal[] valuesToAdd)
        {
            //Act
            foreach (var value in valuesToAdd)
            {
                _sut.Add(value);
            }
            
            //Assert
            Assert.Equal(expected, _sut.Value);
        }
        
        public static IEnumerable<object[]> GetData(int numTests)
        {
            var allData = new List<object[]>
            {
                new object[] { 5, new decimal[] {2, 3} },
                new object[] { 6, new decimal[] {3, 3} },
                new object[] { 9, new decimal[] {6, 3} },
                new object[] { 10, new decimal[] {5, 5} }
            };

            return allData.Take(numTests);
        }
        
        // Sample using ClassData
        [Theory]
        [ClassData(typeof(CalculatorDivisionTestData))]
        public void Divide_CollectionDifferentNumbersUsingClassData_ShouldReturnCorrectResult(
            decimal expected, params decimal[] valuesToDivide)
        {
            //Act
            foreach (var value in valuesToDivide)
            {
                _sut.Divide(value);
            }
            
            //Assert
            Assert.Equal(expected, _sut.Value);
        }
        
        
        // Sample checking appearing Exception (it's correct behaviour) + Display name attribute (change name of test)
        [Fact(DisplayName = "Divide on 0 creates argument exception")]
        public void Divide_OnZero_ShouldReturnArgumentException()
        {
            //Act
            _sut.Divide(6);

            //Assert
            var exception= Assert.Throws<ArgumentException>(() => _sut.Divide(0));
            Assert.Equal("Can't divide by 0", exception.Message);
        }
    }
}