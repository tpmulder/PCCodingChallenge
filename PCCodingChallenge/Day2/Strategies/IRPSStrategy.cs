namespace PCCodingChallenge.Day2.Strategies;

public interface IRPSStrategy
{
    /// <summary>
    /// Calculates the amount of points player 2 gets per round
    /// based on the amount of points player 1 has and the move player 2 makes
    /// </summary>
    /// <param name="p1Points">Amount of points player 1</param>
    /// <param name="p2Move">Move of player 2</param>
    /// <returns>the amount of points player 2 gets</returns>
    /// <exception cref="SomeCustomException">Thrown when <paramref name="p2Move"/> is invalid</exception>
    int CalcP2Points(int p1Points, string p2Move);
}
