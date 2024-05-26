namespace Trips.Services;

public interface IClientService
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);
}