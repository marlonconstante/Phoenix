using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;

namespace Phoenix.Views.Map
{
	public class MapPage : ContentPage
	{
		public MapPage()
		{
	
			var browser = new WebView {
				Source = "http://ariutta.github.io/svg-pan-zoom/demo/custom-controls.html",
				VerticalOptions = LayoutOptions.FillAndExpand,
				WidthRequest = 240
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

