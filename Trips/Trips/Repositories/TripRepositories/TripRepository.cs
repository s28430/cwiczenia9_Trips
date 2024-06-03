using Microsoft.EntityFrameworkCore;
using Trips.Dtos.EntitiesDtos;
using Trips.Entities;

namespace Trips.Repositories.TripRepositories;

public class TripRepository(Cwiczenia9TripContext context) : ITripRepository
{
    private readonly Cwiczenia9TripContext _context = context;
    
    public async Task<ICollection<TripDto>> GetTripsAsync(int pageNum, int pageSize,
        CancellationToken cancellationToken)
    {
   
        var trips = await _context
            .Trips
            .Include(trip => trip.ClientTrips)
            .ThenInclude(ct => ct.IdClientNavigation)
            .OrderByDescending(trip => trip.DateFrom)
            .Select(trip => new TripDto
            {
                Name = trip.Name,
                Description = trip.Description,
                DateFrom = trip.DateFrom,
                DateTo = trip.DateTo,
                MaxPeople = trip.MaxPeople,
                Countries = trip.IdCountries.Select(country => new CountryDto(country.Name)).ToList(),
                Clients = trip.ClientTrips.Select(ct =>
                    new ClientDto(ct.IdClientNavigation.FirstName, ct.IdClientNavigation.LastName))
            })
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync(cancellationToken);
            
        return trips;
    }

    public async Task<Trip?> GetTripByIdAsync(int idTrip, CancellationToken cancellationToken)
    {
        var trip = await _context
            .Trips
            .SingleOrDefaultAsync(trip => trip.IdTrip == idTrip, cancellationToken);

        return trip;
    }

    public async Task AssignClientToTripAsync(int idClient, int idTrip, DateTime registeredAt, 
        DateTime? paymentDate, CancellationToken cancellationToken)
    {
        var ct = new ClientTrip
        {
            IdTrip = idTrip,
            IdClient = idClient,
            RegisteredAt = registeredAt,
            PaymentDate = paymentDate
        };

        await _context.ClientTrips.AddAsync(ct, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}