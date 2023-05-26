using Exporter;
using OpenCdsi;
using OpenCdsi.Schedule;

var writer = new JsonWriter { Root = "../../../docs/v1" };
var dataWriter = new JsonWriter { Root = "../../../docs/_data" };

writer.Write(VersionInfo.Instance, "metadata.json");
writer.Write(new[] { "Antigens", "Vaccines", "Observations", "Cases" }.GetCatalog(), "index.json");

writer.Write(SupportingData.Antigens.Values.GetCatalog(), "antigens/index.json");
dataWriter.Write(SupportingData.Antigens.Values.GetCatalog(), "antigens.json");

SupportingData.Antigens.Values.ForEach(x =>
{
    var key = x.series[0].targetDisease.ToKebabCase();
    x.series.ForEach(y =>
    {
        y.targetDisease = y.targetDisease.ToKebabCase();
        y.vaccineGroup = y.vaccineGroup.ToKebabCase();
        writer.Write(y, $"antigens/{key}/series/{y.seriesName.ToKebabCase()}/index.json");
    });
    writer.Write(x, $"antigens/{key}/index.json");
    writer.Write(x.series.GetCatalog(), $"antigens/{key}/series/index.json");
});

writer.Write(SupportingData.Schedule.Vaccines.GetCatalog(), "vaccines/index.json");
dataWriter.Write(SupportingData.Schedule.Vaccines.GetCatalog(), "vaccines.json");
SupportingData.Schedule.Vaccines.ForEach(x =>
{
    x.association.ForEach(y => y.antigen = y.antigen.ToKebabCase());
    writer.Write(x, $"vaccines/{x.cvx}/index.json");
});

writer.Write(SupportingData.Schedule.VaccineGroups.GetCatalog(), "groups/index.json");
dataWriter.Write(SupportingData.Schedule.VaccineGroups.GetCatalog(), "groups.json");
SupportingData.Schedule.VaccineGroups.ForEach(x =>
{
    var antigens = x.Antigens().Select(y => y.ToKebabCase()).ToList();
    x.name = x.name.ToKebabCase();
    writer.Write(new { VaccineGroup = x, Antigens = antigens }, $"groups/{x.name}/index.json");
    writer.Write(antigens, $"groups/{x.name}/antigens/index.json");
});

writer.Write(SupportingData.Schedule.Observations.GetCatalog(), "observations/index.json");
dataWriter.Write(SupportingData.Schedule.Observations.GetCatalog(), "observations.json");
SupportingData.Schedule.Observations.ForEach(x => writer.Write(x, $"observations/{x.observationCode}/index.json"));

writer.Write(CaseLibrary.Cases.Values.GetCatalog(), "cases/index.json");
dataWriter.Write(CaseLibrary.Cases.Values.GetCatalog(), "cases.json");
CaseLibrary.Cases.Values.ForEach(x =>
{
    var key = x.CdcTestId;
    writer.Write(x, $"cases/{key}/index.json");
    writer.Write(new { x.Evaluation, x.Forecast }, $"cases/{key}/expected-result/index.json");
    writer.Write(new { x.AssessmentDate, x.Patient, x.Doses }, $"cases/{key}/test-data/index.json");
});