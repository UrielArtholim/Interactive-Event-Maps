using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Models;
using Interactive_Event_Maps.Services.Event;
using Interactive_Event_Maps.Services.File;
using Interactive_Event_Maps.Services.Github;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.ViewModels.Base;
using Interactive_Event_Maps.Views.Pages.EventPage;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Event_Maps.ViewModels.Pages
{
	public class EventSelectorViewModel: BaseViewModel
	{
		public List<SelectableEvent> SelectableElements { get; set; }
		public ICommand SelectCommand { get; private set; }
		public ICommand RefreshCommand { get; private set; }
		public bool IsRefreshing { get; private set; }
		
		private INavigationService navigationService;
		private IEventService eventService;
		private IGitHubService gitHubService;
		private IFileService fileService;

		public EventSelectorViewModel(INavigationService navigationService, IEventService eventService, IGitHubService gitHubService, IFileService fileService) 
		{
			this.navigationService = navigationService;
			this.eventService = eventService;
			this.gitHubService = gitHubService;
			this.fileService = fileService;
			this.RefreshCommand = new Command(() => RefreshEventList());
			this.SelectCommand = new Command<string>(s => Task.Factory.StartNew(async () => await ShowSelectedEventAsync(s)));
			this.SelectableElements = [];
			this.Init();			
		}

		public void RefreshEventList()
		{
			Console.WriteLine("Refreshing Event List");
			MainThread.BeginInvokeOnMainThread(() =>
			{
				this.SelectableElements.Clear();
				this.SelectableElements.AddRange(Task.Run(this.eventService.GetAvailableEventsAsync).GetAwaiter().GetResult());
			});
			Console.WriteLine("Event List Refreshed");
			this.IsRefreshing = false;
		}

		public async Task ShowSelectedEventAsync(string selectedEvent)
		{
			Console.WriteLine($"Clicked Event: {selectedEvent}");
			//await navigationService.PushAsync(ServiceHelper.GetService<EventPage>(), false);
		}

		private void Init()
		{
			if (!base.initialized)
			{
				this.IsBusy = true;
				try
				{
					RefreshEventList();
				}
				finally
				{
					this.IsBusy = false;
					this.initialized = true;
				}
			}
		}
	}
}
