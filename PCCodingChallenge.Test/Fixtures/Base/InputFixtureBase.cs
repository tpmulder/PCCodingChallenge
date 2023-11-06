namespace PCCodingChallenge.Test.Fixtures.Base;

public abstract class InputFixtureBase
{
    public string[] ValidFileInputTexts { get; private set; }
    public string[] InvalidFileInputTexts { get; private set; }

    public InputFixtureBase(string fileNameBase, IInputValidator? inputValidator = null)
    {
        var relPath = "TestInput";

        var validInputList = new List<string>();
        var InvalidInputList = new List<string>();

        var i = 1;
        while (File.Exists(Path.Combine(".", relPath, $"{fileNameBase}{i}.txt")))
        {
            validInputList.Add(InputReader.ReadTextFile(relPath, $"{fileNameBase}{i}", inputValidator));
            i++;
        }

        ValidFileInputTexts = validInputList.ToArray();

        i = 1;
        while (File.Exists(Path.Combine(".", relPath, $"{fileNameBase}{i}_Invalid.txt")))
        {
            InvalidInputList.Add(InputReader.ReadTextFile(relPath, $"{fileNameBase}{i}_Invalid"));
            i++;
        }

        InvalidFileInputTexts = InvalidInputList.ToArray();
    }
}
