using Microsoft.EntityFrameworkCore;
using Trips.Entities;
using Trips.Exceptions;

namespace Trips.Repositories.ClientRepositories;

public class ClientRepository(Cwiczenia9TripContext dbContext) : IClientRepository
{
    private readonly Cwiczenia9TripContext _context = dbContext;
    
    public async Task DeleteClientAsync(int idClient, CancellationToken cancellationToken)
    {
        var client = await _context
            .Clients
            .Include(client => client.ClientTrips)
            .FirstOrDefaultAsync(client => client.IdClient == idClient, cancellationToken);

        if (client is null)
        {
            throw new ClientNotFoundException($"Client with id {idClient} does not exist");
        }

        if (client.ClientTrips.Count != 0)
        {
            throw new ClientHasTripsException($"Client with id {idClient} " +
                                              $"has trips and therefore cannot be removed.");
        }

        _context.Clients.Remove(client);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Client?> GetClientByPeselAsync(string pesel, CancellationToken cancellationToken)
    {
        var client = await _context
            .Clients
            .Where(client => client.Pesel == pesel)
            .Include(client => client.ClientTrips)
            .FirstOrDefaultAsync(cancellationToken);
        return client;
    }

    public async Task<ICollection<Trip>> GetTripsOfClientByClientPeselAsync(string clientPesel,
        CancellationToken cancellationToken)
    {
        var trips = await _context
            .ClientTrips
            .Where(ct => ct.IdClientNavigation.Pesel == clientPesel)
            .Include(ct => ct.IdTripNavigation)
            .Select(ct => ct.IdTripNavigation)
            .ToListAsync(cancellationToken);

        return trips;
    }
}