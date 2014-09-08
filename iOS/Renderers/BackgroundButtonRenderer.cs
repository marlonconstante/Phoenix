using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using MonoTouch.UIKit;
using Phoenix.Controls;

[assembly:ExportRenderer(typeof(BackgroundButton), typeof(BackgroundButtonRenderer))]
namespace Renderers
{
	public class BackgroundButtonRenderer : ButtonRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Button> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null)
			{
				Control.SetBackgroundImage(UIImage.FromFile(BackgroundButton.ImageFileName), UIControlState.Normal);
			}
		}

		/// <summary>
		/// Gets the background button.
		/// </summary>
		/// <value>The background button.</value>
		public BackgroundButton BackgroundButton {
			get {
				return Element as BackgroundButton;
			}
		}
	}
}