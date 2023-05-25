using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exporter
{
    public static class Kebab
    {
        public static string ToPascalCase(this string s)
        {
            return string.Join("", ToWords(s).Select(Capitalize));
        }
        public static string ToCamelCase(this string s)
        {
            s = ToPascalCase(s);
            return s.Substring(0, 1).ToLower() + s.Substring(1);
        }
        public static string ToKebabCase(this string s)
        {
            return string.Join("-", ToWords(s));
        }
        public static string ToSnakeCase(this string s)
        {
            return string.Join("_", ToWords(s));
        }

        static string Capitalize(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }

        static IEnumerable<string> ToWords(string s)
        {
            if (Regex.Match(s, @"\s").Success)
            {
                return s.Replace("-", " ").ToLower().Split(' ');
            }
            else
            {
                var words = Regex.Split(s, @"(?<!^)(?=[A-Z-_])").AsEnumerable();

                words = words.Select(x => Regex.Replace(x, @"[-_]", ""))
                     .Select(x => x.ToLower())
                     .Where(x => x != "");

                return words.All(x => x.Length == 1)
                    ? new List<string> { string.Join("", words) }
                    : words;
            }
        }
    }
}
