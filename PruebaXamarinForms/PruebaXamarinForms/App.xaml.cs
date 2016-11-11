﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace PruebaXamarinForms
{
    public partial class App : Application
    {
        private MainPage _mainPage;

        public App()
        {
            _mainPage = new PruebaXamarinForms.MainPage();

            InitializeComponent();

            MainPage = _mainPage;
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
