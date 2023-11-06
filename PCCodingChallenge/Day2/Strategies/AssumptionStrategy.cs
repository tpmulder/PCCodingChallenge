namespace PCCodingChallenge.Day2.Strategies;

public class AssumptionStrategy : IRPSStrategy
{
    public int CalcP2Points(int p1Points, string p2Move) => p2Move.ToUpper() switch
    {
        "X" => 1,   // Rock
        "Y" => 2,   // Paper
        "Z" => 3,   // Scissors
        _ => throw new SomeCustomException($"Invalid move from player 2: {p2Move}")
    };
}
