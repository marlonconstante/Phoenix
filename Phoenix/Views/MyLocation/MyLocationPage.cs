using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Views.Map;
using Phoenix.Controls;
using Phoenix.Utils;

namespace Phoenix.Views.MyLocation
{
	public class MyLocationPage : ContentPage
	{
		public MyLocationPage()
		{
			NavigationPage.SetBackButtonTitle(this, string.Empty);

			BackgroundColor = Color.FromHex("15496f");

			var label = new ExtendedLabel {
				TranslationY = DeviceScreen.Instance.RelativeHeight(14),
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Regular.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(34),
				TextColor = Color.FromHex("fefdfd"),
				Text = "Digite o código mais próximo\nda região que você se encontra"
			};

			QrInput = new QrCodeEntry {
				TranslationY = DeviceScreen.Instance.RelativeHeight(22),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(60)
			};
			QrInput.OnCodeComplete = () => {
				ParentPage.LocationCode = QrInput.Text;
				Navigation.PopAsync();
			};

			var cameraButton = new BackgroundButton {
				TranslationY = DeviceScreen.Instance.RelativeHeight(34),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "cameraButton.png",
				WidthRequest = DeviceScreen.Instance.RelativeWidth(134),
				HeightRequest = DeviceScreen.Instance.RelativeHeight(134)
			};

			cameraButton.Clicked += (sender, e) => {
				var qrCodeReader = new QrCodeCameraPage();
				qrCodeReader.Title = "Minha Localização";
				QrInput.Text = string.Empty;
				qrCodeReader.ParentPage = this;
				Navigation.PushAsync(qrCodeReader);
			};

			var photoLabel = new ExtendedLabel {
				TranslationY = DeviceScreen.Instance.RelativeHeight(34),
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Light.otf",
				FontSize = DeviceScreen.Instance.RelativeHeight(28),
				TextColor = Color.FromHex("b8c0c8"),
				Text = "Ou fotografe o código presente na placa"
			};

			var layout = new StackLayout
			{
				VerticalOptions = LayoutOptions.Start,
				HorizontalOptions = LayoutOptions.Center,
				Children = {
					label,
					QrInput,
					cameraButton,
					photoLabel
				}
			};
			Content = layout;
		}

		/// <summary>
		/// Raises the appearing event.
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			QrInput.Focus();
		}

		/// <summary>
		/// Gets or sets the qr input.
		/// </summary>
		/// <value>The qr input.</value>
		public QrCodeEntry QrInput { set; get; }

		/// <summary>
		/// Gets or sets the parent page.
		/// </summary>
		/// <value>The parent page.</value>
		public MapPage ParentPage { set; get; }
	}
}