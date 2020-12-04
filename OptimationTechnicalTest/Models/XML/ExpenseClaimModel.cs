using System;
using System.Xml.Serialization;

namespace OptimationTechnicalTest.Models.XML
{
    [Serializable]
    public class ExpenseClaimModel
    {
        [XmlElement(ElementName = "expense")]
        public ExpenseModel Expense { get; set; }
    }
}
