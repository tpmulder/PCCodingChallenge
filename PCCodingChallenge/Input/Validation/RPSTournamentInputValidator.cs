namespace PCCodingChallenge.Input.Validation;

public class RPSTournamentInputValidator : IInputValidator
{
    public bool ValidateInput(string input, out string msg)
    {
        var lines = input.Split("\r\n").Select(e => e.Trim());
        var validMoves = new[] { "A", "B", "C", "X", "Y", "Z" };

        var i = 1;

        foreach (var line in lines)
        {
            var parts = line.Split(' ');

            if (parts.Length != 2)
            {
                msg = GetLineError(i) + "This line doesn't contain only two moves";
                return false;
            }

            var (move1, move2) = (parts[0], parts[1]);

            if (!validMoves[..3].Any(e => e == move1) || !validMoves[3..].Contains(move2))
            {
                msg = GetLineError(i) + "This line contains invalid moves";
                return false;
            }

            i++;
        }

        msg = "";
        return true;

        static string GetLineError(int line) => $"Validation failed for line {line}\r\n";
    }
}
