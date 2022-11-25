using OpenCdsi;
using System.Text.Json;


var OutputFolder = "../../../_data/cdsi";
var IndexBasename = "catalog";
var FileExtension = "json";
var JsonOptions = new JsonSerializerOptions
{
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
};

Console.WriteLine("Supporting data / testcase export");

string json = JsonSerializer.Serialize(new { Testcases = CaseLibrary.ResourceVersion, SupportingData = SupportingData.ResourceVersion }, JsonOptions);

var dir = Directory.CreateDirectory($"{OutputFolder}");
File.WriteAllText($"{OutputFolder}/versions.{FileExtension}", json);

string munge(string key)
{
    return key.ToLower().Replace(' ', '_');
}

void writeItem(object o, string folder, string key)
{
    string json = JsonSerializer.Serialize(o, JsonOptions);

    var dir = Directory.CreateDirectory($"{OutputFolder}/{folder}/");
    File.WriteAllText($"{dir.FullName}/{key}.{FileExtension}", json);
}

void writeCatalog(object o, string folder)
{
    var json = JsonSerializer.Serialize(o, JsonOptions);

    var dir = Directory.CreateDirectory($"{OutputFolder}/{folder}/");
    File.WriteAllText($"{dir.FullName}/{IndexBasename}.{FileExtension}", json);
}

writeCatalog(SupportingData.Schedule.Observations.Select(x => new { Idx = x.observationCode, Text = x.observationTitle, Group = string.IsNullOrWhiteSpace(x.indicationText) ? "Indicated" : "Contraindicated" }), "observations");
foreach (var o in SupportingData.Schedule.Observations)
{
    writeItem(o, "observations", o.observationCode);
}

writeCatalog(SupportingData.Antigens.Select(x => new { Idx = munge(x.Key), Text = x.Key }), "antigens");
foreach (var o in SupportingData.Antigens)
{
    writeItem(o.Value, "antigens", munge(o.Key));
}

writeCatalog(SupportingData.Schedule.Vaccines.Select(x => new { Idx = x.cvx, Text = x.shortDescription }), "vaccines");
foreach (var o in SupportingData.Schedule.Vaccines)
{
    writeItem(o, "vaccines", munge(o.cvx));
}


writeCatalog(CaseLibrary.Cases.Select(x => new { Idx = x.Key, Text = x.Value.TestcaseName, Group = x.Value.VaccineGroup }), "cases");
foreach (var o in CaseLibrary.Cases)
{
    writeItem(o.Value, "cases", munge(o.Key));
}