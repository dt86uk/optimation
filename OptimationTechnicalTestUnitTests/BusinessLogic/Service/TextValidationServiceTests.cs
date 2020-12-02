using Microsoft.VisualStudio.TestTools.UnitTesting;
using OptimationTechnicalTest.BusinessLogic;

namespace OptimationTechnicalTestUnitTests.BusinessLogic.Service
{
    [TestClass]
    public class TextValidationServiceTests
    {
        private ITextValidationService textValidationService;

        [TestInitialize]
        public void Init()
        {
            textValidationService = new TextValidationService();
        }

        [TestMethod]
        public void IsCharacterOpeningAngleBracketTest_IsTrue()
        {
            //arrange
            char openingBracket = '<';

            //act
            var result = textValidationService.IsCharacterOpeningAngleBracket(openingBracket);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCharacterOpeningAngleBracketTest_IsFalse()
        {
            //arrange
            char characterOne = 'a';
            char characterTwo = '1';
            char characterThree = '@';

            //act
            var result1 = textValidationService.IsCharacterOpeningAngleBracket(characterOne);
            var result2 = textValidationService.IsCharacterOpeningAngleBracket(characterTwo);
            var result3 = textValidationService.IsCharacterOpeningAngleBracket(characterThree);

            //assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void IsCharacterClosingAngleBracket_IsTrue()
        {
            //arrange
            char closingBracket = '>';

            //act
            var result = textValidationService.IsCharacterClosingAngleBracket(closingBracket);

            //assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsCharacterClosingAngleBracket_IsFalse()
        {
            //arrange
            char characterOne = 'a';
            char characterTwo = '1';
            char characterThree = '@';

            //act
            var result1 = textValidationService.IsCharacterClosingAngleBracket(characterOne);
            var result2 = textValidationService.IsCharacterClosingAngleBracket(characterTwo);
            var result3 = textValidationService.IsCharacterClosingAngleBracket(characterThree);

            //assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }

        [TestMethod]
        public void GetOpeningBracketPositionTest_IsTrue()
        {
            //arrange
            string testText = "Hi Somebody, here is the info required <test>hello world</test>";
            int firstOpeningBracket = testText.IndexOf('<');

            //act
            var result = textValidationService.GetOpeningBracketPosition(testText);

            //assert
            Assert.IsTrue(result > -1); //represents index of char not found
            Assert.IsTrue(result == firstOpeningBracket);
        }

        [TestMethod]
        public void GetClosingBracketPositionTest_IsTrue()
        {
            //arrange
            string testText = "Hi Somebody, here is the info required <test>hello world</test>";
            int firstClosingBracket = testText.IndexOf('<');

            //act
            var result = textValidationService.GetOpeningBracketPosition(testText);

            //assert
            Assert.IsTrue(result > -1); //represents index of char not found
            Assert.IsTrue(result == firstClosingBracket);
        }

        [TestMethod]
        public void GetOpeningBracketPositionTest_IsFalse()
        {
            //arrange
            string testText1 = string.Empty;
            string testText2 = "This does not contain a bracket";

            //act
            var result1 = textValidationService.GetOpeningBracketPosition(testText1);
            var result2 = textValidationService.GetOpeningBracketPosition(testText2);

            //assert
            Assert.IsTrue(result1 == -1); //represents index of char not found
            Assert.IsTrue(result2 == -1);
        }
    }
}