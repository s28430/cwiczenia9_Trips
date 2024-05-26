namespace Trips.Exceptions;

public class ClientHasTripsException : Exception
{
    public ClientHasTripsException()
    {
    }

    public ClientHasTripsException(string? message) : base(message)
    {
    }
}