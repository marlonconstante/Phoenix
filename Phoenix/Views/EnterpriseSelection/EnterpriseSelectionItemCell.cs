using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Utils;

namespace Phoenix.Views.EnterpriseSelection
{
	public class EnterpriseSelectionItemCell : ExtendedViewCell
	{
		public EnterpriseSelectionItemCell()
		{
			var display = Resolver.Resolve<IDisplay>();

			ShowSeparator = false;
			ShowDisclousure = false;

			var label = new Label
			{
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				Font = Font.OfSize("Source Sans Pro", NamedSize.Large).WithAttributes(FontAttributes.Bold),
				TextColor = Color.White
			};
			label.SetBinding(Label.TextProperty, "Name");

			var backgroundImage = new Image()
			{
				Source = ImageSource.FromFile("cemita.png"),
				Aspect = Aspect.AspectFill
			};

			var boxView = new BoxView
			{
				VerticalOptions = LayoutOptions.End,
				WidthRequest = DeviceScreen.Instance.DisplayWidth,
				HeightRequest = 80,
				BackgroundColor = Color.White,
				Opacity = 0.5
			};

			var grid = new Grid
			{
				ColumnDefinitions =
				{
					new ColumnDefinition()
					{
						Width = DeviceScreen.Instance.DisplayWidth
					}
				},
				RowDefinitions =
				{
					new RowDefinition()
					{
						Height = 200
					}
				},
				Children =
				{
					{ backgroundImage, 0, 0 },
					{ boxView, 0, 0 },
					{ label, 0, 0 }
				}
			};

			View = grid;
		}
	}
}

