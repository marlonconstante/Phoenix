using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using MonoTouch.UIKit;

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
				Control.BackgroundColor = UIColor.FromRGB(201, 201, 206).ColorWithAlpha(0.7f);
			}
		}
	}
}