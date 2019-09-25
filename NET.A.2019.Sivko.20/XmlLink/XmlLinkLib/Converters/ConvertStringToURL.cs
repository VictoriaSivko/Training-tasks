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
            string key, value;

            source = source.Remove(0, source.IndexOf("//")+2);
            source = source.Remove(0, source.IndexOf("//")+2);
            string host = source.Substring(0, source.IndexOf("/"));
            source = source.Replace($"{host}/", "");

            if(Regex.IsMatch(source, @"\w+"))
            {
                List<string> segments = new List<string>();

                while (Regex.IsMatch(source, @"\w+"))
                {
                    segments.Add(source.Substring(0, source.IndexOf("/")>0 ? source.IndexOf("/") : source.IndexOf("?") > 0? source.IndexOf("?") : source.Length));
                    source = Regex.Replace(source, @"^\w*[/]?", "");
                }

                if (source.Contains("?") && source.Contains("="))
                {
                    key = source.Substring(1, source.LastIndexOf("=")-1);
                    source = source.Replace($"?{key}=", "");
                    value = source;
                    return new URL(host, segments.ToArray(), key, value);
                }
                else
                {
                    return new URL(host, segments.ToArray());
                }
            }
            else
            {
                return new URL(host);
            }
        }

        public URL Convert(string source, IValidation<string> validation)
        {
            throw new NotImplementedException();
        }
    }
}
