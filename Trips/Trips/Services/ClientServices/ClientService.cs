using Trips.Repositories.ClientRepositories;

namespace Trips.Services.ClientServices;

public class ClientService(IClientRepository clientRepository) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    
    public async Task DeleteClientAsync(int idClient, CancellationToken cancellationToken)
    {
        await _clientRepository.DeleteClientAsync(idClient, cancellationToken);
    }
}