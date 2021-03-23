using System;
using System.Diagnostics;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Windows.Media.Imaging;
using JPMorrow.UI.Views;
using JPMorrow.Revit.Addin.Mods;
using JPMorrow.Revit.Versioning;
using JPMorrow.Tools.Diagnostics;

namespace MainApp
{
	#region addin info
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    [Autodesk.Revit.DB.Macros.AddInId("16824613-93A7-4981-B2CF-27AB6E52280A")]
	#endregion
	public partial class ThisApplication : IExternalApplication
	{
		public DockPaneView m_MyDockableWindow = null;
		public static Modules mods;
		public static string AppBaseDirectory { get => "C:\\ProgramData\\Autodesk\\Revit\\Addins\\MarathonScripts"; }
		
		public Result OnStartup(UIControlledApplication a)
        {
			// create buttons
			string path = Assembly.GetExecutingAssembly().Location;

			mods = new Modules();
			mods.LoadModules(Path.GetDirectoryName(path) + "\\ALL_MODULES.TXT");

            string ribbonName = "Marathon Add-Ins";
            String exeConfigPath = Path.GetDirectoryName(path) + "\\RevitAddinHookup.dll";

			a.CreateRibbonTab(ribbonName);

			foreach (string category in mods.GetDistictCategoryList().OrderBy(x => x.First())) {

				RibbonPanel rp = a.CreateRibbonPanel(ribbonName, category);

				List<ModuleData> cat_mods = mods.GetModulesByCategory(category);

				List<PBDataPair> all_data = new List<PBDataPair>();
				List<RibbonItem> all_items = new List<RibbonItem>();

				for(var i = 0; i < cat_mods.Count; i++) {
					var m_data = cat_mods[i];

					//Create Button Data
					PushButtonData pbd = new PushButtonData(m_data.Caption, m_data.Caption, exeConfigPath, "MainApp.Invoke" + m_data.InvokeName);

					//Make button images
					try {
						pbd.Image = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\" + m_data.Icon), UriKind.Absolute));
						pbd.LargeImage = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\" + m_data.LargeIcon), UriKind.Absolute));
					}
					catch {
						pbd.Image = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_s.png"), UriKind.Absolute));
						pbd.LargeImage = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_b.png"), UriKind.Absolute));
					}

					all_data.Add(new PBDataPair(m_data, pbd));
				}

				// get year of revit to find dll to enable button
				RevitVersion v = new RevitVersion(a);

				// check if dll exists and remove button if not
				bool dll_chk(PBDataPair x) => File.Exists(Path.GetDirectoryName(path) + "\\" + x.Data.DirectoryName + "\\" + x.Data.DirectoryName + "_" + v.Year + ".dll");
				all_data.RemoveAll(x => !dll_chk(x));


				while(all_data.Any()) {
					List<PBDataPair> rem_pbds = all_data.RemoveTake(3).ToList();
					List<RibbonItem> rps = new List<RibbonItem>();

					switch(rem_pbds.Count) {
						case 3:
							rps.AddRange(rp.AddStackedItems(rem_pbds[0].PBData, rem_pbds[1].PBData, rem_pbds[2].PBData));
							break;
						case 2:
							rps.AddRange(rp.AddStackedItems(rem_pbds[0].PBData, rem_pbds[1].PBData));
							break;
						case 1:
							rps.Add(rp.AddItem(rem_pbds[0].PBData));
							break;
						default:
							break;
					}

					for (var i = 0; i < rem_pbds.Count; i++) {
						rps[i].Enabled = true;
						rps[i].Visible = true;
					}

					all_items.AddRange(rps);
				}

				//set visibility of category
				bool visCount = all_items.FindAll(x => x.Enabled == true).Count == 0 ? true : false;
				if (visCount)
					rp.Visible = false;
			}

			//@FIX - Finish implementing dockpanel
			/*
			DockablePaneProviderData data = new DockablePaneProviderData();

			DockPaneView MainDockableWindow = new DockPaneView();

			m_MyDockableWindow = MainDockableWindow;
			MainDockableWindow.SetupDockablePane(data);

			DockablePaneId dpid = new DockablePaneId(
			new Guid( "816A3912-6918-2319-2380-1927301a2372" ) );

			a.RegisterDockablePane(dpid, "Marathon Revit Addins", MainDockableWindow as IDockablePaneProvider);

    		PushButtonData PB_ShowWindow = new PushButtonData( "Show Window", "Show Window", exeConfigPath, "RevitAddinHookup.ShowDockableWindow" );
    		PB_ShowWindow.Image = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_s.png"), UriKind.Absolute));
			PB_ShowWindow.LargeImage = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_b.png"), UriKind.Absolute));

    		PushButtonData PB_HideWindow = new PushButtonData( "Hide Window", "Hide Window", exeConfigPath, "RevitAddinHookup.HideDockableWindow" );
    		PB_HideWindow.Image = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_s.png"), UriKind.Absolute));
			PB_HideWindow.LargeImage = new BitmapImage(new Uri(Path.Combine(Path.GetDirectoryName(path) + "\\Res\\default_b.png"), UriKind.Absolute));

			var panel = a.CreateRibbonPanel(ribbonName, "Dock");
			panel.AddItem(PB_ShowWindow);
			panel.AddItem(PB_HideWindow);
			*/

			return Result.Succeeded;
        }

        #region startup stuff
		private void Module_Startup(object sender, EventArgs e)
		{

		}

		private void Module_Shutdown(object sender, EventArgs e)
		{

		}

		public Result OnShutdown(UIControlledApplication a)
		{
			return Result.Succeeded;
		}

		private void InternalStartup()
		{
			this.Startup += new System.EventHandler(Module_Startup);
			this.Shutdown += new System.EventHandler(Module_Shutdown);
		}
		#endregion
	}

	// remove a certain number of entries from a list and return them
	public static class LINQ_Extensions
	{
		public static List<T> RemoveTake<T>(this List<T> source, int count)
		{
			if (source.Count < count) count = source.Count;
			List<T> retList = new List<T>();
			for (var i = 0; i < count; i++)
			{
				T item = source[0];
				retList.Add(item);
				source.Remove(item);
			}
			return retList;
		}
	}

	/// <summary>
	/// You can only register a dockable dialog in "Zero doc state"
	/// </summary>
	public class AvailabilityNoOpenDocument : IExternalCommandAvailability
	{
		public bool IsCommandAvailable(
			UIApplication a,
			CategorySet b )
		{
			if( a.ActiveUIDocument == null )
			{
			return true;
			}
			return false;
		}
	}

	/// <summary>
	/// Show dockable dialog
	/// </summary>
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class ShowDockableWindow : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements )
		{
			DockablePaneId dpid = new DockablePaneId(
			new Guid( "816A3912-6918-2319-2380-1927301a2372" ) );

			DockablePane dp = commandData.Application
			.GetDockablePane( dpid );

			dp.Show();

			return Result.Succeeded;
		}
	}

	/// <summary>
	/// Hide dockable dialog
	/// </summary>
	[Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
	public class HideDockableWindow : IExternalCommand
	{
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements )
		{
			DockablePaneId dpid = new DockablePaneId(
			new Guid( "816A3912-6918-2319-2380-1927301a2372" ) );

			DockablePane dp = commandData.Application
			.GetDockablePane( dpid );

			dp.Hide();
			return Result.Succeeded;
		}
	}
}