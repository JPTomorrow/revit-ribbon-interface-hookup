using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Controls.Primitives;
using System.Windows.Ink;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shell;
using JPMorrow.UI.ViewModels;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using MainApp;

namespace JPMorrow.UI.Views
{
	/// <summary>
	/// Code Behind landing for templateForm.xaml
	/// </summary>
	public partial class DockPaneView : Page, IDockablePaneProvider
	{
		/// <summary>
		/// Default Constructor.static Bind DataContext
		/// </summary>
		public DockPaneView()
		{
			InitializeComponent();
			this.DataContext = new DockPaneModel();
		}


		public void SetupDockablePane(DockablePaneProviderData data)
		{
			data.FrameworkElement = this as System.Windows.FrameworkElement;
			data.InitialState = new DockablePaneState();
			data.InitialState.DockPosition = DockPosition.Tabbed;
			data.InitialState.TabBehind = DockablePanes.BuiltInDockablePanes.ProjectBrowser;
			data.VisibleByDefault = true;
			//data.EditorInteraction.InteractionType = EditorInteractionType.Dismiss;
		}
	}
}
