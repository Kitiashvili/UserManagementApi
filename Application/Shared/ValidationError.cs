namespace Application.Shared;

public class ValidationError
{
    public string PropertyName { get; set; } 
    public string Message { get; set; } 

    public ValidationError(string name, string message)
    {
        PropertyName = name;
        Message = message;
    }
}