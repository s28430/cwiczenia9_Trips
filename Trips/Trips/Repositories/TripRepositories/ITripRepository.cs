using Trips.Dtos.EntitiesDtos;
using Trips.Entities;

namespace Trips.Repositories.TripRepositories;

public interface ITripRepository
{
    public Task<ICollection<TripDto>> GetTripsAsync(CancellationToken cancellationToken);

    public Task<Trip?> GetTripByIdAsync(int idTrip, CancellationToken cancellationToken);

    public Task AssignClientToTripAsync(int idClient, int idTrip, DateTime registeredAt, DateTime? paymentDate,
        CancellationToken cancellationToken);
}