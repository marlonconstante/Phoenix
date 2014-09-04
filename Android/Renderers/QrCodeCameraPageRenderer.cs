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
		protected async override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			var scanner = new ZXing.Mobile.MobileBarcodeScanner(Context);

			var options = new MobileBarcodeScanningOptions()
			{
				AutoRotate = false,
				PossibleFormats = new System.Collections.Generic.List<ZXing.BarcodeFormat>() { ZXing.BarcodeFormat.QR_CODE }
			};
					
			var result = await scanner.Scan(options);

			if (result != null)
			{
				var page = e.NewElement as QrCodeCameraPage;
//				parent.QrInput.Text = result.Text;
//				Console.WriteLine("Text: " + parent.QrInput.Text);

				page.SetQrCode(result.Text);

				Console.WriteLine("Scanned Barcode: " + result.Text);
			}
		}
	}
}

