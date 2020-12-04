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
            string testText = "Hi somebody, here is my expenses claim <expense><total>1024.01</total></expense>. Thanks!";
            int firstOpeningBracket = testText.IndexOf('<');

            //act
            var result = textValidationService.GetOpeningBracketPosition(testText);

            //assert
            Assert.IsTrue(result > -1); //represents index of char not found
            Assert.IsTrue(result == firstOpeningBracket);
        }

        [TestMethod]
        public void GetOpeningBracketPositionTest_IsFalse()
        {
            //arrange
            string testText1 = string.Empty;
            
            //act
            var result = textValidationService.GetOpeningBracketPosition(testText1);

            //assert
            Assert.IsTrue(result == -1); //represents index of char not found
        }

        [TestMethod]
        public void GetClosingBracketPositionTest_IsTrue()
        {
            //arrange
            string testText = "Hi somebody, here is my expenses claim <expense><total>1024.01</total></expense>. Thanks!";
            int firstClosingBracket = testText.IndexOf('>');

            //act
            var result = textValidationService.GetClosingBracketPosition(testText);

            //assert
            Assert.IsTrue(result > -1); //represents index of char not found
            Assert.IsTrue(result != -1);
            Assert.IsTrue(result == firstClosingBracket);
        }

        [TestMethod]
        public void GetClosingBracketPositionTest_IsFalse()
        {
            //arrange
            string testText = "Hi somebody, here is my expenses claim. Total = 1024.01. Thanks!";

            //act
            var result = textValidationService.GetClosingBracketPosition(testText);

            //assert
            Assert.IsTrue(result == -1); //represents index of char not found
        }
    }
}