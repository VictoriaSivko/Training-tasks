using XmlLinkLib.Interfaces;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace XmlLinkLib.Converters
{
    public class ConvertStringToURL : IConverter<string, URL>
    {
        public URL Convert(string source)
        {
            string[] components = Regex.Split(source, @"[/=?]");
            List<string> segments = new List<string>();
            URL url = new URL();

            int i = components.Length-1;
            while (i > 2)
            {
                if (source.Contains("?") && source.Contains("=") && i == components.Length - 1)
                {
                    url.Value = components[i--];
                    url.Key = components[i--];
                }

                if (!string.IsNullOrWhiteSpace(components[i]))
                    segments.Add(components[i]);

                i--;
            }

            segments.Reverse();
            url.UrlSegments = segments.ToArray();
            url.Host = components[2];

            return url;
        }

        public URL Convert(string source, IValidation<string> validation)
        {
            throw new NotImplementedException();
        }
    }
}
