using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using XLabs.Ioc;
using XLabs.Forms;
using XLabs.Platform.Device;
using Phoenix.Utils;

namespace Phoenix.Droid
{
    [Activity(Label = "Phoenix.Droid", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            ConfigResolver();
            ConfigDeviceScreen();


            LoadApplication(new App());
        }

        /// <summary>
        /// Configs the resolver.
        /// </summary>
        void ConfigResolver()
        {
            var resolverContainer = new SimpleContainer();

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

