using OpenCdsi;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;


var OutputFolder = "../../../output";
var IndexFileName = "index.md";
var JsonOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

Console.WriteLine("site exporter");

var dir = Directory.CreateDirectory($"{OutputFolder}");
File.WriteAllText($"{OutputFolder}/{IndexFileName}", $"---\ntitle: Supporting Data\ncaseVer: 4.28\ndataVer: 4.38\n---");

string munge(string key)
{
    return key.ToLower().Replace(' ', '_');
}

void writeItem(object o, string layout, string key, string title)
{
    string json = JsonSerializer.Serialize(o, JsonOptions);

    var dir = Directory.CreateDirectory($"{OutputFolder}/{layout}s/{key}");
    File.WriteAllText($"{dir.FullName}/{IndexFileName}", $"---\ntitle: \"{title}\"\ndata: {json}\nlayout: {layout}\n---");
}

void writeCatalog(object o, string layout)
{
    var data = new { Layout= layout, Items=o };
    var json = JsonSerializer.Serialize(data, JsonOptions);

    var dir = Directory.CreateDirectory($"{OutputFolder}/{layout}s");
    File.WriteAllText($"{dir.FullName}/{IndexFileName}", $"---\ntitle: Catalog\ndata: {json}\nlayout: catalog\n---");
}

writeCatalog(SupportingData.Schedule.Observations.Select(x => new  { Idx = x.observationCode, Text = x.observationTitle, Group = string.IsNullOrWhiteSpace(x.indicationText) ? "Indicated" : "Contraindicated" }), "observation");
foreach (var o in SupportingData.Schedule.Observations)
{
    writeItem(o, "observation", o.observationCode, $"{o.observationCode} - {o.observationTitle}");
}

writeCatalog(SupportingData.Antigens.Select(x => new  { Idx = munge(x.Key), Text = x.Key }), "antigen");
foreach (var o in SupportingData.Antigens)
{
    writeItem(o.Value, "antigen", munge(o.Key), o.Key);
}

writeCatalog(SupportingData.Schedule.Vaccines.Select(x => new  { Idx = x.cvx, Text = x.shortDescription }), "vaccine");
foreach (var o in SupportingData.Schedule.Vaccines)
{
    writeItem(o, "vaccine", munge(o.cvx), $"{o.cvx} - {o.shortDescription}");
}


writeCatalog(CaseLibrary.Cases.Select(x => new  { Idx = x.Key, Text = x.Value.TestcaseName, Group = x.Value.VaccineGroup }), "case");
foreach (var o in CaseLibrary.Cases)
{
    writeItem(o.Value, "case", munge(o.Key), $"{o.Key} - {o.Value.TestcaseName}");
}
