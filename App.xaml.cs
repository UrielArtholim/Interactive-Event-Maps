using Interactive_Event_Maps.Services.Event;
using Interactive_Event_Maps.Services.File;
using Interactive_Event_Maps.Services.Github;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.ViewModels.Pages;
using Interactive_Event_Maps.Views.Pages;

namespace Interactive_Event_Maps
{
	public partial class App : Application
	{
		public App(IServiceProvider services)
		{
			InitializeComponent();
			MainPage = services.GetRequiredService<EventSelectorPage>();			
		}
	}
}
