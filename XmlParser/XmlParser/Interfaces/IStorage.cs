using System.Collections.Generic;

namespace XmlParser.Interfaces
{
    public interface IStorage<in TSource>
    {
        void Save(IEnumerable<TSource> source);
    }
}
