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

			var labelName = new CustomLabel
			{
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Bold.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(45),
				TextColor = Color.White,
				DropShadow = true
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
						Height = DeviceScreen.Instance.RelativeHeight(400)
					}
				},
				Children =
				{
					{ backgroundImage, 0, 0 },
					{ BoxImage, 0, 0 },
					{ labelName, 0, 0 },
					{ PlaceGrid, 0, 0 }
				}
			};

			View = grid;
		}

		/// <summary>
		/// Gets the box image.
		/// </summary>
		/// <value>The box image.</value>
		Image BoxImage
		{
			get
			{
				var boxImage = new Image
				{
					Aspect = Aspect.AspectFill,
					VerticalOptions = LayoutOptions.End,
					Source = ImageSource.FromFile("clearBox.png"),
					HeightRequest = DeviceScreen.Instance.RelativeHeight(64)
				};
				return boxImage;
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
					WidthRequest = DeviceScreen.Instance.RelativeWidth(28),
					HeightRequest = DeviceScreen.Instance.RelativeHeight(38)
				};

				var labelPlaceName = new ExtendedLabel
				{
					VerticalOptions = LayoutOptions.Center,
					XAlign = TextAlignment.Start,
					FontName = "SourceSansPro-Regular.otf",
					FontSize = DeviceScreen.Instance.RelativeHeight(32),
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
							Height = DeviceScreen.Instance.RelativeHeight(64)
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