/*
 * Opdracht: https://adventofcode.com/2022/day/2
 * 
 * Platgeslagen:
 * Je opties en punten:
 * Steen = 1
 * Papier = 2
 * Schaar = 3
 * 
 * De mogelijke uitkomsten en punten:
 * Winst = 6
 * Gelijkspel = 3
 * Verlies = 0
 * 
 * Een guy met puntoren (waarschijnlijk een scammer) geeft je een lijst met een voorspelling van wat de tegenstander gaat doen.
 * Daarnaast staat er ook gespecificeert wat jij zou moeten doen.
 * Al snel valt het je op dat je niet elke keer wint volgens het schema.
 * Waarschijnlijk is dat om het wat minder fishy te laten lijken, maar het zou ook zomaar kunnen dat je keihard opgelicht wordt!
 * Het is aan jou om te onderzoeken hoe de vork in de steel zit.
 * 
 * Nou, let's go!
 */


// Day 2 Exercises
// ______________________________________________________________________________________________________________

var schema2 = InputReader.ReadTextFile("Input", "PuzzleInput2", new RPSTournamentInputValidator());
var rpsCalc = new RPSCalculator(new AssumptionStrategy());

// Part 1
Console.WriteLine("Let's calculate the points according to what I assume is the meaning of the plan...\r\n");

Log2Results(schema2, rpsCalc);

// Part 2
Console.WriteLine("Let's calculate the points according to the REAL meaning of the plan...\r\n");

rpsCalc.ChangeStrategy(new RealityStrategy());

Log2Results(schema2, rpsCalc);

static void Log2Results(string schema, RPSCalculator calc)
{
    var (p1Total, p2Total) = calc.CalcTournamentPoints(schema);

    Console.WriteLine(
        $"Player 1 has a total of {p1Total} points.\r\n" +
        $"Player 2 has a total of {p2Total} points.\r\n" +
        $"This makes that, given everything goes exactly according to plan, the guy with the pointy ears\r\n" +
        $"is{(p1Total < p2Total ? " probably not" : "")} a scammer!\r\n"
    );
}

/*
 * Opdracht: https://adventofcode.com/2022/day/25
 * 
 * Platgeslagen:
 * SNAFU formule per character:
 * V = value
 * C = character
 * P = position
 * 
 * V = C * (5^P)
 * 
 * Vormen van C:
 * 2 -> 2
 * 1 -> 1
 * 0 -> 0
 * - -> -1
 * = -> -2
 * 
 * Een paar guys met puntoren zitten in een hetelucht ballon.
 * Het is erg koud dus weten ze niet hoe ze moeten landen.
 * Jij moet ze helpen bij het ontcijferen van de code die op de kachel van de ballon staat en ze de juiste instructies geven om te landen.
 * 
 * Nou, let's go!
 */

// Day 25 Exercises
// ______________________________________________________________________________________________________________

var schema25 = InputReader.ReadTextFile("Input", "PuzzleInput25", new FuelInputValidator());
var fuelCalc = new FuelCalculator(schema25);
var (calcs, tot, totCode) = fuelCalc.CalcFuel();

Console.WriteLine(string.Join(Environment.NewLine, calcs.Select(e => e.code.PadRight(calcs.Max(e => e.code.Length) + 5) + $"-> {e.val}")));
Console.WriteLine($"\r\nThe total amount of fuel needed for the balloons is {tot} ({totCode})!");

Console.ReadLine();