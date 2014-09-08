using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Views.Map;
using Phoenix.Controls;

namespace Phoenix.Views.MyLocation
{
	public class MyLocationPage : ContentPage
	{
		public MyLocationPage()
		{
			NavigationPage.SetBackButtonTitle(this, string.Empty);

			BackgroundColor = Color.FromHex("15496f");

			var label = new ExtendedLabel {
				TranslationY = 7,
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Regular.otf",
				FontSize = 17,
				TextColor = Color.FromHex("fefdfd"),
				Text = "Digite o código mais próximo\nda região que você se encontra"
			};

			QrInput = new QrCodeEntry {
				TranslationY = 11,
				HeightRequest = 30
			};
			QrInput.OnCodeComplete = () => {
				ParentPage.LocationCode = QrInput.Text;
				Navigation.PopAsync();
			};

			var buttonSize = Device.OnPlatform(67, 134, 134);
			var cameraButton = new BackgroundButton {
				TranslationY = 17,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				ImageFileName = "cameraButton.png",
				HeightRequest = buttonSize,
				WidthRequest = buttonSize
			};

			cameraButton.Clicked += (sender, e) => {
				var qrCodeReader = new QrCodeCameraPage();
				qrCodeReader.Title = "Minha Localização";
				QrInput.Text = string.Empty;
				qrCodeReader.ParentPage = this;
				Navigation.PushAsync(qrCodeReader);
			};

			var photoLabel = new ExtendedLabel {
				TranslationY = 17,
				XAlign = TextAlignment.Center,
				FontName = "SourceSansPro-Light.otf",
				FontSize = 14,
				TextColor = Color.FromHex("b8c0c8"),
				Text = "Ou fotografe o código presente na placa"
			};

			var layout = new StackLayout {
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