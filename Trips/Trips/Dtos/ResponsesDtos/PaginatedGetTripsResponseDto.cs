using Trips.Dtos.EntitiesDtos;

namespace Trips.Dtos.ResponsesDtos;

public record PaginatedGetTripsResponseDto(int PageNum, int PageSize, int AllPages, IEnumerable<TripDto> Trips);