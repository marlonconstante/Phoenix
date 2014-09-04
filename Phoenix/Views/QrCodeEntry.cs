using System;
using Xamarin.Forms;

namespace Phoenix.Views
{
	public class QrCodeEntry : Entry
	{
		const int s_maxCodeSize = 4;

		public QrCodeEntry()
		{
			Keyboard = Keyboard.Numeric;
			TextChanged += OnTextChanged;
			BackgroundColor = Color.FromHex("e8edf1");
			TextColor = Color.FromHex("565656"); 
		}

		/// <summary>
		/// Raises the text changed event.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Event Arguments.</param>
		void OnTextChanged(object sender, EventArgs args)
		{
			Entry entry = sender as Entry;
			String val = entry.Text; 

			if (val.Length == s_maxCodeSize)
			{
				OnCodeComplete();
			}
			else if (val.Length > s_maxCodeSize)
			{
				val = val.Remove(val.Length - 1);
				entry.Text = val;
			}
		}

		/// <summary>
		/// Gets or sets the on code complete.
		/// </summary>
		/// <value>The on code complete.</value>
		public Action OnCodeComplete { set; get; }
	}
}