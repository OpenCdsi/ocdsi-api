using Exporter;
using OpenCdsi;
using OpenCdsi.Schedule;

var writer = new JsonWriter { Root = "../../../output" };

writer.Write(VersionInfo.Instance, "metadata.json");
writer.Write(new[] { "Antigens", "Vaccines", "Observations", "Cases" }.GetCatalog(), "index.json");

writer.Write(SupportingData.Antigens.Values.GetCatalog(), "antigens/index.json");
SupportingData.Antigens.Values.ForEach(x =>
{
    var key = x.series[0].targetDisease.Munge();
    writer.Write(x, $"antigens/{key}/index.json");
    writer.Write(x.series.GetCatalog(), $"antigens/{key}/series/index.json");
    x.series.ForEach(y => writer.Write(y, $"antigens/{key}/series/{y.seriesName.Munge()}/index.json"));
});

writer.Write(SupportingData.Schedule.Vaccines.GetCatalog(), "vaccines/index.json");
SupportingData.Schedule.Vaccines.ForEach(x => writer.Write(x, $"vaccines/{x.cvx}/index.json"));

writer.Write(SupportingData.Schedule.VaccineGroups.GetCatalog(), "groups/index.json");
SupportingData.Schedule.VaccineGroups.ForEach(x => writer.Write(new { VaccineGroup = x, Antigens = x.Antigens() }, $"groups/{x.name.Munge()}/index.json"));

writer.Write(SupportingData.Schedule.Observations.GetCatalog(), "observations/index.json");
SupportingData.Schedule.Observations.ForEach(x => writer.Write(x, $"observations/{x.observationCode}/index.json"));

writer.Write(CaseLibrary.Cases.Values.GetCatalog(), "cases/index.json");
CaseLibrary.Cases.Values.ForEach(x =>
{
    var key = x.CdcTestId;
    writer.Write(x, $"cases/{key}/index.json");
    writer.Write(new { x.AssessmentDate, x.Patient, x.Doses }, $"cases/{key}/medical/index.json");
});