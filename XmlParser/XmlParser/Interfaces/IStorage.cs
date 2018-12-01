using System.Collections.Generic;

namespace XmlParser.Interfaces
{
    /// <summary>
    /// Interface provides method for Storage.
    /// </summary>
    /// <typeparam name="TSource">Type of data for saving.</typeparam>
    public interface IStorage<in TSource>
    {
        /// <summary>
        /// Saves data into a storage.
        /// </summary>
        /// <param name="source">Data for saving.</param>
        void Save(IEnumerable<TSource> source);
    }
}
