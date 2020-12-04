using System.Xml;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimationTechnicalTest.BusinessLogic;
using OptimationTechnicalTest.Models.API;
using OptimationTechnicalTest.Models.XML;

namespace OptimationTechnicalTestUnitTests.BusinessLogic.Service
{
    [TestClass]
    public class ImportServiceTests
    {
        private ImportService importService;
        private Mock<ITextValidationService> mockTextValidationService;
        private Mock<IXmlService> mockXmlService;

        [TestInitialize]
        public void Init()
        {
            mockTextValidationService = new Mock<ITextValidationService>();
            mockXmlService = new Mock<IXmlService>();
            importService = new ImportService(mockTextValidationService.Object, mockXmlService.Object);
        }

        [TestMethod]
        public void ProcessTextTest_ReturnsModel_IsRequestSuccessful_IsTrue()
        {
            //arrange
            string inText = "Hi somebody, here is my expenses claim <expense><total>1024.01</total></expense>. Thanks!";
            string xmlString = "<expense><total>1024.01</total></expense>";
            var textValidationService = new TextValidationService();
            var xmlService = new XmlService();
            int openingBracketPosition = textValidationService.GetOpeningBracketPosition(inText);
            int closingBracketPosition = textValidationService.GetClosingBracketPosition(inText);
            XmlDocument xmlDoc = xmlService.BuildXmlDocumentFromString(xmlString);
            var expenseModel = new ExpenseClaimModel()
            {
                Expense = new ExpenseModel()
                {
                    Total = 1024.01m
                }
            };
            var responseModel = new ApiResponseModel();

            mockTextValidationService.Setup(p => p.GetOpeningBracketPosition(inText)).Returns(openingBracketPosition);
            mockTextValidationService.Setup(p => p.GetClosingBracketPosition(inText)).Returns(closingBracketPosition);
            mockXmlService.Setup(p => p.IsRecognisedElement(It.IsAny<string>())).Returns(true);
            mockXmlService.Setup(p => p.BuildXmlDocumentFromString(It.IsAny<string>())).Returns(xmlDoc);
            mockXmlService.Setup(p => p.BuildExpenseClaimModelFromXmlDocument(xmlDoc)).Returns(expenseModel);

            //act
            var result = importService.ProcessText(inText);

            //assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.IsRequestSuccessful);
            Assert.IsTrue(result.GstCost > 0);
            Assert.IsTrue(result.TotalExcludingGst > 0);
            Assert.IsNull(result.ErrorMessage);
        }

        [TestMethod]
        public void ProcessTextTest_ReturnsModel_IsRequestSuccessful_IsFalse()
        {
            //arrange
            string inText = "Hi somebody, here is my expenses claim <expense><total>1024.01</total></expense>. Thanks!";
            string xmlString = "<expense><total>1024.01</total></expense>";
            var textValidationService = new TextValidationService();
            var xmlService = new XmlService();
            int openingBracketPosition = textValidationService.GetOpeningBracketPosition(inText);
            int closingBracketPosition = textValidationService.GetClosingBracketPosition(inText);
            XmlDocument xmlDoc = xmlService.BuildXmlDocumentFromString(xmlString);
            var responseModel = new ApiResponseModel();

            mockTextValidationService.Setup(p => p.GetOpeningBracketPosition(inText)).Returns(openingBracketPosition);
            mockTextValidationService.Setup(p => p.GetClosingBracketPosition(inText)).Returns(closingBracketPosition);
            mockXmlService.Setup(p => p.IsRecognisedElement(It.IsAny<string>())).Returns(true);
            mockXmlService.Setup(p => p.BuildXmlDocumentFromString(It.IsAny<string>())).Returns(xmlDoc);
            mockXmlService.Setup(p => p.BuildExpenseClaimModelFromXmlDocument(xmlDoc)).Returns((ExpenseClaimModel)null);

            //act
            var result = importService.ProcessText(inText);

            //assert
            Assert.IsNotNull(result);
            Assert.IsFalse(result.IsRequestSuccessful);
            Assert.IsTrue(result.GstCost == 0);
            Assert.IsTrue(result.TotalExcludingGst == 0);
            Assert.IsTrue(!string.IsNullOrEmpty(result.ErrorMessage));
            Assert.AreEqual(result.ErrorMessage, "Could not build based response from the XML provided.");
        }
    }
}