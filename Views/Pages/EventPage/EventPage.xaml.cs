using Interactive_Event_Maps.ViewModels.Pages;

namespace Interactive_Event_Maps.Views.Pages.EventPage;

public partial class EventPage : ContentPage
{
	public EventPage(EventPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}