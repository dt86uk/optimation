namespace OptimationTechnicalTest.BusinessLogic
{
    public class TextValidationService : ITextValidationService
    {
        public bool IsCharacterOpeningAngleBracket(char inChar)
        {
            return inChar == '<';
        }

        public bool IsCharacterClosingAngleBracket(char inChar)
        {
            return inChar == '>';
        }

        public int GetOpeningBracketPosition(string inText)
        {
            return inText.IndexOf('<');
        }

        public int GetClosingBracketPosition(string inText)
        {
            return inText.IndexOf('>');
        }
    }
}