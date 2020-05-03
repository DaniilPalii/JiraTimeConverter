using System.Text.RegularExpressions;

namespace JiraTimeConverter
{
    public static class RegexExtensions
    {
        public static bool TryMatchInt(this Regex regex, string text, out int? matchedValue)
        {
            if (regex.TryMatch(text, out var matchedTextValue))
            {
                matchedValue = int.Parse(matchedTextValue);

                return true;
            }
            else
            {
                matchedValue = null;

                return false;
            }
        }

        public static bool TryMatch(this Regex regex, string text, out string matchedValue)
        {
            var match = regex.Match(text);

            if (match.Success)
            {
                matchedValue = match.Value;

                return true;
            }
            else
            {
                matchedValue = null;

                return false;
            }
        }
    }
}
