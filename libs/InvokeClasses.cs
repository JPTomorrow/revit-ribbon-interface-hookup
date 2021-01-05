using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using debuggerPrint;
using JPMorrow.Revit.Versioning;

namespace MainApp
{
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public abstract class InvokeModuleBase {
		public string ExeConfigPath { get; set; }
		public string ResourcePath { get; set; }

		public abstract string ModuleName { get; }

		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			RevitVersion v = new RevitVersion(commandData.Application.Application.VersionName);
			string path = Assembly.GetExecutingAssembly().Location;
			ExeConfigPath = Path.GetDirectoryName(path) + "\\" + ModuleName + "\\" + ModuleName + "_" + v.Year + ".dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(ExeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower()) {
						object ibaseObject = Activator.CreateInstance(objType);
						object[] arguments = new object[] { commandData, exeConfigPath2, elements };
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
	public class InvokeSplitElementConduit : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SplitElementConduit"; }
	public class InvokeConduitRunInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunInfo"; }
	public class InvokeSingleConduitRunInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SingleConduitRunInfo"; }
	public class InvokeJboxMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "JboxMatchParams"; }
	public class InvokeConduitMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitMatchParams"; }
	public class InvokeConduitRunMatchParamService : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunMatchParamService"; }
	public class InvokeConduitTaggingFactory : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitTaggingFactory"; }
	public class InvokeConduitIdGenerator : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitIdGenerator"; }
	public class InvokeSwapJboxParam : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SwapJboxParam"; }
	public class InvokePanelScheduleInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PanelScheduleInf"; }
	public class InvokeAutoRouteBranchConduit : InvokeModuleBase, IExternalCommand { public override string ModuleName => "AutoRouteBranchConduit"; }
	//View Projects
	public class InvokeLinkedFileSettingsOverride : InvokeModuleBase, IExternalCommand { public override string ModuleName => "LinkedFileSettingsOverride"; }
	public class InvokeHideUselessReferencePlanes : InvokeModuleBase, IExternalCommand { public override string ModuleName => "HideUselessReferencePlanes"; }
	public class InvokeAlign3DViewToScopeBox : InvokeModuleBase, IExternalCommand { public override string ModuleName => "Align3DViewToScopeBox"; }
	public class InvokeClampFloorplanCropRegion : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ClampFloorplanCropRegion"; }
	public class InvokePanelFilterTemplates : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PanelFilterTemplates"; }
	//Search projects
	public class InvokeElementFinder : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ElementFinder"; }
	public class InvokeFindReplaceParameter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FindReplaceParameter"; }
	public class InvokeFindByParameterInView : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FindByParameterInView"; }
	//M.P.A.C.T. projects
    public class InvokeWireBOMLite : InvokeModuleBase, IExternalCommand { public override string ModuleName => "WireBOMLite"; }
	//Graphics projects
	public class InvokeFixOverrideColor : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FixOverrideColor"; }
	// Fixture projects
	public class InvokeLightingFixtureElevationToStructure : InvokeModuleBase, IExternalCommand { public override string ModuleName => "LightingFixtureElevationToStructure"; }
	//Test projects
	public class InvokeRevitSTLExporter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "RevitSTLExporter"; }
}
