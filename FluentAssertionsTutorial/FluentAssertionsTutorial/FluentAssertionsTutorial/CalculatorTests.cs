using System;
using System.Globalization;
using FluentAssertions;
using Xunit;

namespace FluentAssertionsTutorial
{
    public class CalculatorTests
    {
        private readonly Calculator _sut;

        public CalculatorTests()
        {
            _sut = new Calculator();
        }
        
        // Sample with Assert
        [Theory]
        [InlineData(13,5,8)]
        [InlineData(0,-3,3)]
        [InlineData(0,0,0)]
        public void Add_ShouldAddTwoNumbers_WhenTheAdditionIsValid(
            decimal expected,
            decimal firstToAdd,
            decimal secondToTest)
        {
            // Arrange
            _sut.Add(firstToAdd);
            _sut.Add(secondToTest);
            
            // Act
            var result = _sut.Value;

            //Assert
            Assert.Equal(expected, result);
            Assert.StartsWith("The result is: ", _sut.Text);
            Assert.EndsWith(result.ToString(CultureInfo.InvariantCulture), _sut.Text);
        }
        
        // Sample with FluentAssertion
        [Theory]
        [InlineData(13,5,8)]
        [InlineData(0,-3,3)]
        [InlineData(0,0,0)]
        public void Add_ShouldAddTwoNumbers_WhenTheAdditionIsValidFa(
            decimal expected,
            decimal firstToAdd,
            decimal secondToTest)
        {
            // Arrange
            _sut.Add(firstToAdd);
            _sut.Add(secondToTest);
            
            // Act
            var result = _sut.Value;

            //Assert
            result.Should().Be(expected);
            _sut.Text.Should().StartWith("The result is: ");
            _sut.Text.Should().EndWith(result.ToString(CultureInfo.InvariantCulture));
        }
        
        //
        
        // Sample with Assert
        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZero()
        {
            // Arrange
            _sut.Divide(50);

            // Act
            Func<object> resultFunc = () => _sut.Divide(0);

            // Assert
            var exception = Assert.Throws<DivideByZeroException>(resultFunc);
            Assert.Equal("Attempted to divide by zero.", exception.Message);
        }
        
        // Sample with FluentAssertions
        [Fact]
        public void Divide_ShouldThrowDivideByZeroException_WhenDividingByZeroFa()
        {
            // Arrange
            _sut.Divide(50);

            // Act
            Func<object> resultFunc = () => _sut.Divide(0);

            // Assert
            resultFunc.Should()
                .Throw<DivideByZeroException>()
                .WithMessage("Attempted to divide by zero.");
        }
    }
}