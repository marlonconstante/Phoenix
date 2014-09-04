using System;
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
		protected override void OnElementChanged(VisualElementChangedEventArgs eventArgs)
		{
			base.OnElementChanged(eventArgs);

			var scanner = new ZXing.Mobile.MobileBarcodeScanner();

			var options = new MobileBarcodeScanningOptions()
			{
				AutoRotate = false,
				PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE }
			};

			var task = scanner.Scan(options);

			task.Start();
			task.Wait();
		
			if (task.Result != null)
			{
				var parent = e.NewElement as MyLocationPage;
				parent.QrInput.Text = task.Result.Text;

				Console.WriteLine("Scanned Barcode: " + task.Result.Text);
			}
		}
	}
}