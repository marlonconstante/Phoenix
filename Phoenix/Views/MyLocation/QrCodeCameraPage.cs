using System;
using Xamarin.Forms;

namespace Phoenix.Views.MyLocation
{
	public class QrCodeCameraPage : ContentPage
	{
		public MyLocationPage ParentPage { set; get;}

		public void SetQrCode(string qrCode)
		{
			ParentPage.QrInput.Text = qrCode;
			Navigation.PopModalAsync();
		}
	}
}

