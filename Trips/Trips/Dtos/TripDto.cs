using System.ComponentModel.DataAnnotations;

namespace Trips.Dtos;

public class TripDto
{
    public string Name { get; set; } = null!;
    
    public string Description { get; set; } = null!;
    
    public DateTime DateFrom { get; set; }
    
    public DateTime DateTo { get; set; }

    public int MaxPeople { get; set; }

    public IEnumerable<CountryDto> Countries { get; set; } = null!;

    public IEnumerable<ClientDto> Clients { get; set; } = null!;
}