using OptimationTechnicalTest.Models.API;

namespace OptimationTechnicalTest.BusinessLogic
{
    public interface IImportService
    {
        ApiResponseModel ProcessText(string inText);
    }
}