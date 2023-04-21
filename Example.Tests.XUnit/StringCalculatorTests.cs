using StringCalculatorKata;

namespace Example.Tests.XUnit;

public class StringCalculatorTests
{
    [Theory]
    [InlineData("1", 1)]
    public void GivenOneNumber_ShouldReturnThatNumber(string numbers, int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();

        // Act
        var actual = sut.Add(numbers);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1,2", 3)]
    public void GivenManyNumber_ShouldReturnTheSumOfThoseNumbers(string numbers, int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();

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

    [Theory]
    [InlineData("8\n13", 21)]
    public void GivenNewLineDelimiter_ShouldReturnTheSumOfAllNumbers(string numbers, int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();

        // Act
        var actual = sut.Add(numbers);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//;\n123;321", 444)]
    public void GivenCustomDelimiter_ShouldReturnTheSumOfAllNumbers(string numbers, int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();

        // Act
        var actual = sut.Add(numbers);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("//;\n123;-1", "negatives not allowed -1")]
    public void GivenNegativeNumber_ShouldThrowException(string numbers, string expected)
    {
        // Arrange
        var sut = CreateStringCalculator();


        // Act & Assert
        var exception = Assert.Throws<Exception>(() => sut.Add(numbers));
        Assert.Equal(expected, exception.Message);
    }

    [Theory]
    [InlineData("//[^]\n10^11\n12", 33)]
    public void GivenCustomDelimiterOfAnyLength_ShouldReturnTheSumOfAllNumbers(string numbers, int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();

        // Act
        var actual = sut.Add(numbers);

        // Assert
        Assert.Equal(expected, actual);
    }


    [Theory]
    [InlineData("//[^][%%]\n10^11%%12", 33)]
    public void GivenMultipleCustomDelimitersOfAnyLength_ShouldReturnTheSumOfAllNumbers(string numbers,
        int expected)
    {
        // Arrange
        var sut = CreateStringCalculator();


        // Act
        var actual = sut.Add(numbers);

        // Assert
        Assert.Equal(expected, actual);
    }

    private static StringCalculator CreateStringCalculator() => new();
}