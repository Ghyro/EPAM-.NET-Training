using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Task.BLL.Interfaces;

namespace Task.BLL.BussinessModel
{
    public class XmlCreator : IXmlCreator
    {
        private ICustomLogger logger;
        private IXmlService service;

        public XmlCreator() : this(new CustomLogger(), new XmlService())
        {
        }

        public XmlCreator(ICustomLogger logger, IXmlService service)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            if (service is null)
            {
                throw new ArgumentNullException(nameof(service));
            }

            this.logger = logger;
            this.service = service;
        }

        /// <summary>
        /// Create XML document
        /// </summary>
        /// <param name="sourceFile">Input source text file</param>
        /// <returns>XML document</returns>
        public XDocument CreateXml(IEnumerable<string> sourceFile)
        {
            if (sourceFile is null)
            {
                throw new ArgumentNullException(nameof(sourceFile));
            }

            var document = new XDocument(new XDeclaration("1.0", "utf-8", null));
            var rootElement = new XElement("urlAddresses");

            foreach (var item in sourceFile)
            {
                if (service.ValidDocument(item))
                {
                    var urlAddressNode = new XElement("urlAddress");

                    GetHost(item, urlAddressNode);

                    GetSegment(item, urlAddressNode);

                    GetParam(item, urlAddressNode);

                    rootElement.Add(urlAddressNode);
                }
                else
                {
                    logger.Warn($"{item} is not valid!");
                }
            }

            document.Add(rootElement);
            return document;
        }

        /// <summary>
        /// Host creator
        /// </summary>
        /// <param name="url">Input url</param>
        /// <param name="parent">Parent node</param>
        private void GetHost(string url, XElement parent)
        {
            var host = service.GetHost(url);

            XElement xHost = new XElement("host", new XAttribute("name", host));

            parent.Add(xHost);
        }

        /// <summary>
        /// URI creator (segments)
        /// </summary>
        /// <param name="url">Input url</param>
        /// <param name="parent">Parent node</param>
        private void GetSegment(string url, XElement parent)
        {
            IEnumerable<string> setUri = this.service.GetUri(url);

            if (setUri.Count() > 0)
            {
                XElement uriNode = new XElement("uri");

                uriNode.Add(setUri.Select(s => new XElement("segment", s)));

                parent.Add(uriNode);
            }
        }

        /// <summary>
        /// Parameters creator
        /// </summary>
        /// <param name="url">Input url</param>
        /// <param name="parent">Parent node</param>
        private void GetParam(string url, XElement parent)
        {
            Dictionary<string, string> parameters = this.service.GetParam(url);

            if (parameters.Count > 0)
            {
                XElement parametersNode = new XElement("parameters");

                parametersNode.Add(parameters.Select(s => new XElement("parameter", new XAttribute("value", s.Value), new XAttribute("key", s.Key))));

                parent.Add(parameters);
            }
        }
    }
}
