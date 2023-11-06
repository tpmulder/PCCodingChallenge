namespace PCCodingChallenge.Test.Input;

[Collection(CollectionDefinitions.InputTestCollection)]
public class InputReader_ValidShould
{
    [Theory]
    [InlineData("PuzzleInput2_Test1", nameof(RPSTournamentInputValidator), "C Z\r\nC Z\r\nB Z\r\nB X\r\nB Z\r\nC Y\r\nA Y\r\nC Y\r\nB X\r\nC Y\r\nB Y\r\nC X\r\nB X\r\nA Y\r\nC Z\r\nB X\r\nB Z\r\nB Y\r\nB X\r\nB X")]
    [InlineData("PuzzleInput25_Test1", nameof(FuelInputValidator), "20-==1==1212==2=\r\n1=022102-=02=1=11\r\n2110--=1011=\r\n1--21=-11=2-01\r\n1==\r\n211--11-11001=120==\r\n122---0-\r\n1120020-1\r\n1-=-0\r\n2=-022=-110-1=020")]
    public void ReadTextFile_WithInvalidSchema_ThrowsException(string fileName, string validatorName, string expectedSchema)
    {
        // Arrange

        // This could be more dynamic, but since it's important to know what you're testing, making this more dynamic would be irrelevant
        // Leaving the validator testing out of this file and instead seperate it would be more optimal, but since this is only an exercise I've decided to skip that part
        IInputValidator validator = validatorName switch
        {
            nameof(FuelInputValidator) => new FuelInputValidator(),
            _ => new RPSTournamentInputValidator()
        };

        // Act
        var schema = InputReader.ReadTextFile("TestInput", fileName, validator);

        // Assert
        Assert.Equal(schema, expectedSchema);
    }
}
