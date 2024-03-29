﻿using System;
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
        public static string ToPascalCase(this string text)
        {
            return text.AsWords().AsPascalCase();
        }
        public static string ToCamelCase(this string text)
        {
            return text.AsWords().AsCamelCase();
        }
        public static string ToSnakeCase(this string text)
        {
            return text.AsWords().AsSnakeCase();
        }
        public static string ToKebabCase(this string text)
        {
            return text.AsWords().AsKebabCase();
        }


        internal static string AsPascalCase(this IEnumerable<string> wordList)
        {
            return string.Join("", wordList.Select(Capitalize));
        }
        internal static string AsCamelCase(this IEnumerable<string> wordList)
        {
            return string.Join("", wordList.Take(1).Concat(wordList.Skip(1).Select(Capitalize)));
        }
        internal static string AsKebabCase(this IEnumerable<string> wordList)
        {
            return string.Join("-", wordList);
        }
        internal static string AsSnakeCase(this IEnumerable<string> wordList)
        {
            return string.Join("_", wordList);
        }
        internal static string Capitalize(string s)
        {
            return s.Substring(0, 1).ToUpper() + s.Substring(1);
        }
        internal static IEnumerable<string> AsWords(this string text)
        {
            if (Regex.Match(text, "/|-|_| ").Success)
            {
                return Regex.Replace(text, "/|-|_", " ").Split(" ").Where(word => word != "").Select(word => word.ToLower());
            }

            if (Regex.Match(text, "[a-z][A-Z]").Success)
            {
                return Regex.Split(text, @"(?<!^)(?=[A-Z])").Select(word => word.ToLower());
            }

            return new List<string> { text.ToLower() };
        }
    }
}
