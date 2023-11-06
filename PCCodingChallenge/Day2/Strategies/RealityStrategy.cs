namespace PCCodingChallenge.Day2.Strategies;

public class RealityStrategy : IRPSStrategy
{
    public int CalcP2Points(int p1Points, string p2Move)
    {
        bool? result = p2Move.ToUpper() switch
        {
            "X" => false,   // Loss
            "Y" => null,    // Draw
            "Z" => true,    // Win
            _ => throw new SomeCustomException($"Invalid move from player 2: {p2Move}")
        };

        if (result is null) return p1Points;    // Same points as p1 if draw
        else
        {
            var r = result.Value;

            return true switch
            {
                _ when r && p1Points == 3 => 1,     // Win
                _ when r => p1Points + 1,           // Win
                _ when !r && p1Points == 1 => 3,    // Loss
                _ => p1Points - 1                   // Loss
            };
        }
    }
}
