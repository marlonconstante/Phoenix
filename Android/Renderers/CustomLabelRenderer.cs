using Phoenix.Controls;
using Renderers;
using Android.Content;
using System;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Android.Graphics;

[assembly:ExportRenderer(typeof(CustomLabel), typeof(CustomLabelRenderer))]
namespace Renderers
{
	public class CustomLabelRenderer : LabelRenderer
	{
		/// <summary>
		/// Raises the element changed event.
		/// </summary>
		/// <param name="eventArgs">Event arguments.</param>
		protected override void OnElementChanged(ElementChangedEventArgs<Label> eventArgs)
		{
			base.OnElementChanged(eventArgs);

			if (eventArgs.OldElement == null)
			{
				UpdateUI(CustomLabel, Control);
			}
		}

		/// <summary>
		/// Updates the UI.
		/// </summary>
		/// <param name="view">View.</param>
		/// <param name="control">Control.</param>
		void UpdateUI(CustomLabel view, TextView control)
		{
			if (!string.IsNullOrEmpty(view.FontName))
			{
				string filename = view.FontName;
				if (filename.LastIndexOf(".", System.StringComparison.Ordinal) != filename.Length - 4)
				{
					filename = string.Format("{0}.ttf", filename);
				}
				control.Typeface = TrySetFont(filename);
			}

			if (!string.IsNullOrEmpty(view.FontNameAndroid))
			{
				control.Typeface = TrySetFont(view.FontNameAndroid);
			}

			if (view.FontSize > 0)
			{
				control.TextSize = (float) view.FontSize;
			}

			if (view.IsUnderline)
			{
				control.PaintFlags = control.PaintFlags | PaintFlags.UnderlineText;
			}

			if (view.DropShadow)
			{
				control.SetShadowLayer(1, 0, 0, Android.Graphics.Color.Black);
			}
		}

		/// <summary>
		/// Tries the set font.
		/// </summary>
		/// <returns>The set font.</returns>
		/// <param name="fontName">Font name.</param>
		Typeface TrySetFont(string fontName)
		{
			try
			{                
				return Typeface.CreateFromAsset(Context.Assets, "fonts/" + fontName);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Not found in assets. Exception: {0}", ex);
				try
				{
					return Typeface.CreateFromFile("fonts/" + fontName);
				}
				catch (Exception ex1)
				{
					Console.WriteLine("Not found by file. Exception: {0}", ex1);

					return Typeface.Default;
				}
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