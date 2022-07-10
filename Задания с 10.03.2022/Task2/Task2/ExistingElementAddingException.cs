namespace UniqueList;

/// <summary>
/// Exception that is thrown when trying to add an already existing value
/// </summary>
public class ExistingElementAddingException : Exception
{
    public ExistingElementAddingException()
    {
    }

    public ExistingElementAddingException(string message) : base(message)
    {
    }
}