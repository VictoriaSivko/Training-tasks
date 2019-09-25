using System.IO;
using XmlLinkLib.Interfaces;
using System;
using XmlLinkLib.Converters;
using XmlLinkLib.Validation;

namespace XmlLinkLib.Repositories
{
    public class TxtUrlRepo : IRepository<URLService>
    {
        /// <summary>
        /// Gets or sets name (path) of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the CSVRepository class.
        /// </summary>
        /// <param name="name">Name (path) of the file.</param>
        public TxtUrlRepo(string name)
        {
            Name = name;
        }

        public URLService Read()
        {
            URLService url = new URLService();

            using (FileStream fs = new FileStream($"{ Name }.txt", FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (StreamReader streamReader = new StreamReader(fs, System.Text.Encoding.Default))
                {
                    string str;
                    UrlValidation urlValidation = new UrlValidation();
                    ConvertStringToURL convertStringToURL = new ConvertStringToURL();

                    while ((str = streamReader.ReadLine()) != null)
                    {
                        if(urlValidation.Valid(str))
                            url.Add(convertStringToURL.Convert(str));
                    }

                    return url;
                }
            }

            return url;
        }

        public void Write(URLService item)
        {
            throw new System.NotImplementedException();
        }
    }
}
