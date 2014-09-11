using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Labs.Droid;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;
using Phoenix.Utils;

namespace Phoenix.Android
{

	[Activity(Label = "Phoenix.Android.Android", MainLauncher = true, ScreenOrientation = ScreenOrientation.Portrait, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : XFormsApplicationDroid
	{
		/// <summary>
		/// Raises the create event.
		/// </summary>
		/// <param name="bundle">Bundle.</param>
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			ConfigResolver();
			ConfigDeviceScreen();

			Xamarin.Forms.Forms.Init(this, bundle);

			SetPage(App.GetMainPage());
		}

		/// <summary>
		/// Configs the resolver.
		/// </summary>
		void ConfigResolver()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();
			app.Init(this);

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IDependencyContainer>(t => resolverContainer);

			Resolver.SetResolver(resolverContainer.GetResolver());
		}

		/// <summary>
		/// Configs the device screen.
		/// </summary>
		void ConfigDeviceScreen()
		{
			DeviceScreen.Instance.ReservedHeight = GetDimensionPixelSize("status_bar_height") + GetDimensionPixelSize("action_bar_default_height");
		}

		/// <summary>
		/// Gets the size of the dimension pixel.
		/// </summary>
		/// <returns>The dimension pixel size.</returns>
		/// <param name="id">Identifier.</param>
		int GetDimensionPixelSize(string id) { 
			var resourceId = Resources.GetIdentifier(id, "dimen", "android");
			if (resourceId > 0) {
				return Resources.GetDimensionPixelSize(resourceId);
			} 
			return 0;
		}
	}
}