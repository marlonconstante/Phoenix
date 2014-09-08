using System;
using Xamarin.Forms;

namespace Phoenix.Controls
{
	public class BackgroundButton : Button
	{
		/// <summary>
		/// Gets or sets the name of the image file.
		/// </summary>
		/// <value>The name of the image file.</value>
		public string ImageFileName {
			get;
			set;
		}

		/// <summary>
		/// Gets the name of the image.
		/// </summary>
		/// <value>The name of the image.</value>
		public string ImageName {
			get {
				return ImageFileName.Substring(0, ImageFileName.IndexOf("."));
			}
		}
	}
}