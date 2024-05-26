using System.Collections;
using Trips.Dtos;

namespace Trips.Repositories;

public interface ITripRepository
{
    public Task<ICollection<TripDto>> GetTripsAsync(CancellationToken cancellationToken);
}