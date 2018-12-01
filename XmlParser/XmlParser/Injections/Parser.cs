using System;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    /// <summary>
    /// Class parses data.
    /// </summary>
    public class Parser : IParser<string, Uri>
    {
        IValidator<string> validator;

        /// <summary>
        /// Constructor which takes 1 argument.
        /// </summary>
        /// <param name="validator">Validator for data.</param>
        public Parser(IValidator<string> validator)
        {
            this.validator = validator ?? throw new ArgumentNullException($"{nameof(validator)} can't be equal to null.");
        }

        /// <summary>
        /// Method parses data.
        /// </summary>
        /// <param name="source">Data for parsing.</param>
        /// <returns> Parsed data.</returns>
        public Uri Parse(string source)
        {           
            if(!validator.IsValid(source))
            {
                throw new FormatException($"{nameof(source)} is not correct.");
            }

            return new Uri(source);
        }
    }
}
