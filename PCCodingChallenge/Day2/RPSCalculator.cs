namespace PCCodingChallenge.Day2;

public class RPSCalculator
{
    private IRPSStrategy _strat;

    public RPSCalculator(IRPSStrategy strat)
    {
        _strat = strat;
    }

    /// <summary>
    /// Changes the strategy used to calculate the move of player 2
    /// </summary>
    /// <param name="strat">The strategy used</param>
    public void ChangeStrategy(IRPSStrategy strat) => _strat = strat;

    /// <summary>
    /// Calculates the total amount of points player 1 and player 2 get 
    /// after multiple rounds defined in <paramref name="schema"/>
    /// </summary>
    /// <param name="schema">Schema of tournament</param>
    /// <returns>
    /// <list type="number">
    /// <item>
    /// <term>p1Points</term>
    /// <description>Total amount of points player 1 gets</description>
    /// </item>
    /// <item>
    /// <term>p2Points</term>
    /// <description>Total amount of points player 2 gets</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <exception cref="SomeCustomException">Thrown when either player 1 or player 2 makes an invalid move</exception>
    public (int p1Total, int p2Total) CalcTournamentPoints(string schema)
    {
        var roundResults = schema.Split("\r\n");
        var results = new List<(int p1Points, int p2Points)>();

        // Calculate the points the players get from each round
        Array.ForEach(roundResults, e =>
        {
            var arr = e.Split(' ');

            results.Add(CalcRoundPoints(arr[0], arr[1]));
        });

        return (results.Sum(e => e.p1Points), results.Sum(e => e.p2Points));
    }

    /// <summary>
    /// Calculates the total amount of points player 1 and player 2 get
    /// </summary>
    /// <param name="p1Move">Move of player 1</param>
    /// <param name="p2Move">Move of player 2</param>
    /// <returns>
    /// <list type="number">
    /// <item>
    /// <term>p1Points</term>
    /// <description>Amount of points player 1 gets</description>
    /// </item>
    /// <item>
    /// <term>p2Points</term>
    /// <description>Amount of points player 2 gets</description>
    /// </item>
    /// </list>
    /// </returns>
    /// <exception cref="SomeCustomException">Thrown when either player 1 or player 2 makes an invalid move</exception>
    public (int p1Points, int p2Points) CalcRoundPoints(string p1Move, string p2Move)
    {
        int p1Points, p2Points;

        p1Points = p1Move.ToUpper() switch
        {
            "A" => 1,
            "B" => 2,
            "C" => 3,
            _ => throw new SomeCustomException($"Invalid move from player 1: {p1Move}")
        };

        // Calculate the points for the move of player 2 based on the strategy used
        p2Points = _strat.CalcP2Points(p1Points, p2Move);

        // Calculate the points for each player based on the result of the round
        Func<int, int, (int, int)> addResultPointsFunc = true switch
        {
            _ when p1Points == p2Points => (a, b) => { a += 3; b += 3; return (a, b); }, // Draw
            _ when p1Points == 1 && p2Points == 3 ||
                   p1Points == 2 && p2Points == 1 ||
                   p1Points == 3 && p2Points == 2 => (a, b) => (a + 6, b),               // Player 1 win
            _ => (a, b) => (a, b + 6)                                                    // Player 2 win
        };

        return addResultPointsFunc(p1Points, p2Points);
    }
}
