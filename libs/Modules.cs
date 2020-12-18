using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using JPMorrow.Tools.Diagnostics;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.DB;

namespace JPMorrow.Revit.Addin.Mods
{
	public class Modules
	{
		public List<ModuleData> ModulesList { get; set; } = new List<ModuleData>();

		public Modules(List<ModuleData> modules)
		{
			ModulesList.AddRange(modules);
		}

		public Modules() {}

		public List<string> GetDistictCategoryList()
		{
			return ModulesList.Select(x => x.Category).Distinct().ToList();
		}

		public List<ModuleData> GetModulesByCategory(string category)
		{
			return ModulesList.FindAll(x => x.Category == category);
		}

		public void LoadModules(string filepath)
		{
			if(!File.Exists(filepath))
			{
				var file = File.Create(filepath);
				file.Close();
			}

			using(StreamReader sr = new StreamReader(filepath))
			{
				string[] lines = sr.ReadToEnd().Split('\n');

				foreach(var line in lines)
				{
					if(String.IsNullOrWhiteSpace(line)) continue;
					if(line.StartsWith("####")) continue;
					string[] mod_info_arr = line.Split('|');

					try
					{
						ModuleData mod_to_add = new ModuleData(
							mod_info_arr[0], mod_info_arr[1],
							mod_info_arr[2], mod_info_arr[3],
							mod_info_arr[4], mod_info_arr[5]);
						ModulesList.Add(mod_to_add);
					}
					catch
					{
						debugger.show(err: line);
					}

				}
			}

		}
	}

	public class ModuleData
	{
		public string Caption { get; set; }
		public string DirectoryName { get; set; }
		public string InvokeName { get; set; }
		public string Icon { get; set; }
		public string LargeIcon { get; set; }
		public string Category { get; set; }

		public ModuleData(string buttonCaption, string dirName, string invokeName, string icon, string lgIcon, string category)
		{
			Caption = buttonCaption;
			DirectoryName = dirName;
			InvokeName = invokeName;
			Icon = icon;
			LargeIcon = lgIcon;

			if (String.IsNullOrWhiteSpace(category))
				Category = "Misc.";
			else
				Category = category;
		}
	}

	public class PBDataPair
	{
		public ModuleData Data { get; }
		public PushButtonData PBData { get; }

		public PBDataPair(ModuleData data, PushButtonData pbd)
		{
			Data = data;
			PBData = pbd;
		}
	}
}
