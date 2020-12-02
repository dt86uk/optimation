using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimationTechnicalTest.BusinessLogic;

namespace OptimationTechnicalTestUnitTests.BusinessLogic.Service
{
    public class ImportServiceTests
    {
        private ImportService importService;

        [TestInitialize]
        public void Init()
        {
            importService = new ImportService();
        }

        [TestMethod]
        public void ProcessTextTest()
        {
            //do test here
        }
    }
}
