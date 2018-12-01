
namespace XmlParser.Interfaces
{
    /// <summary>
    /// Interface provides method for Validator.
    /// </summary>
    /// <typeparam name="TSource">Type of data for validation.</typeparam>
    public interface IValidator<in TSource>
    {
        /// <summary>
        /// Method validates data.
        /// </summary>
        /// <param name="source">Data for validation.</param>
        /// <returns>Result of the validation.</returns>
        bool IsValid(TSource source);
    }
}
