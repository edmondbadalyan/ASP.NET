using Microsoft.AspNetCore.Mvc;

namespace WebApplication4
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class MovieScheduleController : ControllerBase
    {
        private readonly IMovieScheduleService _service;
        private readonly ILogger<MovieScheduleController> _logger;

        public MovieScheduleController(
            IMovieScheduleService service,
            ILogger<MovieScheduleController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<MovieScheduleDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var schedules = await _service.GetAllSchedulesAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting movie schedules");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
