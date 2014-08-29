using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;

namespace Phoenix.Views.EnterpriseSelection
{
	public class EnterpriseSelectionItemCell : ViewCell
	{
		public EnterpriseSelectionItemCell()
		{
			var display = Resolver.Resolve<IDisplay>();

			var label = new Label {
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				TextColor = Color.White
			};
			label.SetBinding(Label.TextProperty, "Name");

			var backgroundImage = new Image() {
				Source = ImageSource.FromFile("cemita.png"),
				Aspect = Aspect.AspectFill
			};

			var grid = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition() {
						Width = display.Width / 2
					}
				},
				RowDefinitions = {
					new RowDefinition() {
						Height = 200
					}
				},
				Children = {
					{ backgroundImage, 0, 0 },
					{ label, 0, 0 }
				}
			};

			View = grid;
		}
	}
}

