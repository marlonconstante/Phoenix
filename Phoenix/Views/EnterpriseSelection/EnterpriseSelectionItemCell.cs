using System;
using Xamarin.Forms;

namespace Views.EnterpriseSelection
{
	public class EnterpriseSelectionItemCell : ViewCell
	{
		public EnterpriseSelectionItemCell()
		{
			var label = new Label {
				YAlign = TextAlignment.Center
			};
			label.SetBinding (Label.TextProperty, "Name");

//			var tick = new Image {
//				Source = FileImageSource.FromFile ("check.png"),
//			};
//			tick.SetBinding (Image.IsVisibleProperty, "Done");

			var layout = new StackLayout {
				Padding = new Thickness(20, 0, 0, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {label}
			};
			View = layout;
		}
	}
}

