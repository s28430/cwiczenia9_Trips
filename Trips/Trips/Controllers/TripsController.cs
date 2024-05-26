using Microsoft.AspNetCore.Mvc;
using Trips.Services;

namespace Trips.Controllers;

[ApiController]
[Route("/api/trips")]
public class TripsController(ITripService tripService) : ControllerBase
{
    private readonly ITripService _tripService = tripService;

    [HttpGet]
    public async Task<IActionResult> GetTripsInfo(CancellationToken cancellationToken)
    {
        return Ok(await _tripService.GetTripsInfoAsync(null, null, cancellationToken));
    }
}