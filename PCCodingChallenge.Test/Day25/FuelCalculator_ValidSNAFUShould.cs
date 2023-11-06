namespace PCCodingChallenge.Test.Day25;

[Collection(CollectionDefinitions.Day25TestCollection)]
public class FuelCalculator_ValidSNAFUShould
{
    private readonly string[] _testFileInputs;

    public FuelCalculator_ValidSNAFUShould(Day25Fixture fixture)
    {
        _testFileInputs = fixture.ValidFileInputTexts;
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("0", 0)]
    [InlineData("-", -1)]
    [InlineData("=", -2)]
    [InlineData("10", 5)]
    [InlineData("1=0", 15)]
    [InlineData("2=-", 39)]
    [InlineData("1-0=", 98)]
    [InlineData("1-20", 110)]
    [InlineData("1-20=-1=0", 342390)]
    public void ConvertFromSNAFU_WithValidSNAFUCode_ReturnsExpectedResult(string code, long expected)
    {
        // Act
        long result = FuelCalculator.ConvertFromSNAFU(code);

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void ConvertFromSNAFU_WithEmptyCode_ReturnsZero()
    {
        // Arrange
        string code = "";

        // Act
        long result = FuelCalculator.ConvertFromSNAFU(code);

        // Assert
        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData(1, "1")]
    [InlineData(2, "2")]
    [InlineData(5, "10")]
    [InlineData(25, "100")]
    [InlineData(960, "2==20")]
    [InlineData(354845, "10=-=---0")]
    [InlineData(26845, "2-=0--0")]
    public void ConvertToSNAFU_WithValidNumber_ReturnsExpectedResult(long num, string expectedCode)
    {
        // Act
        string result = FuelCalculator.ConvertToSNAFU(num);

        // Assert
        Assert.Equal(expectedCode, result);
    }

    [Fact]
    public void ConvertToSNAFU_WithZero_ReturnsZeroCode()
    {
        // Arrange
        long num = 0;

        // Act
        string result = FuelCalculator.ConvertToSNAFU(num);

        // Assert
        Assert.Equal("0", result);
    }
}
