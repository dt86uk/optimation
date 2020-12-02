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

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string emailBody)
        {
            var rtnModel = importService.ProcessText(emailBody);

            //return rtnModel.IsRequestSuccessful ? Ok(rtnModel) : BadRequest(rtnModel);
        }
    }
}