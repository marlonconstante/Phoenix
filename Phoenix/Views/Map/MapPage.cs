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

			var assembly = typeof(MapPage).GetTypeInfo().Assembly;
			Stream stream = assembly.GetManifestResourceStream("Phoenix.Views.Map.CristoRei.svg");

			string text;
			using (var reader = new System.IO.StreamReader (stream)) {
				text = reader.ReadToEnd ();
			}


			var htmlSource = new HtmlWebViewSource ();
			htmlSource.Html = text;


			var browser = new WebView {
				Source = htmlSource,
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

