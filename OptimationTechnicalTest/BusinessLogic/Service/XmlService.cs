using System;
using System.Xml;
using OptimationTechnicalTest.Models.XML;

namespace OptimationTechnicalTest.BusinessLogic
{
    public class XmlService : IXmlService
    {
        private const string ExpenseXmlParentName = "expense";
        private const string ExpenseXmlChildName = "total";

        public XmlDocument BuildXmlDocumentFromString(string xml)
        {
            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);
                return xmlDoc;
            }
            catch
            {
                return null;
            }
        }

        public ExpenseClaimModel BuildExpenseClaimModelFromXmlDocument(XmlDocument xmlDoc)
        {
            try
            {
                var xmlElements = xmlDoc.GetElementsByTagName(ExpenseXmlChildName);

                if (xmlElements == null)
                {
                    return null;    
                }

                var expenseModel = new ExpenseClaimModel()
                {
                    Expense = new ExpenseModel() 
                    {
                        Total = Convert.ToDecimal(xmlDoc.InnerText)
                    }
                };

                return expenseModel;
            }
            catch
            {
                return null;
            }
        }

        public bool IsRecognisedElement(string inElementName)
        {
            return string.Equals(ExpenseXmlParentName, inElementName, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}