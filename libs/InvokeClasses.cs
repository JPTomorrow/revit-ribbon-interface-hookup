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
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSplitElementConduit : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SplitElementConduit"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitRunInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunInfo"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSingleConduitRunInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SingleConduitRunInfo"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeJboxMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "JboxMatchParams"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitMatchParams : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitMatchParams"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitWorksetMatch : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitWorksetMatch"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitRunMatchParamService : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitRunMatchParamService"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitTaggingFactory : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitTaggingFactory"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitIdGenerator : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ConduitIdGenerator"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSwapJboxParam : InvokeModuleBase, IExternalCommand { public override string ModuleName => "SwapJboxParam"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePanelScheduleInfo : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PanelScheduleInf"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeAutoRouteBranchConduit : InvokeModuleBase, IExternalCommand { public override string ModuleName => "AutoRouteBranchConduit"; }
	//View Projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeLinkedFileSettingsOverride : InvokeModuleBase, IExternalCommand { public override string ModuleName => "LinkedFileSettingsOverride"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeHideUselessReferencePlanes : InvokeModuleBase, IExternalCommand { public override string ModuleName => "HideUselessReferencePlanes"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeAlign3DViewToScopeBox : InvokeModuleBase, IExternalCommand { public override string ModuleName => "Align3DViewToScopeBox"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeClampFloorplanCropRegion : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ClampFloorplanCropRegion"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePanelFilterTemplates : InvokeModuleBase, IExternalCommand { public override string ModuleName => "PanelFilterTemplates"; }
	//Search projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeElementFinder : InvokeModuleBase, IExternalCommand { public override string ModuleName => "ElementFinder"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeFindReplaceParameter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FindReplaceParameter"; }
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeFindByParameterInView : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FindByParameterInView"; }
	//M.P.A.C.T. projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class InvokeWireBOMLite : InvokeModuleBase, IExternalCommand { public override string ModuleName => "WireBOMLite"; }
	//Graphics projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeFixOverrideColor : InvokeModuleBase, IExternalCommand { public override string ModuleName => "FixOverrideColor"; }
	// Fixture projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeLightingFixtureElevationToStructure : InvokeModuleBase, IExternalCommand { public override string ModuleName => "LightingFixtureElevationToStructure"; }
	//Test projects
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeRevitSTLExporter : InvokeModuleBase, IExternalCommand { public override string ModuleName => "RevitSTLExporter"; }
}
