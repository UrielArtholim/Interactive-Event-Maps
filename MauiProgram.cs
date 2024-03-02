using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Services.Event;
using Interactive_Event_Maps.Services.File;
using Interactive_Event_Maps.Services.Github;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.ViewModels.Pages;
using Interactive_Event_Maps.Views.Pages;
using Interactive_Event_Maps.Views.Pages.EventPage;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Interactive_Event_Maps
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.RegisterAppServices()
				.RegisterViewModels()
				.RegisterPages()
				.UseMauiMaps()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();
#endif
			var app = builder.Build();

			ServiceHelper.Initialize(app.Services);

			return app;
		}

		public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
			mauiAppBuilder.Services.AddSingleton<IGitHubService, GitHubService>();
			mauiAppBuilder.Services.AddSingleton<IEventService, EventService>();
			mauiAppBuilder.Services.AddSingleton<IFileService, FileService>();
			return mauiAppBuilder;
		}

		public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<EventSelectorViewModel>();
			mauiAppBuilder.Services.AddTransient<EventPageViewModel>();
			return mauiAppBuilder;
		}

		public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder) 
		{
			mauiAppBuilder.Services.AddTransient<EventSelectorPage>();
			mauiAppBuilder.Services.AddTransient<EventPage>();
			return mauiAppBuilder;
		}
	}
}
