using Interactive_Event_Maps.Views.Pages;

namespace Interactive_Event_Maps
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
			Button button = new Button
			{
				Text = "Start maps",
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};

			button.Clicked += async (sender, args) =>
			{
				await Navigation.PushAsync(new MapPage());
			};
		}

		
	}

}
