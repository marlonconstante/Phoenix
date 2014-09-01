using System;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;
using Xamarin.Forms;

namespace Phoenix.Utils
{
	public class DeviceScreen
	{
		static DeviceScreen m_instance;

		private DeviceScreen()
		{
			Display = Resolver.Resolve<IDisplay>();
		}

		/// <summary>
		/// Gets the display width.
		/// </summary>
		/// <value>The display width.</value>
		public int DisplayWidth {
			get {
				return Device.OnPlatform(Display.Width / 2, Display.Width, Display.Width);
			}
		}

		/// <summary>
		/// Gets the display height.
		/// </summary>
		/// <value>The display height.</value>
		public int DisplayHeight {
			get {
				return Device.OnPlatform(Display.Height / 2, Display.Height, Display.Height);
			}
		}

		/// <summary>
		/// Gets the display height of the visible area of the device.
		/// </summary>
		/// <value>The display height of the visible.</value>
		public int DisplayVisibleHeight {
			get {
				return Device.OnPlatform((Display.Height / 2) - 64, Display.Height - 100, Display.Height - 100);
			}
		}

		/// <summary>
		/// Gets the display.
		/// </summary>
		/// <value>The display.</value>
		public IDisplay Display {
			get;
			private set;
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		/// <value>The instance.</value>
		public static DeviceScreen Instance {
			get {
				if (m_instance == null)
				{
					m_instance = new DeviceScreen();
				}
				return m_instance;
			}
		}

	}
}