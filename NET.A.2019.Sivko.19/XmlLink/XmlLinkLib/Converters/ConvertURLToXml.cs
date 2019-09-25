using System.IO;
using System.Xml;
using System.Xml.Linq;
using XmlLinkLib.Interfaces;

namespace XmlLinkLib
{
    public class ConvertURLToXml : IConverter<URLService, XDocument>
    {
        public XDocument Convert(URLService item)
        {
            XDocument xdoc = new XDocument();
            XElement root = new XElement("urlAddresses");
            xdoc.Add(root);

            for (int i = 0; i < item.Count; i++)
            {
                XElement urlAddress = new XElement("urlAddress");

                XElement host = new XElement("host");
                host.Add(new XAttribute("name", item[i].Host));
                urlAddress.Add(host);

                if (item[i].UrlSegments != null)
                {
                    XElement uri = new XElement("uri");
                    for (int j = 0; j < item[i].UrlSegments.Length; j++)
                        uri.Add(new XElement("segment", item[i].UrlSegments[j]));
                    urlAddress.Add(uri);

                    if (item[i].Key != null && item[i].Value != null)
                    {
                        XElement parameters = new XElement("parameters",
                            new XElement("parameter",
                                new XAttribute("value", item[i].Value),
                                new XAttribute("key", item[i].Key)));
                        urlAddress.Add(parameters);
                    }
                }
                else if (item[i].Key != null && item[i].Value != null)
                {
                    XElement parameters = new XElement("parameters",
                        new XElement("parameter",
                            new XAttribute("value", item[i].Value),
                            new XAttribute("key", item[i].Key)));
                    urlAddress.Add(parameters);
                }

                xdoc.Root.Add(urlAddress);
            }
           
            return xdoc;
        }
    }
}
