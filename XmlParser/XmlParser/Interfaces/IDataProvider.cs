using System.Collections.Generic;

namespace XmlParser.Interfaces
{
    /// <summary>
    /// Interface provides method for DataProvider.
    /// </summary>
    /// <typeparam name="TResult">Type of the result.</typeparam>
    public interface IDataProvider<out TResult>
    {
        /// <summary>
        /// Gets data from the source.
        /// </summary>
        /// <returns>Taken collection of data.</returns>
        IEnumerable<TResult> GetData();
    }
}
