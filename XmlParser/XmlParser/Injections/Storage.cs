using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XmlParser.Interfaces;

namespace XmlParser.Injections
{
    /// <summary>
    /// Class is a data storage.
    /// </summary>
    public class Storage : IStorage<Uri>
    {
        readonly string filePath = string.Empty;

        /// <summary>
        /// Constructor with 1 argument.
        /// </summary>
        /// <param name="path">Path of the storage.</param>
        public Storage(string path)
        {
            if(path == null)
            {
                throw new ArgumentNullException($"{nameof(path)} can't be equal to null.");
            }

            if(string.IsNullOrEmpty(path))
            {
                throw new ArgumentException($"{nameof(path)} can't be empty.");
            }

            if(!File.Exists(path))
            {
                throw new FileNotFoundException("File doesn't exist.");
            }

            filePath = path;
        }

        /// <summary>
        /// Saves data into a storage.
        /// </summary>
        /// <param name="source">Data for saving.</param>
        public void Save(IEnumerable<Uri> source)
        {
            if(source == null)
            {
                throw new ArgumentNullException($"{nameof(source)} can't be equal to null.");
            }

            SaveData(source);
        }

        void SaveData(IEnumerable<Uri> source)
        {
            XDocument document = new XDocument(new XDeclaration("1.0", "UTF-8", "yes"));

            XElement mainElement = new XElement("UrlAdresses");

            foreach (var uri in source)
            {
                XElement element = new XElement("urlAdress");

                AddHost(element, uri);
                AddUri(element, uri);
                AddParams(element, uri);

                mainElement.Add(element);
            }

            document.Add(mainElement);
            document.Save(filePath);
        }

        void AddHost(XElement element, Uri uri)
        {
            XElement host = new XElement("host", new XAttribute("name", uri.Host));
            element.Add(host);
        }

        void AddUri(XElement element, Uri uri)
        {
            XElement uriElement = new XElement("uri");

            foreach (var item in uri.Segments.Where(x => x != "/"))
            {
                uriElement.Add(new XElement("segment", item));
            }

            element.Add(uriElement);
        }

        void AddParams(XElement element, Uri uri)
        {
            var queryKeys = System.Web.HttpUtility.ParseQueryString(uri.Query);

            if (queryKeys.HasKeys())
            {
                XElement parameters = new XElement("parameters");

                for (int i = 0; i < queryKeys.Count; i++)
                {
                    XElement parametr = new XElement("parametr", new XAttribute("value", queryKeys[i]));

                    parametr.Add(new XAttribute("key", queryKeys.AllKeys[i]));

                    parameters.Add(parametr);
                }

                element.Add(parameters);
            }             
        }
    }
}
