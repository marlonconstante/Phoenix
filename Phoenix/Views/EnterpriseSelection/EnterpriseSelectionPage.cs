using Xamarin.Forms;
using Models;
using Phoenix.Views.Map;
using Phoenix.Utils;

namespace Phoenix.Views.EnterpriseSelection
{
	public class EnterpriseSelectionPage : ContentPage
	{
		ListView m_listView;

		public EnterpriseSelectionPage()
		{
			Title = "Empreendimentos";

			NavigationPage.SetHasNavigationBar(this, true);
			NavigationPage.SetBackButtonTitle(this, string.Empty);

			m_listView = new ListView
			{
				RowHeight = (int)DeviceScreen.Instance.RelativeHeight(400),
				ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell))
			};
					
			var baseURL = "http://177.52.183.128/themes/sourceApp/";
//			var baseURL = "http://192.168.25.10:3001/dist/";


			m_listView.ItemsSource = new Enterprise []
			{ 
				new Enterprise { Id = 5, Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = string.Concat(baseURL, "CristoRei.html"), ImageName = "CrematorioMetropolitanoCristoRei.png" },
				new Enterprise { Id = 8, Name = "Cemitério E Crematório Metropolitano\nSaint Hilaire", PlaceName = "Viamão", UrlMap = string.Concat(baseURL,"SaintHilaire.html"), ImageName = "CemiterioECrematorioMetropolitanoSaintHilaire.png" },
				new Enterprise { Id = 2, Name = "Cemitério Parque\nJardim São Vicente", PlaceName = "Canoas", UrlMap = string.Concat(baseURL,"SaoVicente.html"), ImageName = "CemiterioParqueJardinSaoVicente.png" },
				new Enterprise { Id = 6, Name = "Cemitério Parque\nMemorial da Colina", PlaceName = "Cachoerinha", UrlMap = string.Concat(baseURL,"MemorialColina.html"), ImageName = "CemiterioParqueMemorialDaColina.png" },
				new Enterprise { Id = 7, Name = "Crematório Metropolitano\nSão José", PlaceName = "Porto Alegre", UrlMap = string.Concat(baseURL,"SaoJose.html"), ImageName = "CrematorioMetropolitanoSaoJose.png" }
			};

			m_listView.ItemSelected += (sender, e) =>
			{
				var enterprise = (Enterprise)e.SelectedItem;
				if (enterprise != null)
				{
					var mapPage = new MapPage(enterprise);
					Navigation.PushAsync(mapPage);
				}
			};

			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children =
				{
					m_listView
				}
			};
			Content = layout;
		}

		/// <summary>
		/// Raises the disappearing event.
		/// </summary>
		protected override void OnDisappearing()
		{
			base.OnDisappearing();

			m_listView.SelectedItem = null;
		}
	}
}