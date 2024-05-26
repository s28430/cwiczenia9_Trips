using Trips.Dtos.ResponsesDtos;
using Trips.Repositories.TripRepositories;

namespace Trips.Services.TripServices;

public class TripService(ITripRepository tripRepository) : ITripService
{
    private readonly ITripRepository _tripRepository = tripRepository;
    
    public async Task<PaginatedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, int? pageSize, CancellationToken cancellationToken)
    {
        var trips = await _tripRepository.GetTripsAsync(cancellationToken);

        var pageNumNonNull = pageNum ?? 1;
        var pageSizeNonNull = pageSize ?? 10;
        
        var totalCount = trips.Count;
        var allPages = (int)Math.Ceiling((double) totalCount / pageSizeNonNull);

        var skippedTrips = trips
            .Skip((pageNumNonNull - 1) * pageSizeNonNull).ToList();
        
        
        return new PaginatedGetTripsResponseDto(pageNum ?? 1, pageSize ?? 10, allPages, skippedTrips);
    }
}