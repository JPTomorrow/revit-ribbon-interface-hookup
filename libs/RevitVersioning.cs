// This is a one off version of RevitVersioning meant for this program only

using System.Linq;
using Autodesk.Revit.UI;
using JPMorrow.Revit.Documents;
using JPMorrow.Tools.Diagnostics;

namespace JPMorrow.Revit.Versioning {

    public class RevitVersion {

        public RevitVersion(UIControlledApplication a) {
            
            Version = a.ControlledApplication.VersionName;
        }

        public RevitVersion(string version_name) {
            
            Version = version_name;
        }

        public string Version { get; private set; }
        public string Year { get => Version.Split(' ').Last(); }

        public bool IsVersionBelowYear(int year) {

            var year_str = Version.Split(' ').Last();
            var year_int = int.Parse(year_str);
            return year_int < year;
        }
    }
}
