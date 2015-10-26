using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Renderers;
using XLabs.Forms.Controls;

[assembly:ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace Renderers
{
    public class CustomWebViewRenderer : WebViewRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<WebView> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null)
			{
				Control.Settings.BuiltInZoomControls = true;
				Control.Settings.DisplayZoomControls = false;
				Control.SetWebChromeClient(new Android.Webkit.WebChromeClient());
			}
		}
	}
}