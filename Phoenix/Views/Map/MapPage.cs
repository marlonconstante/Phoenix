using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Phoenix.Utils;

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
				
			var whereButton = new Image
			{ 
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("cemita.png"),
				HeightRequest = 60,
				WidthRequest = 60
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
					{ whereButton, 0, 0 },
					{ searchFamiliarField, 0, 0 }
				}
			};
					
			Content = gridLayout;
		}
	}
}

