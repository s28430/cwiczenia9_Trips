namespace Trips.Repositories.ClientRepositories;

public interface IClientRepository
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);
}