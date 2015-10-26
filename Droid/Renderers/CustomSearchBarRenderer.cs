using System;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Renderers;
using Android.Widget;

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
				var id = Control.Context.Resources.GetIdentifier("android:id/search_src_text", null, null);
				var textView = Control.FindViewById(id) as TextView;
				textView.SetTextColor(Android.Graphics.Color.Black);
			}
		}
	}
}