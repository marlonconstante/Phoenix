using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Utils;
using Phoenix.Controls;

namespace Phoenix.Views.EnterpriseSelection
{
	public class EnterpriseSelectionItemCell : ExtendedViewCell
	{
		public EnterpriseSelectionItemCell()
		{
			ShowSeparator = false;
			ShowDisclousure = false;

			var backgroundImage = new Image
			{
				Aspect = Aspect.AspectFill
			};
			backgroundImage.SetBinding(Image.SourceProperty, "ImageName");

			var labelName = new ShadowLabel
			{
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Bold",
				FontSize = 22.5,
				TextColor = Color.White
			};
			labelName.SetBinding(Label.TextProperty, "Name");

			var grid = new Grid
			{
				ColumnDefinitions =
				{
					new ColumnDefinition
					{
						Width = DeviceScreen.Instance.DisplayWidth
					}
				},
				RowDefinitions =
				{
					new RowDefinition
					{
						Height = 200
					}
				},
				Children =
				{
					{ backgroundImage, 0, 0 },
					{ BoxView, 0, 0 },
					{ labelName, 0, 0 },
					{ PlaceGrid, 0, 0 }
				}
			};

			View = grid;
		}

		/// <summary>
		/// Gets the box view.
		/// </summary>
		/// <value>The box view.</value>
		BoxView BoxView
		{
			get
			{
				var boxView = new BoxView
				{
					VerticalOptions = LayoutOptions.End,
					WidthRequest = DeviceScreen.Instance.DisplayWidth,
					HeightRequest = 32,
					BackgroundColor = Color.FromRgb(0, 114, 188),
					Opacity = 0.7
				};
				return boxView;
			}
		}

		/// <summary>
		/// Gets the place grid.
		/// </summary>
		/// <value>The place grid.</value>
		Grid PlaceGrid
		{
			get
			{
				var pinImage = new Image
				{
					Source = ImageSource.FromFile("pinLeaked.png"),
					Aspect = Aspect.AspectFit,
					WidthRequest = 14,
					HeightRequest = 19
				};

				var labelPlaceName = new ExtendedLabel
				{
					VerticalOptions = LayoutOptions.Center,
					XAlign = TextAlignment.Start,
					FontName = "SourceSansPro-Regular",
					FontSize = 16,
					TextColor = Color.White
				};
				labelPlaceName.SetBinding(Label.TextProperty, "PlaceName");

				var placeGrid = new Grid
				{
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.End,
					ColumnDefinitions =
					{
						new ColumnDefinition
						{
							Width = pinImage.WidthRequest
						},
						new ColumnDefinition
						{
							Width = GridLength.Auto
						}
					},
					RowDefinitions =
					{
						new RowDefinition
						{
							Height = 32
						}
					},
					Children =
					{
						{ pinImage, 0, 0 },
						{ labelPlaceName, 1, 0 }
					}
				};

				return placeGrid;
			}
		}
	}
}