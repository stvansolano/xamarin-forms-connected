using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PruebaXamarinForms
{
    public partial class App : Application
    {
        private MainPage _mainPage;
        private ControlsPage _controlsPage;

        public App()
        {
            _mainPage = new MainPage();
            _controlsPage = new ControlsPage();

            InitializeComponent();

            MainPage = _mainPage; //_controlsPage;
        }

        protected override void OnStart()
        {
            _mainPage.Load();
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
