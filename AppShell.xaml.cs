using Interactive_Event_Maps.Views.Pages;

namespace Interactive_Event_Maps
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(EventSelectorPage), typeof(EventSelectorPage));
		}
	}
}
