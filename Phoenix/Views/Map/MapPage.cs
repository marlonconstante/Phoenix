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
				Source = "http://gpmil.com/svg/CristoRei.svg",
				WidthRequest = DeviceScreen.Instance.DisplayWidth
			};

			var searchFamiliarField = new SearchBar()
			{ 
				VerticalOptions = LayoutOptions.Start,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 40,
				Placeholder = "Nome ou CPF",
			};
				
			var pinButton = new ImageButton
			{ 
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("pin.png"),
				HeightRequest = 60,
				WidthRequest = 60,
			};

			pinButton.Clicked += (sender, e) =>
			{
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				Navigation.PushAsync(myLocationPage);
			};
					
			var gridLayout = new Grid
			{
				ColumnDefinitions =
				{
					new ColumnDefinition()
					{
						Width = DeviceScreen.Instance.DisplayWidth
					}
				},
				RowDefinitions =
				{
					new RowDefinition()
					{
						Height = DeviceScreen.Instance.DisplayVisibleHeight
					}
				},
				Children =
				{
					{ browser, 0, 0 },	
					{ pinButton, 0, 0 },
					{ searchFamiliarField, 0, 0 }
				}
			};
					
			Content = gridLayout;
		}
	}
}

