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

			var searchFamiliarField = new SearchBar
			{
				VerticalOptions = LayoutOptions.Start,
				BackgroundColor = (Device.OS == TargetPlatform.Android) ? Color.FromHex("f9f8f8").MultiplyAlpha(0.8f) : Color.FromHex("c9c9ce").MultiplyAlpha(0.7f),
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = DeviceScreen.Instance.RelativeHeight(88),
				Placeholder = "Buscar um Ente"
			};

			m_listView = new ListView
			{
				TranslationY = searchFamiliarField.HeightRequest,
				RowHeight = (int)DeviceScreen.Instance.RelativeHeight(176),
				ItemTemplate = new DataTemplate(typeof(PersonSelectionItemCell)),
				BackgroundColor = Color.FromHex("f9f8f8").MultiplyAlpha(0.8f),
				IsEnabled = Device.OS != TargetPlatform.Android,
				IsVisible = Device.OS != TargetPlatform.Android,
				Opacity = 0
			};

			searchFamiliarField.TextChanged += async (sender, e) =>
			{
				var text = e.NewTextValue.ToLower();
				var visible = !string.IsNullOrEmpty(text);

				m_listView.ItemsSource = persons.Where((p) => p.Name.ToLower().Contains(text));
//				m_listView.ItemsSource = await SearchPeople(text);
				m_listView.Opacity = visible ? 1 : 0;
				if (Device.OS == TargetPlatform.Android)
				{
					m_listView.IsEnabled = visible;
					m_listView.IsVisible = visible;
				}
			};


			m_listView.ItemSelected += (sender, e) =>
			{
				Person = m_listView.SelectedItem as Person;
				searchFamiliarField.Unfocus();
				searchFamiliarField.Text = string.Empty;
			};

			m_browser = new WebView
			{
				Source = BrowserURL,
				HeightRequest = DeviceScreen.Instance.DisplayVisibleHeight
			};

			var pinButton = new BackgroundButton
			{
				TranslationY = DeviceScreen.Instance.RelativeHeight(-23),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "pin.png",
				WidthRequest = DeviceScreen.Instance.RelativeWidth(174),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(174)
			};

			pinButton.Clicked += (sender, e) =>
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
			return new Person[]
			{
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
				return m_listView.SelectedItem as Person;
			}
			set
			{
				m_listView.SelectedItem = value;

				m_browser.Source = string.Concat(BrowserURL, "&zoomIn=", value.Sector);
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
		string BrowserURL
		{
			get
			{
				return string.Concat(m_enterprise.UrlMap, URLParameters);
			}
		}

		async Task<List<Person>> SearchPeople(string nameToSearch)
		{
			if (nameToSearch == string.Empty)
				return null;

			var httpClient = new HttpClient();
			var content = "{\"empreendimento\": {\"id\": " + m_enterprise.Id + "},\"pessoa\": {  \"nome\": \"" + nameToSearch + "\" }}";
			string responseStr;

			try
			{
				var getResponse = await httpClient.PostAsync("http://kyryon-cortel.jelasticlw.com.br/rest/pessoa", new StringContent(
					                  content,
					                  Encoding.UTF8,
					                  "application/json"));

				responseStr = await getResponse.Content.ReadAsStringAsync();
			}
			catch (Exception ex)
			{
				throw ex;
			}

			var responseList = JsonConvert.DeserializeObject<List<PersonJson>>(responseStr);

			var persons = new List<Person>();

			foreach (var item in responseList)
			{
				persons.Add(new Person
				{
					Name = item.nome,
					PlaceName = m_enterprise.PlaceName,
					Sector = item.localizador,
					Unit = item.unidade
				});
			}

			return persons;
		}
	}
}