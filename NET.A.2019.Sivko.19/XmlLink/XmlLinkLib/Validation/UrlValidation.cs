using System.Text.RegularExpressions;
using XmlLinkLib.Interfaces;

namespace XmlLinkLib.Validation
{
    public class UrlValidation : IValidation<string>
    {
        public bool Valid(string item)
        {
            if (Regex.IsMatch(item, @"\w*//(\w+/?)+([?]\w+[=]\w+)?"))
                return true;

            return false;
        }
    }
}
