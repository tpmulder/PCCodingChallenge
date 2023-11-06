namespace PCCodingChallenge.Day25;

public class FuelCalculator
{
    private string _fuelSchema;

    public FuelCalculator(string fuelSchema)
    {
        _fuelSchema = fuelSchema;
    }

    /// <summary>
    /// Changes the current fuel instructions of the calculator to <paramref name="fuelSchema"/>
    /// </summary>
    /// <param name="fuelSchema">Bob's fuel instructions</param>
    public void ChangeSchema(string fuelSchema) => _fuelSchema = fuelSchema;

    /// <summary>
    /// Calculates the total amount of fuel needed based on the fuel instructions provided to the calculator
    /// </summary>
    /// <returns>
    /// <list type="number">
    /// <item>
    /// <term>conversions</term>
    /// <description>List of all conversions made to calculate the total fuel needed</description>
    /// </item>
    /// <item>
    /// <term>totalFuel</term>
    /// <description>Total amount of fuel needed</description>
    /// </item>
    /// <item>
    /// <term>totalFuelCode</term>
    /// <description>SNAFU representation of total amount of fuel needed</description>
    /// </item>
    /// </list>
    /// </returns>
    public (List<(string code, long val)> conversions, long totalFuel, string totalFuelCode) CalcFuel()
    {
        var decs = _fuelSchema.Split("\r\n");

        long total = 0;

        var conversions = new List<(string, long)>();

        Array.ForEach(decs, e => {
            var val = ConvertFromSNAFU(e);
            conversions.Add((e, val));
            total += val;
        });

        return (conversions, total, ConvertToSNAFU(total));
    }

    /// <summary>
    /// Converts a SNAFU code to its numerical representation
    /// </summary>
    /// <param name="code">The converted code</param>
    /// <returns>Numerical representation of <paramref name="code"/></returns>
    /// <exception cref="SomeCustomException"></exception>
    public static long ConvertFromSNAFU(string code)
    {
        long num = 0;
        var p = 0;

        foreach (var c in code.Reverse())
        {
            var val = TranslateCharToNum(c) * (long)Math.Pow(5, p);

            num += val;

            p++;
        }

        return num;

        static int TranslateCharToNum(char character) => character switch
        {
            '1' => 1,
            '2' => 2,
            '0' => 0,
            '-' => -1,
            '=' => -2,
            _ => throw new SomeCustomException($"Invalid character: {character}")
        };
    }

    /// <summary>
    /// Converts a number to its SNAFU representation
    /// </summary>
    /// <param name="num">The converted number</param>
    /// <returns>SNAFU representation of <paramref name="num"/></returns>
    public static string ConvertToSNAFU(long num)
    {
        if (num == 0) return "0";

        var code = new StringBuilder();

        while (num != 0)
        {
            // make sure mod can't be negative
            var rem = ((num % 5) + 5) % 5;

            if (new long[] { 0, 1, 2 }.Contains(rem))
            {
                code.Append(rem);
                num /= 5;
            }
            else
            {
                code.Append(rem == 3 ? '=' : '-');

                // rem 3 or 4? add +1 to next num
                num = num / 5 + 1;
            }
        }

        var chars = code.ToString().ToCharArray();
        Array.Reverse(chars);
        return new string(chars);
    }
}
