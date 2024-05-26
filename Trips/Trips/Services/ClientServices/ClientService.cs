using Trips.Dtos.RequestsDtos;
using Trips.Entities;
using Trips.Exceptions;
using Trips.Repositories.ClientRepositories;
using Trips.Repositories.TripRepositories;

namespace Trips.Services.ClientServices;

public class ClientService(IClientRepository clientRepository, ITripRepository tripRepository,
    Cwiczenia9TripContext dbContext) : IClientService
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly ITripRepository _tripRepository = tripRepository;
    
    private readonly Cwiczenia9TripContext _context = dbContext;
    
    public async Task DeleteClientAsync(int idClient, CancellationToken cancellationToken)
    {
        await _clientRepository.DeleteClientAsync(idClient, cancellationToken);
    }

    private async Task<bool> ClientExistsByPeselAsync(string pesel, CancellationToken cancellationToken)
    {
        var client = await _clientRepository.GetClientByPeselAsync(pesel, cancellationToken);
        return client is not null;
    }

    private async Task<bool> ClientAssignedToTripAsync(string clientPesel, int idTrip, CancellationToken cancellationToken)
    {
        var tripsOfClient = 
            await _clientRepository.GetTripsOfClientByClientPeselAsync(clientPesel, cancellationToken);
        return tripsOfClient.FirstOrDefault(trip => trip.IdTrip == idTrip) is not null;
    }

    private async Task<bool> TripExistsByIdAsync(int idTrip, CancellationToken cancellationToken)
    {
        var trip = await _tripRepository.GetTripByIdAsync(idTrip, cancellationToken);
        return trip is not null;
    }

    public async Task AssignClientToTripAsync(AssignClientToTripRequestDto data, CancellationToken cancellationToken)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        

        if (!await ClientExistsByPeselAsync(data.ClientPesel, cancellationToken))
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new ClientNotFoundException($"Client with pesel '{data.ClientPesel}' does not exist.");
        }


        if (await ClientAssignedToTripAsync(data.ClientPesel, data.IdTrip, cancellationToken))
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new ClientAlreadyAssignedToTripException($"Client with pesel '{data.ClientPesel}'" +
                                                   $" is already assigned to trip with id {data.IdTrip}.");
        }

        if (!await TripExistsByIdAsync(data.IdTrip, cancellationToken))
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new TripNotFoundException($"Trip with id {data.IdTrip} does not exist.");
        }
    }
}