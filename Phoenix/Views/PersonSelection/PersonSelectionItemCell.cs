using System;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms;
using Phoenix.Utils;
using Phoenix.Controls;

namespace Phoenix.Views.PersonSelection
{
	public class PersonSelectionItemCell : ExtendedViewCell
	{
		public PersonSelectionItemCell()
		{
			ShowDisclousure = false;
			SeparatorPadding = new Thickness(DeviceScreen.Instance.RelativeWidth(74), 0, 0, 0);

			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("loupe.png"),
				WidthRequest = DeviceScreen.Instance.RelativeWidth(25),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(25)
			};

			var labelName = new CustomLabel
			{
				HeightRequest = DeviceScreen.Instance.RelativeHeight(55),
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Semibold.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(40),
				TextColor = Color.FromHex("323233")
			};
			labelName.SetBinding(Label.TextProperty, "Name");

			var labelUnit = new CustomLabel
			{
				TranslationY = DeviceScreen.Instance.RelativeHeight(-10),
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Regular.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(34),
				TextColor = Color.FromHex("6b6b6f")
			};
			labelUnit.SetBinding(Label.TextProperty, "Unit");

			var labelPlaceName = new CustomLabel
			{
				TranslationY = DeviceScreen.Instance.RelativeHeight(-26),
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Regular.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(34),
				TextColor = Color.FromHex("6b6b6f")
			};
			labelPlaceName.SetBinding(Label.TextProperty, "PlaceName");

			var layout = new StackLayout {
				Padding = new Thickness(DeviceScreen.Instance.RelativeWidth(-12), DeviceScreen.Instance.RelativeWidth(16), 0, 0),
				Children = {
					labelName,
					labelUnit,
					labelPlaceName
				}
			};

			var grid = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = DeviceScreen.Instance.RelativeWidth(74)
					},
					new ColumnDefinition {
						Width = GridLength.Auto
					}
				},
				Children = {
					{ image, 0, 0 },
					{ layout, 1, 0 }
				}
			};

			View = grid;
		}
	}
}