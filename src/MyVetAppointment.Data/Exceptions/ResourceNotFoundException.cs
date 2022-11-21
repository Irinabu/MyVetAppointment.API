namespace MyVetAppointment.Data.Exceptions;

public class ResourceNotFoundException : Exception
{
    public ResourceNotFoundException(Type type)
        : base($"Resource of type {type.Name} was not found.")
    {
    }
}