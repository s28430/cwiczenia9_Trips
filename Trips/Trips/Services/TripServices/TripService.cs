using Trips.Dtos.ResponsesDtos;
using Trips.Repositories.TripRepositories;

namespace Trips.Services.TripServices;

public class TripService(ITripRepository tripRepository) : ITripService
{
    private readonly ITripRepository _tripRepository = tripRepository;
    
    public async Task<PaginatedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, int? pageSize, CancellationToken cancellationToken)
    {
        var pageNumNonNull = pageNum ?? 1;
        var pageSizeNonNull = pageSize ?? 10;
        var trips = await _tripRepository.GetTripsAsync(pageNumNonNull, pageSizeNonNull, cancellationToken);
        
        var totalCount = trips.Count;
        var allPages = (int)Math.Ceiling((double) totalCount / pageSizeNonNull);
        
        return new PaginatedGetTripsResponseDto(pageNum ?? 1, pageSize ?? 10, allPages, trips);
    }
}