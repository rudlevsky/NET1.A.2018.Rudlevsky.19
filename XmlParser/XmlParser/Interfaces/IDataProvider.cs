using System.Collections.Generic;

namespace XmlParser.Interfaces
{
    public interface IDataProvider<out TResult>
    {
        IEnumerable<TResult> GetData();
    }
}
