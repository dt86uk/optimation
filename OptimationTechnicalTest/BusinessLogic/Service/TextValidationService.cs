using System.Text.RegularExpressions;

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
            return inText.IndexOf('<');
        }

        public bool IsElementContentsEmailAddress(string elementContents)
        {
            return Regex.IsMatch(elementContents, 
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", 
                RegexOptions.IgnoreCase);
        }
    }
}