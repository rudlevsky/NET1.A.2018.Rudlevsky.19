using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    public class DataProvider : IDataProvider<string>
    {

        Stream stream;

        public DataProvider(Stream stream)
        {
            this.stream = stream ?? throw new ArgumentNullException($"{nameof(stream)} was equal to null.");
        }

        public IEnumerable<string> GetData()
        {
            var list = new List<string>();

            using(var fileStream = new StreamReader(stream, Encoding.UTF8))
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
