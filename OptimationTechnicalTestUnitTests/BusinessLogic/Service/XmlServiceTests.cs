using System.Xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimationTechnicalTest.BusinessLogic;

namespace OptimationTechnicalTestUnitTests.BusinessLogic.Service
{
    [TestClass]
    public class XmlServiceTests
    {
        private XmlService xmlService;

        [TestInitialize]
        public void Init()
        {
            xmlService = new XmlService();
        }

        [TestMethod]
        public void BuildExpenseClaimModelFromXmlDocument_ReturnsModel()
        {
            //arrange
            string strXml = "<expense><total>1024.01</total></expense>";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strXml);

            //act
            var result = xmlService.BuildExpenseClaimModelFromXmlDocument(xmlDoc);

            //assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Expense);
            Assert.IsTrue(result.Expense.GstCost > 0);
            Assert.IsTrue(result.Expense.Total > 0);
        }

        [TestMethod]
        public void BuildExpenseClaimModelFromXmlDocument_ReturnsNull()
        {
            //arrange
            string strXml = "<valid><butnotwhat><wewant></wewant></butnotwhat></valid>";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(strXml);

            //act
            var result = xmlService.BuildExpenseClaimModelFromXmlDocument(xmlDoc);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void BuildXmlDocumentFromString_ReturnsXmlDoc()
        {
            //arrange
            string strXml = "<expense><total>1024.01</total></expense>";

            //act
            var result = xmlService.BuildXmlDocumentFromString(strXml);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuildXmlDocumentFromString_ReturnsNull()
        {
            //arrange
            string strXml = "NotXml";

            //act
            var result = xmlService.BuildXmlDocumentFromString(strXml);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void IsRecognisedElement_IsTrue()
        {
            //arrange
            var elementName = "expense";

            //act
            var result = xmlService.IsRecognisedElement(elementName);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsRecognisedElement_IsFalse()
        {
            //arrange
            var elementName = "something";

            //act
            var result = xmlService.IsRecognisedElement(elementName);

            //assert
            Assert.IsFalse(result);
        }
    }
}