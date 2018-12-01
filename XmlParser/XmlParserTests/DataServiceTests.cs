using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using XmlParser;
using XmlParser.Injections;
using XmlParser.Interfaces;

namespace XmlParserTests
{
    [TestFixture]
    public class DataServiceTests
    {
        IDataProvider<string> provider = new DataProvider("data.txt");
        ILogger logger = new NLogger(@"D:\Tasks\NET1.A.2018.Rudlevsky.19\XmlParser\XmlParserTests\bin\Debug\logfile.txt");
        IParser<string, Uri> parser = new Parser(new Validator());
        IStorage<Uri> storage = new Storage(@"D:\Tasks\NET1.A.2018.Rudlevsky.19\XmlParser\XmlParserTests\bin\Debug\XFile.xml");
        IDataService dataService;

        string httpsPath = $"https://github.com/AnzhelikaKravchuk?tab=repositories";

        [Test]
        public void DataProviderTest_VerifyGetData()
        {
            IEnumerable<string> collection = new List<string> { httpsPath };

            var mock = new Mock<IDataProvider<string>>();

            mock.Setup(d => d.GetData()).Returns(collection);
        
            dataService = new DataService(mock.Object, parser, storage, logger);

            mock.Verify();
        }

        [Test]
        public void LoggerTest_VerifyWarn()
        {
            var mock = new Mock<ILogger>();

            mock.Setup(d => d.Warn(It.IsAny<string>()));

            dataService = new DataService(provider, parser, storage, mock.Object);

            mock.Verify();
        }

        [Test]
        public void StorageTest_VerifySave()
        {
            var mock = new Mock<IStorage<Uri>>();

            mock.Setup(d => d.Save(It.IsAny<IEnumerable<Uri>>()));

            dataService = new DataService(provider, parser, mock.Object, logger);

            mock.Verify();
        }

        [Test]
        public void ParserTest_VerifySave()
        {
            var mock = new Mock<IParser<string,Uri>>();

            mock.Setup(d => d.Parse(It.IsAny<string>())).Returns(new Uri(httpsPath));

            dataService = new DataService(provider, mock.Object, storage, logger);

            mock.Verify();
        }

        [Test]
        public void ValidatorTest_VerifySave()
        {
            var mock = new Mock<IValidator<string>>();

            mock.Setup(d => d.IsValid(It.IsAny<string>())).Returns(true);

            dataService = new DataService(provider, new Parser(mock.Object), storage, logger);

            mock.Verify();
        }
    }
}
