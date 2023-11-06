namespace PCCodingChallenge.Input.Validation;

public class FuelInputValidator : IInputValidator
{
    public bool ValidateInput(string input, out string msg)
    {
        var lines = input.Split("\r\n").Select(e => e.Trim());
        var validChars = new HashSet<char> { '0', '1', '2', '-', '=' };

        var i = 1;
        foreach (var line in lines)
        {
            if (line.Any(e => !validChars.Contains(e)))
            {
                msg = GetLineError(i) + "This line contains invalid character(s)";
                return false;
            }

            i++;
        }

        msg = "";
        return true;

        static string GetLineError(int line) => $"Validation failed for line {line}\r\n";
    }
}
