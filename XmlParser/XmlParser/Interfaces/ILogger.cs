
namespace XmlParser.Interfaces
{
    /// <summary>
    /// Interface provides method for Logger.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes warn into file.
        /// </summary>
        /// <param name="message">Message which will be written.</param>
        void Warn(string message);
    }
}
