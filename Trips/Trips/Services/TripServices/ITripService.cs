using Trips.Dtos.ResponsesDtos;

namespace Trips.Services.TripServices;

public interface ITripService
{
    public Task<PaginatedGetTripsResponseDto> GetTripsInfoAsync(int? pageNum, 
        int? pageSize, CancellationToken cancellationToken);
}