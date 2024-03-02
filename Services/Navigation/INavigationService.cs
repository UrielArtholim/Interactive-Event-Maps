using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Navigation
{
	public interface INavigationService
	{
		Task PushAsync(ContentPage contentPage, bool allowReturn = true);

		Task PopAsync();

		Task PushModalAsync(ContentPage contentPage);

		Task PopModalAsync();
	}
}
