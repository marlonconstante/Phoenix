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

			Xamarin.Forms.Forms.Init(this, bundle);

			SetPage(App.GetMainPage());
		}

		/// <summary>
		/// Configs the resolver.
		/// </summary>
		private void ConfigResolver()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppDroid();
			app.Init(this);

			resolverContainer.Register<IDevice>(t => AndroidDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IDependencyContainer>(t => resolverContainer);

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

