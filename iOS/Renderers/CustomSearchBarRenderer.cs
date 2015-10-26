using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using UIKit;

[assembly:ExportRenderer(typeof(SearchBar), typeof(CustomSearchBarRenderer))]
namespace Renderers
{
	public class CustomSearchBarRenderer : SearchBarRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null)
			{
				Control.BackgroundImage = new UIImage();
			}
		}
	}
}