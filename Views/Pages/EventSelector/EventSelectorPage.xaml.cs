using Interactive_Event_Maps.ViewModels.Pages;

namespace Interactive_Event_Maps.Views.Pages;

public partial class EventSelectorPage : ContentPage
{
	public EventSelectorPage(EventSelectorViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}