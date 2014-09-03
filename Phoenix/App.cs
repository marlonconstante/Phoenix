using System;
using Xamarin.Forms;
using Phoenix.Views.EnterpriseSelection;

namespace Phoenix
{
	public class App
	{
		/// <summary>
		/// Gets the main page.
		/// </summary>
		/// <returns>The main page.</returns>
		public static Page GetMainPage()
		{	
			var mainNav = new NavigationPage(new EnterpriseSelectionPage())
			{
				BarBackgroundColor = Color.FromRgb(248, 248, 248),
				BarTextColor = Color.FromRgb(86, 86, 86)
			};
					
			return mainNav;
		}
	}
}