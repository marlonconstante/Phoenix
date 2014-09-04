using Xamarin.Forms;
using Models;
using Phoenix.Views.Map;

namespace Phoenix.Views.EnterpriseSelection
{
	public class EnterpriseSelectionPage : ContentPage
	{
		ListView m_listView;

		public EnterpriseSelectionPage()
		{
			Title = "Empreendimentos";

			NavigationPage.SetHasNavigationBar(this, true);

			m_listView = new ListView
			{
				RowHeight = 200,
				ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell))
			};

			m_listView.ItemsSource = new Enterprise []
			{ 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo", UrlMap = "https://rawgit.com/marlonconstante/Phoenix-Maps/master/demo/CristoRei.html" }
			};

			m_listView.ItemSelected += (sender, e) => {
				var enterprise = (Enterprise) e.SelectedItem;
				var mapPage = new MapPage(enterprise);
				Navigation.PushAsync(mapPage);
			};

			var layout = new StackLayout {
				VerticalOptions = LayoutOptions.FillAndExpand,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children =
				{
					m_listView
				}
			};
			Content = layout;
		}
	}
}