using System;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    public class Parser : IParser<string, Uri>
    {

        IValidator<string> validator;

        public Parser(IValidator<string> validator)
        {
            this.validator = validator ?? throw new ArgumentNullException($"{nameof(validator)} can't be equal to null.");
        }

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
