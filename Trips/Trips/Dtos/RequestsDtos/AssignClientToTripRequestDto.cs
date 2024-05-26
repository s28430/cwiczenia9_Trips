using System.ComponentModel.DataAnnotations;

namespace Trips.Dtos.RequestsDtos;

public class AssignClientToTripRequestDto
{
    [Required]
    public string ClientFirstName { get; set; } = null!;
    
    [Required]
    public string ClientLastName { get; set; } = null!;
    
    [Required]
    public string ClientEmail { get; set; } = null!;
    
    [Required]
    public string ClientPesel { get; set; } = null!;
    
    [Required]
    public string ClientTelephone { get; set; } = null!;

    [Required]
    public int IdTrip { get; set; }

    [Required]
    public string TripName { get; set; } = null!;

    [Required]
    public string PaymentDate { get; set; } = null!;
}