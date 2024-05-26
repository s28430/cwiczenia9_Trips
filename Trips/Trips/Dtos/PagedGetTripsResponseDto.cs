namespace Trips.Dtos;

public record PagedGetTripsResponseDto(int PageNum, int PageSize, int AllPages, IEnumerable<TripDto> Trips);