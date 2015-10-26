using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using System.Drawing;
using UIKit;

[assembly:ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace Renderers
{
	public class CustomWebViewRenderer : WebViewRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(VisualElementChangedEventArgs eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null)
			{
				var webView = NativeView as UIWebView;
				webView.ScalesPageToFit = false;
			}
		}
	}
}