namespace Trips.Exceptions;

public class ClientAlreadyAssignedToTripException : Exception
{
    public ClientAlreadyAssignedToTripException()
    {
    }

    public ClientAlreadyAssignedToTripException(string? message) : base(message)
    {
    }
}