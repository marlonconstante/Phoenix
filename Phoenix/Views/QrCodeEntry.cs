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

		public Action OnCodeComplete { set; get; }

		void OnTextChanged(object sender, EventArgs e)
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

	}
}

