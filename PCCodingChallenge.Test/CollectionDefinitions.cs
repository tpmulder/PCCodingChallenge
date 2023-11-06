namespace PCCodingChallenge.Test;

public class CollectionDefinitions
{
    public const string Day2TestCollection = "Day 2 Test Collection";
    public const string Day25TestCollection = "Day 25 Test Collection";
    public const string InputTestCollection = "Input Test Collection";

    [CollectionDefinition(Day2TestCollection)]
    public class Day2Collection : ICollectionFixture<Day2Fixture> { }

    [CollectionDefinition(Day25TestCollection)]
    public class Day25Collection : ICollectionFixture<Day25Fixture> { }
}
