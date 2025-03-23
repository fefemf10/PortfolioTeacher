using Blazorise;
using System.Text.RegularExpressions;

namespace PortfolioSite.Extensions
{
    public static class ValidationRuleExtension
    {
        public static void IsNotEmptyAndCharacter(ValidatorEventArgs e)
        {
            e.Status = (ValidationRule.IsNotEmpty(e.Value as string) && Regex.IsMatch(e.Value as string, @"^\p{L}+$"))
            ? ValidationStatus.Success : ValidationStatus.Error;
        }
        public static void IsEmptyAndCharacter(ValidatorEventArgs e)
        {
            e.Status = ValidationRule.IsEmpty(e.Value as string) || Regex.IsMatch(e.Value as string, @"^\p{L}+$")
            ? ValidationStatus.Success : ValidationStatus.Error;
        }
    }
}
