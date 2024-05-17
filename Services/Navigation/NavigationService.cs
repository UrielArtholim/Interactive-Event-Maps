using Interactive_Event_Maps.Helpers.Service;
using Interactive_Event_Maps.ViewModels.Base;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Navigation
{
	public class NavigationService : INavigationService
	{
		public NavigationService() { }


		public async Task PushAsync(ContentPage contentPage, bool isBackAllowed = false)
		{
			await Application.Current?.MainPage.Navigation.PushAsync(contentPage);
			if (!isBackAllowed)
			{
				await PopToRootAsync();
				await Application.Current?.MainPage.Navigation.PushAsync(contentPage);
			}

		}

		public async Task PopAsync()
		{
			await Application.Current?.MainPage.Navigation.PopAsync();
		}

		public async Task PopToRootAsync()
		{
			await Application.Current.MainPage.Navigation.PopToRootAsync();
		}

		public void SetMainPage(Page page)
		{
			Application.Current.MainPage = page;	
		}
		
	}
}
