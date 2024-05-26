using Trips.Entities;

namespace Trips.Repositories.ClientRepositories;

public interface IClientRepository
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);

    public Task<Client?> GetClientByPeselAsync(string pesel, CancellationToken cancellationToken);

    public Task<ICollection<Trip>> GetTripsOfClientByClientPeselAsync(string clientPesel, 
        CancellationToken cancellationToken);
}