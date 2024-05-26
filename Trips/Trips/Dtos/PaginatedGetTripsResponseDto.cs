namespace Trips.Dtos;

public record PaginatedGetTripsResponseDto(int PageNum, int PageSize, int AllPages, IEnumerable<TripDto> Trips);