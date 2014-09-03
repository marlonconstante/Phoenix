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
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei", PlaceName = "São Leopoldo" }
			};

			m_listView.ItemSelected += (sender, e) => {
				var enterprise = (Enterprise)e.SelectedItem;
				var mapPage = new MapPage();
				mapPage.Title = enterprise.Name;
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