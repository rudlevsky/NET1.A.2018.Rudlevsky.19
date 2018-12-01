using System;
using System.Collections.Generic;
using XmlParser.Interfaces;

namespace XmlParser
{
    public class DataService : IDataService
    {

        IDataProvider<string> provider;
        ILogger logger;
        IParser<string, Uri> parser;
        IStorage<Uri> storage;

        public DataService(IDataProvider<string> provider, IParser<string, Uri> parser, IStorage<Uri> storage, ILogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException($"{nameof(logger)} can't be equal to null.");
            this.parser = parser ?? throw new ArgumentNullException($"{nameof(parser)} can't be equal to null.");
            this.provider = provider ?? throw new ArgumentNullException($"{nameof(provider)} can't be equal to null.");
            this.storage = storage ?? throw new ArgumentNullException($"{nameof(storage)} can't be equal to null.");
        }

        public void MoveToFile()
        {

            var data = provider.GetData();
            var correctData = new List<Uri>();

            foreach (var item in data)
            {
                try
                {
                    correctData.Add(parser.Parse(item));
                }
                catch(FormatException ex)
                {
                    logger.Warn(ex.Message);
                }
            }

            storage.Save(correctData);
        }
    }
}
