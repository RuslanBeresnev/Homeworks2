namespace UniqueList;

/// <summary>
/// Exception that is thrown when trying to interact with a non-existent element
/// </summary>
public class NonExistentElementReferencingException : Exception
{
    public NonExistentElementReferencingException()
    {
    }
    public NonExistentElementReferencingException(string message) : base(message)
    {
    }
}