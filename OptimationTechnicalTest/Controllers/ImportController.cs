using Microsoft.AspNetCore.Mvc;
using OptimationTechnicalTest.BusinessLogic;

namespace OptimationTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        private readonly IImportService importService;

        public ImportController(IImportService inImportService)
        {
            importService = inImportService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Success!");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string emailBody)
        {
            var rtnModel = importService.ProcessText(emailBody);

            if (rtnModel.IsRequestSuccessful)
            {
                return Ok(rtnModel);
            }
            else
            {
                return BadRequest(rtnModel);
            }
        }
    }
}