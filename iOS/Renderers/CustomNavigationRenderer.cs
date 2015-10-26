using System;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Renderers;
using UIKit;


[assembly:ExportRenderer(typeof(NavigationPage), typeof(CustomNavigationRenderer))]
namespace Renderers
{
	public class CustomNavigationRenderer : NavigationRenderer
	{
		/// <summary>
		/// Views the did load.
		/// </summary>
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			NavigationBar.TintColor = UIColor.FromRGB(0, 121, 255);
			NavigationBar.BarTintColor = NavigationPage.BarBackgroundColor.ToUIColor();

            var textAttributes = new UIStringAttributes {
				Font = UIFont.FromName("SourceSansPro-Semibold", 17),
			};
            //TODO: Ta certo isso?
            NavigationBar.TintColor = NavigationPage.BarTextColor.ToUIColor();
		}

		/// <summary>
		/// Gets the navigation page.
		/// </summary>
		/// <value>The navigation page.</value>
		public NavigationPage NavigationPage {
			get {
				return Element as NavigationPage;
			}
		}
	}
}