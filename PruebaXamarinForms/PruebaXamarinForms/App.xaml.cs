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
        private ContactsPage _contactsPage;

        public App()
        {
            _mainPage = new MainPage();
            _controlsPage = new ControlsPage();
            _contactsPage = new ContactsPage();

            InitializeComponent();

            MainPage = _contactsPage; //_controlsPage;
            // _mainPage;
        }

        protected override void OnStart()
        {
            _contactsPage.Load();
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
