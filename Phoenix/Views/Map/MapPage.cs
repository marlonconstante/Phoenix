using System;
using Xamarin.Forms;

namespace Views.Map
{
	public class MapPage : ContentPage
	{
		public MapPage()
		{

			var browser = new WebView {
				Source = "http://maps.google.com",
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var buttonWhereAmI = new Button { Text = "Onde eu estou?" };

			var familiarName = new Entry { Placeholder = "Nome ou CPF" };

			Content = new StackLayout {
				Children = {
					familiarName,
					browser,
					buttonWhereAmI
				}
			};
		}
	}
}

