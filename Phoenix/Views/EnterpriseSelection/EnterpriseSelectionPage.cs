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
				RowHeight = (int) DeviceScreen.Instance.RelativeHeight(400),
				ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell))
			};

			m_listView.ItemsSource = new Enterprise []
			{ 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html", ImageName = "CrematorioMetropolitanoCristoRei.png" },
				new Enterprise { Name = "Cemitério E Crematório Metropolitano\nSaint Hilaire", PlaceName = "Viamão", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/SaintHilaire.html", ImageName = "CemiterioECrematorioMetropolitanoSaintHilaire.png" },
				new Enterprise { Name = "Cemitério Parque\nJardin São Vicente", PlaceName = "Canoas", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/SaoVicente.html", ImageName = "CemiterioParqueJardinSaoVicente.png" },
				new Enterprise { Name = "Cemitério Parque\nMemorial da Colina", PlaceName = "Cachoerinha", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/MemorialColina.html", ImageName = "CemiterioParqueMemorialDaColina.png" },
				new Enterprise { Name = "Crematório Metropolitano\nSão José", PlaceName = "Porto Alegre", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/SaoJose.html", ImageName = "CrematorioMetropolitanoSaoJose.png" }
			};

			m_listView.ItemSelected += (sender, e) =>
			{
				var enterprise = (Enterprise) e.SelectedItem;
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