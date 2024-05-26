namespace Trips.Exceptions;

public class TripNotFoundException : Exception
{
    public TripNotFoundException()
    {
    }

    public TripNotFoundException(string? message) : base(message)
    {
    }
}