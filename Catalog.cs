using OpenCdsi.Cases;
using OpenCdsi.Schedule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter
{
    public class CatalogItem
    {
        public string Key { get; init; } = string.Empty;
        public string Url { get; internal set; } = string.Empty;
        public string Text { get; init; } = string.Empty;
        public string Group { get; init; } = "None";
    }

    public static class CatalogHelpers
    {
        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<string> data)
        {
            return data
                .Select(x => new CatalogItem { Key = x.ToCamelCase(), Text = x, Url = $"v1/{x.ToCamelCase()}/index.json" });
        }
        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<string> data, string prefix)
        {
            return data
                .Select(x => new CatalogItem { Key = x.ToCamelCase(), Text = x, Url = $"{prefix}/{x.ToCamelCase()}/index.json" });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingData> data)
        {
            return data
                .Select(x => x.series[0].targetDisease)
                .Select(x => new CatalogItem { Key = x.ToCamelCase(), Text = x, Url = $"v1/antigens/{x.ToCamelCase()}/index.json" });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingDataSeries> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.seriesName.ToCamelCase(),
                    Text = x.seriesName,
                    Group = x.seriesType,
                    Url = $"v1/antigens/{x.targetDisease.ToCamelCase()}/series/{x.seriesName.ToCamelCase()}/index.json"
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataObservation> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.observationCode.ToCamelCase(),
                    Text = x.observationTitle,
                    Group = !string.IsNullOrWhiteSpace(x.indicationText) ? "Indicated" : "Contraindicated",
                    Url = $"v1/observations/{x.observationCode.ToCamelCase()}/index.json"
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataCvxMap> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.cvx,
                    Text = x.shortDescription,
                    Url = $"v1/vaccines/{x.cvx}/index.json"
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataVaccineGroup> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.name.ToCamelCase(),
                    Text = x.name,
                    Url = $"v1/groups/{x.name.ToCamelCase()}/index.json",
                });
        }
        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<testcase> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.CdcTestId,
                    Text = x.TestcaseName,
                    Group = x.VaccineGroup,
                    Url = $"v1/cases/{x.CdcTestId}/index.json"
                });
        }
    }
}
