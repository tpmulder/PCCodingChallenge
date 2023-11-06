namespace PCCodingChallenge.Test.Input;

[Collection(CollectionDefinitions.InputTestCollection)]
public class InputReader_InvalidShould
{
    [Theory]
    [InlineData("PuzzleInput2_Test1_Invalid", nameof(RPSTournamentInputValidator), 11, "only two")]
    [InlineData("PuzzleInput2_Test2_Invalid", nameof(RPSTournamentInputValidator), 11, "invalid")]
    [InlineData("PuzzleInput25_Test1_Invalid", nameof(FuelInputValidator), 3, "invalid")]
    public void ReadTextFile_WithInvalidSchema_ThrowsException(string fileName, string validatorName, int validationErrorOn, string validationMessage)
    {
        // Arrange

        // This could be more dynamic, but since it's important to know what you're testing, making this more dynamic would be irrelevant
        // Leaving the validator testing out of this file and instead seperate it would be more optimal, but since this is only an exercise I've decided to skip that part
        IInputValidator validator = validatorName switch
        {
            nameof(FuelInputValidator) => new FuelInputValidator(),
            _ => new RPSTournamentInputValidator()
        };

        // Act and Assert
        var exc = Assert.Throws<SomeCustomException>(() => InputReader.ReadTextFile("TestInput", fileName, validator));
        Assert.Contains(validationMessage, exc.Message);
        Assert.Equal(validationErrorOn, ExtractIntValue(exc.Message));

        static int ExtractIntValue(string input)
        {
            // Define a regular expression pattern to match integers.
            string pattern = @"\d+";

            // Use the regular expression to find matches.
            Match match = Regex.Match(input, pattern);

            if (match.Success)
            {
                // Try to parse the matched value as an integer.
                if (int.TryParse(match.Value, out int result))
                {
                    return result;
                }
            }

            // Return a default value or throw an exception if necessary.
            // In this case, I'm returning -1 to indicate that no valid integer was found.
            return -1;
        }
    }
}
