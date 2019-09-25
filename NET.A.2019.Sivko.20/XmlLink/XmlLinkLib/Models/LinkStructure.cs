using System.Collections.Generic;

namespace XmlLinkLib
{
    public class URLService
    {
        public List<URL> UrlList { get; private set; }
        public int Count { get { return UrlList.Count; } } 
        public URLService(params URL[] url)
        {
            UrlList = new List<URL>();
            foreach (URL item in url)
                if (item != null)
                    UrlList.Add(item);
        }

        public void Add(URL item)
        {
            if (item != null)
                UrlList.Add(item);
        }

        public URL this[int index]
        {
            get { return UrlList[index]; }
            set
            {
                if (value != null)
                    UrlList.Add(value);
            }

        }
    }

    public class URL
    {
        public string Host { get; }
        public string[] UrlSegments { get; }
        public string Key { get; }
        public string Value { get; }

        public URL() { }
        public URL(string host, string[] urlSegments, string key = null, string value = null)
        {
            Host = host;
            UrlSegments = urlSegments;
            Key = key;
            Value = value;
        }

        public URL(string host)
        {
            Host = host;
        }

        public override string ToString()
        {
            string url = null;

            for (int i = 0; i < UrlSegments.Length; i++)
                url += UrlSegments[i] + "/";
            url = url.Remove(url.LastIndexOf("/"));
            return $"{Host}/{(url == null ? "" : url)}{(Key == null || Value == null ? "" : $"?{Key}={Value}")}";
        }
    }
}
