﻿using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CustomSplash
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashPage : ContentPage
    {
        private readonly Action _onAnimationCompleted;

        public SplashPage(Action onAnimationCompleted)
        {
            InitializeComponent();
            _onAnimationCompleted = onAnimationCompleted;
        }

        protected override void OnAppearing()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            base.OnAppearing();
            ScaleIcon();
        }

        private async void ScaleIcon()
        {
            // wait until the UI is present
            await Task.Delay(300);

            // animate the splash logo
            await SplashIcon.ScaleTo(0.5, 500, Easing.CubicInOut);
            var animationTasks = new[]{
                SplashIcon.ScaleTo(100.0, 1000, Easing.CubicInOut),
                SplashIcon.FadeTo(0, 700, Easing.CubicInOut)
            };
            await Task.WhenAll(animationTasks);

            _onAnimationCompleted();
            //// navigate to main page
            //Navigation.InsertPageBefore(new MainPage(), Navigation.NavigationStack[0]);
            //await Navigation.PopToRootAsync(false);
        }
    }
}