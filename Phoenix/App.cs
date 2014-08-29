using System;
using Xamarin.Forms;
using Phoenix.Views.EnterpriseSelection;

namespace Phoenix
{
	public class App
	{
		public static Page GetMainPage()
		{	
			var mainNav = new NavigationPage(new EnterpriseSelectionPage());

			return mainNav;
		}
	}
}

