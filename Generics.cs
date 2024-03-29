﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCdsi;
using OpenCdsi.Cases;
using OpenCdsi.Schedule;

namespace Exporter
{
    public static class Generics
    {
        public static string AsUrl(this IEnumerable<string> list)
        {
            return list.Any()
                ? $"/{string.Join('/', list.ToArray())}/index.json"
               : "/index.json";
        }


        public static void ForEach<T>(this IEnumerable<T> data, Action<T> func)
        {
            foreach (var item in data) { func(item); }
        }
    }
}
