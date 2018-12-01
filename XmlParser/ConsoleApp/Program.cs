using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlParser;
using XmlParser.Injections;
using XmlParser.Interfaces;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using(var stream = new FileStream("data.txt", FileMode.Open))
            {
                string logPath = @"C:\Users\rudle\Desktop\XmlParser\ConsoleApp\bin\Debug\log.txt";
                IDataService dataService = new DataService(new DataProvider(stream), new Parser(new Validator()), new Storage("XFile.xml"), new NLogger(logPath));

                dataService.MoveToFile();
            }

            Console.ReadLine();
        }
    }
}
