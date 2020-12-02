using OptimationTechnicalTest.Models;

namespace OptimationTechnicalTest.BusinessLogic
{
    public interface IImportService
    {
        BaseApiResponseModel ProcessText(string inText);
    }
}