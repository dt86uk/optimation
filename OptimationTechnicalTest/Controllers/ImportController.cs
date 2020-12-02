using Microsoft.AspNetCore.Mvc;

namespace OptimationTechnicalTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportController : ControllerBase
    {
        // POST api/values
        [HttpPost]
        public void Post([FromBody] string emailBody)
        {
        }
    }
}