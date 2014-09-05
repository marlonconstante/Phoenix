using System;
using Xamarin.Forms;

namespace Phoenix.Views.MyLocation
{
	public class QrCodeCameraPage : ContentPage
	{
		/// <summary>
		/// Sets the qr code.
		/// </summary>
		/// <param name="qrCode">Qr code.</param>
		public void SetQrCode(string qrCode)
		{
			ParentPage.QrInput.Text = qrCode.Remove(0,1);

			if (Device.OS == TargetPlatform.iOS)
			{
				Navigation.PopAsync();
			}
		}

		/// <summary>
		/// Gos the back.
		/// </summary>
		public void GoBack()
		{
			Navigation.PopAsync();
		}

		/// <summary>
		/// Gets or sets the parent page.
		/// </summary>
		/// <value>The parent page.</value>
		public MyLocationPage ParentPage { set; get; }
	}
}