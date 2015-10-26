using System;

using Xamarin.Forms;
using Phoenix.Views.EnterpriseSelection;

namespace Phoenix
{
    public class App : Application
    {
        public static INavigation Navigation { get; private set; }

        public App()
        {
            var mainNav = new NavigationPage(new EnterpriseSelectionPage())
                {
                    BarBackgroundColor = Color.FromRgb(248, 248, 248),
                    BarTextColor = Color.FromRgb(86, 86, 86)
                };
                        

            MainPage = mainNav;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

