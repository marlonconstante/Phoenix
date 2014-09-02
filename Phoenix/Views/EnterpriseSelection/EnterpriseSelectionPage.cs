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
			Title = "Selecione o Empreendimento";

			NavigationPage.SetHasNavigationBar(this, true);

			m_listView = new ListView
			{
				RowHeight = 200,
				ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell))
			};

			// These commented-out lines were used to test the ListView prior to integrating the database
			m_listView.ItemsSource = new Enterprise []
			{ 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" }, 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" }, 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" }, 
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" },
				new Enterprise { Name = "Crematório Metropolitano\nCristo Rei" }
			};

			var layout = new StackLayout();

			layout.Children.Add(m_listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			layout.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			m_listView.ItemSelected += (sender, e) => {
				var enterprise = (Enterprise)e.SelectedItem;
				var mapPage = new MapPage();
				mapPage.Title = enterprise.Name;
				Navigation.PushAsync(mapPage);
			};
		}
	}
}

