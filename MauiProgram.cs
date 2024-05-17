using CommunityToolkit.Maui;
using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Services.Data;
using Interactive_Event_Maps.Services.Event;
using Interactive_Event_Maps.Services.Files;
using Interactive_Event_Maps.Services.GitHub;
using Interactive_Event_Maps.Services.Location;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.Services.Settings.SettingsService;
using Interactive_Event_Maps.ViewModels.Base;
using Interactive_Event_Maps.ViewModels.Pages;
using Interactive_Event_Maps.Views.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace Interactive_Event_Maps
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.UseMauiCommunityToolkit()
				.RegisterAppServices()
				.RegisterViewModels()
				.RegisterPages()
				.UseMauiMaps()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});
			var assembly = Assembly.GetExecutingAssembly();
			using var stream = assembly.GetManifestResourceStream("Interactive_Event_Maps.environment.settings.json");
			var config = new ConfigurationBuilder().AddJsonStream(stream).Build();
			builder.Configuration.AddConfiguration(config);

#if DEBUG
			builder.Logging.AddDebug();
#endif
			var app = builder.Build();			
			ServiceHelper.Initialize(app.Services);

			return app;
		}

		public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddSingleton<SettingsService>();
			mauiAppBuilder.Services.AddSingleton<IGitHubService, GitHubService>();
			mauiAppBuilder.Services.AddSingleton<INavigationService, NavigationService>();
			mauiAppBuilder.Services.AddSingleton<IFileService,  FileService>();
			mauiAppBuilder.Services.AddSingleton<IEventService, EventService>();
			mauiAppBuilder.Services.AddSingleton<ILocationService, LocationService>();
			mauiAppBuilder.Services.AddSingleton<IDataService, DataService>();

			return mauiAppBuilder;
		}

		public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<HomeViewModel>();
			mauiAppBuilder.Services.AddTransient<EventSelectorViewModel>();
			mauiAppBuilder.Services.AddTransient<LocationCalendarViewModel>();
			mauiAppBuilder.Services.AddTransient<LocationMapViewModel>();
			mauiAppBuilder.Services.AddTransient<LocationSelectorViewModel>();
			return mauiAppBuilder;
		}

		public static MauiAppBuilder RegisterPages(this MauiAppBuilder mauiAppBuilder)
		{
			mauiAppBuilder.Services.AddTransient<HomePage>();
			mauiAppBuilder.Services.AddTransient<EventSelectorPage>();
			mauiAppBuilder.Services.AddTransient<LocationCalendarPage>();
			mauiAppBuilder.Services.AddTransient<LocationMapPage>();
			mauiAppBuilder.Services.AddTransient<LocationSelectorPage>();
			return mauiAppBuilder;
		}
	}
}
