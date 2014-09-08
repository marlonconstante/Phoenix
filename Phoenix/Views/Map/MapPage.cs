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
using Phoenix.Controls;

namespace Phoenix.Views.Map
{
	public class MapPage : ContentPage
	{
		WebView m_browser;
		ListView m_listView;
		Enterprise m_enterprise;
		string m_locationCode;

		public MapPage(Enterprise enterprise)
		{
			Title = enterprise.Name;

			NavigationPage.SetBackButtonTitle(this, string.Empty);

			m_enterprise = enterprise;

			var persons = GetPersons();

			var searchFamiliarField = new SearchBar {
				VerticalOptions = LayoutOptions.Start,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 40,
				Placeholder = "Buscar um Ente"
			};

			m_listView = new ListView {
				TranslationY = searchFamiliarField.HeightRequest,
				RowHeight = 88,
				ItemTemplate = new DataTemplate(typeof(PersonSelectionItemCell)),
				BackgroundColor = Color.FromHex("f9f8f8").MultiplyAlpha(0.8f),
				Opacity = 0
			};

			searchFamiliarField.Focused += (sender, e) => {
				m_listView.ItemsSource = persons;
				m_listView.Opacity = 1;
			};

			searchFamiliarField.Unfocused += (sender, e) => {
				searchFamiliarField.Text = string.Empty;
				m_listView.Opacity = 0;
			};

			searchFamiliarField.TextChanged += (sender, e) => {
				m_listView.ItemsSource = persons.Where((p) => p.Name.ToLower().Contains(e.NewTextValue.ToLower()));
			};

			m_listView.ItemSelected += (sender, e) => {
				m_browser.Source = BrowserURL;
				searchFamiliarField.Unfocus();
			};

			m_browser = new WebView {
				Source = BrowserURL
			};

			var pinSize = Device.OnPlatform(87, 87, 87);
			var pinButton = new BackgroundButton {
				TranslationY = -11.5,
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "pin.png",
				WidthRequest = pinSize,
				HeightRequest = pinSize
			};

			pinButton.Clicked += (sender, e) => {
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				myLocationPage.ParentPage = this;
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
					{ m_browser, 0, 0 },
					{ pinButton, 0, 0 },
					{ searchFamiliarField, 0, 0 },
					{ m_listView, 0, 0 }
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
				new Person { Name = "Anderson Silva", Unit = "Unidade 123456", Sector = "setor_9_09_19", PlaceName = "São Leopoldo" },
				new Person { Name = "Andreia Souza", Unit = "Unidade 123456", Sector = "setor_5_07_13", PlaceName = "São Leopoldo" },
				new Person { Name = "Andrei Duarte", Unit = "Unidade 123456", Sector = "setor_2_04_38", PlaceName = "São Leopoldo" },
				new Person { Name = "Bernardete Fonseca", Unit = "Unidade 123456", Sector = "criptas_6_04", PlaceName = "São Leopoldo" },
				new Person { Name = "Claudio Gonçalves", Unit = "Unidade 123456", Sector = "setor_2_02_43", PlaceName = "São Leopoldo" }
			};
		}

		/// <summary>
		/// Gets or sets the location code.
		/// </summary>
		/// <value>The location code.</value>
		public string LocationCode {
			get {
				return m_locationCode;
			}
			set {
				m_locationCode = value;

				m_browser.Source = BrowserURL;
			}
		}

		/// <summary>
		/// Gets or sets the person.
		/// </summary>
		/// <value>The person.</value>
		public Person Person {
			get {
				return m_listView.SelectedItem as Person;
			}
			set {
				m_listView.SelectedItem = value;

				m_browser.Source = BrowserURL;
			}
		}

		/// <summary>
		/// Gets the URL parameters.
		/// </summary>
		/// <value>The URL parameters.</value>
		string URLParameters {
			get {
				string parameters = string.Empty;
				if (Person != null)
				{
					parameters += string.Concat("&sectorCode=", Person.Sector);
				}

				if (!string.IsNullOrEmpty(LocationCode))
				{
					parameters += string.Concat("&locationCode=_", LocationCode);
				}
				return string.Concat("?scale=", string.IsNullOrEmpty(parameters) ? 1 : 2, parameters);
			}
		}

		/// <summary>
		/// Gets the browser URL.
		/// </summary>
		/// <value>The browser URL.</value>
		string BrowserURL {
			get {
				return string.Concat(m_enterprise.UrlMap, URLParameters);
			}
		}
	}
}