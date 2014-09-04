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
			ParentPage.QrInput.Text = qrCode;
			Navigation.PopModalAsync();
		}

		/// <summary>
		/// Gets or sets the parent page.
		/// </summary>
		/// <value>The parent page.</value>
		public MyLocationPage ParentPage { set; get; }
	}
}