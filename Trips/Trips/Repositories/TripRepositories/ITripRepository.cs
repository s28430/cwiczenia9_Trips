using Trips.Dtos.EntitiesDtos;

namespace Trips.Repositories.TripRepositories;

public interface ITripRepository
{
    public Task<ICollection<TripDto>> GetTripsAsync(CancellationToken cancellationToken);
}