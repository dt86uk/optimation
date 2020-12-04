using OptimationTechnicalTest.Models.API;

namespace OptimationTechnicalTest.BusinessLogic
{
    public class ImportService : IImportService
    {
        private readonly ITextValidationService textValidationService;
        private readonly IXmlService xmlService;

        public ImportService(ITextValidationService inTextValidationService, IXmlService inXmlService)
        {
            textValidationService = inTextValidationService;
            xmlService = inXmlService;
        }

        public ApiResponseModel ProcessText(string inText)
        {
            var responseModel = new ApiResponseModel();

            int firstElementIndexStart = textValidationService.GetOpeningBracketPosition(inText);
            int firstElementIndexEnd = textValidationService.GetClosingBracketPosition(inText);

            string firstElementContent = inText.Substring(firstElementIndexStart + 1, (firstElementIndexEnd - firstElementIndexStart - 1));

            bool isRecognisedElement = xmlService.IsRecognisedElement(firstElementContent);

            if (!isRecognisedElement)
            {
                responseModel.ErrorMessage = "No XML elements recognised in text.";
                return responseModel;
            }

            //element recognised, get the contents
            string openingBracket = $"<{firstElementContent}>";
            string closingBracket = $"</{firstElementContent}>";
            int pFrom = inText.IndexOf(openingBracket);
            int pTo = inText.LastIndexOf(closingBracket);

            string content = inText.Substring(pFrom, pTo - pFrom);
            string xml = $"{content}{closingBracket}";

            //build & look for contents inbetween e.g <name>stuff here</name>            
            var xmlDoc = xmlService.BuildXmlDocumentFromString(xml);
            var model = xmlService.BuildExpenseClaimModelFromXmlDocument(xmlDoc);

            if (model == null)
            {
                responseModel.ErrorMessage = "Could not build based response from the XML provided.";
                return responseModel;
            }

            responseModel.IsRequestSuccessful = true;
            responseModel.GstCost = model.Expense.GstCost;
            responseModel.TotalExcludingGst = model.Expense.TotalExcludingGst;

            return responseModel;
        }
    }
}