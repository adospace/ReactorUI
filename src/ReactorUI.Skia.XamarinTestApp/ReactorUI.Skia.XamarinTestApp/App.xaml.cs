using ReactorUI.TestApp;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReactorUI.Skia.XamarinTestApp
{
    public partial class App : global::Xamarin.Forms.Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();

            Xamarin.ReactorApplication
                .Create(new ListComponent())
                .ModernTheme()
                .Run();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
