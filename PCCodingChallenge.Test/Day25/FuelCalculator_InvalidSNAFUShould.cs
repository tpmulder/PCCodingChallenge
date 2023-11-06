namespace PCCodingChallenge.Test.Day25;

[Collection(CollectionDefinitions.Day25TestCollection)]
public class FuelCalculator_InvalidSNAFUShould
{
    private readonly string[] _testFileInputs;

    public FuelCalculator_InvalidSNAFUShould(Day25Fixture fixture)
    {
        _testFileInputs = fixture.InvalidFileInputTexts;
    }

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    public void CalcFuel_WithInvalidFuelSchema_ThrowsException(int testFileIndex)
    {
        // Arrange
        var calculator = new FuelCalculator(_testFileInputs[testFileIndex]);

        // Act and Assert
        Assert.Throws<SomeCustomException>(() => calculator.CalcFuel());
    }

    [Fact]
    public void ConvertFromSNAFU_WithInvalidCharacter_ThrowsException()
    {
        // Arrange
        string code = "3"; // '3' is not a valid SNAFU character

        // Act and Assert
        Assert.Throws<SomeCustomException>(() => FuelCalculator.ConvertFromSNAFU(code));
    }
}
