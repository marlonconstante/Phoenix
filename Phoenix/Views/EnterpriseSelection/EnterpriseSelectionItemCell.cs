using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Controls;

namespace Views.EnterpriseSelection
{
	public class EnterpriseSelectionItemCell : ExtendedViewCell
	{
		public EnterpriseSelectionItemCell()
		{
			var display = Resolver.Resolve<IDisplay>();
			var width = display.Width;

			ShowSeparator = false;
			ShowDisclousure = false;

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
						Width = Device.OnPlatform(width / 2, width, width)
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

