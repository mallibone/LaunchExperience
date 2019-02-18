using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CustomSplash
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var splashPage = new SplashPage();
            var mainPage = new NavigationPage(splashPage) { BarBackgroundColor = Color.FromHex("#2196F3")};

            //NavigationPage.SetHasNavigationBar(this, false);
            MainPage = mainPage;
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
