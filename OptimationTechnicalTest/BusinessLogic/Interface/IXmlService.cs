using System.Xml;
using OptimationTechnicalTest.Models.XML;

namespace OptimationTechnicalTest.BusinessLogic
{
    public interface IXmlService
    {
        XmlDocument BuildXmlDocumentFromString(string xml);
        ExpenseClaimModel BuildExpenseClaimModelFromXmlDocument(XmlDocument xmlDoc);
        bool IsRecognisedElement(string inElementName);
    }
}