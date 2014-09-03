using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Phoenix.Utils;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Views.MyLocation;

namespace Phoenix.Views.Map
{
	public class MapPage : ContentPage
	{
		public MapPage()
		{
			var browser = new WebView
			{
				Source = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html?id=campoVerde",
				WidthRequest = DeviceScreen.Instance.DisplayWidth
			};

			var searchFamiliarField = new SearchBar
			{ 
				VerticalOptions = LayoutOptions.Start,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 40,
				Placeholder = "Nome ou CPF"
			};

			var pinSize = Device.OnPlatform(87, 87, 87);
			var pinButton = new ImageButton
			{ 
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("pin.png"),
				ImageWidthRequest = pinSize,
				ImageHeightRequest = pinSize,
				WidthRequest = pinSize,
				HeightRequest = Device.OnPlatform(110, 110, 110)
			};

			pinButton.Clicked += (sender, e) =>
			{
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				Navigation.PushAsync(myLocationPage);
			};
					
			var grid = new Grid
			{
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = DeviceScreen.Instance.DisplayWidth
					}
				},
				RowDefinitions = {
					new RowDefinition {
						Height = DeviceScreen.Instance.DisplayVisibleHeight
					}
				},
				Children = {
					{ browser, 0, 0 },	
					{ pinButton, 0, 0 },
					{ searchFamiliarField, 0, 0 }
				}
			};
					
			Content = grid;
		}
	}
}

