using System;
using System.Collections.Generic;
using System.IO;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    public class DataProvider : IDataProvider<string>
    {

        string filePath;

        public DataProvider(string filePath)
        {
            this.filePath = filePath ?? throw new ArgumentNullException($"{nameof(filePath)} was equal to null.");
        }

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
