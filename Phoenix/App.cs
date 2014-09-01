using System;
using Xamarin.Forms;
using Phoenix.Views.EnterpriseSelection;

namespace Phoenix
{
	public class App
	{
		public static Page GetMainPage()
		{	
			var mainNav = new NavigationPage(new EnterpriseSelectionPage())
			{
				BarBackgroundColor = Color.White,
				BarTextColor = Color.FromRgb(56, 56, 56)
			};
					
			return mainNav;
		}
			
	}
}

