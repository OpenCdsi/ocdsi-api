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
                .Select(x => new CatalogItem { Key = x.ToKebabCase(), Text = x, Url = $"v1/{x.ToKebabCase()}/index.json" });
        }
        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<string> data, string prefix)
        {
            return data
                .Select(x => new CatalogItem { Key = x.ToKebabCase(), Text = x, Url = $"{prefix}/{x.ToKebabCase()}/index.json" });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingData> data)
        {
            return data
                .Select(x => x.series[0].targetDisease)
                .Select(x => new CatalogItem { Key = x.ToKebabCase(), Text = x, Url = $"v1/antigens/{x.ToKebabCase()}/index.json" });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingDataSeries> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.seriesName.ToKebabCase(),
                    Text = x.seriesName,
                    Group = x.seriesType,
                    Url = $"v1/antigens/{x.targetDisease.ToKebabCase()}/series/{x.seriesName.ToKebabCase()}/index.json"
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataObservation> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.observationCode.ToKebabCase(),
                    Text = x.observationTitle,
                    Group = !string.IsNullOrWhiteSpace(x.indicationText) ? "Indicated" : "Contraindicated",
                    Url = $"v1/observations/{x.observationCode.ToKebabCase()}/index.json"
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
                    Key = x.name.ToKebabCase(),
                    Text = x.name,
                    Url = $"v1/groups/{x.name.ToKebabCase()}/index.json",
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
