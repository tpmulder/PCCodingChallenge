using System.Numerics;

namespace PCCodingChallenge.Test.Day2;

[Collection(CollectionDefinitions.Day2TestCollection)]
public class RPSCalculator_InvalidMoveShould
{
    private readonly RPSCalculator _rpsCalc;

    public RPSCalculator_InvalidMoveShould()
    {
        _rpsCalc = new RPSCalculator(new AssumptionStrategy());
    }

    [Theory]
    [InlineData(nameof(AssumptionStrategy), "A", "B", "player 2")]
    [InlineData(nameof(RealityStrategy), "G", "X", "player 1")]
    public void CalcRoundPoints_WithInvalidMove_ThrowsException(string strategyName, string p1Move, string p2Move, string wrongMoveMsg)
    {
        // Arrange

        // This could be more dynamic, but since it's important to know what you're testing, making this more dynamic would be irrelevant
        // Leaving the strategy testing out of this file and instead seperate it would be more optimal, but since this is only an exercise I've decided to skip that part
        IRPSStrategy strat = strategyName switch
        {
            nameof(AssumptionStrategy) => new AssumptionStrategy(),
            _ => new RealityStrategy()
        };

        _rpsCalc.ChangeStrategy(strat);

        // Act and Assert
        var exc = Assert.Throws<SomeCustomException>(() => _rpsCalc.CalcRoundPoints(p1Move, p2Move));
        Assert.Contains(wrongMoveMsg, exc.Message);
    }
}
