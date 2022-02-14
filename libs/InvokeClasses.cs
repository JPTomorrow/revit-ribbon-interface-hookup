using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using debuggerPrint;
using JPMorrow.Revit.Versioning;
using System.Security.Policy;
using JPMorrow.Tools.Diagnostics;

namespace MainApp
{
    public abstract class InvokeModuleBase
    {
        public string ExeConfigPath { get; set; }
        public string ResourcePath { get; set; }
        public abstract string ModuleName { get; }

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            RevitVersion v = new RevitVersion(commandData.Application.Application.VersionName);
            string path = Assembly.GetExecutingAssembly().Location;
            ExeConfigPath = ThisApplication.AppBaseDirectory + "\\" + ModuleName + "\\" + ModuleName + "_" + v.Year + ".dll";

            string strCommandName = "ThisApplication";

            var bytes = File.ReadAllBytes(ExeConfigPath);
            var asm = Assembly.Load(bytes);

            IEnumerable<Type> myIEnumerableType = GetTypesSafely(asm);

            foreach (Type objType in myIEnumerableType)
            {
                if (objType.IsClass)
                {
                    if (objType.Name.ToLower() == strCommandName.ToLower())
                    {
                        object ibaseObject = Activator.CreateInstance(objType);

                        String res_path = Path.GetDirectoryName(path) + "\\Res";
                        object[] arguments = new object[] { commandData, res_path, elements };
                        object result = null;

                        result = objType.InvokeMember("Execute", BindingFlags.Default | BindingFlags.InvokeMethod, null, ibaseObject, arguments);

                        break;
                    }
                }
            }
            return Result.Succeeded;
        }

        private static IEnumerable<Type> GetTypesSafely(Assembly assembly)
        {

            try
            {
                return assembly.GetTypes();
            }
            catch (ReflectionTypeLoadException ex)
            {
                return ex.Types.Where(x => x != null);
            }
        }

    }

    //Conduit Projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitRunInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunInfo"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitToJboxParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitToJboxParams"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeJboxMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "JboxMatchParams"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitMatchParams"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitMatchParamsRack : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitMatchParamsRack"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitWorksetMatch : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitWorksetMatch"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeConduitRunMatchParamService : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunMatchParamService"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeSwapJboxParam : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SwapJboxParam"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokePullBoxSizer : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PullBoxSizer"; }

    //View Projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeAlign3DViewToScopeBox : InvokeModuleBase, IExternalCommand { public override string ModuleName => "Align3DViewToScopeBox"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeClampFloorplanCropRegion : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ClampFloorplanCropRegion"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokePanelFilterTemplates : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PanelFilterTemplates"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeToggleFilters : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ToggleFilters"; }

    //Search projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeSelectedFindView : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SelectedFindView"; }

    //M.P.A.C.T. projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeWireBOMLite : InvokeModuleBase, IExternalCommand { public override string ModuleName => "WireBOMLite"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeBOMJsonExporter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "BOMJsonExporter"; }

    // Fixture projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeLightingFixtureElevationToStructure : InvokeModuleBase, IExternalCommand { public override string ModuleName => "LightingFixtureElevationToStructure"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeJboxTagLargestConduitDiameter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "JboxTagLargestConduitDiameter"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeUpdateJboxClearances : InvokeModuleBase, IExternalCommand { public override string ModuleName => "UpdateJboxClearances"; }

    //Test projects
    // [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    // public class InvokeRevitTestBed : InvokeModuleBase, IExternalCommand { public override string ModuleName => "RevitTestBed"; }

    //Help Projects
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeMarathonHelp : InvokeModuleBase, IExternalCommand { public override string ModuleName => "MarathonHelp"; }
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeRevitTestBed : InvokeModuleBase, IExternalCommand { public override string ModuleName => "RevitTestBed"; }
}