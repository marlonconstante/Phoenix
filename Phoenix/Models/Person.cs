using System;

namespace Phoenix.Models
{
	public class Person
	{
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
		/// Gets or sets the unit.
		/// </summary>
		/// <value>The unit.</value>
		public string Unit {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the sector.
		/// </summary>
		/// <value>The sector.</value>
		public string Sector {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the name of the place.
		/// </summary>
		/// <value>The name of the place.</value>
		public string PlaceName {
			get;
			set;
		}

		/// <summary>
		/// Gets or sets the sepultamento.
		/// </summary>
		/// <value>The sepultamento.</value>
		public DateTime BurialDate
		{
			get;
			set;
		}
	}
}