using Ninject.Modules;
using System;
using XmlParser;
using XmlParser.Injections;
using XmlParser.Interfaces;

namespace ConsoleApp
{
    public class Configuration : NinjectModule
    {
        const string LOG_PATH = @"D:\Tasks\NET1.A.2018.Rudlevsky.19\XmlParser\XmlParser\bin\Debug\log.txt";

        public override void Load()
        {
            Bind<IDataProvider<string>>().To<DataProvider>().WithConstructorArgument("data.txt");
            Bind<ILogger>().To<NLogger>().WithConstructorArgument(LOG_PATH);
            Bind<IParser<string, Uri>>().To<Parser>();
            Bind<IStorage<Uri>>().To<Storage>().WithConstructorArgument("XFile.xml");
            Bind<IValidator<string>>().To<Validator>();
            Bind<IDataService>().To<DataService>();
        }
    }
}
