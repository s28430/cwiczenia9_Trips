using Trips.Dtos;

namespace Trips.Services;

public interface ITripService
{
    public Task<PaginatedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, 
        int? pageSize, CancellationToken cancellationToken);
}