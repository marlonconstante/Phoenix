using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using XLabs.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;
using Phoenix.Utils;

namespace Phoenix.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : XFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            // Code for starting up the Xamarin Test Cloud Agent
            #if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
            #endif

            ConfigResolver();
            ConfigDeviceScreen();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        /// <summary>
        /// Configs the resolver.
        /// </summary>
        void ConfigResolver()
        {
            var resolverContainer = new SimpleContainer();

            var app = new XFormsAppiOS();
            app.Init(this);

            resolverContainer.Register<IDevice>(t => AppleDevice.CurrentDevice)
                .Register<IDisplay>(t => t.Resolve<IDevice>().Display)
                .Register<IDependencyContainer>(t => resolverContainer);

            Resolver.SetResolver(resolverContainer.GetResolver());
        }

        /// <summary>
        /// Configs the device screen.
        /// </summary>
        void ConfigDeviceScreen()
        {
            DeviceScreen.Instance.ReservedHeight = 128d;
        }

    }
}

