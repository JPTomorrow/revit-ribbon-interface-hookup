using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using debuggerPrint;

/// <summary>
///  TO FOLD ALL REGIONS CTRL + SHIFT + ALT + K
/// </summary>
namespace MainApp
{
	//Conduit Projects

	#region InvokeSplitElementConduit Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSplitElementConduit : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\SplitElementConduit\\SplitElementConduit.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeConduitRunInfo Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitRunInfo : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ConduitRunInfo\\ConduitRunInfo.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeSingleConduitRunInfo Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSingleConduitRunInfo : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\SingleConduitRunInfo\\SingleConduitRunInfo.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeJboxMatchParams Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeJboxMatchParams : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\JboxMatchParams\\JboxMatchParams.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeConduitMatchParams Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitMatchParams : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ConduitMatchParams\\ConduitMatchParams.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	#region InvokeConduitRunMatchParamService Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitRunMatchParamService : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ConduitRunMatchParamService\\ConduitRunMatchParamService.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	#region ConduitTaggingFactory Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitTaggingFactory : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ConduitTaggingFactory\\ConduitTaggingFactory.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeConduitIdGenerator Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeConduitIdGenerator : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ConduitIdGenerator\\ConduitIdGenerator.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeSwapJboxParam Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeSwapJboxParam : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\SwapJboxParam\\SwapJboxParam.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokePanelScheduleInfo Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePanelScheduleInfo : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\PanelScheduleInfo\\PanelScheduleInfo.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeAutoRouteBranchConduit Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeAutoRouteBranchConduit : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\AutoRouteBranchConduit\\AutoRouteBranchConduit.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeAutoRouteBranchConduit Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePullBoxSizer : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\PullBoxSizer\\PullBoxSizer.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	//View Projects

	#region InvokeLinkedFileSettingsOverride Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeLinkedFileSettingsOverride : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\LinkedFileSettingsOverride\\LinkedFileSettingsOverride.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeHideUselessReferencePlanes Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeHideUselessReferencePlanes : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\HideUselessReferencePlanes\\HideUselessReferencePlanes.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeAlign3DViewToScopeBox Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeAlign3DViewToScopeBox : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\Align3DViewToScopeBox\\Align3DViewToScopeBox.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeClampFloorplanCropRegion Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeClampFloorplanCropRegion : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ClampFloorplanCropRegion\\ClampFloorplanCropRegion.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeClampFloorplanCropRegion Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeRevealAllHidden : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\RevealAllHidden\\RevealAllHidden.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

    #region InvokePanelFilterTemplates Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePanelFilterTemplates : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
            String exeConfigPath = Path.GetDirectoryName(path) + "\\PanelFilterTemplates\\PanelFilterTemplates.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	//Search projects

	#region InvokeFindByParameterInView Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeFindByParameterInView : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\FindByParameterInView\\FindByParameterInView.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeFindReplaceParameter Class
	public class InvokeFindReplaceParameter : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\FindReplaceParameter\\FindReplaceParameter.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeElementFinder Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeElementFinder : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ElementFinder\\ElementFinder.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	//sheets projects

	#region InvokeScopeBoxIntoSheets Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeScopeBoxIntoSheets : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ScopeBoxIntoSheets\\ScopeBoxIntoSheets.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeImportImgsIntoSheet Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeImportImgsIntoSheet : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ImportImgsIntoSheet\\ImportImgsIntoSheet.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeImportSchedsIntoSheet Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeImportSchedsIntoSheet : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\ImportSchedIntoSheets\\ImportSchedIntoSheets.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	//M.P.A.C.T. projects

	#region InvokeBOMGenerator Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeBOMGenerator : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\BOMGenerator\\BOMGenerator.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokePThreeGenerator Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokePThreeGenerator : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\PThreeGenerator\\PThreeGenerator.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeP3L Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeP3L : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\P3L\\P3L.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	#region InvokeWireBOMLite Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeWireBOMLite : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			String exeConfigPath = Path.GetDirectoryName(path) + "\\WireBOMLite\\WireBOMLite.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	//Hangers projects

	#region InvokeHangerConstruction Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeHangerConstruction : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\HangerConstruction\\HangerConstruction.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "HangerConstruction";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
	#region InvokeHangerSetup Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeHangerSetup : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\HangerConstruction\\HangerConstruction.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "HangerSetup";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	//Graphics projects

	#region InvokeFixOverrideColor Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeFixOverrideColor : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\FixOverrideColor\\FixOverrideColor.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	// Fixture projects

	#region InvokeFixOverrideColor Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeLightingFixtureElevationToStructure : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\LightingFixtureElevationToStructure\\LightingFixtureElevationToStructure.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion


	//Test projects

	#region InvokeWireWorksRunId Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeRevitTestBed : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\RevitTestBed\\RevitTestBed.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion

	#region InvokeRevitSTLExporter Class
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class InvokeRevitSTLExporter : IExternalCommand
	{
		//public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
		{
			string path = Assembly.GetExecutingAssembly().Location;
			//String exeConfigPath = Path.GetDirectoryName(path) + "..\\..\\..\\" + "myMacros\\2018\\Revit\\AppHookup\\_969_PRLChecklists\\AddIn\\_969_PRLChecklists.dll";
			String exeConfigPath = Path.GetDirectoryName(path) + "\\RevitSTLExporter\\RevitSTLExporter.dll";
			String exeConfigPath2 = Path.GetDirectoryName(path) + "\\Res";

			string strCommandName = "ThisApplication";

			byte[] assemblyBytes = File.ReadAllBytes(exeConfigPath);

			Assembly objAssembly = Assembly.Load(assemblyBytes);
			IEnumerable<Type> myIEnumerableType = GetTypesSafely(objAssembly);
			foreach (Type objType in myIEnumerableType)
			{
				if (objType.IsClass)
				{
					if (objType.Name.ToLower() == strCommandName.ToLower())
					{
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
	#endregion
}
