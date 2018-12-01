using System;
using System.Collections.Generic;
using System.IO;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    /// <summary>
    /// Class provides data.
    /// </summary>
    public class DataProvider : IDataProvider<string>
    {
        string filePath;

        /// <summary>
        /// Constructor whick takes 1 argument.
        /// </summary>
        /// <param name="filePath">Path of the file with the data.</param>
        public DataProvider(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException($"{nameof(filePath)} was equal to null.");
        }

        /// <summary>
        /// Gets data from the source.
        /// </summary>
        /// <returns>Taken collection of data.</returns>
        public IEnumerable<string> GetData()
        {
            var list = new List<string>();

            using(var fileStream = new StreamReader(filePath))
            {
                string text = string.Empty;

                while((text = fileStream.ReadLine()) != null)
                {
                    list.Add(text);
                }
            }

            return list;
        }
    }
}
