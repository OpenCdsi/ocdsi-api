using System;
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
        public static string Munge(this string key)
        {
            return key.ToLower().Replace(' ', '_').Replace('-', '_');
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<string> data)
        {
            return data
                .Select(x => new CatalogItem { Key = x.Munge(), Text = x });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingData> data)
        {
            return data
                .Select(x => x.series[0].targetDisease)
                .Select(x => new CatalogItem { Key = x.Munge(), Text = x });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<antigenSupportingDataSeries> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.seriesName.Munge(),
                    Text = x.seriesName,
                    Group = x.seriesType
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataObservation> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.observationCode.Munge(),
                    Text = x.observationTitle,
                    Group = !string.IsNullOrWhiteSpace(x.indicationText) ? "Indicated" : "Contraindicated"
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataCvxMap> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.cvx,
                    Text = x.shortDescription
                });
        }

        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<scheduleSupportingDataVaccineGroup> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.name.Munge(),
                    Text = x.name
                });
        }
        public static IEnumerable<CatalogItem> GetCatalog(this IEnumerable<testcase> data)
        {
            return data
                .Select(x => new CatalogItem
                {
                    Key = x.CdcTestId,
                    Text = x.GeneralDescription,
                    Group = x.VaccineGroup
                });
        }

        public static void ForEach<T>(this IEnumerable<T> data, Action<T> func)
        {
            foreach (var item in data) { func(item); }
        }
    }
}
