namespace Trips.Repositories;

public interface IClientRepository
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);
}