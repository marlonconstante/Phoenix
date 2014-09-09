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
				BackgroundColor = (Device.OS == TargetPlatform.Android) ? Color.FromHex("f9f8f8").MultiplyAlpha(0.8f) : Color.FromHex("c9c9ce").MultiplyAlpha(0.7f),
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = DeviceScreen.Instance.RelativeHeight(88),
				Placeholder = "Buscar um Ente"
			};

			m_listView = new ListView {
				TranslationY = searchFamiliarField.HeightRequest,
				RowHeight = (int) DeviceScreen.Instance.RelativeHeight(176),
				ItemTemplate = new DataTemplate(typeof(PersonSelectionItemCell)),
				BackgroundColor = Color.FromHex("f9f8f8").MultiplyAlpha(0.8f),
				IsEnabled = Device.OS == TargetPlatform.iOS,
				IsVisible = Device.OS == TargetPlatform.iOS,
				Opacity = 0
			};

			searchFamiliarField.TextChanged += (sender, e) => {
				var text = e.NewTextValue.ToLower();
				var visible = !string.IsNullOrEmpty(text);

				m_listView.ItemsSource = persons.Where((p) => p.Name.ToLower().Contains(text));
				m_listView.Opacity = visible ? 1 : 0;
				if (Device.OS == TargetPlatform.Android)
				{
					m_listView.IsEnabled = visible;
					m_listView.IsVisible = visible;
				}
			};

			m_listView.ItemSelected += (sender, e) => {
				m_browser.Source = BrowserURL;
				searchFamiliarField.Unfocus();
				searchFamiliarField.Text = string.Empty;
			};

			m_browser = new WebView {
				Source = BrowserURL,
				HeightRequest = DeviceScreen.Instance.DisplayVisibleHeight
			};

			var pinButton = new BackgroundButton {
				TranslationY = DeviceScreen.Instance.RelativeHeight(-23),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "pin.png",
				WidthRequest = DeviceScreen.Instance.RelativeWidth(174),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(174)
			};

			pinButton.Clicked += (sender, e) => {
				var myLocationPage = new MyLocationPage();
				myLocationPage.Title = Title;
				myLocationPage.ParentPage = this;
				Navigation.PushAsync(myLocationPage);
			};

			var grid = new Grid {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = DeviceScreen.Instance.DisplayWidth
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

	//		async Task<IEnumerable<Person>> SearchPeople(string nameToSearch)
	//		{
	//			var client = new RestClient("http://kyryon-cortel.jelasticlw.com.br/rest/");
	//			var request = new RestRequest("pessoa", HttpMethod.Post);
	//			request.AddHeader("Accept", "application/json");
	//			request.Parameters.Clear();
	//
	//
	//			var postContent = new {
	//				empreendimento = new { id = 2 },
	//				pessoa = new {nome = "ale" }
	//			};
	//
	//
	//			var sb = new StringBuilder();
	//			var sw = new StringWriter(sb);
	//			var strJSONContent = new JsonTextWriter(sw);
	//
	//			(new JsonSerializer()).Serialize(strJSONContent, postContent);
	//
	//			request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
	//
	//
	////			request.AddParameter(new Parameter() { Name = "empreendimento", Value = new {id = 2} });
	////			request.AddParameter(new Parameter() { Name = "pessoa", Value = new {nome = "ale"} });
	//	
	//			IRestResponse<IEnumerable<Person>> response = null;
	//
	//			try
	//			{
	//				response = await client.Execute<IEnumerable<Person>>(request);	
	//			}
	//			catch (Exception ex)
	//			{
	//				throw ex;
	//			}
	//		
	//
	//		
	//			return response.Data;
	//		}

	//		async Task<IEnumerable<Person>> SearchPeople(string nameToSearch)
	//		{
	//			var client = new RestClient("http://kyryon-cortel.jelasticlw.com.br/rest/");
	//			var request = new RestRequest("pessoa", HttpMethod.Post);
	//			request.AddHeader("Accept", "application/json");
	//			request.AddHeader("Content-Type", "application/json");
	//			request.Parameters.Clear();
	//
	////			request.AddParameter("empreendimento", "{id = 2}", ParameterType.RequestBody);
	////			request.AddParameter("pessoa", "{nome = \"ale\"}", ParameterType.RequestBody);
	//
	//			request.AddParameter("{ \"empreendimento\": {\"id\": 2}, \"pessoa\": {  \"nome\": \"ale\" } }", ParameterType.RequestBody);
	//
	//			IRestResponse<IEnumerable<Person>> response = null;
	//
	//			try
	//			{
	//				response = await client.Execute<IEnumerable<Person>>(request);	
	//			}
	//			catch (Exception ex)
	//			{
	//				throw ex;
	//			}
	//				
	//			return response.Data;
	//		}


	//		async Task<IEnumerable<Person>> SearchPeople(string nameToSearch)
	//		{
	//			var client = new RestClient("http://kyryon-cortel.jelasticlw.com.br/rest/");
	//			var request = new RestRequest("pessoa", HttpMethod.Post);
	//			request.AddHeader("Accept", "application/json");
	//			request.AddHeader("Content-Type", "application/json");
	//			request.Parameters.Clear();
	//
	//			request.AddParameter("empreendimento", "{id = 2}", ParameterType.RequestBody);
	//			request.AddParameter("pessoa", "{nome = \"ale\"}", ParameterType.RequestBody);
	//
	//			IRestResponse<IEnumerable<Person>> response = null;
	//
	//			try
	//			{
	//				response = await client.Execute<IEnumerable<Person>>(request);	
	//			}
	//			catch (Exception ex)
	//			{
	//				throw ex;
	//			}
	//
	//			return response.Data;
	//		}

	//		async Task<IEnumerable<Person>> SearchPeople(string nameToSearch)
	//		{
	//			var client = new RestClient("http://kyryon-cortel.jelasticlw.com.br/rest/");
	//			var request = new RestRequest("pessoa", HttpMethod.Post);
	//			request.AddHeader("Accept", "application/json");
	//			request.AddHeader("Content-Type", "application/json");
	//			request.Parameters.Clear();
	//
	//			request.AddParameter("empreendimento", new {id = 2}, ParameterType.RequestBody);
	//			request.AddParameter("pessoa", new {nome = "ale"}, ParameterType.RequestBody);
	//
	//			IRestResponse<IEnumerable<Person>> response = null;
	//
	//			try
	//			{
	//				response = await client.Execute<IEnumerable<Person>>(request);	
	//			}
	//			catch (Exception ex)
	//			{
	//				throw ex;
	//			}
	//
	//			return response.Data;
	//		}

	//		async Task SearchPeople(string nameToSearch)
	//		{
	//			HttpWebRequest httpWReq =
	//				(HttpWebRequest)WebRequest.Create("http://kyryon-cortel.jelasticlw.com.br/rest/pessoa");
	//
	//			Encoding encoding = new UTF8Encoding();
	//			string postData = "{ \"empreendimento\": {\"id\": 2}, \"pessoa\": {  \"nome\": \"ale\" } }";
	//			byte[] data = encoding.GetBytes(postData);
	//
	//
	//			httpWReq.Method = "POST";
	//			httpWReq.ContentType = "application/json";//charset=UTF-8";
	//
	//			Stream stream = await httpWReq.GetRequestStreamAsync();
	//			stream.Write(data, 0, data.Length);
	//			stream.Close();
	//
	//			var response = await httpWReq.GetResponseAsync();
	//			string s=response.ToString();
	//			StreamReader reader = new StreamReader(response.GetResponseStream());
	//			String jsonresponse = "";
	//			String temp = null;
	//			while ((temp = reader.ReadLine()) != null)
	//			{
	//				jsonresponse += temp;
	//			}
	//
	//		}

	//		async Task SearchPeople(string nameToSearch)
	//		{
	//			string url = "http://kyryon-cortel.jelasticlw.com.br/rest/pessoa";
	//			HttpWebRequest request = (HttpWebRequest)WebRequest.Create (url); 
	//			request.Method = "POST"; 
	//			request.Headers.Add("Param1", "kiran"); 
	//			request.ContentType = "application/json";
	//			string postData = "{ \"empreendimento\": {\"id\": 2}, \"pessoa\": {  \"nome\": \"ale\" } }";
	//
	//			HttpWebResponse myResp = (HttpWebResponse)request.GetResponseAsync();
	//	}

//	async Task<IRestResponse> SearchPeople(string nameToSearch)
//	{
//		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
//		{
//			Formatting = Formatting.Indented,
//			ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
//
//		};
//
//		var serializer = new JsonSerializer();
//
//		var client = new RestClient("http://kyryon-cortel.jelasticlw.com.br/rest/");
//		var request = new RestRequest("pessoa", HttpMethod.Post);
//		request.AddHeader("Accept", "application/json");
//		request.Parameters.Clear();
//
//
//		var postContent = new {
//			empreendimento = new { id = 2 },
//			pessoa = new {nome = "ale" }
//		};
//
//
//		var sb = new StringBuilder();
//		var sw = new StringWriter(sb);
//		var strJSONContent = new JsonTextWriter(sw);
//
//
//		serializer.Serialize(strJSONContent, postContent);
//
//		request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
//
//		IRestResponse response = null;
//
//		try
//		{
//			response = await client.Execute(request);	
//		}
//		catch (Exception ex)
//		{
//			throw ex;
//		}
//
//		return response;
//	}

}