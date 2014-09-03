using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Phoenix.Views.MyLocation;
using Renderers;
using System.Threading.Tasks;

[assembly:ExportRenderer(typeof(QrCodeCameraPage), typeof(QrCodeCameraPageRenderer))]
namespace Renderers
{
	public class QrCodeCameraPageRenderer : PageRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			var scanner = new ZXing.Mobile.MobileBarcodeScanner(Context);
			var task = scanner.Scan();
			
			task.Start();
			task.Wait();
			
			if (task.Result != null)
				Console.WriteLine("Scanned Barcode: " + task.Result.Text);
		}
	}
}

