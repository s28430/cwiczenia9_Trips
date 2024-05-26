namespace Trips.Services.ClientServices;

public interface IClientService
{
    public Task DeleteClientAsync(int idClient, CancellationToken cancellationToken);
}