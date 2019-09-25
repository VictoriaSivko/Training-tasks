using System;
using XmlLinkLib;
using XmlLinkLib.Repositories;
using XmlLinkLib.Validation;

namespace ConsoleXmlLink
{
    class Program
    {
        static void Main(string[] args)
        {
            URLService urlService = new TxtUrlRepo("Links").Read();
            new XmlUrlRepo("New").Write(new ConvertURLToXml().Convert(urlService));
        }
    }
}
