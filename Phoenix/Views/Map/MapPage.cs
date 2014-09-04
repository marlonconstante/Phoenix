using System;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using Phoenix.Utils;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Views.MyLocation;
using Phoenix.Views.PersonSelection;
using Phoenix.Models;
using System.Linq;
using Models;

namespace Phoenix.Views.Map
{
	public class MapPage : ContentPage
	{
		public MapPage(Enterprise enterprise)
		{
			Title = enterprise.Name;

			var persons = GetPersons();

			var browser = new WebView {
				Source = enterprise.UrlMap,
				WidthRequest = DeviceScreen.Instance.DisplayWidth
			};

			var searchFamiliarField = new SearchBar { 
				VerticalOptions = LayoutOptions.Start,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 40,
				Placeholder = "Buscar um Ente"
			};

			var listView = new ListView {
				TranslationY = searchFamiliarField.HeightRequest,
				RowHeight = 88,
				HeightRequest = DeviceScreen.Instance.DisplayVisibleHeight - searchFamiliarField.HeightRequest - 316,
				VerticalOptions = LayoutOptions.Fill,
				ItemTemplate = new DataTemplate(typeof(PersonSelectionItemCell)),
				ItemsSource = persons,
				BackgroundColor = Color.FromHex("f9f8f8").MultiplyAlpha(0.8f),
				IsVisible = false
			};

			searchFamiliarField.Focused += (sender, e) => {
				listView.IsVisible = true;
			};

			searchFamiliarField.TextChanged += (sender, e) => {
				listView.ItemsSource = persons.Where((p) => p.Name.Contains(e.NewTextValue));
			};

			listView.ItemSelected += (sender, e) => {
				var person = (Person) e.SelectedItem;
				listView.IsVisible = false;
				searchFamiliarField.Unfocus();
				browser.Source = string.Concat(enterprise.UrlMap, "?id=campoVerde");
			};

			var pinSize = Device.OnPlatform(87, 87, 87);
			var pinButton = new ImageButton { 
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("pin.png"),
				ImageWidthRequest = pinSize,
				ImageHeightRequest = pinSize,
				WidthRequest = pinSize,
				HeightRequest = Device.OnPlatform(110, 110, 110)
			};

			pinButton.Clicked += (sender, e) => {
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				Navigation.PushAsync(myLocationPage);
			};
					
			var grid = new Grid {
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
					{ searchFamiliarField, 0, 0 },
					{ listView, 0, 0 }
				}
			};
					
			Content = grid;
		}

		/// <summary>
		/// Gets the persons.
		/// </summary>
		/// <returns>The persons.</returns>
		Person[] GetPersons()
		{
			return new Person[] { 
				new Person { Name = "Anderson Silva", Unit = "Unidade 123456", PlaceName = "São Leopoldo" },
				new Person { Name = "Andreia Souza", Unit = "Unidade 123456", PlaceName = "São Leopoldo" },
				new Person { Name = "Andrei Duarte", Unit = "Unidade 123456", PlaceName = "São Leopoldo" },
				new Person { Name = "Bernardete Fonseca", Unit = "Unidade 123456", PlaceName = "São Leopoldo" },
				new Person { Name = "Claudio Gonçalves", Unit = "Unidade 123456", PlaceName = "São Leopoldo" }
			};
		}
	}
}