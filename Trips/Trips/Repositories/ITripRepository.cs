using Trips.Dtos;

namespace Trips.Repositories;

public interface ITripRepository
{
    public Task<IEnumerable<TripDto>> GetTripsAsync(CancellationToken cancellationToken);
}