using Trips.Dtos.RequestsDtos;

namespace Trips.Services.ClientServices;

public interface IClientService
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);

    public Task AssignClientToTripAsync(AssignClientToTripRequestDto data, CancellationToken cancellationToken);
}