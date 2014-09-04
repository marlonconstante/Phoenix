using System;
using System.Text.RegularExpressions;

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
		/// Gets the unit code.
		/// </summary>
		/// <value>The unit code.</value>
		public string UnitCode {
			get {
				return new Regex(@"[^\d]").Replace(Unit, "");
			}
		}

		/// <summary>
		/// Gets or sets the name of the place.
		/// </summary>
		/// <value>The name of the place.</value>
		public string PlaceName {
			get;
			set;
		}
	}
}