
namespace XmlParser.Interfaces
{
    /// <summary>
    /// Interface provides method for Parser.
    /// </summary>
    /// <typeparam name="TSource">Type of the data for parsing.</typeparam>
    /// <typeparam name="TResult">Type of the result of parsing.</typeparam>
    public interface IParser<in TSource, out TResult>
    {
        /// <summary>
        /// Method parses data.
        /// </summary>
        /// <param name="source">Data for parsing.</param>
        /// <returns> Parsed data.</returns>
        TResult Parse(TSource source);
    }
}
