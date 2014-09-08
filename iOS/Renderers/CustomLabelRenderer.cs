using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using MonoTouch.UIKit;
using Xamarin.Forms.Labs.iOS.Controls;
using Phoenix.Controls;
using System.Drawing;

[assembly:ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Renderers
{
	public class CustomLabelRenderer : ExtendedLabelRenderer
	{
		/// <summary>
		/// The on element changed callback.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Label> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null && CustomLabel.DropShadow)
			{
				Control.Layer.ShadowColor = UIColor.Black.CGColor;
				Control.Layer.ShadowOffset = new SizeF(0, 0);
				Control.Layer.ShadowOpacity = 1;
				Control.Layer.ShadowRadius = 1;
			}
		}

		/// <summary>
		/// Gets the custom label.
		/// </summary>
		/// <value>The custom label.</value>
		public CustomLabel CustomLabel {
			get {
				return Element as CustomLabel;
			}
		}
	}
}