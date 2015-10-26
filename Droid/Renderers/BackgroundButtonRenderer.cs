using System;
using Xamarin.Forms;
using Renderers;
using Phoenix.Controls;
using Xamarin.Forms.Platform.Android;
using Phoenix.Droid;


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
				var resourceId = (int) typeof(Resource.Drawable).GetField(BackgroundButton.ImageName).GetValue(null);
				Control.SetBackgroundResource(resourceId);
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