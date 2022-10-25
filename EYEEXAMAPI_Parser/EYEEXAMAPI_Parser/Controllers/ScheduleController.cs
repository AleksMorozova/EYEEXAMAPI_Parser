using EYEEXAMAPI_Parser.Parsers;
using EYEEXAMAPI_Parser.Services;
using Microsoft.AspNetCore.Mvc;

namespace EYEEXAMAPI_Parser.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;
        public readonly IScheduleParser _scheduleParser;

        public ScheduleController(IScheduleService scheduleService, IScheduleParser scheduleParser)
        {
            _scheduleService = scheduleService;
            _scheduleParser = scheduleParser;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedule()
        {
            var rawSchedule = await _scheduleService.GetRawSchedule();

            var parsedSchedule = _scheduleParser.Parse(rawSchedule!);

            return Ok(parsedSchedule);
        }
    }
}
