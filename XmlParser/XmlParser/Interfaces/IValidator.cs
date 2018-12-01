using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.Interfaces
{
    public interface IValidator<in TSource>
    {

        bool IsValid(TSource source);
    }
}
