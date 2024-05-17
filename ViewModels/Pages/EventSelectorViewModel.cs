using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.Models;
using Interactive_Event_Maps.Services.Event;
using Interactive_Event_Maps.Services.Navigation;
using Interactive_Event_Maps.ViewModels.Base;
using Interactive_Event_Maps.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Interactive_Event_Maps.ViewModels.Pages
{
	public class EventSelectorViewModel: BaseObservableCollectionViewModel<EventInformation>
	{
		private IEventService eventService;
		private string refreshText;
		public string RefreshText 
		{
			get => this.refreshText;
			set => SetProperty(ref this.refreshText, value);
		}
		public ICommand RefreshCommand { get; private set; }
		public ICommand SelectCommand {  get; private set; }
		public EventSelectorViewModel() : base()
		{
			this.eventService = ServiceHelper.GetService<IEventService>() ?? throw new Exception("Service not available: IEventService");
			this.Title = "Selección de evento";
			this.RefreshText = "Cargando eventos disponibles...";
			this.RefreshCommand = new Command(async () => await UpdateEventCollectionAsync());
			this.SelectCommand = new Command<EventInformation>(AccessEventInfoAsync);
			this.IsBusy = true;
			MainThread.InvokeOnMainThreadAsync(UpdateEventCollectionAsync);
			this.IsBusy = false;
		}

		private async Task UpdateEventCollectionAsync()
		{
			this.Collection = await this.eventService.GetAvailableEventsAsync();
		}

		public void AccessEventInfoAsync(EventInformation selectedEvent)
		{
			Console.WriteLine($"Selected event called {selectedEvent.FormattedName}");
			App.Navigation.SetMainPage(new EventTabbedPage(selectedEvent));
		}
	}
}
