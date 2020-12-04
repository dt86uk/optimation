namespace OptimationTechnicalTest.BusinessLogic
{
    public interface ITextValidationService
    {
        bool IsCharacterOpeningAngleBracket(char inChar);
        bool IsCharacterClosingAngleBracket(char inChar);
        int GetOpeningBracketPosition(string inText);
        int GetClosingBracketPosition(string inText);
    }
}