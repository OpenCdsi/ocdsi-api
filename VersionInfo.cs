using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exporter
{
    public class VersionInfo
    {
        public static VersionInfo Instance => new VersionInfo();
        public string TestcaseVersion => OpenCdsi.Cases.Metadata.ResourceVersion;
        public string SupportingDataVersion => OpenCdsi.Schedule.Metadata.ResourceVersion;
    }
}
