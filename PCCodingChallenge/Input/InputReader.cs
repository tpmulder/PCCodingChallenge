namespace PCCodingChallenge.Input;

public static class InputReader
{
    /// <summary>Reads a text file from a specified directory</summary>
    /// <param name="relativePath">Path relative to file</param>
    /// <param name="fileName">Name of file</param>
    /// <param name="validator">Input validator to check if the file is valid</param>
    /// <returns>An unformatted string representation of the contents of the file</returns>
    /// <exception cref="SomeCustomException">Thrown when the file can't be found/read</exception>
    public static string ReadTextFile(string relativePath, string fileName, IInputValidator? validator = null)
    {
        try
        {
            // Create relative path to file
            var path = Path.Combine(".", relativePath, $"{fileName}.txt");

            // Open the text file using a stream reader.
            using var sr = new StreamReader(path);

            var content = sr.ReadToEnd();

            if (validator != null)
            {
                var isValid = validator.ValidateInput(content, out var msg);

                if (!isValid) throw new SomeCustomException(msg);
            }

            return content;
        }
        catch (IOException e)
        {
            // Wrap error in a custom exception for better coding experience
            throw new SomeCustomException(
                $"The file could not be found/read:\r\n" +
                $"{e.Message}"
            );
        }
    }
}
