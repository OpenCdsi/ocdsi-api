using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Exporter
{
    public class JsonWriter
    {
        internal static readonly JsonSerializerOptions JsonOptions = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };
        public string Root { get; init; }

        public void Write(object o, string path)
        {
            var fname = Path.Combine(Root, path);
            var json = JsonSerializer.Serialize(o, JsonOptions);
            var dir = Path.GetDirectoryName(fname);
            Directory.CreateDirectory(dir);
            File.WriteAllText(fname, json);
        }
    }
}
