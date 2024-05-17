using Interactive_Event_Maps.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interactive_Event_Maps.Services.Navigation
{
	public interface INavigationService
	{
		Task PushAsync(ContentPage contentPage, bool isBackAllowed = false);
		Task PopAsync();

		void SetMainPage(Page page);
	}
}
