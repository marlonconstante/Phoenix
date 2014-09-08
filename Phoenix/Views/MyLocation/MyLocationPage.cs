using System;
using Xamarin.Forms;
using Xamarin.Forms.Labs.Controls;
using Phoenix.Views.Map;

namespace Phoenix.Views.MyLocation
{
	public class MyLocationPage : ContentPage
	{
		public MyLocationPage()
		{
			NavigationPage.SetBackButtonTitle(this, string.Empty);

			BackgroundColor = Color.FromHex("15496f");

			var label = new ExtendedLabel {
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				FontName = "Source Sans Pro",
				FontSize = 17,
				TextColor = Color.FromHex("e8edf1"),
				Text = "\n\nDigite o código mais próximo\nda região que você se encontra\n\n"

			};

			QrInput = new QrCodeEntry();
			QrInput.OnCodeComplete = () => {
				ParentPage.LocationCode = QrInput.Text;
				Navigation.PopAsync();
			};

			var imgButtonSize = Device.OnPlatform(60, 130, 130);
			var buttonSize = Device.OnPlatform(50, 80, 60);
			var cameraButton = new ImageButton {
				Source = ImageSource.FromFile("cameraButton.png"),
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				ImageHeightRequest = imgButtonSize,
				ImageWidthRequest = imgButtonSize,
				BackgroundColor = Color.Transparent,
				HeightRequest = buttonSize,
				WidthRequest = buttonSize,
			};

			cameraButton.Clicked += (sender, e) => {
				var qrCodeReader = new QrCodeCameraPage();
				qrCodeReader.Title = "Minha Localização";
				QrInput.Text = string.Empty;
				qrCodeReader.ParentPage = this;
				Navigation.PushAsync(qrCodeReader);
			};

			var photoLabel = new ExtendedLabel {
				YAlign = TextAlignment.Center,
				XAlign = TextAlignment.Center,
				FontName = "Source Sans Pro",
				FontSize = 14,
				TextColor = Color.FromHex("fcfbf9"),
				Text = "\nOu fotografe o código presente na placa"
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