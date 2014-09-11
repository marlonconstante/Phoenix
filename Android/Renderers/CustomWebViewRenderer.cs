using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Renderers;

[assembly:ExportRenderer(typeof(WebView), typeof(CustomWebViewRenderer))]
namespace Renderers
{
	public class CustomWebViewRenderer : WebRenderer
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
			}
		}
	}
}