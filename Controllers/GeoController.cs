using DistanceApi.Models.Requests;
using DistanceApi.Models.Response;
using DistanceApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DistanceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class GeoController(GeoService geoService) : ControllerBase
{
    private readonly GeoService _geoService = geoService;
    
    [HttpPost]
    public IActionResult GetDistanceKm([FromBody] GetDistanceKmRequest request)
    {
        var distance = _geoService.CalculateDistanceKm(
            request.StartPoint,
            request.EndPoint);

        return Ok(new GetDistanceKmResponse(distance));
    }
}
