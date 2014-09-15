using System;

namespace Models
{
	public class Enterprise
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public int Id
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		/// <value>The name.</value>
		public string Name
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the short name.
		/// </summary>
		/// <value>The short name.</value>
		public string ShortName {
			get {
				return Name.Substring(Name.LastIndexOf("\n") + 1);
			}
		}

		/// <summary>
		/// Gets or sets the name of the place.
		/// </summary>
		/// <value>The name of the place.</value>
		public string PlaceName
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the URL map.
		/// </summary>
		/// <value>The URL map.</value>
		public string UrlMap
		{
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the image.
		/// </summary>
		/// <value>The name of the image.</value>
		public string ImageName
		{
			get;
			set;
		}
	}
}