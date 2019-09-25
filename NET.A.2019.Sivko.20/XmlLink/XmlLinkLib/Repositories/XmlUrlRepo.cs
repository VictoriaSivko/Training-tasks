using System.Xml.Linq;
using XmlLinkLib.Interfaces;

namespace XmlLinkLib.Repositories
{
    public class XmlUrlRepo : IRepository<XDocument>
    {
        /// <summary>
        /// Gets or sets name (path) of the file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the CSVRepository class.
        /// </summary>
        /// <param name="name">Name (path) of the file.</param>
        public XmlUrlRepo(string name)
        {
            Name = name;
        }

        public XDocument Read()
        {
            throw new System.NotImplementedException();
        }


        public void Write(XDocument xDocument)
        {
            xDocument.Save($"{Name}.xml");
        }
    }
}
