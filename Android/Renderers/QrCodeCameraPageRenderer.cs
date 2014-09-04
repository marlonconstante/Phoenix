using System;
using Xamarin.Forms.Platform.Android;
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
		protected async override void OnElementChanged(ElementChangedEventArgs<Page> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			var scanner = new MobileBarcodeScanner(Context);

			var options = new MobileBarcodeScanningOptions()
			{
				AutoRotate = false,
				PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE }
			};
					
			var result = await scanner.Scan(options);

			if (result != null)
			{
				var page = eventArgs.NewElement as QrCodeCameraPage;
				page.SetQrCode(result.Text);

				Console.WriteLine("Scanned Barcode: " + result.Text);
			}
		}
	}
}