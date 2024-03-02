using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Navigation
{
	public class NavigationService : INavigationService
	{
		public async Task PopAsync()
		{
			if(Shell.Current.Navigation.NavigationStack.Count > 0) 
			{
				await MainThread.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PopAsync());
			}
		}

		public async Task PopModalAsync()
		{
			if (Shell.Current.Navigation.ModalStack.Count > 0)
			{
				await MainThread.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PopModalAsync());
			}
		}

		public async Task PushAsync(ContentPage contentPage, bool allowReturn = false)
		{
			if(!allowReturn)
			{
				NavigationService.CleanNavigationStack();
			}
			await MainThread.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PushAsync(new NavigationPage(contentPage)));
		}

		public async Task PushModalAsync(ContentPage contentPage)
		{
			while(Shell.Current.Navigation.ModalStack.Count > 0)
			{
				await this.PopModalAsync();
			}
			await MainThread.InvokeOnMainThreadAsync(async () => await Shell.Current.Navigation.PushModalAsync(contentPage));
		}

		private static void CleanNavigationStack()
		{
			while (Shell.Current.Navigation.NavigationStack.Count > 0)
			{
				Shell.Current.Navigation.RemovePage(Shell.Current.Navigation.NavigationStack.Last());
			}
		}
	}
}
