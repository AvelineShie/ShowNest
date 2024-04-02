using Microsoft.AspNetCore.Mvc;
using ShowNest.Web.Services.Seats;

namespace ShowNest.Web.WebAPI;

[ApiController]
[Route("api/seats")]
public class SeatsController : ControllerBase
{
    private readonly ISeatsService _seatService;

    public SeatsController(ISeatsService seatsService)
    {
        _seatService = seatsService;
    }
    
    [HttpGet]
    public async  Task<IActionResult> Index(int seatAreaId)
    {
        var viewModel = await _seatService.GetSeatsSelectionViewModelBySeatAreaId(seatAreaId);
        
        return new JsonResult(viewModel);
    }
}