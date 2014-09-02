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
				Source = "https://cdn.rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html?id=campoVerde",
				WidthRequest = DeviceScreen.Instance.DisplayWidth
			};

			var searchFamiliarField = new SearchBar()
			{ 
				VerticalOptions = LayoutOptions.Start,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 40,
				Placeholder = "Nome ou CPF",
			};
				
			var imgButtonSize = Device.OnPlatform(50, 120, 120);
			var buttonSize = Device.OnPlatform(50, 80, 60);
			var pinButton = new ImageButton
			{ 
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("pin.png"),
				ImageHeightRequest = imgButtonSize,
				ImageWidthRequest = imgButtonSize,
				BackgroundColor = Color.Transparent,
				HeightRequest = buttonSize,
				WidthRequest = buttonSize,
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

