namespace PCCodingChallenge.Input.Validation;

public interface IInputValidator
{
    /// <summary>
    /// Validates the contents of a file
    /// </summary>
    /// <param name="input">File contents</param>
    /// <param name="msg">Validation message</param>
    /// <returns>True if validation is succesful or false if validation failed</returns>
    bool ValidateInput(string input, out string msg);
}
