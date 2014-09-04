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
				Padding = new Thickness(37f, 8f, 0f, 0f),
				Children = {
					labelName,
					labelUnit,
					labelPlaceName
				}
			};

			View = layout;
		}
	}
}