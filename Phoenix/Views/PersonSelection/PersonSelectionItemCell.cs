using System;
using Xamarin.Forms.Labs.Controls;
using Xamarin.Forms;

namespace Phoenix.Views.PersonSelection
{
	public class PersonSelectionItemCell : ExtendedViewCell
	{
		public PersonSelectionItemCell()
		{
			ShowDisclousure = false;
			SeparatorPadding = new Thickness(37f, 0f, 0f, 0f);

			var imageSize = Device.OnPlatform(13.75, 25, 25);
			var image = new Image
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Source = ImageSource.FromFile("loupe.png"),
				WidthRequest = imageSize,
				HeightRequest = imageSize
			};

			var labelName = new ExtendedLabel
			{
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Semibold",
				FontSize = 20,
				TextColor = Color.FromHex("323233")
			};
			labelName.SetBinding(Label.TextProperty, "Name");

			var labelUnit = new ExtendedLabel
			{
				TranslationY = -2,
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Regular",
				FontSize = 17,
				TextColor = Color.FromHex("6b6b6f")
			};
			labelUnit.SetBinding(Label.TextProperty, "Unit");

			var labelPlaceName = new ExtendedLabel
			{
				TranslationY = -10,
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Start,
				FontName = "SourceSansPro-Regular",
				FontSize = 17,
				TextColor = Color.FromHex("6b6b6f")
			};
			labelPlaceName.SetBinding(Label.TextProperty, "PlaceName");

			var layout = new StackLayout {
				Padding = new Thickness(-6f, 8f, 0f, 0f),
				Children = {
					labelName,
					labelUnit,
					labelPlaceName
				}
			};

			var grid = new Grid {
				ColumnDefinitions = {
					new ColumnDefinition {
						Width = 37
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