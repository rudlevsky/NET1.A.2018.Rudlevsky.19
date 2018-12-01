using System.Text.RegularExpressions;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    /// <summary>
    /// Class validates data.
    /// </summary>
    public class Validator : IValidator<string>
    {
        const string REGEX_RULE = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        /// <summary>
        /// Method validates data.
        /// </summary>
        /// <param name="source">Data for validation.</param>
        /// <returns>Result of the validation.</returns>
        public bool IsValid(string source)
        => Regex.IsMatch(source, REGEX_RULE, RegexOptions.IgnoreCase);
    }
}
