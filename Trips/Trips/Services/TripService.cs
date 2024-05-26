using Trips.Dtos;
using Trips.Repositories;

namespace Trips.Services;

public class TripService(ITripRepository tripRepository) : ITripService
{
    private readonly ITripRepository _tripRepository = tripRepository;
    
    public async Task<PagedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, int? pageSize, CancellationToken cancellationToken)
    {
        pageNum ??= 1;
        pageSize ??= 10;
        
        var trips = await _tripRepository.GetTripsAsync(cancellationToken);

        return new PagedGetTripsResponseDto(1, 2, 4, trips);
    }
}