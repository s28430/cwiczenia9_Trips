using Microsoft.EntityFrameworkCore;
using Trips.Dtos.EntitiesDtos;
using Trips.Entities;

namespace Trips.Repositories.TripRepositories;

public class TripRepository(Cwiczenia9TripContext context) : ITripRepository
{
    private readonly Cwiczenia9TripContext _context = context;
    
    public async Task<ICollection<TripDto>> GetTripsAsync(CancellationToken cancellationToken)
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
            .ToListAsync(cancellationToken);
            
        return trips;
    }
}