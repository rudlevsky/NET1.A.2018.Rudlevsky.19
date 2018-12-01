using Ninject;
using XmlParser.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new Configuration());
           
            var dataService = kernel.Get<IDataService>();

            dataService.MoveToFile();
        }
    }
}