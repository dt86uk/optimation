using System.Xml.Serialization;

namespace OptimationTechnicalTest.Models.XML
{
    public class ExpenseModel
    {
        [XmlElement(ElementName = "total")]
        public decimal Total { get; set; }

        public decimal TotalExcludingGst => Total - GstCost;

        public decimal GstCost => GstValue * Total;

        private const decimal GstValue = 0.15m;
    }
}