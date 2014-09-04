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
		protected override void OnElementChanged(VisualElementChangedEventArgs e)
		{
			base.OnElementChanged(e);

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