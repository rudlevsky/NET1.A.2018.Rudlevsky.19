﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    public class Validator : IValidator<string>
    {
        const string REGEX_RULE = @"(http|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?";

        public bool IsValid(string source)
        => Regex.IsMatch(source, REGEX_RULE, RegexOptions.IgnoreCase);
    }
}