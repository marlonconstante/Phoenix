using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using Xamarin.Forms.Labs.iOS;
using Xamarin.Forms.Labs.Services;
using Xamarin.Forms.Labs;

namespace Phoenix.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : XFormsApplicationDelegate
	{
		UIWindow window;

		/// <summary>
		/// Finisheds the launching.
		/// </summary>
		/// <returns><c>true</c>, if launching was finisheded, <c>false</c> otherwise.</returns>
		/// <param name="app">App.</param>
		/// <param name="options">Options.</param>
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.Init();

			ConfigResolver();

			window = new UIWindow(UIScreen.MainScreen.Bounds);
			
			window.RootViewController = App.GetMainPage().CreateViewController();
			window.MakeKeyAndVisible();
			
			return true;
		}

		/// <Docs>Reference to the UIApplication that invoked this delegate method.</Docs>
		/// <summary>
		/// Gets the supported interface orientations.
		/// </summary>
		/// <returns>The supported interface orientations.</returns>
		/// <param name="application">Application.</param>
		/// <param name="window">Window.</param>
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, UIWindow window)
		{
			return UIInterfaceOrientationMask.Portrait;
		}

		/// <summary>
		/// Configs the resolver.
		/// </summary>
		private void ConfigResolver()
		{
			var resolverContainer = new SimpleContainer();

			var app = new XFormsAppiOS();
			app.Init(this);

			resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
				.Register<IDisplay>(t => t.Resolve<IDevice>().Display)
				.Register<IDependencyContainer>(t => resolverContainer);

			Resolver.SetResolver(resolverContainer.GetResolver());
		}
	}
}

