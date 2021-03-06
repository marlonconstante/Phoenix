﻿using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Phoenix.Views.MyLocation;
using Renderers;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly:ExportRenderer(typeof(QrCodeCameraPage), typeof(QrCodeCameraPageRenderer))]
namespace Renderers
{
	public class QrCodeCameraPageRenderer : PageRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected async override void OnElementChanged(VisualElementChangedEventArgs eventArgs)
		{
			base.OnElementChanged(eventArgs);

			var scanner = new MobileBarcodeScanner();
			scanner.CancelButtonText = "Cancelar";

			var options = new MobileBarcodeScanningOptions()
			{
				AutoRotate = false,
				PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE }
			};

			var result = await scanner.Scan(options);
			var page = eventArgs.NewElement as QrCodeCameraPage;

			if (result != null)
			{
				page.SetQrCode(result.Text);
			}
			else
			{
				page.GoBack();
			}
		}
	}
}