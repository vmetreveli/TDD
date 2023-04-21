using StringCalculatorKata;

namespace StringCalculatorKataTestsX
{
    public class StringCalculatorTests
    {
        [Fact]
        public void GivenOneNumber_ShouldReturnThatNumber()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "1";
            var expected = 1;

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenManyNumber_ShouldReturnTheSumOfThoseNumbers()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "1,2";
            var expected = 3;

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData(" ", 0)]
        [InlineData("     ", 0)]
        public void GivenNoNumbers_ShouldReturn0(string numbers, int expected)
        {
            // Arrange
            var sut = CreateStringCalculator();

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenNewLineDelimiter_ShouldReturnTheSumOfAllNumbers()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "8\n13";
            var expected = 21;

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenCustomDelimiter_ShouldReturnTheSumOfAllNumbers()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "//;\n123;321";
            var expected = 444;

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GivenNegativeNumber_ShouldThrowException()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "//;\n123;-1";
            var expected = "negatives not allowed -1";

            // Act & Assert
            var exception = Assert.Throws<Exception>(() => sut.Add(numbers));
            Assert.Equal(expected, exception.Message);
        }

        [Fact]
        public void GivenCustomDelimiterOfAnyLength_ShouldReturnTheSumOfAllNumbers()
        {
            // Arrange
            var sut = CreateStringCalculator();
            var numbers = "//[^]\n10^11\n12";
            var expected = 33;

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        
        [Theory]
        [InlineData("//[^][%%]\n10^11%%12", 33)]
        public void GivenMultipleCustomDelimitersOfAnyLength_ShouldReturnTheSumOfAllNumbers(string numbers,int expected)
        {
            // Arrange
            var sut = CreateStringCalculator();
           

            // Act
            var actual = sut.Add(numbers);

            // Assert
            Assert.Equal(expected, actual);
        }

        private static StringCalculator CreateStringCalculator()
        {
            return new StringCalculator();
        }
    }
}