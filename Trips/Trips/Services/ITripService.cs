using Trips.Dtos;

namespace Trips.Services;

public interface ITripService
{
    public Task<PagedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, 
        int? pageSize, CancellationToken cancellationToken);
}