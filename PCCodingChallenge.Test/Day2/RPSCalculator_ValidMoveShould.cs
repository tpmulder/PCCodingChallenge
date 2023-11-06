namespace PCCodingChallenge.Test.Day2;

[Collection(CollectionDefinitions.Day2TestCollection)]
public class RPSCalculator_ValidMoveShould
{
    private readonly string[] _testFileInputs;
    private readonly RPSCalculator _rpsCalc;

    public RPSCalculator_ValidMoveShould(Day2Fixture fixture)
    {
        _testFileInputs = fixture.ValidFileInputTexts;
        _rpsCalc = new RPSCalculator(new AssumptionStrategy());
    }

    [Theory]
    [InlineData(nameof(AssumptionStrategy), 0, 114, 90)]
    [InlineData(nameof(AssumptionStrategy), 1, 100, 99)]
    [InlineData(nameof(RealityStrategy), 0, 108, 92)]
    [InlineData(nameof(RealityStrategy), 1, 91, 99)]
    public void CalcTournamentPoints_WithValidSchema_ReturnsExpectedResult(string strategyName, int testFileIndex, int p1Points, int p2Points)
    {
        // Arrange
        var schema = _testFileInputs[testFileIndex];

        // This could be more dynamic, but since it's important to know what you're testing, making this more dynamic would be irrelevant
        // Leaving the strategy testing out of this file and instead seperate it would be more optimal, but since this is only an exercise I've decided to skip that part
        IRPSStrategy strat = strategyName switch
        {
            nameof(AssumptionStrategy) => new AssumptionStrategy(),
            _ => new RealityStrategy()
        };

        _rpsCalc.ChangeStrategy(strat);

        // Act
        var (p1Total, p2Total) = _rpsCalc.CalcTournamentPoints(schema);

        // Assert
        Assert.Equal(p1Points, p1Total);
        Assert.Equal(p2Points, p2Total);
    }
}
