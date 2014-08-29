﻿using System;
using Xamarin.Forms;
using Models;
using Views.Map;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;

namespace Views.EnterpriseSelection
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
				RowHeight = 200
			};
			m_listView.ItemTemplate = new DataTemplate(typeof(EnterpriseSelectionItemCell));

			// These commented-out lines were used to test the ListView prior to integrating the database
			m_listView.ItemsSource = new Enterprise []
			{ 
				new Enterprise { Name = "Cemita 1" }, 
				new Enterprise { Name = "Cemita 2" },
				new Enterprise { Name = "Cemita 3" }, 
				new Enterprise { Name = "Cemita 4" },
				new Enterprise { Name = "Cemita 5" }
			};


			var layout = new StackLayout();
			if (Device.OS == TargetPlatform.WinPhone)
			{ // WinPhone doesn't have the title showing
				layout.Children.Add(new Label{ Text = "Todo", Font = Font.BoldSystemFontOfSize(NamedSize.Large) });
			}
			layout.Children.Add(m_listView);
			layout.VerticalOptions = LayoutOptions.FillAndExpand;
			Content = layout;

			m_listView.ItemSelected += (sender, e) => {
				var enterprise = (Enterprise)e.SelectedItem;
				var mapPage = new MapPage();
//				mapPage.BindingContext = enterprise;
				Navigation.PushAsync(mapPage);
			};
		}
	}
}
