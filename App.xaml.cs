using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.Views.Pages;

namespace Interactive_Event_Maps
{
	public partial class App : Application
	{
		public static INavigationService Navigation { get; set; }
		public App()
		{
			InitializeComponent();
			Navigation = ServiceHelper.GetService<INavigationService>() ?? throw new Exception("Service not available: INavigationService");
			MainPage = ServiceHelper.GetService<HomePage>();			
		}
	}
}
