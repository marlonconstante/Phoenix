﻿using System;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace Phoenix.Utils
{
	public class DeviceScreen
	{
		static DeviceScreen m_instance;

		private DeviceScreen()
		{
			Display = Resolver.Resolve<IDisplay>();
			ReservedHeight = 0d;
		}

		/// <summary>
		/// Gets the display width.
		/// </summary>
		/// <value>The display width.</value>
		public double DisplayWidth {
			get {
				return RelativeWidth(Display.Width);
			}
		}

		/// <summary>
		/// Gets the display height.
		/// </summary>
		/// <value>The display height.</value>
		public double DisplayHeight {
			get {
				return RelativeHeight(Display.Height);
			}
		}

		/// <summary>
		/// Relatives the width.
		/// </summary>
		/// <returns>The width.</returns>
		/// <param name="width">Width.</param>
		public double RelativeWidth(double width)
		{
			return Display.WidthRequestInInches(width / Display.Xdpi);
		}

		/// <summary>
		/// Relatives the height.
		/// </summary>
		/// <returns>The height.</returns>
		/// <param name="height">Height.</param>
		public double RelativeHeight(double height)
		{
			return Display.HeightRequestInInches(height / Display.Ydpi);
		}

		/// <summary>
		/// Gets the display height of the visible.
		/// </summary>
		/// <value>The display height of the visible.</value>
		public double DisplayVisibleHeight {
			get {
				return DisplayHeight - RelativeHeight(ReservedHeight);
			}
		}

		/// <summary>
		/// Gets or sets the height of the reserved.
		/// </summary>
		/// <value>The height of the reserved.</value>
		public double ReservedHeight {
			get;
			set;
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