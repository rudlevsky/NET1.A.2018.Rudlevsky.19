using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlParser.Interfaces
{
    public interface IDataProvider<out TResult>
    {
        IEnumerable<TResult> GetData();
    }
}
