using Microsoft.AspNetCore.Mvc;
using Trips.Exceptions;
using Trips.Services;

namespace Trips.Controllers;

[ApiController]
[Route("/api/trips")]
public class TripsController(ITripService tripService, IClientService clientService) : ControllerBase
{
    private readonly ITripService _tripService = tripService;
    private readonly IClientService _clientService = clientService;

    [HttpGet]
    public async Task<IActionResult> GetTripsInfoAsync(int? pageNum, int? pageSize, CancellationToken cancellationToken)
    {
        return Ok(await _tripService.GetTripsInfoAsync(pageNum, pageSize, cancellationToken));
    }

    [HttpDelete("/{id:int}")]
    public async Task<IActionResult> DeleteClientAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            await _clientService.DeleteClientAsync(id, cancellationToken);
            return NoContent();
        }
        catch (ClientNotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (ClientHasTripsException e)
        {
            return Conflict(e.Message);
        }
    }
}