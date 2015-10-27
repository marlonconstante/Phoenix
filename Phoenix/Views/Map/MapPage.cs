using System;
using Xamarin.Forms;
using Phoenix.Utils;
using Phoenix.Views.MyLocation;
using Phoenix.Views.PersonSelection;
using Phoenix.Models;
using System.Linq;
using Models;
using Phoenix.Controls;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using Phoenix.Models.Json;
using Xamarin;

namespace Phoenix.Views.Map
{
	public class MapPage : ContentPage
	{
		WebView m_browser;
		ListView m_listView;
		Enterprise m_enterprise;
		Person m_person;
		string m_locationCode;
		ActivityIndicator m_indicator;
		SearchBar m_searchFamiliarField;

		public MapPage(Enterprise enterprise)
		{
			Title = enterprise.ShortName;

			NavigationPage.SetBackButtonTitle(this, string.Empty);

			m_enterprise = enterprise;

			m_searchFamiliarField = new SearchBar
			{
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = (Device.OS == TargetPlatform.Android) ? Color.FromHex("f9f8f8") : Color.FromHex("c9c9ce"),
				Placeholder = "Informe o Nome"
			};

			m_indicator = new ActivityIndicator()
			{
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center,
				TranslationY = DeviceScreen.Instance.RelativeHeight(20),
				IsVisible = false,
				Color = Color.Black
			};

			m_listView = new ListView
			{
				RowHeight = (int)DeviceScreen.Instance.RelativeHeight(176),
				ItemTemplate = new DataTemplate(typeof(PersonSelectionItemCell)),
				BackgroundColor = Color.FromHex("f9f8f8").MultiplyAlpha(0.8f),
				IsEnabled = Device.OS != TargetPlatform.Android,
				IsVisible = Device.OS != TargetPlatform.Android,
				Opacity = 0,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			m_searchFamiliarField.TextChanged += async (sender, e) =>
			{
				var text = e.NewTextValue?.ToLower() ?? string.Empty;

				ShowIndicator(true);
				m_listView.ItemsSource = await SearchPeople(text);
				ShowIndicator(false);

				var visible = !string.IsNullOrEmpty(m_searchFamiliarField.Text);
				m_listView.Opacity = visible ? 1 : 0;
				if (Device.OS == TargetPlatform.Android)
				{
					m_listView.IsEnabled = visible;
					m_listView.IsVisible = visible;
					m_listView.VerticalOptions = LayoutOptions.Fill;
				}
			};

			m_listView.ItemSelected += (sender, e) =>
			{
				try
				{
					var person = (Person)e.SelectedItem;
					if (person != null)
					{
						Person = person;
						m_searchFamiliarField.Unfocus();
						m_searchFamiliarField.Text = string.Empty;
						m_listView.SelectedItem = null;
					}
				}
				catch (Exception ex)
				{
					Insights.Report(ex);
				}
			};

			m_browser = new WebView
			{
				Source = BrowserURL,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			var qrCodeButton = new BackgroundButton
			{
				TranslationY = -DeviceScreen.Instance.RelativeHeight(24.0),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "qrCode.png",
				WidthRequest = DeviceScreen.Instance.RelativeWidth(174.0),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(174.0)
			};

			if (DeviceScreen.Instance.Display.Width <= 320)
			{
				qrCodeButton.WidthRequest = DeviceScreen.Instance.RelativeWidth(90.0);
				qrCodeButton.HeightRequest = DeviceScreen.Instance.RelativeHeight(90.0);
			}

			qrCodeButton.Clicked += (sender, e) =>
			{
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				myLocationPage.ParentPage = this;
				Navigation.PushAsync(myLocationPage);
			};

			var grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions =
				{
					new ColumnDefinition
					{
						Width = DeviceScreen.Instance.DisplayWidth
					}
				},
				Children =
				{
					{ m_browser, 0, 0 },
					{ qrCodeButton, 0, 0 },
					{ m_listView, 0, 0 },
					{ m_indicator, 0, 0 }
				}
			};

			Content = new StackLayout {
				Spacing = 0d,
				Children = {
					m_searchFamiliarField,
					grid
				}
			};
		}

		/// <summary>
		/// Gets or sets the location code.
		/// </summary>
		/// <value>The location code.</value>
		public string LocationCode
		{
			get
			{
				return m_locationCode;
			}
			set
			{
				m_locationCode = value;

				m_browser.Source = string.Concat(BrowserURL, "&zoomIn=_", value);



				var url = string.Concat(BrowserURL, "&zoomIn=_", value);
					        
				if (Person != null)
				{
					url = string.Concat(url,   
						"&name=", Person.Name,
						"&date=", Person.BurialDate.ToString("d"),
						"&number=", Person.Unit
					);
				}


				m_browser.Source = new Uri(url).AbsoluteUri;
			}
		}

		/// <summary>
		/// Gets or sets the person.
		/// </summary>
		/// <value>The person.</value>
		public Person Person
		{
			get
			{
				return m_person;
			}
			set
			{
				m_person = value;

				Title = value.Name;

				var url = string.Concat(BrowserURL, "&zoomIn=", value.Sector);

				if (Person != null)
				{
					url = string.Concat(url,   
						"&name=", value.Name,
						"&date=", value.BurialDate.ToString("d"),
						"&number=", value.Unit
					);
				}
					
				m_browser.Source = new Uri(url).AbsoluteUri;
			}
		}

		/// <summary>
		/// Gets the URL parameters.
		/// </summary>
		/// <value>The URL parameters.</value>
		string URLParameters
		{
			get
			{
				StringBuilder parameters = new StringBuilder();
				parameters.Append(string.Concat("?width=", DeviceScreen.Instance.DisplayWidth));
				parameters.Append(string.Concat("&height=", DeviceScreen.Instance.DisplayVisibleHeight));
				if (Person != null)
				{
					parameters.Append(string.Concat("&sectorCode=", Person.Sector));
				}
				if (!string.IsNullOrEmpty(LocationCode))
				{
					parameters.Append(string.Concat("&locationCode=_", LocationCode));
				}
				return parameters.ToString();
			}
		}

		/// <summary>
		/// Gets the browser URL.
		/// </summary>
		/// <value>The browser URL.</value>
		string BrowserURL
		{
			get
			{
				return string.Concat(m_enterprise.UrlMap, URLParameters);
			}
		}

		/// <summary>
		/// Searchs the people.
		/// </summary>
		/// <returns>The people.</returns>
		/// <param name="nameToSearch">Name to search.</param>
		async Task<List<Person>> SearchPeople(string nameToSearch)
		{
			if (nameToSearch.Length < 4)
				return null;
				
			var responseStr = await GetPersonsFromRestServer(nameToSearch);
			var persons = DeserializePersons(responseStr);

			return persons;
		}

		/// <summary>
		/// Gets the persons from rest server.
		/// </summary>
		/// <returns>The persons from rest server.</returns>
		/// <param name="nameToSearch">Name to search.</param>
		async Task<string> GetPersonsFromRestServer(string nameToSearch)
		{
			var httpClient = new HttpClient();
			var content = "{\"empreendimento\": {\"id\": " + m_enterprise.Id + "},\"pessoa\": {  \"nome\": \"" + nameToSearch + "\" }}";
			string responseStr;
			try
			{
				var getResponse = await httpClient.PostAsync("http://177.52.183.128/rest/pessoa", new StringContent(content, Encoding.UTF8, "application/json"));
				responseStr = await getResponse.Content.ReadAsStringAsync();
			}
			catch (Exception ex)
			{
				responseStr = "[]";
			}
			return responseStr;
		}

		/// <summary>
		/// Deserializes the persons.
		/// </summary>
		/// <returns>The persons.</returns>
		/// <param name="responseStr">Response string.</param>
		List<Person> DeserializePersons(string responseStr)
		{
			var responseList = JsonConvert.DeserializeObject<List<PersonJson>>(responseStr);
			var persons = new List<Person>();
			foreach (var item in responseList)
			{
				persons.Add(new Person
				{
					Name = item.nome,
					PlaceName = m_enterprise.PlaceName,
					Sector = item.localizador,
					Unit = item.unidade,
					BurialDate = item.sepultamento
				});
			}
			return persons;
		}

		void ShowIndicator(bool isVisible)
		{
			m_indicator.IsRunning = isVisible;
			m_indicator.IsVisible = isVisible;
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
            m_browser.Source = m_browser.Source;
        }
	}
}
